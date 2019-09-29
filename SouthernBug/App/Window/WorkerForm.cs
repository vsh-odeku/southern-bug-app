using System.ComponentModel;
using System.Windows.Forms;
using SouthernBug.App.Util;

namespace SouthernBug.App.Window
{
    public partial class WorkerForm : Form
    {
        private readonly Holder<object> resultHolder = new Holder<object>();
        private readonly BackgroundWorker worker;

        public WorkerForm(BackgroundWorker worker)
        {
            InitializeComponent();

            this.worker = worker;

            FormClosing += WorkerForm_FormClosing;

            InitializeWorker();
            worker.RunWorkerAsync(resultHolder);
        }

        public object Result { get; private set; }


        public string LoadingTitle
        {
            set => labelTitle.Text = value;
        }

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            worker.CancelAsync();
        }

        private void InitializeWorker()
        {
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Result = resultHolder.Value;
            Close();
        }
    }
}