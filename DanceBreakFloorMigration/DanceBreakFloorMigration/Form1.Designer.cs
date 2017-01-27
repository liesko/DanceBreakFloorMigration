namespace DanceBreakFloorMigration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnDBConnect = new System.Windows.Forms.Button();
            this.BtnMigrationDB = new System.Windows.Forms.Button();
            this.TextBoxMigration = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.postgreLabel = new System.Windows.Forms.Label();
            this.textPostgreDbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPostgreServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPostgresPortName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPostgreUID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPostgresPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textTeaDbName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textTeaServerName = new System.Windows.Forms.TextBox();
            this.textTeaUID = new System.Windows.Forms.TextBox();
            this.textTeaPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textMyBreakDbName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textMyBreakServerName = new System.Windows.Forms.TextBox();
            this.textMyBreakUID = new System.Windows.Forms.TextBox();
            this.textMyBreakPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnDBConnect
            // 
            this.BtnDBConnect.Location = new System.Drawing.Point(12, 12);
            this.BtnDBConnect.Name = "BtnDBConnect";
            this.BtnDBConnect.Size = new System.Drawing.Size(89, 23);
            this.BtnDBConnect.TabIndex = 0;
            this.BtnDBConnect.Text = "DB connect";
            this.BtnDBConnect.UseVisualStyleBackColor = true;
            this.BtnDBConnect.Click += new System.EventHandler(this.BtnDBConnect_Click);
            // 
            // BtnMigrationDB
            // 
            this.BtnMigrationDB.Location = new System.Drawing.Point(12, 41);
            this.BtnMigrationDB.Name = "BtnMigrationDB";
            this.BtnMigrationDB.Size = new System.Drawing.Size(89, 23);
            this.BtnMigrationDB.TabIndex = 1;
            this.BtnMigrationDB.Text = "Start Migration";
            this.BtnMigrationDB.UseVisualStyleBackColor = true;
            this.BtnMigrationDB.Click += new System.EventHandler(this.BtnMigrationDB_Click);
            // 
            // TextBoxMigration
            // 
            this.TextBoxMigration.Location = new System.Drawing.Point(117, 12);
            this.TextBoxMigration.Name = "TextBoxMigration";
            this.TextBoxMigration.Size = new System.Drawing.Size(384, 372);
            this.TextBoxMigration.TabIndex = 3;
            this.TextBoxMigration.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(89, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // postgreLabel
            // 
            this.postgreLabel.AutoSize = true;
            this.postgreLabel.Location = new System.Drawing.Point(12, 416);
            this.postgreLabel.Name = "postgreLabel";
            this.postgreLabel.Size = new System.Drawing.Size(93, 13);
            this.postgreLabel.TabIndex = 5;
            this.postgreLabel.Text = "PostgreDB - name";
            this.postgreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // textPostgreDbName
            // 
            this.textPostgreDbName.Location = new System.Drawing.Point(12, 432);
            this.textPostgreDbName.Name = "textPostgreDbName";
            this.textPostgreDbName.Size = new System.Drawing.Size(100, 20);
            this.textPostgreDbName.TabIndex = 6;
            this.textPostgreDbName.Text = "test4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server";
            // 
            // textBoxPostgreServerName
            // 
            this.textBoxPostgreServerName.Location = new System.Drawing.Point(135, 432);
            this.textBoxPostgreServerName.Name = "textBoxPostgreServerName";
            this.textBoxPostgreServerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPostgreServerName.TabIndex = 8;
            this.textBoxPostgreServerName.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // textBoxPostgresPortName
            // 
            this.textBoxPostgresPortName.Location = new System.Drawing.Point(243, 433);
            this.textBoxPostgresPortName.Name = "textBoxPostgresPortName";
            this.textBoxPostgresPortName.Size = new System.Drawing.Size(50, 20);
            this.textBoxPostgresPortName.TabIndex = 10;
            this.textBoxPostgresPortName.Text = "5432";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "UID";
            // 
            // textBoxPostgreUID
            // 
            this.textBoxPostgreUID.Location = new System.Drawing.Point(302, 432);
            this.textBoxPostgreUID.Name = "textBoxPostgreUID";
            this.textBoxPostgreUID.Size = new System.Drawing.Size(58, 20);
            this.textBoxPostgreUID.TabIndex = 12;
            this.textBoxPostgreUID.Text = "peterkim";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Password";
            // 
            // textBoxPostgresPassword
            // 
            this.textBoxPostgresPassword.Location = new System.Drawing.Point(371, 432);
            this.textBoxPostgresPassword.Name = "textBoxPostgresPassword";
            this.textBoxPostgresPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPostgresPassword.TabIndex = 14;
            this.textBoxPostgresPassword.Text = "peterkim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "DanceTeaDB - name";
            // 
            // textTeaDbName
            // 
            this.textTeaDbName.Location = new System.Drawing.Point(15, 488);
            this.textTeaDbName.Name = "textTeaDbName";
            this.textTeaDbName.Size = new System.Drawing.Size(100, 20);
            this.textTeaDbName.TabIndex = 16;
            this.textTeaDbName.Text = "dancetea_manager";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 471);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 471);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "UID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Password";
            // 
            // textTeaServerName
            // 
            this.textTeaServerName.Location = new System.Drawing.Point(135, 487);
            this.textTeaServerName.Name = "textTeaServerName";
            this.textTeaServerName.Size = new System.Drawing.Size(100, 20);
            this.textTeaServerName.TabIndex = 20;
            this.textTeaServerName.Text = "localhost";
            // 
            // textTeaUID
            // 
            this.textTeaUID.Location = new System.Drawing.Point(302, 487);
            this.textTeaUID.Name = "textTeaUID";
            this.textTeaUID.Size = new System.Drawing.Size(58, 20);
            this.textTeaUID.TabIndex = 21;
            this.textTeaUID.Text = "root";
            // 
            // textTeaPassword
            // 
            this.textTeaPassword.Location = new System.Drawing.Point(371, 488);
            this.textTeaPassword.Name = "textTeaPassword";
            this.textTeaPassword.Size = new System.Drawing.Size(100, 20);
            this.textTeaPassword.TabIndex = 22;
            this.textTeaPassword.Text = "ahojahoj";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 525);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "MyBreakDB - name";
            // 
            // textMyBreakDbName
            // 
            this.textMyBreakDbName.Location = new System.Drawing.Point(15, 542);
            this.textMyBreakDbName.Name = "textMyBreakDbName";
            this.textMyBreakDbName.Size = new System.Drawing.Size(100, 20);
            this.textMyBreakDbName.TabIndex = 16;
            this.textMyBreakDbName.Text = "mybreak_db";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 525);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Server";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 525);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "UID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 525);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Password";
            // 
            // textMyBreakServerName
            // 
            this.textMyBreakServerName.Location = new System.Drawing.Point(135, 541);
            this.textMyBreakServerName.Name = "textMyBreakServerName";
            this.textMyBreakServerName.Size = new System.Drawing.Size(100, 20);
            this.textMyBreakServerName.TabIndex = 20;
            this.textMyBreakServerName.Text = "localhost";
            // 
            // textMyBreakUID
            // 
            this.textMyBreakUID.Location = new System.Drawing.Point(302, 541);
            this.textMyBreakUID.Name = "textMyBreakUID";
            this.textMyBreakUID.Size = new System.Drawing.Size(58, 20);
            this.textMyBreakUID.TabIndex = 21;
            this.textMyBreakUID.Text = "root";
            // 
            // textMyBreakPassword
            // 
            this.textMyBreakPassword.Location = new System.Drawing.Point(371, 542);
            this.textMyBreakPassword.Name = "textMyBreakPassword";
            this.textMyBreakPassword.Size = new System.Drawing.Size(100, 20);
            this.textMyBreakPassword.TabIndex = 22;
            this.textMyBreakPassword.Text = "ahojahoj";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 598);
            this.Controls.Add(this.textMyBreakPassword);
            this.Controls.Add(this.textTeaPassword);
            this.Controls.Add(this.textMyBreakUID);
            this.Controls.Add(this.textTeaUID);
            this.Controls.Add(this.textMyBreakServerName);
            this.Controls.Add(this.textTeaServerName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textMyBreakDbName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTeaDbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPostgresPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPostgreUID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPostgresPortName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPostgreServerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPostgreDbName);
            this.Controls.Add(this.postgreLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.TextBoxMigration);
            this.Controls.Add(this.BtnMigrationDB);
            this.Controls.Add(this.BtnDBConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDBConnect;
        private System.Windows.Forms.Button BtnMigrationDB;
        private System.Windows.Forms.RichTextBox TextBoxMigration;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label postgreLabel;
        public System.Windows.Forms.TextBox textPostgreDbName;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxPostgreServerName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxPostgresPortName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxPostgreUID;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxPostgresPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textTeaServerName;
        public System.Windows.Forms.TextBox textTeaUID;
        public System.Windows.Forms.TextBox textTeaPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textMyBreakServerName;
        public System.Windows.Forms.TextBox textMyBreakUID;
        public System.Windows.Forms.TextBox textMyBreakPassword;
        public System.Windows.Forms.TextBox textTeaDbName;
        public System.Windows.Forms.TextBox textMyBreakDbName;
    }
}

