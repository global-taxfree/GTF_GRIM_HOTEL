namespace GTF_STFM.Screen
{
    partial class MessageForm
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
            this.LBL_MSG = new MetroFramework.Controls.MetroLabel();
            this.BTN_YES = new MetroFramework.Controls.MetroButton();
            this.BTN_NO = new MetroFramework.Controls.MetroButton();
            this.BTN_OK = new MetroFramework.Controls.MetroButton();
            this.BTN_CANCEL = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // LBL_MSG
            // 
            this.LBL_MSG.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LBL_MSG.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.LBL_MSG.Location = new System.Drawing.Point(37, 32);
            this.LBL_MSG.Name = "LBL_MSG";
            this.LBL_MSG.Size = new System.Drawing.Size(553, 155);
            this.LBL_MSG.TabIndex = 0;
            this.LBL_MSG.Text = "업무마감을 하시겠습니까?";
            this.LBL_MSG.WrapToLine = true;
            // 
            // BTN_YES
            // 
            this.BTN_YES.Location = new System.Drawing.Point(108, 190);
            this.BTN_YES.Name = "BTN_YES";
            this.BTN_YES.Size = new System.Drawing.Size(100, 29);
            this.BTN_YES.TabIndex = 1;
            this.BTN_YES.Text = "YES";
            this.BTN_YES.UseSelectable = true;
            this.BTN_YES.Click += new System.EventHandler(this.BTN_YES_Click);
            // 
            // BTN_NO
            // 
            this.BTN_NO.Location = new System.Drawing.Point(261, 190);
            this.BTN_NO.Name = "BTN_NO";
            this.BTN_NO.Size = new System.Drawing.Size(100, 29);
            this.BTN_NO.TabIndex = 2;
            this.BTN_NO.Text = "NO";
            this.BTN_NO.UseSelectable = true;
            this.BTN_NO.Click += new System.EventHandler(this.BTN_NO_Click);
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(261, 190);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(100, 29);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseSelectable = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_CANCEL
            // 
            this.BTN_CANCEL.Location = new System.Drawing.Point(414, 190);
            this.BTN_CANCEL.Name = "BTN_CANCEL";
            this.BTN_CANCEL.Size = new System.Drawing.Size(100, 29);
            this.BTN_CANCEL.TabIndex = 4;
            this.BTN_CANCEL.Text = "CANCEL";
            this.BTN_CANCEL.UseSelectable = true;
            this.BTN_CANCEL.Click += new System.EventHandler(this.BTN_CANCEL_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 235);
            this.Controls.Add(this.BTN_CANCEL);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.BTN_NO);
            this.Controls.Add(this.BTN_YES);
            this.Controls.Add(this.LBL_MSG);
            this.MaximizeBox = false;
            this.Name = "MessageForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LBL_MSG;
        private MetroFramework.Controls.MetroButton BTN_YES;
        private MetroFramework.Controls.MetroButton BTN_NO;
        private MetroFramework.Controls.MetroButton BTN_OK;
        private MetroFramework.Controls.MetroButton BTN_CANCEL;
    }
}