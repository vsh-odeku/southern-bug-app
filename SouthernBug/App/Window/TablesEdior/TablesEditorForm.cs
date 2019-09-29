using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using SouthernBug.App.Entity.Connection;
using SouthernBug.App.Entity.Server;
using SouthernBug.App.Model.GUI_Items;
using SouthernBug.App.Model.GUI_Items.Controller;
using SouthernBug.App.Model.GUI_Items.Repr;
using SouthernBug.App.Repository;
using SouthernBug.App.Repository.TableContract.Contracts;
using SouthernBug.App.Util;

namespace SouthernBug.App.Window.TablesEdior
{
    public partial class TablesEditorForm : Form
    {
        public const string ArgDataTableServer = "dataTableServer";

        private readonly IDataTableServer dataTableServer;

        private List<string> currentGroupTables = new List<string>();

        private volatile IDataTableConnection dataTableConnection;
        private bool isTableChanged;

        private YearItemsRepr yearItemsRepr;

        public TablesEditorForm(IDataTableServer dataTableServer)
        {
            InitializeComponent();

            this.dataTableServer = dataTableServer;

            InitControls();
            InitUi();
        }

        [Inject] public Context Context { get; set; }

        private void InitControls()
        {
            yearItemsRepr = new YearItemsRepr(comboBoxTableYear);

            new ComboBoxController(comboBoxTableYear, OnControlEdit);
            new ComboBoxController(comboBoxTableName, OnControlEdit);
        }

        private void InitUi()
        {
            var groups = dataTableServer.GetTableGroups();

            var radioGroup = new RadioGroup(tableTypeFlowLayoutPanel)
            {
                ChangeController = OnControlEdit
            };

            foreach (var group in groups)
            {
                var radio = new RadioButton {Text = group, AutoSize = true};
                radioGroup.AddRadioButton(radio);
            }

            radioGroup[0].Checked = true;

            UiLoadGroup(radioGroup[0].Text);
        }

        private void UiLoadGroup(string tablesGroup)
        {
            currentGroupTables = dataTableServer.GetGroupTableNames(tablesGroup);

            comboBoxTableName.Items.Clear();
            comboBoxTableName.Items.AddRange(currentGroupTables.ToArray());
            comboBoxTableName.SelectedIndex = 0;

            UiLoadTable(currentGroupTables[0]);
        }

        private void UiReloadTable()
        {
            UiLoadTable(dataTableConnection.TableName);
        }

        private void UiLoadTable(string tableName)
        {
            ShowLoading();

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var backgroundWorker = new BackgroundWorker();
            var args = GetArgs();

            backgroundWorker.DoWork += (sender, e) =>
            {
                dataTableConnection = dataTableServer.GetByName(tableName, args);
                dataTableConnection.Pull();
            };

            backgroundWorker.RunWorkerCompleted += (sender, e) =>
            {
                var table = dataTableConnection.LocalDataTable;

                table.RowChanged += OnUiTableChanged;
                table.ColumnChanged += OnUiTableChanged;
                table.RowDeleted += OnUiTableChanged;

                DisplayTable(table);

                ProcessMetaData();

                SetTableEditable(dataTableConnection.IsPushAvailable);

                SetTableChanged(false);
                HideLoading();
            };

            backgroundWorker.RunWorkerAsync();
        }

        private void OnUiTableChanged(object sender, object e)
        {
            SetTableChanged(true);
        }

        private Args GetArgs()
        {
            return OperTableContract.CreateArgs(yearItemsRepr.SelectedValue);
        }

        private void ProcessMetaData()
        {
            tableYearGroupBox.Visible = dataTableConnection
                .GetMeta(OperTableContract.MetaRequiresYear)
                .IsTrue();
        }

        private void SetTableEditable(bool editable)
        {
            dataGridView1.ReadOnly = !editable;
            dataGridView1.AllowUserToDeleteRows = editable;
            dataGridView1.AllowUserToAddRows = editable;

            buttonSave.Visible = editable;
        }

        private void SetTableChanged(bool changed)
        {
            isTableChanged = changed;

            var formTitle = dataTableConnection.TableName;
            if (changed) formTitle += " - [Изменено]";
            Text = formTitle;

            buttonSave.Enabled = changed;
        }

        private void UiSaveChanges()
        {
            dataTableConnection.Push();
            SetTableChanged(false);
        }

        private void ShowLoading()
        {
            Cursor.Current = Cursors.WaitCursor;
            panelMainContent.Visible = false;
            SuspendLayout();
        }

        private void HideLoading()
        {
            panelMainContent.Visible = true;
            ResumeLayout();
            Cursor.Current = Cursors.Default;
        }

        private void DisplayTable(DataTable dataTable)
        {
            dataGridView1.DataSource = dataTable;

            foreach (var column in dataTableConnection.IgnoredColumns) dataGridView1.Columns[column].Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTableChanged)
            {
                var result = AskUserSaveChanges();
                if (result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (result == DialogResult.Yes) UiSaveChanges();
            }
        }

        private DialogResult AskUserSaveChanges()
        {
            return MessageBox.Show("Вы хотите сохранить изменения?",
                $"Таблица \"{dataTableConnection.TableName}\" была изменена",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
        }


        private bool OnControlEdit(Control control)
        {
            if (isTableChanged)
            {
                var result = AskUserSaveChanges();
                if (result == DialogResult.Cancel) return false;

                if (result == DialogResult.Yes) UiSaveChanges();

                OnControlEdited(control);
            }
            else
            {
                OnControlEdited(control);
            }

            return true;
        }

        private void OnControlEdited(Control control)
        {
            if (control == comboBoxTableName)
            {
                var requiredTable = currentGroupTables[comboBoxTableName.SelectedIndex];
                UiLoadTable(requiredTable);
            }
            else if (control == comboBoxTableYear)
            {
                UiReloadTable();
            }
            else if (control is RadioButton rb)
            {
                UiLoadGroup(rb.Text);
            }
        }

        private void ButtonSendToExcel_Click(object sender, EventArgs e)
        {
            if (!buttonSendToExcel.Enabled)
                return;

            buttonSendToExcel.Enabled = false;

            try
            {
                SendToExcel();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Невозможно отправить таблицу в Excel: \n\n{exc.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonSendToExcel.Enabled = true;
        }

        private void SendToExcel()
        {
            var excelExporter = new ExcelExporter(dataTableConnection);

            var worker = new BackgroundWorker();
            worker.DoWork += (ss, ee) => excelExporter.Export(worker, ee);

            var workerForm = new WorkerForm(worker) {LoadingTitle = "Відбувається експорт..." };
            workerForm.ShowDialog();
            var result = workerForm.Result;
            workerForm.Dispose();

            if (result is Exception exc) throw exc;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var button = (Button) sender;

            if (!button.Enabled)
                return;

            UiSaveChanges();
            UiReloadTable();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var dt = dataTableConnection.LocalDataTable;

            if (Tables.Names.PostTablesDic.ContainsKey(dt.TableName))
            {
                e.Row.Cells["OI_Hydro"].Value = Tables.Names.PostTablesDic[dt.TableName];
            }
        }

        private void buttonTermsHelp_Click(object sender, EventArgs e)
        {
            new TermsHelpForm().Show();
        }
    }
}