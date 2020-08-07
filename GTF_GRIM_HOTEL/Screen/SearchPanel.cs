using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using log4net;
using Newtonsoft.Json.Linq;
using GTF_Printer;
using GTF_STFM.Util;
using GTF_STFM.Tran;
using Excel = Microsoft.Office.Interop.Excel;
namespace GTF_STFM.Screen
{
    public partial class SearchPanel : UserControl
    {
        ControlManager m_CtlSizeManager = null;
        ILog m_Logger = null;
        string m_strLastSearchDate = "";
        long m_nPage = 20;
        int ExcelCount = 0;
        string strSearchDate_from = "";
        string strSearchDate_to = "";
        public SearchPanel(ILog Logger = null)
        {
            m_Logger = Logger;
            InitializeComponent();
            //최초생성시 좌표, 크기 조정여부 등록함. 화면별로 Manager 를 가진다. 
            m_CtlSizeManager = new ControlManager(this);
            //횡늘림
            m_CtlSizeManager.addControlMove(TIL_1, false, false, true, false);
            m_CtlSizeManager.addControlMove(LAY_SEARCH, false, false, true, false);

            //종횡 늘림
            m_CtlSizeManager.addControlMove(GRD_SLIP, false, false, true, true);

            //횡이동
            m_CtlSizeManager.addControlMove(BTN_SEARCH, true, false, false, false);


            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();
        }


        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                if (!Constants.OPEN_DATE.Equals(m_strLastSearchDate))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PRINT_DATE"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                string strSlipNo = GRD_SLIP[2, e.RowIndex].Value.ToString();
                string printCnt = (GRD_SLIP[12, e.RowIndex].Value == null || string.Empty.Equals(GRD_SLIP[12, e.RowIndex].Value.ToString().Trim()))
                    ? "0" : GRD_SLIP[12, e.RowIndex].Value.ToString();
                Transaction tran = new Transaction();
                PrintSlipLangForm langForm = new PrintSlipLangForm(m_Logger);
                langForm.ShowDialog(this);
                string strSlipLang = string.Empty;
                if (langForm.m_SelectLang != null && !string.Empty.Equals(langForm.m_SelectLang.Trim()))
                {
                    strSlipLang = langForm.m_SelectLang;
                }
                else
                {
                    MetroMessageBox.Show(this, "Select Lang.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (langForm.DialogResult != DialogResult.OK)
                {
                    return;
                }
                JObject jsonDocs = tran.GetPrintDocs(strSlipNo);
                if (jsonDocs != null)//출력
                {
                    string docid, retailer, goods, tourist, adsinfo, preview = string.Empty;
                    docid = jsonDocs["DOCID"].ToString();
                    retailer = jsonDocs["RETAILER"].ToString();
                    goods = jsonDocs["GOODS"].ToString();
                    tourist = jsonDocs["TOURIST"].ToString();
                    adsinfo = jsonDocs["ADSINFO"].ToString();
                    preview = jsonDocs["PREVIEW"].ToString();

                    docid = strSlipLang + docid.Substring(2);
                    try
                    {
                        GTF_ReceiptPrinter printer = new GTF_ReceiptPrinter(m_Logger);
                        printer.setPrinter(Constants.PRINTER_TYPE);
#if DEBUG
                        printer.PrintSlip_ja(docid.Replace("[REPUBLISH]", "1"), retailer, goods, tourist, adsinfo);
#else
                        printer.PrintSlip_ja(docid.Replace("[REPUBLISH]", "1"), retailer, goods, tourist, adsinfo, "Y".Equals(preview));
#endif
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error(ex.StackTrace);
                    }

                    JObject tempObj = new JObject();
                    JObject tempObj2 = new JObject();
                    tempObj.Add("SLIP_NO", strSlipNo);
                    tempObj2.Add(Constants.PRINT_CNT, (Int32.Parse(printCnt) + 1).ToString());

                    if (GRD_SLIP[13, e.RowIndex].Value == null || !"02".Equals(GRD_SLIP[13, e.RowIndex].Value.ToString()))
                    {
                        MessageForm msgForm = new MessageForm(Constants.getMessage("SLIP_CONFIRM"), null, MessageBoxButtons.YesNo);
                        msgForm.ShowDialog(this);
                        if (msgForm.DialogResult == DialogResult.Yes)
                        {
                            string refunddt = System.DateTime.Now.ToString("yy'/'MM'/'dd HH:mm:ss");
                            tempObj2.Add("SLIP_STATUS_CODE", "02");
                            tempObj2.Add("REFUNDDT", refunddt);
                            refunddt = "";
                        }
                    }

                    tran.UpdateSlip(tempObj, tempObj2);
                    tempObj.RemoveAll();
                    tempObj2.RemoveAll();
                    tempObj = null;
                    tempObj2 = null;
                    BTN_SEARCH_Click(null, null);
                }
                else
                {
                    MetroMessageBox.Show(this, "Print Error", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void SearchPanel_Load(object sender, EventArgs e)
        {
            //ControlManager CtlSizeManager = new ControlManager(this);
            //CtlSizeManager.ChageLabel(this);
            //CtlSizeManager = null;
        }

        private void SearchPanel_SizeChanged(object sender, EventArgs e)
        {
            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();
            this.Refresh();
        }

        private void GRD_SLIP_Scroll(object sender, ScrollEventArgs e)
        {
            int firstDisplayed = GRD_SLIP.FirstDisplayedScrollingRowIndex;
            int displayed = GRD_SLIP.DisplayedRowCount(true);
            int lastVisible = (firstDisplayed + displayed) - 1;
            int lastIndex = GRD_SLIP.RowCount - 1;

            if (lastVisible == lastIndex)//마지막행으로 스크롤되면 자동으로 추가 조회 하도록 하는 기능을..
            {

            }
        }


        private void BTN_QR_SCAN_Click(object sender, EventArgs e)
        {
            TXT_BUY_SERIAL_NO.Focus();
        }

        private void BTN_SEARCH_Click(object sender, EventArgs e)
        {
            serchList(1);
        }

        private void BTN_EXCEL_DOWN(object sender, EventArgs e)
        {
            downExcel(1);
        }
        //엑셀 다운
        private void downExcel(int nSelect)
        {
            try
            {
                //엑셀
                Excel.Application ExcelApp = null;
                Excel.Workbook ExcelBook = null;
                Excel.Worksheet ExcelSheet = null;
                Excel.Range rangeColor = null;
                Excel.Range rangeBorder = null;
                //Excel.Range rangeFilter = null;
                Excel.Range rangeDate = null;
                Excel.Range rangeText = null;
                try
                {
                    ExcelApp = new Excel.Application();
                    ExcelApp.Visible = false;
                    ExcelApp.DisplayAlerts = false;
                    ExcelApp.Interactive = false;

                }
                catch (Exception ex)
                {
                    m_Logger.Error(ex.Message + "\n" + ex.StackTrace);
                        //엑셀이 정상적으로 설치되지 않았습니다.
                        MessageBox.Show("엑셀이 정상적으로 설치되지 않았습니다.", "Message");
                        return;
                }
                if (ExcelCount == 0)
                {
                    //다운받을 목록이 없습니다.
                    MessageBox.Show("다운받을 목록이 없습니다.", "Message");
                }
                else
                {
                    ExcelBook = ExcelApp.Workbooks.Add(Type.Missing);
                    ExcelSheet = ExcelBook.ActiveSheet;
                    ExcelSheet.Name = "조회목록";
                    //1열
                    ExcelSheet.Cells[1, 1] = "순번";
                    ExcelSheet.Cells[1, 2] = "구매일련번호";
                    ExcelSheet.Cells[1, 3] = "발행일";
                    ExcelSheet.Cells[1, 4] = "공급가격";
                    ExcelSheet.Cells[1, 5] = "세금";
                    ExcelSheet.Cells[1, 6] = "환급금";
                    ExcelSheet.Cells[1, 7] = "전표상태";
                    for (int i = 0; i < ExcelCount; i++)
                    {
                        //2열
                        ExcelSheet.Cells[i + 2, 1] = (i + 1).ToString();
                        ExcelSheet.Cells[i + 2, 2] = GRD_SLIP[1, i].Value;
                        ExcelSheet.Cells[i + 2, 3] = GRD_SLIP[2, i].Value;
                        ExcelSheet.Cells[i + 2, 4] = GRD_SLIP[3, i].Value;
                        ExcelSheet.Cells[i + 2, 5] = GRD_SLIP[4, i].Value;
                        ExcelSheet.Cells[i + 2, 6] = GRD_SLIP[5, i].Value;
                        ExcelSheet.Cells[i + 2, 7] = GRD_SLIP[6, i].Value;
                    }
                    //셀 색상
                    rangeColor = ExcelSheet.get_Range("A1","G1");
                    rangeColor.Interior.Color = ColorTranslator.ToOle(Color.Wheat);
                    //셀 테두리
                    rangeBorder = ExcelSheet.get_Range("A1", "G" + (ExcelCount + 1) + "");
                    rangeBorder.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //자동필터
                    //rangeFilter = ExcelSheet.get_Range("A1", "G1");
                    //rangeFilter.AutoFilter(7, "환급전", Excel.XlAutoFilterOperator.xlAnd, true);
                    //셀형식
                    rangeDate = ExcelSheet.get_Range("C1", "C" + (ExcelCount + 1) + "");
                    rangeDate.NumberFormat = "yyyy-mm-dd";
                    //컬럼 텍스트형식
                    rangeText = ExcelSheet.get_Range("B1", "B" + (ExcelCount + 1) + "");
                    rangeText.NumberFormat = "0";
                    rangeText.ColumnWidth = 23;
                    //엑셀 저장
                    SaveFileDialog dialog = new SaveFileDialog();
                    String fileName = "";
                    dialog.FileName = strSearchDate_from + "~" + strSearchDate_to + ".xlsx";
                    dialog.InitialDirectory = @"C:";
                    dialog.Title = "Excel 저장 위치 지정";
                    dialog.DefaultExt = "xlsx";
                    dialog.Filter = "Xlsx files(*.xlsx)|*.xlsx";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        ExcelBook.SaveAs(fileName);
                        //ExcelBook.SaveAs("C:\\" + strSearchDate_from + "~" + strSearchDate_to + ".xlsx");
                        MessageBox.Show("엑셀파일이 다운로드 되었습니다.", "Message");
                    }
                    ExcelBook.Close();
                    ExcelApp.Quit();
                }
                }
            catch (Exception ex)
            {
                m_Logger.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }
        private void serchList(int nSelect)
        {
            try
            {
                //네트워크 체크
                if (!Constants.ONLINE_STATUS)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_NETWORK"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TXT_REFUND_DATE_FROM.Value > TXT_REFUND_DATE_TO.Value)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("DATE_ERROR"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TimeSpan timeDiff = TXT_REFUND_DATE_TO.Value - TXT_REFUND_DATE_FROM.Value;
                if (timeDiff.Days > 31)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("DATE_OVER"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ExcelCount = 0;//엑셀 다운로드목록 초기화
                GRD_SLIP.Rows.Clear();
                Transaction tran = new Transaction();//거래내용 조회
                strSearchDate_from = TXT_REFUND_DATE_FROM.Value.ToString("yyyyMMdd");
                strSearchDate_to = TXT_REFUND_DATE_TO.Value.ToString("yyyyMMdd");

                JObject sendObj = new JObject();
                sendObj.Add("from_date", strSearchDate_from);
                sendObj.Add("to_date", strSearchDate_to);
                sendObj.Add("tml_id", Constants.TML_ID);
                sendObj.Add("buy_serial_no", TXT_BUY_SERIAL_NO.Text);
                sendObj.Add("page", nSelect + "");

                JObject objRet = tran.sendServer_object(sendObj.ToString(), tran.url_Slip_SearchListCnt, 60, false);
                long nTotalCnt = 0;
                if (objRet != null && "S".Equals(objRet["result"].ToString()) && objRet["totalcount"] != null
                   && Int64.TryParse(objRet["totalcount"].ToString(), out nTotalCnt))
                {
                    nTotalCnt = Int64.Parse(objRet["totalcount"].ToString());
                }

                if (nTotalCnt == 0)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("NO_SERACH_DATA"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    JArray arrRet = tran.sendServer_arr(sendObj.ToString(), tran.url_Slip_SearchList, 60, false);
                    if (arrRet == null || arrRet.Count == 0)
                    {
                        LBL_TOTAL_PAGE.Text = "0";
                        MetroMessageBox.Show(this, Constants.getMessage("NO_SERACH_DATA"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        long nTotalPage = (nTotalCnt / m_nPage);
                        if (nTotalCnt % m_nPage != 0)
                        {
                            nTotalPage++;
                        }

                        replacePageCount(nSelect - 1, nTotalPage);
                        LBL_TOTAL_PAGE.Text = nTotalPage + "";

                        m_strLastSearchDate = strSearchDate_to;
                        GRD_SLIP.Rows.Add(arrRet.Count);
                        //엑셀다운 카운트
                        ExcelCount = arrRet.Count;
                        for (int i = 0; i < arrRet.Count; i++)
                        {
                            JObject tempObj = (JObject)arrRet[i];
                            GRD_SLIP[0, i].Value = (i + 1).ToString();
                            GRD_SLIP[1, i].Value = tempObj["buy_serial_no"].ToString();
                            GRD_SLIP[2, i].Value = tempObj["sell_date"].ToString().Substring(0, 4) + "-" + tempObj["sell_date"].ToString().Substring(4, 2) + "-" + tempObj["sell_date"].ToString().Substring(6, 2);
                            GRD_SLIP[3, i].Value = Int64.Parse(tempObj["sales_amount"].ToString());
                            GRD_SLIP[4, i].Value = Int64.Parse(tempObj["tax_amount"].ToString());
                            GRD_SLIP[5, i].Value = Int64.Parse(tempObj["refund_amount"].ToString());


                            //arrbuy_serial_no[i] = GRD_SLIP[1, i].Value;
                            //arrsell_date[i] = GRD_SLIP[2, i].Value;
                            //arrsales_amount[i] = Int64.Parse(tempObj["sales_amount"].ToString());
                            //arrtax_amount[i] = Int64.Parse(tempObj["tax_amount"].ToString());
                            //arrrefund_amount[i] = Int64.Parse(tempObj["refund_amount"].ToString());

                            if ("01".Equals(tempObj["slip_status_code"].ToString()))
                            {
                                GRD_SLIP[6, i].Value = "환급전";
                                //arrslip_status_code[i] = "환급전";
                            }
                            else if ("02".Equals(tempObj["slip_status_code"].ToString()))
                            {
                                GRD_SLIP[6, i].Value = "환급완료";
                                //arrslip_status_code[i] = "환급완료";
                            }
                            else if ("03".Equals(tempObj["slip_status_code"].ToString()))
                            {
                                GRD_SLIP[6, i].Value = "취소";
                               // arrslip_status_code[i] = "취소";
                            }
                            tempObj = null;



                        }


                    }
                }
                tran = null;
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void GRD_SLIP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //팝업호출
            if (e.RowIndex >= 0 && e.ColumnIndex != 12)
            {
                try
                {
                    //네트워크 체크
                    if (!Constants.ONLINE_STATUS)
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("ERROR_NETWORK"), "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    setWaitCursor(true);
                    string strBuySerialNo = GRD_SLIP[1, e.RowIndex].Value.ToString(); //구매일련번호
                    SlipDetailInfo slipForm = new SlipDetailInfo(strBuySerialNo, m_Logger);
                    slipForm.ShowDialog(this);
                    slipForm = null;
                }
                catch (Exception ex)
                {
                    m_Logger.Error(ex.StackTrace);
                }
                finally
                {
                    setWaitCursor(false);
                }
            }
        }

        private void setWaitCursor(Boolean bWait)
        {
            if (bWait)
            {
                Cursor.Current = Cursors.WaitCursor;
                this.UseWaitCursor = true;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                this.UseWaitCursor = false;
            }
        }


        private void replacePageCount(int nSelectIdx, long nTotalPage)
        {
            COM_PAGE.SelectedIndexChanged -= COM_PAGE_SelectedIndexChanged;

            COM_PAGE.Items.Clear();
            Dictionary<string, string> page_list = new Dictionary<string, string>();
            for (int i = 1; i <= nTotalPage; i++)
            {
                COM_PAGE.Items.Add(i + "");
            }
            COM_PAGE.SelectedIndex = nSelectIdx;
            COM_PAGE.SelectedIndexChanged += COM_PAGE_SelectedIndexChanged;
        }

        private void COM_PAGE_SelectedIndexChanged(object sender, EventArgs e)
        {
            serchList(COM_PAGE.SelectedIndex + 1);
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
