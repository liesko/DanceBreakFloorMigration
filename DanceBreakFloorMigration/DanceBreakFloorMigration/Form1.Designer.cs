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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 409);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.TextBoxMigration);
            this.Controls.Add(this.BtnMigrationDB);
            this.Controls.Add(this.BtnDBConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnDBConnect;
        private System.Windows.Forms.Button BtnMigrationDB;
        private System.Windows.Forms.RichTextBox TextBoxMigration;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

