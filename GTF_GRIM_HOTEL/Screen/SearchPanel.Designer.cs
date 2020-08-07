namespace GTF_STFM.Screen
{
    partial class SearchPanel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LBL_REFUND_DATE = new MetroFramework.Controls.MetroLabel();
            this.TXT_REFUND_DATE_FROM = new MetroFramework.Controls.MetroDateTime();
            this.TXT_BUY_SERIAL_NO = new MetroFramework.Controls.MetroTextBox();
            this.LBL_SLIP_NO = new MetroFramework.Controls.MetroLabel();
            this.GRD_SLIP = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAY_SEARCH = new System.Windows.Forms.TableLayoutPanel();
            this.TXT_REFUND_DATE_TO = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TIL_1 = new MetroFramework.Controls.MetroTile();
            this.BTN_SEARCH = new MetroFramework.Controls.MetroButton();
            this.BTN_EXCELDW = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.COM_PAGE = new System.Windows.Forms.ComboBox();
            this.LBL_PAGE = new MetroFramework.Controls.MetroLabel();
            this.LBL = new MetroFramework.Controls.MetroLabel();
            this.LBL_TOTAL_PAGE = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_SLIP)).BeginInit();
            this.LAY_SEARCH.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_REFUND_DATE
            // 
            this.LBL_REFUND_DATE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_REFUND_DATE.AutoSize = true;
            this.LBL_REFUND_DATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.LBL_REFUND_DATE.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LBL_REFUND_DATE.Location = new System.Drawing.Point(1, 1);
            this.LBL_REFUND_DATE.Margin = new System.Windows.Forms.Padding(0);
            this.LBL_REFUND_DATE.Name = "LBL_REFUND_DATE";
            this.LBL_REFUND_DATE.Size = new System.Drawing.Size(182, 31);
            this.LBL_REFUND_DATE.TabIndex = 45;
            this.LBL_REFUND_DATE.Text = "발행기간";
            this.LBL_REFUND_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_REFUND_DATE.UseCustomBackColor = true;
            // 
            // TXT_REFUND_DATE_FROM
            // 
            this.TXT_REFUND_DATE_FROM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_REFUND_DATE_FROM.CalendarFont = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TXT_REFUND_DATE_FROM.CustomFormat = "yyyy-MM-dd";
            this.TXT_REFUND_DATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TXT_REFUND_DATE_FROM.Location = new System.Drawing.Point(185, 2);
            this.TXT_REFUND_DATE_FROM.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_REFUND_DATE_FROM.MinimumSize = new System.Drawing.Size(0, 29);
            this.TXT_REFUND_DATE_FROM.Name = "TXT_REFUND_DATE_FROM";
            this.TXT_REFUND_DATE_FROM.Size = new System.Drawing.Size(246, 29);
            this.TXT_REFUND_DATE_FROM.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_REFUND_DATE_FROM.TabIndex = 0;
            // 
            // TXT_BUY_SERIAL_NO
            // 
            this.TXT_BUY_SERIAL_NO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LAY_SEARCH.SetColumnSpan(this.TXT_BUY_SERIAL_NO, 3);
            // 
            // 
            // 
            this.TXT_BUY_SERIAL_NO.CustomButton.Image = null;
            this.TXT_BUY_SERIAL_NO.CustomButton.Location = new System.Drawing.Point(651, 1);
            this.TXT_BUY_SERIAL_NO.CustomButton.Name = "";
            this.TXT_BUY_SERIAL_NO.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.TXT_BUY_SERIAL_NO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TXT_BUY_SERIAL_NO.CustomButton.TabIndex = 1;
            this.TXT_BUY_SERIAL_NO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TXT_BUY_SERIAL_NO.CustomButton.UseSelectable = true;
            this.TXT_BUY_SERIAL_NO.CustomButton.Visible = false;
            this.TXT_BUY_SERIAL_NO.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TXT_BUY_SERIAL_NO.Lines = new string[0];
            this.TXT_BUY_SERIAL_NO.Location = new System.Drawing.Point(185, 33);
            this.TXT_BUY_SERIAL_NO.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.TXT_BUY_SERIAL_NO.MaxLength = 32767;
            this.TXT_BUY_SERIAL_NO.Name = "TXT_BUY_SERIAL_NO";
            this.TXT_BUY_SERIAL_NO.PasswordChar = '\0';
            this.TXT_BUY_SERIAL_NO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TXT_BUY_SERIAL_NO.SelectedText = "";
            this.TXT_BUY_SERIAL_NO.SelectionLength = 0;
            this.TXT_BUY_SERIAL_NO.SelectionStart = 0;
            this.TXT_BUY_SERIAL_NO.ShortcutsEnabled = true;
            this.TXT_BUY_SERIAL_NO.Size = new System.Drawing.Size(681, 31);
            this.TXT_BUY_SERIAL_NO.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_BUY_SERIAL_NO.TabIndex = 3;
            this.TXT_BUY_SERIAL_NO.UseSelectable = true;
            this.TXT_BUY_SERIAL_NO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TXT_BUY_SERIAL_NO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LBL_SLIP_NO
            // 
            this.LBL_SLIP_NO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_SLIP_NO.AutoSize = true;
            this.LBL_SLIP_NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(201)))));
            this.LBL_SLIP_NO.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LBL_SLIP_NO.Location = new System.Drawing.Point(1, 33);
            this.LBL_SLIP_NO.Margin = new System.Windows.Forms.Padding(0);
            this.LBL_SLIP_NO.Name = "LBL_SLIP_NO";
            this.LBL_SLIP_NO.Size = new System.Drawing.Size(182, 31);
            this.LBL_SLIP_NO.TabIndex = 87;
            this.LBL_SLIP_NO.Text = "구매일련번호";
            this.LBL_SLIP_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_SLIP_NO.UseCustomBackColor = true;
            // 
            // GRD_SLIP
            // 
            this.GRD_SLIP.AllowUserToAddRows = false;
            this.GRD_SLIP.AllowUserToDeleteRows = false;
            this.GRD_SLIP.AllowUserToResizeColumns = false;
            this.GRD_SLIP.AllowUserToResizeRows = false;
            this.GRD_SLIP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GRD_SLIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GRD_SLIP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GRD_SLIP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GRD_SLIP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GRD_SLIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRD_SLIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column10,
            this.Column14});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GRD_SLIP.DefaultCellStyle = dataGridViewCellStyle9;
            this.GRD_SLIP.EnableHeadersVisualStyles = false;
            this.GRD_SLIP.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.GRD_SLIP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GRD_SLIP.Location = new System.Drawing.Point(13, 170);
            this.GRD_SLIP.Name = "GRD_SLIP";
            this.GRD_SLIP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GRD_SLIP.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.GRD_SLIP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRD_SLIP.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.GRD_SLIP.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GRD_SLIP.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GRD_SLIP.RowTemplate.Height = 23;
            this.GRD_SLIP.RowTemplate.ReadOnly = true;
            this.GRD_SLIP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GRD_SLIP.ShowEditingIcon = false;
            this.GRD_SLIP.Size = new System.Drawing.Size(864, 499);
            this.GRD_SLIP.Style = MetroFramework.MetroColorStyle.Orange;
            this.GRD_SLIP.TabIndex = 2;
            this.GRD_SLIP.UseStyleColors = true;
            this.GRD_SLIP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellContentClick);
            this.GRD_SLIP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GRD_SLIP_CellDoubleClick);
            this.GRD_SLIP.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GRD_SLIP_Scroll);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "순번";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column8.HeaderText = "구매일련번호";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "발행일";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "공급가격";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.Column7.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column7.HeaderText = "세금";
            this.Column7.Name = "Column7";
            this.Column7.Width = 85;
            // 
            // Column10
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column10.HeaderText = "환급금";
            this.Column10.Name = "Column10";
            this.Column10.Width = 85;
            // 
            // Column14
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column14.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column14.HeaderText = "전표상태";
            this.Column14.Name = "Column14";
            // 
            // LAY_SEARCH
            // 
            this.LAY_SEARCH.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.LAY_SEARCH.ColumnCount = 4;
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.14141F));
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.19192F));
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.14141F));
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.19192F));
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.14141F));
            this.LAY_SEARCH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.19192F));
            this.LAY_SEARCH.Controls.Add(this.TXT_REFUND_DATE_FROM, 1, 0);
            this.LAY_SEARCH.Controls.Add(this.LBL_REFUND_DATE, 0, 0);
            this.LAY_SEARCH.Controls.Add(this.LBL_SLIP_NO, 0, 1);
            this.LAY_SEARCH.Controls.Add(this.TXT_BUY_SERIAL_NO, 1, 1);
            this.LAY_SEARCH.Controls.Add(this.TXT_REFUND_DATE_TO, 3, 0);
            this.LAY_SEARCH.Controls.Add(this.metroLabel1, 2, 0);
            this.LAY_SEARCH.Location = new System.Drawing.Point(12, 55);
            this.LAY_SEARCH.Margin = new System.Windows.Forms.Padding(0);
            this.LAY_SEARCH.Name = "LAY_SEARCH";
            this.LAY_SEARCH.RowCount = 2;
            this.LAY_SEARCH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LAY_SEARCH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LAY_SEARCH.Size = new System.Drawing.Size(867, 65);
            this.LAY_SEARCH.TabIndex = 1;
            // 
            // TXT_REFUND_DATE_TO
            // 
            this.TXT_REFUND_DATE_TO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_REFUND_DATE_TO.CalendarFont = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TXT_REFUND_DATE_TO.CustomFormat = "yyyy-MM-dd";
            this.TXT_REFUND_DATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TXT_REFUND_DATE_TO.Location = new System.Drawing.Point(617, 2);
            this.TXT_REFUND_DATE_TO.Margin = new System.Windows.Forms.Padding(1);
            this.TXT_REFUND_DATE_TO.MinimumSize = new System.Drawing.Size(0, 29);
            this.TXT_REFUND_DATE_TO.Name = "TXT_REFUND_DATE_TO";
            this.TXT_REFUND_DATE_TO.Size = new System.Drawing.Size(248, 29);
            this.TXT_REFUND_DATE_TO.Style = MetroFramework.MetroColorStyle.Orange;
            this.TXT_REFUND_DATE_TO.TabIndex = 114;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(436, 1);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(176, 31);
            this.metroLabel1.TabIndex = 115;
            this.metroLabel1.Text = "~";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TIL_1
            // 
            this.TIL_1.ActiveControl = null;
            this.TIL_1.Enabled = false;
            this.TIL_1.Location = new System.Drawing.Point(0, 126);
            this.TIL_1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.TIL_1.Name = "TIL_1";
            this.TIL_1.Size = new System.Drawing.Size(900, 2);
            this.TIL_1.Style = MetroFramework.MetroColorStyle.Orange;
            this.TIL_1.TabIndex = 105;
            this.TIL_1.TabStop = false;
            this.TIL_1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.TIL_1.UseSelectable = true;
            // 
            // BTN_SEARCH
            // 
            this.BTN_SEARCH.Location = new System.Drawing.Point(688, 10);
            this.BTN_SEARCH.Name = "BTN_SEARCH";
            this.BTN_SEARCH.Size = new System.Drawing.Size(94, 29);
            this.BTN_SEARCH.TabIndex = 0;
            this.BTN_SEARCH.Text = "조회";
            this.BTN_SEARCH.UseSelectable = true;
            this.BTN_SEARCH.Click += new System.EventHandler(this.BTN_SEARCH_Click);
            // 
            // BTN_EXCELDW
            // 
            this.BTN_EXCELDW.Location = new System.Drawing.Point(788, 10);
            this.BTN_EXCELDW.Name = "BTN_EXCELDW";
            this.BTN_EXCELDW.Size = new System.Drawing.Size(91, 29);
            this.BTN_EXCELDW.TabIndex = 0;
            this.BTN_EXCELDW.Text = " 엑셀다운";
            this.BTN_EXCELDW.UseSelectable = true;
            this.BTN_EXCELDW.Click += new System.EventHandler(this.BTN_EXCEL_DOWN);
            // 
            // metroLabel3
            // 
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(12, 10);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 36);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 132;
            this.metroLabel3.Text = "조회";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseStyleColors = true;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // COM_PAGE
            // 
            this.COM_PAGE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COM_PAGE.BackColor = System.Drawing.SystemColors.Window;
            this.COM_PAGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_PAGE.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.COM_PAGE.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.COM_PAGE.FormatString = "N0";
            this.COM_PAGE.FormattingEnabled = true;
            this.COM_PAGE.IntegralHeight = false;
            this.COM_PAGE.ItemHeight = 17;
            this.COM_PAGE.Location = new System.Drawing.Point(705, 139);
            this.COM_PAGE.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.COM_PAGE.Name = "COM_PAGE";
            this.COM_PAGE.Size = new System.Drawing.Size(60, 25);
            this.COM_PAGE.TabIndex = 142;
            this.COM_PAGE.SelectedIndexChanged += new System.EventHandler(this.COM_PAGE_SelectedIndexChanged);
            // 
            // LBL_PAGE
            // 
            this.LBL_PAGE.AutoSize = true;
            this.LBL_PAGE.Location = new System.Drawing.Point(838, 143);
            this.LBL_PAGE.Name = "LBL_PAGE";
            this.LBL_PAGE.Size = new System.Drawing.Size(39, 19);
            this.LBL_PAGE.TabIndex = 143;
            this.LBL_PAGE.Text = "Page";
            // 
            // LBL
            // 
            this.LBL.AutoSize = true;
            this.LBL.Location = new System.Drawing.Point(768, 143);
            this.LBL.Name = "LBL";
            this.LBL.Size = new System.Drawing.Size(14, 19);
            this.LBL.TabIndex = 144;
            this.LBL.Text = "/";
            // 
            // LBL_TOTAL_PAGE
            // 
            this.LBL_TOTAL_PAGE.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.LBL_TOTAL_PAGE.Location = new System.Drawing.Point(788, 143);
            this.LBL_TOTAL_PAGE.Name = "LBL_TOTAL_PAGE";
            this.LBL_TOTAL_PAGE.Size = new System.Drawing.Size(44, 19);
            this.LBL_TOTAL_PAGE.TabIndex = 145;
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LBL_TOTAL_PAGE);
            this.Controls.Add(this.LBL);
            this.Controls.Add(this.LBL_PAGE);
            this.Controls.Add(this.COM_PAGE);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.TIL_1);
            this.Controls.Add(this.LAY_SEARCH);
            this.Controls.Add(this.GRD_SLIP);
            this.Controls.Add(this.BTN_SEARCH);
            this.Controls.Add(this.BTN_EXCELDW);
            this.DoubleBuffered = true;
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(900, 680);
            this.Load += new System.EventHandler(this.SearchPanel_Load);
            this.SizeChanged += new System.EventHandler(this.SearchPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.GRD_SLIP)).EndInit();
            this.LAY_SEARCH.ResumeLayout(false);
            this.LAY_SEARCH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LBL_REFUND_DATE;
        private MetroFramework.Controls.MetroDateTime TXT_REFUND_DATE_FROM;
        private MetroFramework.Controls.MetroTextBox TXT_BUY_SERIAL_NO;
        private MetroFramework.Controls.MetroLabel LBL_SLIP_NO;
        private MetroFramework.Controls.MetroGrid GRD_SLIP;
        private System.Windows.Forms.TableLayoutPanel LAY_SEARCH;
        private MetroFramework.Controls.MetroTile TIL_1;
        private MetroFramework.Controls.MetroButton BTN_SEARCH;
        private MetroFramework.Controls.MetroButton BTN_EXCELDW;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroDateTime TXT_REFUND_DATE_TO;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.ComboBox COM_PAGE;
        private MetroFramework.Controls.MetroLabel LBL_PAGE;
        private MetroFramework.Controls.MetroLabel LBL;
        private MetroFramework.Controls.MetroLabel LBL_TOTAL_PAGE;
    }
}
