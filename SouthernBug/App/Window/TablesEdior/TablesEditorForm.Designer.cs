namespace SouthernBug.App.Window.TablesEdior
{
    partial class TablesEditorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablesEditorForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.headerLeftFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.tableTypeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tableNameGroupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxTableName = new System.Windows.Forms.ComboBox();
            this.tableYearGroupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxTableYear = new System.Windows.Forms.ComboBox();
            this.buttonTermsHelp = new System.Windows.Forms.Button();
            this.panelRoot = new System.Windows.Forms.Panel();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.tableWrapperPanel = new System.Windows.Forms.Panel();
            this.headerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSendToExcel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.headerLeftFlowLayoutPanel.SuspendLayout();
            this.tableTypeGroupBox.SuspendLayout();
            this.tableTypeFlowLayoutPanel.SuspendLayout();
            this.tableNameGroupBox.SuspendLayout();
            this.tableYearGroupBox.SuspendLayout();
            this.panelRoot.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            this.tableWrapperPanel.SuspendLayout();
            this.headerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1129, 625);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            // 
            // headerLeftFlowLayoutPanel
            // 
            this.headerLeftFlowLayoutPanel.AutoSize = true;
            this.headerLeftFlowLayoutPanel.Controls.Add(this.tableTypeGroupBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.tableNameGroupBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.tableYearGroupBox);
            this.headerLeftFlowLayoutPanel.Controls.Add(this.buttonTermsHelp);
            this.headerLeftFlowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.headerLeftFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.headerLeftFlowLayoutPanel.Name = "headerLeftFlowLayoutPanel";
            this.headerLeftFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.headerTableLayoutPanel.SetRowSpan(this.headerLeftFlowLayoutPanel, 2);
            this.headerLeftFlowLayoutPanel.Size = new System.Drawing.Size(929, 70);
            this.headerLeftFlowLayoutPanel.TabIndex = 4;
            // 
            // tableTypeGroupBox
            // 
            this.tableTypeGroupBox.AutoSize = true;
            this.tableTypeGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableTypeGroupBox.Controls.Add(this.tableTypeFlowLayoutPanel);
            this.tableTypeGroupBox.Location = new System.Drawing.Point(20, 10);
            this.tableTypeGroupBox.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.tableTypeGroupBox.Name = "tableTypeGroupBox";
            this.tableTypeGroupBox.Size = new System.Drawing.Size(365, 53);
            this.tableTypeGroupBox.TabIndex = 7;
            this.tableTypeGroupBox.TabStop = false;
            this.tableTypeGroupBox.Text = "Тип даних";
            // 
            // tableTypeFlowLayoutPanel
            // 
            this.tableTypeFlowLayoutPanel.AutoSize = true;
            this.tableTypeFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableTypeFlowLayoutPanel.Controls.Add(this.radioButton1);
            this.tableTypeFlowLayoutPanel.Controls.Add(this.radioButton2);
            this.tableTypeFlowLayoutPanel.Controls.Add(this.radioButton3);
            this.tableTypeFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTypeFlowLayoutPanel.Location = new System.Drawing.Point(3, 22);
            this.tableTypeFlowLayoutPanel.Name = "tableTypeFlowLayoutPanel";
            this.tableTypeFlowLayoutPanel.Size = new System.Drawing.Size(359, 28);
            this.tableTypeFlowLayoutPanel.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(109, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Оперативні";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(118, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Базові";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(199, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(157, 22);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Криві витрат води";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // tableNameGroupBox
            // 
            this.tableNameGroupBox.Controls.Add(this.comboBoxTableName);
            this.tableNameGroupBox.Location = new System.Drawing.Point(408, 10);
            this.tableNameGroupBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.tableNameGroupBox.Name = "tableNameGroupBox";
            this.tableNameGroupBox.Size = new System.Drawing.Size(259, 55);
            this.tableNameGroupBox.TabIndex = 6;
            this.tableNameGroupBox.TabStop = false;
            this.tableNameGroupBox.Text = "Таблиця";
            // 
            // comboBoxTableName
            // 
            this.comboBoxTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTableName.FormattingEnabled = true;
            this.comboBoxTableName.Location = new System.Drawing.Point(3, 22);
            this.comboBoxTableName.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTableName.Name = "comboBoxTableName";
            this.comboBoxTableName.Size = new System.Drawing.Size(253, 26);
            this.comboBoxTableName.TabIndex = 3;
            // 
            // tableYearGroupBox
            // 
            this.tableYearGroupBox.Controls.Add(this.comboBoxTableYear);
            this.tableYearGroupBox.Location = new System.Drawing.Point(680, 10);
            this.tableYearGroupBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tableYearGroupBox.Name = "tableYearGroupBox";
            this.tableYearGroupBox.Size = new System.Drawing.Size(92, 55);
            this.tableYearGroupBox.TabIndex = 7;
            this.tableYearGroupBox.TabStop = false;
            this.tableYearGroupBox.Text = "Рік";
            this.tableYearGroupBox.Visible = false;
            // 
            // comboBoxTableYear
            // 
            this.comboBoxTableYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTableYear.FormattingEnabled = true;
            this.comboBoxTableYear.Location = new System.Drawing.Point(3, 22);
            this.comboBoxTableYear.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTableYear.Name = "comboBoxTableYear";
            this.comboBoxTableYear.Size = new System.Drawing.Size(86, 26);
            this.comboBoxTableYear.TabIndex = 3;
            // 
            // buttonTermsHelp
            // 
            this.buttonTermsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTermsHelp.Location = new System.Drawing.Point(800, 17);
            this.buttonTermsHelp.Margin = new System.Windows.Forms.Padding(25, 10, 0, 3);
            this.buttonTermsHelp.Name = "buttonTermsHelp";
            this.buttonTermsHelp.Size = new System.Drawing.Size(121, 45);
            this.buttonTermsHelp.TabIndex = 7;
            this.buttonTermsHelp.Text = "Умовні\r\nпозначення";
            this.buttonTermsHelp.UseVisualStyleBackColor = true;
            this.buttonTermsHelp.Click += new System.EventHandler(this.buttonTermsHelp_Click);
            // 
            // panelRoot
            // 
            this.panelRoot.Controls.Add(this.panelMainContent);
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Margin = new System.Windows.Forms.Padding(4);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Size = new System.Drawing.Size(1129, 711);
            this.panelRoot.TabIndex = 1;
            // 
            // panelMainContent
            // 
            this.panelMainContent.Controls.Add(this.tableWrapperPanel);
            this.panelMainContent.Controls.Add(this.headerTableLayoutPanel);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 0);
            this.panelMainContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1129, 711);
            this.panelMainContent.TabIndex = 5;
            this.panelMainContent.Visible = false;
            // 
            // tableWrapperPanel
            // 
            this.tableWrapperPanel.Controls.Add(this.dataGridView1);
            this.tableWrapperPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableWrapperPanel.Location = new System.Drawing.Point(0, 86);
            this.tableWrapperPanel.Name = "tableWrapperPanel";
            this.tableWrapperPanel.Size = new System.Drawing.Size(1129, 625);
            this.tableWrapperPanel.TabIndex = 6;
            // 
            // headerTableLayoutPanel
            // 
            this.headerTableLayoutPanel.ColumnCount = 2;
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayoutPanel.Controls.Add(this.buttonSendToExcel, 1, 1);
            this.headerTableLayoutPanel.Controls.Add(this.buttonSave, 1, 0);
            this.headerTableLayoutPanel.Controls.Add(this.headerLeftFlowLayoutPanel, 0, 0);
            this.headerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.headerTableLayoutPanel.Name = "headerTableLayoutPanel";
            this.headerTableLayoutPanel.RowCount = 3;
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.headerTableLayoutPanel.Size = new System.Drawing.Size(1129, 86);
            this.headerTableLayoutPanel.TabIndex = 5;
            // 
            // buttonSendToExcel
            // 
            this.buttonSendToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendToExcel.Location = new System.Drawing.Point(952, 42);
            this.buttonSendToExcel.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.buttonSendToExcel.Name = "buttonSendToExcel";
            this.buttonSendToExcel.Size = new System.Drawing.Size(165, 32);
            this.buttonSendToExcel.TabIndex = 5;
            this.buttonSendToExcel.Text = "Відправити в Excel";
            this.buttonSendToExcel.UseVisualStyleBackColor = true;
            this.buttonSendToExcel.Click += new System.EventHandler(this.ButtonSendToExcel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(1015, 6);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 6, 12, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // TablesEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 711);
            this.Controls.Add(this.panelRoot);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 750);
            this.Name = "TablesEditorForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.headerLeftFlowLayoutPanel.ResumeLayout(false);
            this.headerLeftFlowLayoutPanel.PerformLayout();
            this.tableTypeGroupBox.ResumeLayout(false);
            this.tableTypeGroupBox.PerformLayout();
            this.tableTypeFlowLayoutPanel.ResumeLayout(false);
            this.tableTypeFlowLayoutPanel.PerformLayout();
            this.tableNameGroupBox.ResumeLayout(false);
            this.tableYearGroupBox.ResumeLayout(false);
            this.panelRoot.ResumeLayout(false);
            this.panelMainContent.ResumeLayout(false);
            this.tableWrapperPanel.ResumeLayout(false);
            this.headerTableLayoutPanel.ResumeLayout(false);
            this.headerTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel headerLeftFlowLayoutPanel;
        private System.Windows.Forms.Panel panelRoot;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.ComboBox comboBoxTableName;
        private System.Windows.Forms.GroupBox tableTypeGroupBox;
        private System.Windows.Forms.FlowLayoutPanel tableTypeFlowLayoutPanel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox tableNameGroupBox;
        private System.Windows.Forms.GroupBox tableYearGroupBox;
        private System.Windows.Forms.ComboBox comboBoxTableYear;
        private System.Windows.Forms.TableLayoutPanel headerTableLayoutPanel;
        private System.Windows.Forms.Panel tableWrapperPanel;
        private System.Windows.Forms.Button buttonSendToExcel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTermsHelp;
    }
}

