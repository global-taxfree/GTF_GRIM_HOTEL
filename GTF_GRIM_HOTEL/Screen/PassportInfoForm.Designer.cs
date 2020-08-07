namespace GTF_STFM.Screen
{
    partial class PassportInfoForm
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
            this.BTN_OK = new MetroFramework.Controls.MetroButton();
            this.BTN_CLOSE = new MetroFramework.Controls.MetroButton();
            this.TXT_PASSPORT_NO = new MetroFramework.Controls.MetroTextBox();
            this.TXT_PASSPORT_NAME = new MetroFramework.Controls.MetroTextBox();
            this.COM_PASSPORT_NAT = new MetroFramework.Controls.MetroComboBox();
            this.COM_PASSPORT_SEX = new MetroFramework.Controls.MetroComboBox();
            this.TXT_PASSPORT_BIRTH = new System.Windows.Forms.DateTimePicker();
            this.TXT_PASSPORT_EXP = new System.Windows.Forms.DateTimePicker();
            this.LAY_PASSPORT = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.LAY_PASSPORT.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(212, 189);
            this.BTN_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(138, 36);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "확인";
            this.BTN_OK.UseSelectable = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // BTN_CLOSE
            // 
            this.BTN_CLOSE.Location = new System.Drawing.Point(400, 189);
            this.BTN_CLOSE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_CLOSE.Name = "BTN_CLOSE";
            this.BTN_CLOSE.Size = new System.Drawing.Size(138, 36);
            this.BTN_CLOSE.TabIndex = 10;
            this.BTN_CLOSE.Text = "닫기";
            this.BTN_CLOSE.UseSelectable = true;
            this.BTN_CLOSE.Click += new System.EventHandler(this.BTN_CLOSE_Click);
            // 
            // TXT_PASSPORT_NO
            // 
            this.TXT_PASSPORT_NO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_PASSPORT_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.TXT_PASSPORT_NO.CustomButton.Image = null;
            this.TXT_PASSPORT_NO.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.TXT_PASSPORT_NO.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_PASSPORT_NO.CustomButton.Name = "";
            this.TXT_PASSPORT_NO.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TXT_PASSPORT_NO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_PASSPORT_NO.CustomButton.TabIndex = 1;
            this.TXT_PASSPORT_NO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_PASSPORT_NO.CustomButton.UseSelectable = true;
            this.TXT_PASSPORT_NO.CustomButton.Visible = false;
            this.TXT_PASSPORT_NO.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_PASSPORT_NO.Lines = new string[0];
            this.TXT_PASSPORT_NO.Location = new System.Drawing.Point(495, 2);
            this.TXT_PASSPORT_NO.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_PASSPORT_NO.MaxLength = 10;
            this.TXT_PASSPORT_NO.Name = "TXT_PASSPORT_NO";
            this.TXT_PASSPORT_NO.PasswordChar = '\0';
            this.TXT_PASSPORT_NO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_PASSPORT_NO.SelectedText = "";
            this.TXT_PASSPORT_NO.SelectionLength = 0;
            this.TXT_PASSPORT_NO.SelectionStart = 0;
            this.TXT_PASSPORT_NO.ShortcutsEnabled = true;
            this.TXT_PASSPORT_NO.Size = new System.Drawing.Size(208, 29);
            this.TXT_PASSPORT_NO.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_PASSPORT_NO.TabIndex = 1;
            this.TXT_PASSPORT_NO.UseSelectable = true;
            this.TXT_PASSPORT_NO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_PASSPORT_NO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TXT_PASSPORT_NAME
            // 
            this.TXT_PASSPORT_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_PASSPORT_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.TXT_PASSPORT_NAME.CustomButton.Image = null;
            this.TXT_PASSPORT_NAME.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.TXT_PASSPORT_NAME.CustomButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXT_PASSPORT_NAME.CustomButton.Name = "";
            this.TXT_PASSPORT_NAME.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TXT_PASSPORT_NAME.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_PASSPORT_NAME.CustomButton.TabIndex = 1;
            this.TXT_PASSPORT_NAME.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_PASSPORT_NAME.CustomButton.UseSelectable = true;
            this.TXT_PASSPORT_NAME.CustomButton.Visible = false;
            this.TXT_PASSPORT_NAME.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_PASSPORT_NAME.Lines = new string[0];
            this.TXT_PASSPORT_NAME.Location = new System.Drawing.Point(143, 2);
            this.TXT_PASSPORT_NAME.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_PASSPORT_NAME.MaxLength = 32767;
            this.TXT_PASSPORT_NAME.Name = "TXT_PASSPORT_NAME";
            this.TXT_PASSPORT_NAME.PasswordChar = '\0';
            this.TXT_PASSPORT_NAME.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_PASSPORT_NAME.SelectedText = "";
            this.TXT_PASSPORT_NAME.SelectionLength = 0;
            this.TXT_PASSPORT_NAME.SelectionStart = 0;
            this.TXT_PASSPORT_NAME.ShortcutsEnabled = true;
            this.TXT_PASSPORT_NAME.Size = new System.Drawing.Size(208, 29);
            this.TXT_PASSPORT_NAME.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_PASSPORT_NAME.TabIndex = 0;
            this.TXT_PASSPORT_NAME.UseSelectable = true;
            this.TXT_PASSPORT_NAME.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_PASSPORT_NAME.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // COM_PASSPORT_NAT
            // 
            this.COM_PASSPORT_NAT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PASSPORT_NAT.FormattingEnabled = true;
            this.COM_PASSPORT_NAT.IntegralHeight = false;
            this.COM_PASSPORT_NAT.ItemHeight = 23;
            this.COM_PASSPORT_NAT.Items.AddRange(new object[] {
            "KOR",
            "CHN",
            "JPN",
            "TWN",
            "USA",
            "SGP"});
            this.COM_PASSPORT_NAT.Location = new System.Drawing.Point(143, 34);
            this.COM_PASSPORT_NAT.Margin = new System.Windows.Forms.Padding(1);
            this.COM_PASSPORT_NAT.Name = "COM_PASSPORT_NAT";
            this.COM_PASSPORT_NAT.Size = new System.Drawing.Size(208, 29);
            this.COM_PASSPORT_NAT.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_PASSPORT_NAT.TabIndex = 2;
            this.COM_PASSPORT_NAT.UseSelectable = true;
            // 
            // COM_PASSPORT_SEX
            // 
            this.COM_PASSPORT_SEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PASSPORT_SEX.FormattingEnabled = true;
            this.COM_PASSPORT_SEX.ItemHeight = 23;
            this.COM_PASSPORT_SEX.Items.AddRange(new object[] {
            "M",
            "F"});
            this.COM_PASSPORT_SEX.Location = new System.Drawing.Point(143, 66);
            this.COM_PASSPORT_SEX.Margin = new System.Windows.Forms.Padding(1);
            this.COM_PASSPORT_SEX.Name = "COM_PASSPORT_SEX";
            this.COM_PASSPORT_SEX.Size = new System.Drawing.Size(208, 29);
            this.COM_PASSPORT_SEX.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_PASSPORT_SEX.TabIndex = 3;
            this.COM_PASSPORT_SEX.UseSelectable = true;
            // 
            // TXT_PASSPORT_BIRTH
            // 
            this.TXT_PASSPORT_BIRTH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_PASSPORT_BIRTH.CustomFormat = "yyyy-MM-dd";
            this.TXT_PASSPORT_BIRTH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_PASSPORT_BIRTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TXT_PASSPORT_BIRTH.Location = new System.Drawing.Point(495, 34);
            this.TXT_PASSPORT_BIRTH.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_PASSPORT_BIRTH.Name = "TXT_PASSPORT_BIRTH";
            this.TXT_PASSPORT_BIRTH.Size = new System.Drawing.Size(208, 29);
            this.TXT_PASSPORT_BIRTH.TabIndex = 5;
            // 
            // TXT_PASSPORT_EXP
            // 
            this.TXT_PASSPORT_EXP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_PASSPORT_EXP.CustomFormat = "yyyy-MM-dd";
            this.TXT_PASSPORT_EXP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_PASSPORT_EXP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TXT_PASSPORT_EXP.Location = new System.Drawing.Point(495, 66);
            this.TXT_PASSPORT_EXP.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_PASSPORT_EXP.Name = "TXT_PASSPORT_EXP";
            this.TXT_PASSPORT_EXP.Size = new System.Drawing.Size(208, 29);
            this.TXT_PASSPORT_EXP.TabIndex = 7;
            // 
            // LAY_PASSPORT
            // 
            this.LAY_PASSPORT.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.LAY_PASSPORT.ColumnCount = 4;
            this.LAY_PASSPORT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LAY_PASSPORT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.LAY_PASSPORT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.LAY_PASSPORT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.LAY_PASSPORT.Controls.Add(this.metroLabel11, 0, 1);
            this.LAY_PASSPORT.Controls.Add(this.TXT_PASSPORT_EXP, 3, 2);
            this.LAY_PASSPORT.Controls.Add(this.COM_PASSPORT_NAT, 1, 1);
            this.LAY_PASSPORT.Controls.Add(this.TXT_PASSPORT_BIRTH, 3, 1);
            this.LAY_PASSPORT.Controls.Add(this.COM_PASSPORT_SEX, 1, 2);
            this.LAY_PASSPORT.Controls.Add(this.metroLabel1, 0, 0);
            this.LAY_PASSPORT.Controls.Add(this.metroLabel8, 0, 2);
            this.LAY_PASSPORT.Controls.Add(this.metroLabel10, 2, 1);
            this.LAY_PASSPORT.Controls.Add(this.metroLabel12, 2, 2);
            this.LAY_PASSPORT.Controls.Add(this.metroLabel13, 2, 0);
            this.LAY_PASSPORT.Controls.Add(this.TXT_PASSPORT_NO, 3, 0);
            this.LAY_PASSPORT.Controls.Add(this.TXT_PASSPORT_NAME, 1, 0);
            this.LAY_PASSPORT.Location = new System.Drawing.Point(32, 70);
            this.LAY_PASSPORT.Margin = new System.Windows.Forms.Padding(0);
            this.LAY_PASSPORT.Name = "LAY_PASSPORT";
            this.LAY_PASSPORT.RowCount = 3;
            this.LAY_PASSPORT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LAY_PASSPORT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LAY_PASSPORT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.LAY_PASSPORT.Size = new System.Drawing.Size(705, 98);
            this.LAY_PASSPORT.TabIndex = 135;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(1, 33);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(140, 31);
            this.metroLabel11.TabIndex = 81;
            this.metroLabel11.Text = "국적";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(1, 1);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(140, 31);
            this.metroLabel1.TabIndex = 77;
            this.metroLabel1.Text = "여권 성명";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(1, 65);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(140, 32);
            this.metroLabel8.TabIndex = 138;
            this.metroLabel8.Text = "성별";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(353, 33);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(140, 31);
            this.metroLabel10.TabIndex = 139;
            this.metroLabel10.Text = "생년월일";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel12.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel12.Location = new System.Drawing.Point(353, 65);
            this.metroLabel12.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(140, 32);
            this.metroLabel12.TabIndex = 140;
            this.metroLabel12.Text = "여권만기일";
            this.metroLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel12.UseCustomBackColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel13.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel13.Location = new System.Drawing.Point(353, 1);
            this.metroLabel13.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(140, 31);
            this.metroLabel13.TabIndex = 139;
            this.metroLabel13.Text = "여권 번호";
            this.metroLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel13.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(32, 19);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(160, 36);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 136;
            this.metroLabel3.Text = "여권 수기 입력";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // PassportInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 263);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.LAY_PASSPORT);
            this.Controls.Add(this.BTN_CLOSE);
            this.Controls.Add(this.BTN_OK);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "PassportInfoForm";
            this.Padding = new System.Windows.Forms.Padding(20, 75, 20, 25);
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Activated += new System.EventHandler(this.PassportInfoForm_Activated);
            this.Load += new System.EventHandler(this.PassportInfoForm_Load);
            this.LAY_PASSPORT.ResumeLayout(false);
            this.LAY_PASSPORT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton BTN_OK;
        private MetroFramework.Controls.MetroButton BTN_CLOSE;
        private MetroFramework.Controls.MetroTextBox TXT_PASSPORT_NAME;
        private MetroFramework.Controls.MetroTextBox TXT_PASSPORT_NO;
        private MetroFramework.Controls.MetroComboBox COM_PASSPORT_SEX;
        private MetroFramework.Controls.MetroComboBox COM_PASSPORT_NAT;
        private System.Windows.Forms.DateTimePicker TXT_PASSPORT_BIRTH;
        private System.Windows.Forms.DateTimePicker TXT_PASSPORT_EXP;
        private System.Windows.Forms.TableLayoutPanel LAY_PASSPORT;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}