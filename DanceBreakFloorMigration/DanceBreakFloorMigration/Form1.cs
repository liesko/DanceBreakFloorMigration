using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration
{
    public partial class Form1 : Form
    {
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        public EventHandler MyEvent;
        public Controller ControlletInstance;
        public Form1()
        {
            MyEvent += MyEventWork;
            InitializeComponent();
            ControlletInstance = new Controller(this);

            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtnMigrationDB.Enabled = true;
            progressBar.Visible = false;
            progressBar.Enabled = false;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ControlletInstance.Remigration();
        }

        private void MyEventWork(object sender, EventArgs eventArgs)
        {
            TextBoxMigration.Invoke(new Action(() => TextBoxMigration.AppendText(((HandlerArgs)eventArgs).Message + "\n")));
        }

        private void BtnDBConnect_Click(object sender, EventArgs e)
        {
            //BtnDBConnect.Enabled = false;
            ControlletInstance.Connect();
        }

        private void BtnMigrationDB_Click(object sender, EventArgs e)
        {
            if (!_backgroundWorker.IsBusy)
            {
                BtnDBConnect.Enabled = false;
                BtnMigrationDB.Enabled = false;
                progressBar.Visible = true;
                progressBar.Enabled = true;
                _backgroundWorker.RunWorkerAsync();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSuplement_Click(object sender, EventArgs e)
        {
            ControlletInstance.Connect();
            ControlletInstance.SuplementRemigration(SuplementCalendar.SelectionRange.Start.ToString());
        }

        private void textBoxPostgresPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
