namespace GTF_STFM.Screen
{
    partial class Login
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
            this.BTN_LOGIN = new MetroFramework.Controls.MetroButton();
            this.BTN_CANCEL = new MetroFramework.Controls.MetroButton();
            this.LBL_ID = new MetroFramework.Controls.MetroLabel();
            this.LBL_PASS = new MetroFramework.Controls.MetroLabel();
            this.TXT_ID = new MetroFramework.Controls.MetroTextBox();
            this.TXT_PASSWORD = new MetroFramework.Controls.MetroTextBox();
            this.CHK_OFFLINE = new MetroFramework.Controls.MetroCheckBox();
            this.Login_ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.LBL_PROGRESS = new MetroFramework.Controls.MetroLabel();
            this.BTN_APPEND = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // BTN_LOGIN
            // 
            this.BTN_LOGIN.Location = new System.Drawing.Point(193, 208);
            this.BTN_LOGIN.Name = "BTN_LOGIN";
            this.BTN_LOGIN.Size = new System.Drawing.Size(75, 29);
            this.BTN_LOGIN.Style = MetroFramework.MetroColorStyle.Orange;
            this.BTN_LOGIN.TabIndex = 2;
            this.BTN_LOGIN.Text = "OK";
            this.BTN_LOGIN.UseSelectable = true;
            this.BTN_LOGIN.Click += new System.EventHandler(this.BTN_LOGIN_Click);
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.Location = new System.Drawing.Point(283, 208);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(75, 29);
            this.BTN_CANCEL.TabIndex = 3;
            this.BTN_CANCEL.Text = "CANCEL";
            this.BTN_CANCEL.UseSelectable = true;
            this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
            // 
            // LBL_ID
            // 
            this.LBL_ID.AutoSize = true;
            this.LBL_ID.Location = new System.Drawing.Point(122, 91);
            this.LBL_ID.Name = "LBL_ID";
            this.LBL_ID.Size = new System.Drawing.Size(21, 19);
            this.LBL_ID.TabIndex = 9;
            this.LBL_ID.Text = "ID";
            // 
            // LBL_PASS
            // 
            this.LBL_PASS.AutoSize = true;
            this.LBL_PASS.Location = new System.Drawing.Point(122, 139);
            this.LBL_PASS.Name = "LBL_PASS";
            this.LBL_PASS.Size = new System.Drawing.Size(64, 19);
            this.LBL_PASS.TabIndex = 8;
            this.LBL_PASS.Text = "Password";
            // 
            // TXT_ID
            // 
            // 
            // 
            // 
            this.TXT_ID.CustomButton.Image = null;
            this.TXT_ID.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.TXT_ID.CustomButton.Name = "";
            this.TXT_ID.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TXT_ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_ID.CustomButton.TabIndex = 1;
            this.TXT_ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_ID.CustomButton.UseSelectable = true;
            this.TXT_ID.CustomButton.Visible = false;
            this.TXT_ID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_ID.Lines = new string[0];
            this.TXT_ID.Location = new System.Drawing.Point(248, 81);
            this.TXT_ID.MaxLength = 32767;
            this.TXT_ID.Name = "TXT_ID";
            this.TXT_ID.PasswordChar = '\0';
            this.TXT_ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_ID.SelectedText = "";
            this.TXT_ID.SelectionLength = 0;
            this.TXT_ID.SelectionStart = 0;
            this.TXT_ID.ShortcutsEnabled = true;
            this.TXT_ID.Size = new System.Drawing.Size(150, 29);
            this.TXT_ID.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_ID.TabIndex = 0;
            this.TXT_ID.UseSelectable = true;
            this.TXT_ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            // 
            // TXT_PASSWORD
            // 
            // 
            // 
            // 
            this.TXT_PASSWORD.CustomButton.Image = null;
            this.TXT_PASSWORD.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.TXT_PASSWORD.CustomButton.Name = "";
            this.TXT_PASSWORD.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TXT_PASSWORD.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_PASSWORD.CustomButton.TabIndex = 1;
            this.TXT_PASSWORD.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_PASSWORD.CustomButton.UseSelectable = true;
            this.TXT_PASSWORD.CustomButton.Visible = false;
            this.TXT_PASSWORD.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_PASSWORD.Lines = new string[0];
            this.TXT_PASSWORD.Location = new System.Drawing.Point(248, 129);
            this.TXT_PASSWORD.MaxLength = 32767;
            this.TXT_PASSWORD.Name = "TXT_PASSWORD";
            this.TXT_PASSWORD.PasswordChar = '●';
            this.TXT_PASSWORD.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_PASSWORD.SelectedText = "";
            this.TXT_PASSWORD.SelectionLength = 0;
            this.TXT_PASSWORD.SelectionStart = 0;
            this.TXT_PASSWORD.ShortcutsEnabled = true;
            this.TXT_PASSWORD.Size = new System.Drawing.Size(150, 29);
            this.TXT_PASSWORD.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_PASSWORD.TabIndex = 1;
            this.TXT_PASSWORD.UseSelectable = true;
            this.TXT_PASSWORD.UseSystemPasswordChar = true;
            this.TXT_PASSWORD.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_PASSWORD.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // CHK_OFFLINE
            // 
            this.CHK_OFFLINE.AutoSize = true;
            this.CHK_OFFLINE.Location = new System.Drawing.Point(39, 141);
            this.CHK_OFFLINE.Name = "CHK_OFFLINE";
            this.CHK_OFFLINE.Size = new System.Drawing.Size(93, 15);
            this.CHK_OFFLINE.TabIndex = 7;
            this.CHK_OFFLINE.Text = "Offline Mode";
            this.CHK_OFFLINE.UseSelectable = true;
            this.CHK_OFFLINE.Visible = false;
            this.CHK_OFFLINE.CheckedChanged += new System.EventHandler(this.CHK_OFFLINE_CheckedChanged);
            // 
            // Login_ProgressBar
            // 
            this.Login_ProgressBar.FontWeight = MetroFramework.MetroProgressBarWeight.Regular;
            this.Login_ProgressBar.Location = new System.Drawing.Point(34, 274);
            this.Login_ProgressBar.MarqueeAnimationSpeed = 10;
            this.Login_ProgressBar.Name = "Login_ProgressBar";
            this.Login_ProgressBar.Size = new System.Drawing.Size(483, 23);
            this.Login_ProgressBar.Style = MetroFramework.MetroColorStyle.Orange;
            this.Login_ProgressBar.TabIndex = 5;
            this.Login_ProgressBar.Click += new System.EventHandler(this.metroProgressBar1_Click);
            // 
            // LBL_PROGRESS
            // 
            this.LBL_PROGRESS.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LBL_PROGRESS.Location = new System.Drawing.Point(37, 248);
            this.LBL_PROGRESS.Name = "LBL_PROGRESS";
            this.LBL_PROGRESS.Size = new System.Drawing.Size(497, 19);
            this.LBL_PROGRESS.TabIndex = 6;
            this.LBL_PROGRESS.Text = "로그인 전";
            this.LBL_PROGRESS.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // BTN_APPEND
            // 
            this.BTN_APPEND.Location = new System.Drawing.Point(23, 100);
            this.BTN_APPEND.Name = "BTN_APPEND";
            this.BTN_APPEND.Size = new System.Drawing.Size(75, 29);
            this.BTN_APPEND.TabIndex = 4;
            this.BTN_APPEND.Text = "APPEND";
            this.BTN_APPEND.UseSelectable = true;
            this.BTN_APPEND.Visible = false;
            this.BTN_APPEND.Click += new System.EventHandler(this.BTN_APPEND_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 327);
            this.Controls.Add(this.BTN_APPEND);
            this.Controls.Add(this.LBL_PROGRESS);
            this.Controls.Add(this.Login_ProgressBar);
            this.Controls.Add(this.CHK_OFFLINE);
            this.Controls.Add(this.TXT_PASSWORD);
            this.Controls.Add(this.TXT_ID);
            this.Controls.Add(this.LBL_PASS);
            this.Controls.Add(this.LBL_ID);
            this.Controls.Add(this.BTN_CANCEL);
            this.Controls.Add(this.BTN_LOGIN);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MetroFramework.Controls.MetroButton BTN_LOGIN;
    private MetroFramework.Controls.MetroButton BTN_CANCEL;
    private MetroFramework.Controls.MetroLabel LBL_ID;
    private MetroFramework.Controls.MetroLabel LBL_PASS;
    private MetroFramework.Controls.MetroTextBox TXT_ID;
    private MetroFramework.Controls.MetroTextBox TXT_PASSWORD;
    private MetroFramework.Controls.MetroCheckBox CHK_OFFLINE;
    private MetroFramework.Controls.MetroProgressBar Login_ProgressBar;
    private MetroFramework.Controls.MetroLabel LBL_PROGRESS;
        private MetroFramework.Controls.MetroButton BTN_APPEND;
    }
}