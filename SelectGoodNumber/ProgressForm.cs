using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SelectGoodNumber
{
    public partial class ProgressForm : Form
    {
        private Thread _runThread;
        private delegate void SetProgressCallBack(int value);
        public ProgressForm()
        {
            InitializeComponent();
        }

        //public ProgressBar CurrentProgressBar
        //{
        //    get { return this.progressBar1; }
        //}

        public void SetProgress(int value)
        {
            if(this.progressBar1.InvokeRequired)
            {
                SetProgressCallBack call = new SetProgressCallBack(SetProgressValue);
                this.progressBar1.Invoke(call, new object[] {value});
            }
        }

        private void SetProgressValue(int value)
        {
            this.progressBar1.Value = value;
        }

        public void Start()
        {
            _runThread = new Thread(_start);
            _runThread.Start();
        }

        public void Stop()
        {
            if (_runThread != null)
                _runThread.Abort();
        }

        private void _start(object obj)
        {
            try
            {
                ShowDialog();
            }
            catch (ThreadAbortException)
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception 
#if DEBUG
                ex
#endif
                )
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}
