namespace GTF_STFM.Screen
{
    partial class PreferencesPanel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.TXT_TML_ID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.COM_PASS_SCAN = new MetroFramework.Controls.MetroComboBox();
            this.COM_PRINTER = new MetroFramework.Controls.MetroComboBox();
            this.COM_SLIP_TYPE = new MetroFramework.Controls.MetroComboBox();
            this.BTN_PRINT_TEST = new MetroFramework.Controls.MetroButton();
            this.BTN_SCAN_TEST = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TXT_SUITE_SELL_PRICE = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.TXT_TMLID_CONFIRM = new MetroFramework.Controls.MetroButton();
            this.COM_PRINTER_TYPE = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.COM_OPOS = new MetroFramework.Controls.MetroComboBox();
            this.COM_SIGNPAD = new MetroFramework.Controls.MetroComboBox();
            this.BTN_OPOS_TEST = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.BTN_SIGN_TEST = new MetroFramework.Controls.MetroButton();
            this.TXT_STANDARD_SELL_PRICE = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.BTN_SAVE = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.BTN_TID_CONFIRM = new MetroFramework.Controls.MetroButton();
            this.COM_PC_NO = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.BTN_HELP = new MetroFramework.Controls.MetroButton();
            this.BTN_DOWNLOAD = new MetroFramework.Controls.MetroButton();
            this.BTN_REG_SIGN = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel9
            // 
            this.metroLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel9.Location = new System.Drawing.Point(1, 1);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(153, 33);
            this.metroLabel9.TabIndex = 58;
            this.metroLabel9.Text = "단말기 ID";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel9.UseCustomBackColor = true;
            this.metroLabel9.Click += new System.EventHandler(this.metroLabel9_Click);
            // 
            // TXT_TML_ID
            // 
            this.TXT_TML_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TXT_TML_ID.CustomButton.Image = null;
            this.TXT_TML_ID.CustomButton.Location = new System.Drawing.Point(173, 1);
            this.TXT_TML_ID.CustomButton.Name = "";
            this.TXT_TML_ID.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TXT_TML_ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_TML_ID.CustomButton.TabIndex = 1;
            this.TXT_TML_ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_TML_ID.CustomButton.UseSelectable = true;
            this.TXT_TML_ID.CustomButton.Visible = false;
            this.TXT_TML_ID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_TML_ID.Lines = new string[0];
            this.TXT_TML_ID.Location = new System.Drawing.Point(158, 4);
            this.TXT_TML_ID.MaxLength = 5;
            this.TXT_TML_ID.Name = "TXT_TML_ID";
            this.TXT_TML_ID.PasswordChar = '\0';
            this.TXT_TML_ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_TML_ID.SelectedText = "";
            this.TXT_TML_ID.SelectionLength = 0;
            this.TXT_TML_ID.SelectionStart = 0;
            this.TXT_TML_ID.ShortcutsEnabled = true;
            this.TXT_TML_ID.Size = new System.Drawing.Size(199, 27);
            this.TXT_TML_ID.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_TML_ID.TabIndex = 0;
            this.TXT_TML_ID.UseSelectable = true;
            this.TXT_TML_ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_TML_ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TXT_TML_ID.TextChanged += new System.EventHandler(this.TXT_TML_ID_TextChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel6.Location = new System.Drawing.Point(43, 403);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(65, 19);
            this.metroLabel6.TabIndex = 70;
            this.metroLabel6.Text = "출력매수";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.Visible = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(1, 103);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(153, 33);
            this.metroLabel7.TabIndex = 72;
            this.metroLabel7.Text = "일반 프린터";
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(1, 35);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(153, 33);
            this.metroLabel8.TabIndex = 74;
            this.metroLabel8.Text = "여권 스캐너";
            this.metroLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // COM_PASS_SCAN
            // 
            this.COM_PASS_SCAN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PASS_SCAN.FormattingEnabled = true;
            this.COM_PASS_SCAN.ItemHeight = 23;
            this.COM_PASS_SCAN.Items.AddRange(new object[] {
            "없음",
            "GTF-PS01(GTF)",
            "WISESCAN420",
            "COMBOSMART(DAWIN)",
            "NP-1000(OKPOS)"});
            this.COM_PASS_SCAN.Location = new System.Drawing.Point(158, 38);
            this.COM_PASS_SCAN.Name = "COM_PASS_SCAN";
            this.COM_PASS_SCAN.Size = new System.Drawing.Size(199, 29);
            this.COM_PASS_SCAN.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_PASS_SCAN.TabIndex = 1;
            this.COM_PASS_SCAN.UseSelectable = true;
            // 
            // COM_PRINTER
            // 
            this.COM_PRINTER.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PRINTER.FormattingEnabled = true;
            this.COM_PRINTER.ItemHeight = 23;
            this.COM_PRINTER.Location = new System.Drawing.Point(158, 106);
            this.COM_PRINTER.Name = "COM_PRINTER";
            this.COM_PRINTER.Size = new System.Drawing.Size(199, 29);
            this.COM_PRINTER.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_PRINTER.TabIndex = 3;
            this.COM_PRINTER.UseSelectable = true;
            // 
            // COM_SLIP_TYPE
            // 
            this.COM_SLIP_TYPE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_SLIP_TYPE.FormattingEnabled = true;
            this.COM_SLIP_TYPE.ItemHeight = 23;
            this.COM_SLIP_TYPE.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.COM_SLIP_TYPE.Location = new System.Drawing.Point(197, 376);
            this.COM_SLIP_TYPE.Name = "COM_SLIP_TYPE";
            this.COM_SLIP_TYPE.Size = new System.Drawing.Size(199, 29);
            this.COM_SLIP_TYPE.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_SLIP_TYPE.TabIndex = 5;
            this.COM_SLIP_TYPE.UseSelectable = true;
            this.COM_SLIP_TYPE.Visible = false;
            // 
            // BTN_PRINT_TEST
            // 
            this.BTN_PRINT_TEST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_PRINT_TEST.Location = new System.Drawing.Point(364, 106);
            this.BTN_PRINT_TEST.Name = "BTN_PRINT_TEST";
            this.BTN_PRINT_TEST.Size = new System.Drawing.Size(149, 27);
            this.BTN_PRINT_TEST.TabIndex = 4;
            this.BTN_PRINT_TEST.Text = "출력 테스트";
            this.BTN_PRINT_TEST.UseSelectable = true;
            this.BTN_PRINT_TEST.Click += new System.EventHandler(this.BTN_PRINT_TEST_Click);
            // 
            // BTN_SCAN_TEST
            // 
            this.BTN_SCAN_TEST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_SCAN_TEST.Location = new System.Drawing.Point(364, 38);
            this.BTN_SCAN_TEST.Name = "BTN_SCAN_TEST";
            this.BTN_SCAN_TEST.Size = new System.Drawing.Size(149, 27);
            this.BTN_SCAN_TEST.TabIndex = 2;
            this.BTN_SCAN_TEST.Text = "여권 스캔 테스트";
            this.BTN_SCAN_TEST.UseSelectable = true;
            this.BTN_SCAN_TEST.Click += new System.EventHandler(this.BTN_SCAN_TEST_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.TXT_SUITE_SELL_PRICE, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel10, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.TXT_TMLID_CONFIRM, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.COM_PRINTER_TYPE, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.COM_PASS_SCAN, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TXT_TML_ID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BTN_SCAN_TEST, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.COM_OPOS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.COM_SIGNPAD, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.COM_PRINTER, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BTN_OPOS_TEST, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.BTN_PRINT_TEST, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.BTN_SIGN_TEST, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.TXT_STANDARD_SELL_PRICE, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel11, 0, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 274);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TXT_SUITE_SELL_PRICE
            // 
            this.TXT_SUITE_SELL_PRICE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TXT_SUITE_SELL_PRICE.CustomButton.Image = null;
            this.TXT_SUITE_SELL_PRICE.CustomButton.Location = new System.Drawing.Point(173, 2);
            this.TXT_SUITE_SELL_PRICE.CustomButton.Name = "";
            this.TXT_SUITE_SELL_PRICE.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.TXT_SUITE_SELL_PRICE.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_SUITE_SELL_PRICE.CustomButton.TabIndex = 1;
            this.TXT_SUITE_SELL_PRICE.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_SUITE_SELL_PRICE.CustomButton.UseSelectable = true;
            this.TXT_SUITE_SELL_PRICE.CustomButton.Visible = false;
            this.TXT_SUITE_SELL_PRICE.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_SUITE_SELL_PRICE.Lines = new string[] {
        "0"};
            this.TXT_SUITE_SELL_PRICE.Location = new System.Drawing.Point(158, 242);
            this.TXT_SUITE_SELL_PRICE.MaxLength = 7;
            this.TXT_SUITE_SELL_PRICE.Name = "TXT_SUITE_SELL_PRICE";
            this.TXT_SUITE_SELL_PRICE.PasswordChar = '\0';
            this.TXT_SUITE_SELL_PRICE.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_SUITE_SELL_PRICE.SelectedText = "";
            this.TXT_SUITE_SELL_PRICE.SelectionLength = 0;
            this.TXT_SUITE_SELL_PRICE.SelectionStart = 0;
            this.TXT_SUITE_SELL_PRICE.ShortcutsEnabled = true;
            this.TXT_SUITE_SELL_PRICE.Size = new System.Drawing.Size(199, 28);
            this.TXT_SUITE_SELL_PRICE.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_SUITE_SELL_PRICE.TabIndex = 136;
            this.TXT_SUITE_SELL_PRICE.Text = "0";
            this.TXT_SUITE_SELL_PRICE.UseSelectable = true;
            this.TXT_SUITE_SELL_PRICE.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_SUITE_SELL_PRICE.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(1, 205);
            this.metroLabel10.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(153, 33);
            this.metroLabel10.TabIndex = 75;
            this.metroLabel10.Text = "일반룸 가격세팅";
            this.metroLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // TXT_TMLID_CONFIRM
            // 
            this.TXT_TMLID_CONFIRM.Location = new System.Drawing.Point(364, 4);
            this.TXT_TMLID_CONFIRM.Name = "TXT_TMLID_CONFIRM";
            this.TXT_TMLID_CONFIRM.Size = new System.Drawing.Size(149, 24);
            this.TXT_TMLID_CONFIRM.TabIndex = 133;
            this.TXT_TMLID_CONFIRM.Text = "ID 검증";
            this.TXT_TMLID_CONFIRM.UseSelectable = true;
            this.TXT_TMLID_CONFIRM.Click += new System.EventHandler(this.TXT_TMLID_CONFIRM_Click);
            // 
            // COM_PRINTER_TYPE
            // 
            this.COM_PRINTER_TYPE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PRINTER_TYPE.FormattingEnabled = true;
            this.COM_PRINTER_TYPE.ItemHeight = 23;
            this.COM_PRINTER_TYPE.Items.AddRange(new object[] {
            "일반프린터",
            "영수증프린터"});
            this.COM_PRINTER_TYPE.Location = new System.Drawing.Point(158, 72);
            this.COM_PRINTER_TYPE.Name = "COM_PRINTER_TYPE";
            this.COM_PRINTER_TYPE.Size = new System.Drawing.Size(199, 29);
            this.COM_PRINTER_TYPE.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_PRINTER_TYPE.TabIndex = 133;
            this.COM_PRINTER_TYPE.UseSelectable = true;
            this.COM_PRINTER_TYPE.SelectedIndexChanged += new System.EventHandler(this.COM_PRINTER_TYPE_SelectedIndexChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(1, 69);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(153, 33);
            this.metroLabel5.TabIndex = 133;
            this.metroLabel5.Text = "프린터 종류";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(1, 137);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(153, 33);
            this.metroLabel1.TabIndex = 88;
            this.metroLabel1.Text = "영수증 프린터";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // COM_OPOS
            // 
            this.COM_OPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_OPOS.FormattingEnabled = true;
            this.COM_OPOS.ItemHeight = 23;
            this.COM_OPOS.Items.AddRange(new object[] {
            "SRP-350III",
            "SRP-350II  Plus",
            "SRP-350III Plus"});
            this.COM_OPOS.Location = new System.Drawing.Point(158, 140);
            this.COM_OPOS.Name = "COM_OPOS";
            this.COM_OPOS.Size = new System.Drawing.Size(199, 29);
            this.COM_OPOS.TabIndex = 88;
            this.COM_OPOS.UseSelectable = true;
            // 
            // COM_SIGNPAD
            // 
            this.COM_SIGNPAD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_SIGNPAD.FormattingEnabled = true;
            this.COM_SIGNPAD.ItemHeight = 23;
            this.COM_SIGNPAD.Items.AddRange(new object[] {
            "없음",
            "다우 사인패드"});
            this.COM_SIGNPAD.Location = new System.Drawing.Point(158, 174);
            this.COM_SIGNPAD.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.COM_SIGNPAD.Name = "COM_SIGNPAD";
            this.COM_SIGNPAD.Size = new System.Drawing.Size(199, 29);
            this.COM_SIGNPAD.Style = MetroFramework.MetroColorStyle.Orange;
            this.COM_SIGNPAD.TabIndex = 76;
            this.COM_SIGNPAD.UseSelectable = true;
            // 
            // BTN_OPOS_TEST
            // 
            this.BTN_OPOS_TEST.Location = new System.Drawing.Point(364, 140);
            this.BTN_OPOS_TEST.Name = "BTN_OPOS_TEST";
            this.BTN_OPOS_TEST.Size = new System.Drawing.Size(149, 24);
            this.BTN_OPOS_TEST.TabIndex = 6;
            this.BTN_OPOS_TEST.Text = "출력테스트";
            this.BTN_OPOS_TEST.UseSelectable = true;
            this.BTN_OPOS_TEST.Click += new System.EventHandler(this.BTN_OPOS_TEST_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(1, 171);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(153, 33);
            this.metroLabel4.TabIndex = 75;
            this.metroLabel4.Text = "사인패드";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // BTN_SIGN_TEST
            // 
            this.BTN_SIGN_TEST.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_SIGN_TEST.Location = new System.Drawing.Point(364, 174);
            this.BTN_SIGN_TEST.Name = "BTN_SIGN_TEST";
            this.BTN_SIGN_TEST.Size = new System.Drawing.Size(149, 27);
            this.BTN_SIGN_TEST.TabIndex = 77;
            this.BTN_SIGN_TEST.Text = "SIGN 테스트";
            this.BTN_SIGN_TEST.UseSelectable = true;
            this.BTN_SIGN_TEST.Click += new System.EventHandler(this.BTN_SIGN_TEST_Click);
            // 
            // TXT_STANDARD_SELL_PRICE
            // 
            this.TXT_STANDARD_SELL_PRICE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Image = null;
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Location = new System.Drawing.Point(173, 1);
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Name = "";
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_STANDARD_SELL_PRICE.CustomButton.TabIndex = 1;
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_STANDARD_SELL_PRICE.CustomButton.UseSelectable = true;
            this.TXT_STANDARD_SELL_PRICE.CustomButton.Visible = false;
            this.TXT_STANDARD_SELL_PRICE.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_STANDARD_SELL_PRICE.Lines = new string[] {
        "0"};
            this.TXT_STANDARD_SELL_PRICE.Location = new System.Drawing.Point(158, 208);
            this.TXT_STANDARD_SELL_PRICE.MaxLength = 7;
            this.TXT_STANDARD_SELL_PRICE.Name = "TXT_STANDARD_SELL_PRICE";
            this.TXT_STANDARD_SELL_PRICE.PasswordChar = '\0';
            this.TXT_STANDARD_SELL_PRICE.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_STANDARD_SELL_PRICE.SelectedText = "";
            this.TXT_STANDARD_SELL_PRICE.SelectionLength = 0;
            this.TXT_STANDARD_SELL_PRICE.SelectionStart = 0;
            this.TXT_STANDARD_SELL_PRICE.ShortcutsEnabled = true;
            this.TXT_STANDARD_SELL_PRICE.Size = new System.Drawing.Size(199, 27);
            this.TXT_STANDARD_SELL_PRICE.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_STANDARD_SELL_PRICE.TabIndex = 134;
            this.TXT_STANDARD_SELL_PRICE.Text = "0";
            this.TXT_STANDARD_SELL_PRICE.UseSelectable = true;
            this.TXT_STANDARD_SELL_PRICE.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_STANDARD_SELL_PRICE.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.metroLabel11.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel11.Location = new System.Drawing.Point(1, 239);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(153, 34);
            this.metroLabel11.TabIndex = 135;
            this.metroLabel11.Text = "스위트룸 가격세팅";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // BTN_SAVE
            // 
            this.BTN_SAVE.Location = new System.Drawing.Point(648, 59);
            this.BTN_SAVE.Name = "BTN_SAVE";
            this.BTN_SAVE.Size = new System.Drawing.Size(125, 29);
            this.BTN_SAVE.TabIndex = 1;
            this.BTN_SAVE.Text = "저장";
            this.BTN_SAVE.UseSelectable = true;
            this.BTN_SAVE.Click += new System.EventHandler(this.BTN_SAVE_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(12, 10);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 36);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 131;
            this.metroLabel3.Text = "환경설정";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // BTN_TID_CONFIRM
            // 
            this.BTN_TID_CONFIRM.Location = new System.Drawing.Point(338, 482);
            this.BTN_TID_CONFIRM.Name = "BTN_TID_CONFIRM";
            this.BTN_TID_CONFIRM.Size = new System.Drawing.Size(150, 29);
            this.BTN_TID_CONFIRM.TabIndex = 1;
            this.BTN_TID_CONFIRM.Text = "ID Confirm";
            this.BTN_TID_CONFIRM.UseSelectable = true;
            this.BTN_TID_CONFIRM.Visible = false;
            this.BTN_TID_CONFIRM.Click += new System.EventHandler(this.BTN_TID_CONFIRM_Click);
            // 
            // COM_PC_NO
            // 
            this.COM_PC_NO.FormattingEnabled = true;
            this.COM_PC_NO.ItemHeight = 23;
            this.COM_PC_NO.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.COM_PC_NO.Location = new System.Drawing.Point(132, 482);
            this.COM_PC_NO.Name = "COM_PC_NO";
            this.COM_PC_NO.Size = new System.Drawing.Size(182, 29);
            this.COM_PC_NO.TabIndex = 75;
            this.COM_PC_NO.UseSelectable = true;
            this.COM_PC_NO.Visible = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(33, 482);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 76;
            this.metroLabel2.Text = "PC NO";
            this.metroLabel2.Visible = false;
            // 
            // BTN_HELP
            // 
            this.BTN_HELP.Location = new System.Drawing.Point(648, 129);
            this.BTN_HELP.Name = "BTN_HELP";
            this.BTN_HELP.Size = new System.Drawing.Size(125, 29);
            this.BTN_HELP.TabIndex = 3;
            this.BTN_HELP.Text = "Help";
            this.BTN_HELP.UseSelectable = true;
            this.BTN_HELP.Visible = false;
            // 
            // BTN_DOWNLOAD
            // 
            this.BTN_DOWNLOAD.Location = new System.Drawing.Point(648, 94);
            this.BTN_DOWNLOAD.Name = "BTN_DOWNLOAD";
            this.BTN_DOWNLOAD.Size = new System.Drawing.Size(125, 29);
            this.BTN_DOWNLOAD.TabIndex = 2;
            this.BTN_DOWNLOAD.Text = "Download";
            this.BTN_DOWNLOAD.UseSelectable = true;
            this.BTN_DOWNLOAD.Visible = false;
            // 
            // BTN_REG_SIGN
            // 
            this.BTN_REG_SIGN.Location = new System.Drawing.Point(528, 407);
            this.BTN_REG_SIGN.Name = "BTN_REG_SIGN";
            this.BTN_REG_SIGN.Size = new System.Drawing.Size(153, 29);
            this.BTN_REG_SIGN.TabIndex = 132;
            this.BTN_REG_SIGN.Text = "호텔 SIGN 등록";
            this.BTN_REG_SIGN.UseSelectable = true;
            this.BTN_REG_SIGN.Visible = false;
            // 
            // PreferencesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BTN_REG_SIGN);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.COM_PC_NO);
            this.Controls.Add(this.BTN_TID_CONFIRM);
            this.Controls.Add(this.BTN_SAVE);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BTN_DOWNLOAD);
            this.Controls.Add(this.BTN_HELP);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.COM_SLIP_TYPE);
            this.Name = "PreferencesPanel";
            this.Size = new System.Drawing.Size(878, 706);
            this.Load += new System.EventHandler(this.PreferencesPanel_Load);
            this.SizeChanged += new System.EventHandler(this.PreferencesPanel_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox TXT_TML_ID;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox COM_PASS_SCAN;
        private MetroFramework.Controls.MetroComboBox COM_PRINTER;
        private MetroFramework.Controls.MetroComboBox COM_SLIP_TYPE;
        private MetroFramework.Controls.MetroButton BTN_PRINT_TEST;
        private MetroFramework.Controls.MetroButton BTN_SCAN_TEST;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton BTN_SAVE;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton BTN_OPOS_TEST;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton BTN_TID_CONFIRM;
        private MetroFramework.Controls.MetroComboBox COM_PC_NO;
        private MetroFramework.Controls.MetroComboBox COM_OPOS;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton BTN_HELP;
        private MetroFramework.Controls.MetroButton BTN_DOWNLOAD;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox COM_SIGNPAD;
        private MetroFramework.Controls.MetroButton BTN_SIGN_TEST;
        private MetroFramework.Controls.MetroButton BTN_REG_SIGN;
        private MetroFramework.Controls.MetroComboBox COM_PRINTER_TYPE;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton TXT_TMLID_CONFIRM;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox TXT_STANDARD_SELL_PRICE;
        private MetroFramework.Controls.MetroTextBox TXT_SUITE_SELL_PRICE;
        private MetroFramework.Controls.MetroLabel metroLabel11;
    }
}
