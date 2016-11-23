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
        public EventHandler MyEvent;
        public Controller ControlletInstance;
        public Form1()
        {
            MyEvent += MyEventWork;
            ControlletInstance = new Controller(this);
            InitializeComponent();
        }

        private void MyEventWork(object sender, EventArgs eventArgs)
        {
           TextBoxMigration.AppendText(((HandlerArgs)eventArgs).Message + "\n");
        }

        private void BtnDBConnect_Click(object sender, EventArgs e)
        {
            //TextBoxMigration.AppendText(Environment.NewLine + ControlletInstance.Connect().ToString());
            ControlletInstance.Connect();
        }

        private void BtnMigrationDB_Click(object sender, EventArgs e)
        {
            ControlletInstance.Remigration();
        }
    }
}
