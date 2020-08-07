namespace GTF_STFM.Screen
{
    partial class PrintSlipLangForm
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
            this.RDO_LANG_CN = new MetroFramework.Controls.MetroRadioButton();
            this.RDO_LANG_EN = new MetroFramework.Controls.MetroRadioButton();
            this.RDO_LANG_KO = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_MSG
            // 
            this.LBL_MSG.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LBL_MSG.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.LBL_MSG.Location = new System.Drawing.Point(13, 33);
            this.LBL_MSG.Name = "LBL_MSG";
            this.LBL_MSG.Size = new System.Drawing.Size(263, 38);
            this.LBL_MSG.TabIndex = 0;
            this.LBL_MSG.Text = "출력언어선택";
            this.LBL_MSG.WrapToLine = true;
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(100, 149);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(100, 29);
            this.BTN_OK.TabIndex = 3;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseSelectable = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // RDO_LANG_CN
            // 
            this.RDO_LANG_CN.AutoSize = true;
            this.RDO_LANG_CN.Checked = true;
            this.RDO_LANG_CN.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.RDO_LANG_CN.Location = new System.Drawing.Point(21, 20);
            this.RDO_LANG_CN.Name = "RDO_LANG_CN";
            this.RDO_LANG_CN.Size = new System.Drawing.Size(67, 19);
            this.RDO_LANG_CN.Style = MetroFramework.MetroColorStyle.Orange;
            this.RDO_LANG_CN.TabIndex = 4;
            this.RDO_LANG_CN.TabStop = true;
            this.RDO_LANG_CN.Text = "중국어";
            this.RDO_LANG_CN.UseSelectable = true;
            // 
            // RDO_LANG_EN
            // 
            this.RDO_LANG_EN.AutoSize = true;
            this.RDO_LANG_EN.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.RDO_LANG_EN.Location = new System.Drawing.Point(94, 20);
            this.RDO_LANG_EN.Name = "RDO_LANG_EN";
            this.RDO_LANG_EN.Size = new System.Drawing.Size(53, 19);
            this.RDO_LANG_EN.Style = MetroFramework.MetroColorStyle.Orange;
            this.RDO_LANG_EN.TabIndex = 5;
            this.RDO_LANG_EN.Text = "영어";
            this.RDO_LANG_EN.UseSelectable = true;
            this.RDO_LANG_EN.CheckedChanged += new System.EventHandler(this.RDO_LANG_EN_CheckedChanged);
            // 
            // RDO_LANG_KO
            // 
            this.RDO_LANG_KO.AutoSize = true;
            this.RDO_LANG_KO.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.RDO_LANG_KO.Location = new System.Drawing.Point(153, 20);
            this.RDO_LANG_KO.Name = "RDO_LANG_KO";
            this.RDO_LANG_KO.Size = new System.Drawing.Size(67, 19);
            this.RDO_LANG_KO.Style = MetroFramework.MetroColorStyle.Orange;
            this.RDO_LANG_KO.TabIndex = 6;
            this.RDO_LANG_KO.Text = "한국어";
            this.RDO_LANG_KO.UseSelectable = true;
            this.RDO_LANG_KO.CheckedChanged += new System.EventHandler(this.RDO_LANG_KO_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RDO_LANG_KO);
            this.groupBox1.Controls.Add(this.RDO_LANG_EN);
            this.groupBox1.Controls.Add(this.RDO_LANG_CN);
            this.groupBox1.Location = new System.Drawing.Point(27, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 59);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            // 
            // PrintSlipLangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.LBL_MSG);
            this.MaximizeBox = false;
            this.Name = "PrintSlipLangForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LBL_MSG;
        private MetroFramework.Controls.MetroButton BTN_OK;
        private MetroFramework.Controls.MetroRadioButton RDO_LANG_CN;
        private MetroFramework.Controls.MetroRadioButton RDO_LANG_EN;
        private MetroFramework.Controls.MetroRadioButton RDO_LANG_KO;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}