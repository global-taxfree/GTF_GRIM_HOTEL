using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

using MetroFramework;
using MetroFramework.Forms;

using GTF_Passport;
using GTF_Printer;
using GTF_STFM.Util;
using Newtonsoft.Json.Linq;
using GTF_STFM.Tran;
using System.IO;

namespace GTF_STFM.Screen
{
    public partial class PreferencesPanel : UserControl
    {
        ControlManager m_CtlSizeManager = null;
        const long OPOS_SUCCESS = 0;
        const long OPOS_E_CLOSED = 101;
        const long OPOS_E_CLAIMED = 102;
        const long OPOS_E_NOTCLAIMED = 103;
        const long OPOS_E_NOSERVICE = 104;
        const long OPOS_E_DISABLED = 105;
        const long OPOS_E_ILLEGAL = 106;
        const long OPOS_E_NOHARDWARE = 107;
        const long OPOS_E_OFFLINE = 108;
        const long OPOS_E_NOEXIST = 109;
        const long OPOS_E_EXISTS = 110;
        const long OPOS_E_FAILURE = 111;
        const long OPOS_E_TIMEOUT = 112;
        const long OPOS_E_BUSY = 113;
        const long OPOS_E_EXTENDED = 114;
        const int PTR_S_RECEIPT = 2;

        Boolean m_bTMLID_CONFIRM = false;
        public PreferencesPanel(ILog Logger = null)
        {
            InitializeComponent();
            ////최초생성시 좌표, 크기 조정여부 등록함. 화면별로 Manager 를 가진다. 
            //m_CtlSizeManager = new ControlManager(this);
            ////횡이동
            //m_CtlSizeManager.addControlMove(BTN_SAVE, true, false, false, false);
            //m_CtlSizeManager.addControlMove(BTN_DOWNLOAD, true, false, false, false);
            //m_CtlSizeManager.addControlMove(BTN_HELP, true, false, false, false);
            //if (m_CtlSizeManager != null)
            //    m_CtlSizeManager.MoveControls();

       
        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void PreferencesPanel_Load(object sender, EventArgs e)
        {
            //ControlManager CtlSizeManager = new ControlManager(this);
            //CtlSizeManager.ChageLabel(this);
            //CtlSizeManager = null;
             TXT_TML_ID.Text = Constants.TML_ID ;

            //COM_PC_NO.SelectedIndex = (Constants.PC_NO - 1) < 0 ?  0 : (Constants.PC_NO - 1);
            //여권스캐너 설정 2019.08.30 스캐너 타입 +1하도록 수정 진행. 안할 경우, 설정한 스캐너 타입이 아닌, 바로 전 스캐너 타입으로 불러와 짐.
            COM_PASS_SCAN.SelectedIndex = (Constants.PASSPORT_TYPE + 1) < 0 ? 0 : (Constants.PASSPORT_TYPE + 1);

            COM_PRINTER_TYPE.SelectedIndex = Constants.PRINTER_SELECT_TYPE < 0 ? 0 : Constants.PRINTER_SELECT_TYPE;

            COM_SIGNPAD.SelectedIndex = Constants.SIGN_PAD_TYPE < 0 ? 0 : Constants.SIGN_PAD_TYPE;

            TXT_STANDARD_SELL_PRICE.Text = Constants.STANDARD_SELL_PRICE.ToString();
            TXT_SUITE_SELL_PRICE.Text = Constants.SUITE_SELL_PRICE.ToString();

            //프린터 설정
            COM_PRINTER.Items.Clear();
            PrinterSettings settings = new PrinterSettings();
            string strDeaultPrinter = "";
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                COM_PRINTER.Items.Add(printer);
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)   // 기본 설정 여부
                    strDeaultPrinter = printer;
            }
            
            if(Constants.PRINTER_TYPE != null && !string.Empty.Equals(Constants.PRINTER_TYPE.Trim()))
            {
                COM_PRINTER.SelectedItem = Constants.PRINTER_TYPE;
            }
            else if (!string.Empty.Equals(strDeaultPrinter))//미설정 시엔 기본프린터 설정
            {
                COM_PRINTER.SelectedItem = strDeaultPrinter;
            }

            //OPOS 프린터 설정
            COM_OPOS.SelectedItem = Constants.PRINTER_OPOS_TYPE;

            //SLIP TYPE 설정
            if (Constants.SLIP_TYPE == null || string.Empty.Equals(Constants.SLIP_TYPE))
            {
                COM_SLIP_TYPE.SelectedIndex = 0;
            }
            else
            {
                COM_SLIP_TYPE.SelectedItem = Constants.SLIP_TYPE;
            }
        }

        private void BTN_SCAN_TEST_Click(object sender, EventArgs e)
        {
            try
            {
                if(COM_PASS_SCAN.SelectedIndex <0)
                {
                    return;
                }
                setWaitCursor(true);

                GTF_PassportScanner passScan = GTF_PassportScanner.Instance(null, Constants.PATH_TEMP);
                
                int nRet = 0;
                nRet = passScan.open(COM_PASS_SCAN.SelectedIndex-1);
                //if ("GTF".Equals(COM_PASS_SCAN.SelectedItem))
                //{
                //    nRet = passScan.open(0);
                //}
                //else if ("OKPOS".Equals(COM_PASS_SCAN.SelectedItem))
                //{
                //    nRet = passScan.open(3);
                //}
                if (nRet > 0)
                {
                    Constants.PASSPORT_SCAN_OPEN = true;
                    //COM_PASS_SCAN.Enabled = false; 
                    int strmrz = passScan.scan(30);
                    if (strmrz > 0)
                    {
                        string strTempData = passScan.getMRZ1() + "\n" + passScan.getMRZ2();
                        MetroMessageBox.Show(this, strTempData /*+ "\n"+passScan.GetPassportFirstName()+"\n"+ passScan.GetPassportLastName() +"\n"+ passScan.GetPassportName()*/
                            , "Passport Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("PASSPORT_REMOVE"), "Passport Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    passScan.close();
                }
                else
                {
                    MetroMessageBox.Show(this, Constants.getMessage("PASSPORT_ERROR"), "Passport Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                setWaitCursor(false);
                BTN_SCAN_TEST.Focus();
            }
        }

        private void BTN_TID_CONFIRM_Click(object sender, EventArgs e)
        {

        }

        private void BTN_PRINT_TEST_Click(object sender, EventArgs e)
        {
            try
            {
                setWaitCursor(true);
                if (COM_PRINTER.SelectedItem == null || string.Empty.Equals(COM_PRINTER.SelectedItem.ToString().Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("PRINTER_NOTHING"), "Print Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    GTF_ReceiptPrinter printer = new GTF_ReceiptPrinter(null);
                    printer.setPrinter(COM_PRINTER.SelectedItem.ToString());
                    printer.PrintSlip_Test();
                }
            }
            finally
            {
                setWaitCursor(false);
                BTN_PRINT_TEST.Focus();
            }
            /*
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = COM_PRINTER.SelectedItem.ToString();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.Print();
            */
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


        private void axOPOSPOSPrinter1_Enter(object sender, EventArgs e)
        {

        }

        private void PreferencesPanel_SizeChanged(object sender, EventArgs e)
        {
            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();
            this.Refresh();
        }

        private void BTN_OPOS_TEST_Click(object sender, EventArgs e)
        {
            try
            {
                setWaitCursor(true);
                if(COM_OPOS.SelectedItem != null && !string.Empty.Equals(COM_OPOS.SelectedItem.ToString()))
                {
                    GTF_ReceiptPrinter printer = new GTF_ReceiptPrinter(null);
                    printer.PrintSlip_sg(COM_OPOS.SelectedItem.ToString());
                }
            }
            finally
            {
                setWaitCursor(false);
                BTN_OPOS_TEST.Focus();
            }
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                //네트워크 체크
                if (!Constants.ONLINE_STATUS)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_NETWORK"), "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                setWaitCursor(true);

                if(TXT_TML_ID.Text == null || string.Empty.Equals(TXT_TML_ID.Text.ToString()) || TXT_TML_ID.Text.ToString().Length < TXT_TML_ID.MaxLength)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("TXT_TML_ID"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TXT_TML_ID.Focus();
                    return;
                }

                if(!m_bTMLID_CONFIRM)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("TMLID_ALERT"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TXT_TML_ID.Focus();
                    return;
                }
                if(COM_PRINTER_TYPE.SelectedItem == null || COM_PRINTER_TYPE.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("COM_PRINTER_TYPE"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    COM_PRINTER.Focus();
                    return;
                }

                if( COM_PRINTER_TYPE.SelectedIndex== 0)
                {
                    if (COM_PRINTER.SelectedItem == null || COM_PRINTER.SelectedIndex < 0)
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("COM_PRINTER"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        COM_PRINTER.Focus();
                        return;
                    }
                }
                else if (COM_PRINTER_TYPE.SelectedIndex == 1)
                {
                    if (COM_OPOS.SelectedItem == null || COM_OPOS.SelectedIndex < 0)
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("COM_OPOS"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        COM_PRINTER.Focus();
                        return;
                    }
                }
                /*
                if(COM_PASS_SCAN.SelectedIndex <0)
                {
                    MetroMessageBox.Show(this, "여권스캐너를 선택해 주세요.", "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    COM_PASS_SCAN.Focus();
                    return;
                }
                if (COM_PRINTER.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, "저장이 완료되었습니다..", "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (COM_OPOS.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, "저장이 완료되었습니다..", "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
                /*
                if (COM_SLIP_TYPE.SelectedIndex < 0)
                {
                    MetroMessageBox.Show(this, Constants.CONF_MANAGER.getCustomValue("Message", "COM_SLIP_TYPE"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    COM_SLIP_TYPE.Focus();
                    setWaitCursor(false);
                    return;
                }
                */

                //Constants 저장

                //Constants.PC_NO = Int32.Parse(COM_PC_NO.Text.ToString());
                Constants.TML_ID= TXT_TML_ID.Text.ToString();

                JObject sendObj = new JObject();
                sendObj.Add("tml_id", Constants.TML_ID);

                Transaction tran = new Transaction();
                JArray arrRet = tran.sendServer_arr(sendObj.ToString(), tran.url_TmlInfo, 60, false);
                if (arrRet != null && arrRet.Count > 0)
                {
                    Parent.Parent.Controls["TIL_SHOP_NAME"].Text = arrRet[0]["shop_name"].ToString();
                    Constants.SHOP_NAME = arrRet[0]["shop_name"].ToString();
                }

                Constants.PASSPORT_TYPE = COM_PASS_SCAN.SelectedIndex-1;

                Constants.PRINTER_SELECT_TYPE = COM_PRINTER_TYPE.SelectedIndex;
                Constants.PRINTER_TYPE = COM_PRINTER.SelectedItem.ToString();
                Constants.PRINTER_OPOS_TYPE = COM_OPOS.SelectedItem == null? "" :COM_OPOS.SelectedItem.ToString();
                //Constants.SLIP_TYPE = COM_SLIP_TYPE.SelectedItem.ToString();
                System.Diagnostics.Debug.WriteLine("TXT_STANDARD_SELL_PRICE : " + TXT_STANDARD_SELL_PRICE);
                System.Diagnostics.Debug.WriteLine("TXT_SUITE_SELL_PRICE : " + TXT_SUITE_SELL_PRICE.Text.ToString());
                //Constants.STANDARD_SELL_PRICE = Int32.Parse(TXT_STANDARD_SELL_PRICE.Text.ToString());   //2019.10.31 추가
                Constants.STANDARD_SELL_PRICE = Int32.Parse(TXT_STANDARD_SELL_PRICE.Text.ToString().Trim() == "" ? "0" : TXT_STANDARD_SELL_PRICE.Text.ToString());   //2019.10.31 추가
                //Constants.SUITE_SELL_PRICE = Int32.Parse(TXT_SUITE_SELL_PRICE.Text.ToString());   //2019.10.31 추가
                Constants.SUITE_SELL_PRICE = Int32.Parse(TXT_SUITE_SELL_PRICE.Text.ToString().Trim() == "" ? "0" : TXT_SUITE_SELL_PRICE.Text.ToString());   //2019.10.31 추가
                Constants.SIGN_PAD_TYPE = COM_SIGNPAD.SelectedIndex;

                //LOCAL DB 저장
                Constants.LDB_MANAGER.updateConfigData("TML_ID", "" + Constants.TML_ID, "터미널번호");
                Constants.LDB_MANAGER.updateConfigData("PASSPORT_TYPE", "" + Constants.PASSPORT_TYPE, "여권스캐너");
                Constants.LDB_MANAGER.updateConfigData("PRINTER_SELECT_TYPE", "" + Constants.PRINTER_SELECT_TYPE, "출력프린터종류");
                Constants.LDB_MANAGER.updateConfigData("PRINTER_TYPE", Constants.PRINTER_TYPE, "일반프린터");
                Constants.LDB_MANAGER.updateConfigData("PRINTER_OPOS_TYPE", Constants.PRINTER_OPOS_TYPE, "영수증프린터");

                Constants.LDB_MANAGER.updateConfigData("SIGN_PAD_TYPE", Constants.SIGN_PAD_TYPE + "", "사인패드종류");

                Constants.LDB_MANAGER.updateConfigData("SHOP_NAME", Constants.SHOP_NAME + "", "매장 명");
                Constants.LDB_MANAGER.updateConfigData("STANDARD_SELL_PRICE", Constants.STANDARD_SELL_PRICE + "", "일반룸가격");  //2019.10.31 추가
                Constants.LDB_MANAGER.updateConfigData("SUITE_SELL_PRICE", Constants.SUITE_SELL_PRICE + "", "스위트룸가격");  //2019.10.31 추가


                //Constants.LDB_MANAGER.updateConfigData("SLIP_TYPE", "" + Constants.SLIP_TYPE, "전표타입");
                //MetroMessageBox.Show(this, "저장 완료되었습니다.", "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetroMessageBox.Show(this, Constants.getMessage("CONFIG_SAVE_SUCCESS"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                setWaitCursor(false);
            }
                
        }

        private void COM_PRINTER_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(COM_PRINTER_TYPE.SelectedIndex == 0)
            {
                COM_PRINTER.Visible = true;
                BTN_PRINT_TEST.Visible = true;

                COM_OPOS.Visible = false;
                BTN_OPOS_TEST.Visible = false;
            }else if(COM_PRINTER_TYPE.SelectedIndex == 1)
            {
                COM_PRINTER.Visible = false;
                BTN_PRINT_TEST.Visible = false;

                COM_OPOS.Visible = true;
                BTN_OPOS_TEST.Visible = true;
            }
        }

        //텍스트 내용 변경 시 플래그 해제
        private void TXT_TML_ID_TextChanged(object sender, EventArgs e)
        {
            m_bTMLID_CONFIRM = false;
        }

        private void TXT_TMLID_CONFIRM_Click(object sender, EventArgs e)
        {
            //네트워크 체크
            if (!Constants.ONLINE_STATUS)
            {
                MetroMessageBox.Show(this, Constants.getMessage("ERROR_NETWORK"), "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JObject sendObj = new JObject();
            sendObj.Add("tml_id", TXT_TML_ID.Text);

            Transaction tran = new Transaction();
            JArray arrRet = tran.sendServer_arr(sendObj.ToString(), tran.url_TmlInfo, 60, false);
            if (arrRet != null && arrRet.Count > 0)
            {
                
                MetroMessageBox.Show(this, "정상 조회 되었습니다."+Environment.NewLine+"매장명:"+arrRet[0]["shop_name"].ToString() , "Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_bTMLID_CONFIRM = true;
            }
            else
            {
                m_bTMLID_CONFIRM = false;
                MetroMessageBox.Show(this, Constants.getMessage("TMLID_ERROR"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TXT_TML_ID.Focus();
            }
        }

        private void BTN_SIGN_TEST_Click(object sender, EventArgs e)
        {
            if (COM_SIGNPAD.SelectedIndex == 0)
            {
                MetroMessageBox.Show(this, Constants.getMessage("SIGNPAD_NOTHING"), "Config Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (COM_SIGNPAD.SelectedIndex == 1)
            {
                string filePath = Directory.GetCurrentDirectory() + "../Image/signtest.bmp";
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                Utils gtfUtil = new Utils();
                int input_amt = 5000;          //결제 금액 - 싸인패드에 표시
                int input_sign_size = 0;         //싸인 크기조절 1 -> 128*64  0- > 120*32
                int auto_flag = 0;            //싸인창 자동 닫힘 flag
                StringBuilder input_sign_path = new StringBuilder(4096);
                input_sign_path.Append("../Image"); //이미지 저장 경로
                StringBuilder input_sign_name = new StringBuilder(1024);   //이미지 제목
                input_sign_name.Append("signtest");
                StringBuilder output_msg = new StringBuilder(1024);

                int resultCode = -1;
                for (int com = 1; com <= 30; com++)
                {
                    resultCode = gtfUtil.gtf_svkGetSign(0, com, input_amt, auto_flag, input_sign_size, input_sign_path.ToString(), input_sign_name.ToString(), output_msg);

                    if (!(resultCode == -41 || resultCode == -44 || resultCode == -45))
                    {
                        Console.WriteLine("result:" + resultCode);
                        break;
                    }
                }
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
