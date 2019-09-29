using System;
using System.Windows.Forms;
using Ninject;
using Ninject.Parameters;
using SouthernBug.App.Repository;
using SouthernBug.App.Util;
using SouthernBug.App.Window.Calculations;
using SouthernBug.App.Window.TablesEdior;

namespace SouthernBug.App.Window.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [Inject] public Context Context { get; set; }

        private void OpenDataWindow(object sender, EventArgs e)
        {
            var dataTableServer = Context.Kernel.Get<AllTablesServer>();
            var arg = new ConstructorArgument(
                TablesEditorForm.ArgDataTableServer, dataTableServer);

            Form form = Context.Kernel.Get<TablesEditorForm>(arg);

            form.Show();
        }

        private void OpenCalcWindow(object sender, EventArgs e)
        {
            Form form = Context.Kernel.Get<CalculationsForm>();
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = Constants.MainFormTitle;
            LoadLogoImg();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        private void LoadLogoImg()
        {
            var hash = Etc.CalculateMD5(Constants.MainLogoPath);

            if (hash != Constants.MainLogoMD5) return;

            pictureBox1.WaitOnLoad = true;
            pictureBox1.ImageLocation = Constants.MainLogoPath;
        }
    }
}