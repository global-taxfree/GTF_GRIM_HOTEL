namespace GTF_STFM.Screen
{
    partial class MessageSmallForm
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
            this.BTN_OK = new MetroFramework.Controls.MetroButton();
            this.TXT_PASSORD = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // LBL_MSG
            // 
            this.LBL_MSG.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LBL_MSG.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.LBL_MSG.Location = new System.Drawing.Point(46, 49);
            this.LBL_MSG.Name = "LBL_MSG";
            this.LBL_MSG.Size = new System.Drawing.Size(294, 37);
            this.LBL_MSG.TabIndex = 0;
            this.LBL_MSG.Text = "환경설정 비밀번호를 입력하세요";
            this.LBL_MSG.WrapToLine = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(143, 148);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(100, 29);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseSelectable = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // TXT_PASSORD
            // 
            this.TXT_PASSORD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TXT_PASSORD.CustomButton.Image = null;
            this.TXT_PASSORD.CustomButton.Location = new System.Drawing.Point(133, 2);
            this.TXT_PASSORD.CustomButton.Name = "";
            this.TXT_PASSORD.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TXT_PASSORD.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_PASSORD.CustomButton.TabIndex = 1;
            this.TXT_PASSORD.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_PASSORD.CustomButton.UseSelectable = true;
            this.TXT_PASSORD.CustomButton.Visible = false;
            this.TXT_PASSORD.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_PASSORD.Lines = new string[0];
            this.TXT_PASSORD.Location = new System.Drawing.Point(109, 101);
            this.TXT_PASSORD.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_PASSORD.MaxLength = 32767;
            this.TXT_PASSORD.Name = "TXT_PASSORD";
            this.TXT_PASSORD.PasswordChar = '*';
            this.TXT_PASSORD.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_PASSORD.SelectedText = "";
            this.TXT_PASSORD.SelectionLength = 0;
            this.TXT_PASSORD.SelectionStart = 0;
            this.TXT_PASSORD.ShortcutsEnabled = true;
            this.TXT_PASSORD.Size = new System.Drawing.Size(161, 30);
            this.TXT_PASSORD.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_PASSORD.TabIndex = 141;
            this.TXT_PASSORD.UseSelectable = true;
            this.TXT_PASSORD.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_PASSORD.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MessageSmallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 200);
            this.Controls.Add(this.TXT_PASSORD);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.LBL_MSG);
            this.MaximizeBox = false;
            this.Name = "MessageSmallForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LBL_MSG;
        private MetroFramework.Controls.MetroButton BTN_OK;
        private MetroFramework.Controls.MetroTextBox TXT_PASSORD;
    }
}