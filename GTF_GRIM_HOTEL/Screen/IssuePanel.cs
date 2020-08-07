using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using Newtonsoft.Json.Linq;
using log4net;
using GTF_Comm;
using GTF_Passport;
using GTF_STFM.Tran;
using GTF_STFM.Util;
using GTF_Printer;
using System.IO;
using System.Globalization;

namespace GTF_STFM.Screen
{
    public partial class IssuePanel : UserControl
    {
        ControlManager m_CtlSizeManager = null;
        GTF_PassportScanner m_passScan = null;

        JArray ArrNationalList = null;
        JArray m_ArrNationalList
        {
            get
            {
                if (ArrNationalList == null || ArrNationalList.Count == 0)
                {

                    ArrNationalList = new JArray();
                    //JObject jsonObj = new JObject();

                    //jsonObj.Add("CHN", "CHINA");
                    //ArrNationalList.Add(jsonObj);
                    //JObject jsonObj2 = new JObject();

                    //jsonObj2.Add("TWN", "TIWAN");
                    //ArrNationalList.Add(jsonObj2);

                    Transaction tran = new Transaction();
                    JArray tenoObj = tran.sendServer_arr("", tran.url_CountryList, 60, false);
                    if(tenoObj != null && tenoObj.Count>0)
                    {
                        ArrNationalList = tenoObj;
                    }
                }
                return ArrNationalList;
            }
            set
            {
                ArrNationalList = value;
            }
        }
        ILog m_Logger = null;

        public IssuePanel(ILog Logger = null)
        {
            m_Logger = Logger;
            InitializeComponent();
            //최초생성시 좌표, 크기 조정여부 등록함. 화면별로 Manager 를 가진다. 
            m_CtlSizeManager = new ControlManager(this);

            //횡좌표이동
            m_CtlSizeManager.addControlMove(BTN_SCAN, true, false, false, false);
            m_CtlSizeManager.addControlMove(BTN_PASSPORT_MANUAL, true, false, false, false);
            //m_CtlSizeManager.addControlMove(BTN_SUBMIT, true, false, false, false);
            m_CtlSizeManager.addControlMove(BTN_CLEAR, true, false, false, false);
            //m_CtlSizeManager.addControlMove(BTN_ITEM_ADD, true, false, false, false);

            //종횡좌표이동
            m_CtlSizeManager.addControlMove(BTN_SUBMIT, true, true, false, false);

            //횡늘림
            m_CtlSizeManager.addControlMove(LAY_REFUND, false, false, true, false);
            m_CtlSizeManager.addControlMove(TIL_1, false, false, true, false);
            m_CtlSizeManager.addControlMove(LAY_PASSPORT, false, false, true, false);
            m_CtlSizeManager.addControlMove(TIL_2, false, false, true, false);

            m_CtlSizeManager.addControlMove(TIL_3, false, false, true, false);
            //m_CtlSizeManager.addControlMove(LAY_AMOUNT, false, false, true, false);

            //종횡 늘림
            //m_CtlSizeManager.addControlMove(GRD_ITEMS, false, false, true, true);

            //화면 디스크립트 변경
            //m_CtlSizeManager.ChageLabel(this);

            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();

            init();
        }


        public Boolean init()
        {
            Boolean bRet = true;

            try {
                //초기 Load 시 국적 조회 
                m_passScan = GTF_PassportScanner.Instance(null, Constants.PATH_TEMP);
                Console.WriteLine("국적 카운트:" + m_ArrNationalList.Count());
            }catch(Exception e)
            {
                bRet = false;
            }
            return bRet;
        }

        private void IssuePanel_Load(object sender, EventArgs e)
        {

            //metroDateTime1.Format = DateTimePickerFormat.Custom;
            //metroDateTime1.CustomFormat = "MM/dd/yyyy";


            //COM_REFUND_TYPE.Items.Clear();

            for (int i = 0; i < 31; i++)
            {
                COM_STD_NIGHT.Items.Add(i + "");
                COM_SUT_NIGHT.Items.Add(i+ "");
            }
            COM_STD_NIGHT.SelectedIndex = 0;
            COM_SUT_NIGHT.SelectedIndex = 0;

            /*
            COM_REFUND_TYPE.Items.Add(new Utils.ComboItem("01", Constants.getScreenText("COMBO_ITEM_CASH")));
            COM_REFUND_TYPE.Items.Add(new Utils.ComboItem("04", Constants.getScreenText("COMBO_ITEM_CARD")));
            COM_REFUND_TYPE.Items.Add(new Utils.ComboItem("06", Constants.getScreenText("COMBO_ITEM_QQ")));
            */
            COM_REFUND_TYPE.SelectedIndex = 0; // 사후환급 고정

            COM_PAYMENT.SelectedIndex = 0; //2018.02.20 현금결제 초기값
            Dictionary<string, string> gender_list = new Dictionary<string, string>();
            gender_list.Add("M", "M");
            gender_list.Add("F", "F");
            COM_PASSPORT_SEX.Items.Clear();
            COM_PASSPORT_SEX.DataSource = new BindingSource(gender_list, null);
            COM_PASSPORT_SEX.DisplayMember = "Value";
            COM_PASSPORT_SEX.ValueMember = "Key";
            COM_PASSPORT_SEX.SelectedIndex = 0;

            COM_PASSPORT_SEX.DropDownStyle = ComboBoxStyle.Simple;

            ;
        }

        private void BTN_SCAN_Click(object sender, EventArgs e)
        {
            try
            {
                if (Constants.PASSPORT_TYPE < 0)//여권스캐너 미 선택시 경고창
                {
                    MetroMessageBox.Show(this, Constants.getMessage("PASSPORT_NOTHING"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Wait 커서 상태면 return 처리
                //if (Cursor.Current == Cursors.WaitCursor)
                if (this.UseWaitCursor)
                    return;

                setWaitCursor(true);
                if (m_passScan.open(Constants.PASSPORT_TYPE) > 0)
                {
                    int strmrz = m_passScan.scan(7);
                    if (strmrz > 0)
                    {
                        //공용
                        TXT_PASSPORT_NAME.Text = m_passScan.GetPassportName();
                        TXT_PASSPORT_NO.Text = m_passScan.GetPassportNo();
                        TXT_PASSPORT_NAT.Text = m_passScan.GetNationality();
                        //TXT_PASSPORT_NAT_NAME.Text = this.searchNatonalityName(m_passScan.GetNationality());
                        COM_PASSPORT_SEX.Text = m_passScan.GetSex();
                        COM_PASSPORT_SEX.SelectedValue = m_passScan.GetSex();

                        Utils gtfUtil = new Utils();
                        string strBirth = gtfUtil.getFullDate(m_passScan.GetBirthDate());
                        strBirth = strBirth.Substring(0, 4) + "-" + strBirth.Substring(4, 2) + "-" + strBirth.Substring(6, 2);
                        //string strExp = gtfUtil.getFullDate(m_passScan.GetExpireDate());
                        string strExp = "20" + m_passScan.GetExpireDate();
                        strExp = strExp.Substring(0, 4) + "-" + strExp.Substring(4, 2) + "-" + strExp.Substring(6, 2);
                        //TXT_PASSPORT_BIRTH.Text = gtfUtil.getFullDate(m_passScan.GetBirthDate());
                        //TXT_PASSPORT_EXP.Text = gtfUtil.getFullDate(m_passScan.GetExpireDate());

                        TXT_PASSPORT_BIRTH.Text = strBirth;
                        TXT_PASSPORT_EXP.Text = strExp;

                    }
                    else
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("PASSPORT_REMOVE"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            finally
            {
                setWaitCursor(false);
            }
        }

        private void BTN_SUBMIT_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean bRet = false;
                //처리중에 이중 입력 방지
                if (this.UseWaitCursor)
                    return;
                setWaitCursor(true);
                Utils util = new Utils();
                Transaction tran = new Transaction();
                if (Constants.PRINTER_TYPE == null || string.Empty.Equals(Constants.PRINTER_TYPE.Trim()))
                {

                    MetroMessageBox.Show(this, Constants.getMessage("PASSPORT_NOTHING"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    setWaitCursor(false);
                    BTN_SUBMIT.Focus();
                    return;
                }
                //정합성 체크. 여권정보 없어도 출력 할 수 있게끔..
                if (!validationCheck(false, true))
                {
                    setWaitCursor(false);
                    BTN_SUBMIT.Focus();
                    return;
                }

                long nCalTax = Int64.Parse(TXT_SALES_AMT.Text.ToString().Replace(",", "")) / 11;
                long nViewTax = Int64.Parse(TXT_TAX_AMT.Text.ToString().Replace(",", "")) ;
                //예상새액이 계산 세액보다 5% 이상 차이가 있으면 오류 확인 팝업 호출
                Boolean bDiff =( Math.Abs(nCalTax - nViewTax) * 100 / nCalTax ) >= 5.0 ? true : false;
                DialogResult dRet;
                if (bDiff)
                {
                    dRet = MetroMessageBox.Show(this, Constants.getMessage("TAX_CONFIRM")
                        +"\n● 예상 세금액:"+ string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nCalTax).Replace("$", "")
                        + "\n● 입력 세금액:" + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nViewTax).Replace("$", "")
                        , "Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dRet != DialogResult.Yes)
                    {
                        setWaitCursor(false);
                        BTN_SUBMIT.Focus();
                        return;
                    }
                }

                //전표발행여부 확인
                //전표를 발행하시겠습니까?
                //아래에 관련 데이터 출력해야 함
                //여권정보 
                //숙박일수
                dRet = MetroMessageBox.Show(this, Constants.getMessage("ISSUE_CONFIRM")+"\n● 공급가격:"+TXT_SALES_AMT.Text+ "\n● 세금:"
                    + TXT_TAX_AMT.Text+ "\n● 환급금:" + TXT_REFUND_AMT.Text, "Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRet != DialogResult.Yes)
                {
                    setWaitCursor(false);
                    BTN_SUBMIT.Focus();
                    return;
                }

                try
                {
                    setWaitCursor(true);
                    
                    JObject jsonSlip = new JObject();

                    JObject jsonStdInfo = new JObject();
                    JObject jsonSutInfo = new JObject();

                    JArray arrjsonSlip = new JArray();

                    int nSerialNo = 0;
                    //calAccAmt();//금액 재계산
                    calAccAmt(true,true);//금액 재계산

                    long nStdNight = Int64.Parse(COM_STD_NIGHT.Text.Replace(",",""));
                    long nSutNight = Int64.Parse(COM_SUT_NIGHT.Text.Replace(",", ""));

                    long nStdSalesAmt = Int64.Parse(TXT_STD_SALES_AMT.Text.Replace(",", ""));
                    long nSutSalesAmt = Int64.Parse(TXT_SUT_SALES_AMT.Text.Replace(",", ""));

                    jsonSlip.Add("passport_no", TXT_PASSPORT_NO.Text);
                    jsonSlip.Add("passport_name", TXT_PASSPORT_NAME.Text);
                    jsonSlip.Add("passport_nat", TXT_PASSPORT_NAT.Text );
                    jsonSlip.Add("passport_sex", COM_PASSPORT_SEX.Text);
                    jsonSlip.Add("passport_birth", TXT_PASSPORT_BIRTH.Text.Replace("-", "").Replace("/", ""));
                    jsonSlip.Add("passport_expire", TXT_PASSPORT_EXP.Text.Replace("-", "").Replace("/", ""));
                    
                    jsonSlip.Add("sales_amount", TXT_SALES_AMT.Text.Replace(",", ""));
                    jsonSlip.Add("tax_amount", TXT_TAX_AMT.Text.Replace(",", ""));
                    jsonSlip.Add("charge_amount", (Int64.Parse(TXT_TAX_AMT.Text.Replace(",", "")) - Int64.Parse(TXT_REFUND_AMT.Text.Replace(",", ""))).ToString());
                    jsonSlip.Add("refund_amount", TXT_REFUND_AMT.Text.Replace(",", ""));
                    jsonSlip.Add("tml_id", Constants.TML_ID);
                    jsonSlip.Add("sale_date", TXT_REFUND_DATE.Text.Replace("-", "").Replace("/", "") );
                    jsonSlip.Add("sale_time",  DateTime.Now.ToString("HHmmss"));

                    jsonSlip.Add("payment_type", COM_PAYMENT.SelectedIndex !=0 ? "02" : "01");//2018.02.20 지불조건 추가
                    //jsonSlip.Add("export_expiry_date", TXT_PASSPORT_EXP.Text);
                    //jsonSlip.Add("shop_name", TXT_PASSPORT_EXP.Text);
                    //jsonSlip.Add("biz_permit_no", "104-00-00000");
                    //jsonSlip.Add("company_reg_no", "");//관광사업자등록번호

                    //jsonSlip.Add("shop_name", "글로벌호텔");//관광사업자등록번호
                    //jsonSlip.Add("ceo_name", "홍길동");//관광사업자등록번호
                    //jsonSlip.Add("shop_addr", "서울특별시 중구 퇴계로 131 2층");//관광사업자등록번호

                    jsonSlip.Add("remark", TXT_REMARK.Text);
                    jsonSlip.Add("sign_img", TXT_SIGN_DATA.Text);
                    if(TXT_SIGN_DATA.Text != null  && !"".Equals(TXT_SIGN_DATA.Text.Trim()))
                    {
                        jsonSlip.Add("sign_img_type_code", "01");
                    }
                    else
                    {
                        jsonSlip.Add("sign_img_type_code", "");
                    }
                    
                    //숙박일 수 있는 경우 
                    if (COM_STD_NIGHT.SelectedIndex > 0)
                    {
                        nSerialNo++;
                        jsonStdInfo.Add("serial_no", nSerialNo.ToString());
                        jsonStdInfo.Add("unit_price", (Int64.Parse( TXT_STD_SALES_AMT.Text.Replace(",", "")) / Int64.Parse(COM_STD_NIGHT.Text)).ToString() );
                        jsonStdInfo.Add("qty", COM_STD_NIGHT.Text);
                        jsonStdInfo.Add("goods_name", "일반객실(standard room)");
                        
                        jsonStdInfo.Add("sales_amount", TXT_STD_SALES_AMT.Text.Replace(",", ""));
                        jsonStdInfo.Add("tax_amount", TXT_STD_TAX_AMT.Text.Replace(",", ""));
                        jsonStdInfo.Add("vat_amount", TXT_STD_TAX_AMT.Text.Replace(",", ""));
                        jsonStdInfo.Add("sct_amount", "0");
                        jsonStdInfo.Add("et_amount", "0");
                        jsonStdInfo.Add("item_code", "40");
                        jsonStdInfo.Add("item_name", "Standard");
                        jsonStdInfo.Add("item_tax_code", "1");

                        arrjsonSlip.Add(jsonStdInfo);
                    }
                    if (COM_SUT_NIGHT.SelectedIndex > 0)
                    {
                        nSerialNo++;
                        jsonSutInfo.Add("serial_no", nSerialNo.ToString());
                        jsonSutInfo.Add("unit_price", (Int64.Parse(TXT_SUT_SALES_AMT.Text.Replace(",", "")) / Int64.Parse(COM_SUT_NIGHT.Text)).ToString());
                        jsonSutInfo.Add("qty", COM_SUT_NIGHT.Text);
                        jsonSutInfo.Add("goods_name", "스위트룸(suite room)");
                        jsonSutInfo.Add("sales_amount", TXT_SUT_SALES_AMT.Text.Replace(",", ""));
                        jsonSutInfo.Add("tax_amount", TXT_SUT_TAX_AMT.Text.Replace(",", ""));
                        jsonSutInfo.Add("vat_amount", TXT_SUT_TAX_AMT.Text.Replace(",", ""));
                        jsonSutInfo.Add("sct_amount", "0");
                        jsonSutInfo.Add("et_amount", "0");
                        jsonSutInfo.Add("item_code", "41");
                        jsonSutInfo.Add("item_name", "Suite");
                        jsonSutInfo.Add("item_tax_code", "1");
                        arrjsonSlip.Add(jsonSutInfo);
                    }
                    jsonSlip.Add("buyList", arrjsonSlip);

                    //송신
                    JObject objRet = tran.sendServer_object(jsonSlip.ToString(), tran.url_Slip_Submit, 60, true, true);
                    if (objRet != null && "S".Equals(objRet["result"].ToString()))
                    {
                        jsonSlip.Add("biz_permit_no", objRet["biz_permit_no"]);
                        jsonSlip.Add("buy_serial_no", objRet["buy_serial_no"]);
                        jsonSlip.Add("company_reg_no", objRet["company_reg_no"]);
                        jsonSlip.Add("shop_name", objRet["shop_name"]);
                        jsonSlip.Add("ceo_name", objRet["ceo_name"]);
                        jsonSlip.Add("shop_addr", objRet["shop_addr"]);
                        jsonSlip.Add("shop_phone", objRet["shop_phone"]);

                        try {
                            PrintUtil pu = new PrintUtil();
                            pu.PrintRefundSlip(jsonSlip);
                            bRet = true;
                            MetroMessageBox.Show(this, Constants.getMessage("ISSUE_SUCCESS"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch(Exception ex2)
                        {
                            MetroMessageBox.Show(this, Constants.getMessage("ERROR_PRINT"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //bRet = true;
                    }
                    else
                    {
                        if (objRet != null && objRet["resp_msg"] != null)
                        {
                            MetroMessageBox.Show(this, objRet["resp_msg"].ToString(), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MetroMessageBox.Show(this, Constants.getMessage("ISSUE_ERROR"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    setWaitCursor(false);
                    BTN_SUBMIT.Focus();
                }

                //거래 성공 시 화면 초기화
                if (bRet)
                {
                    SCREEN_CLEAR();
                }
            }
            catch (Exception e2)
            {
                Constants.LOGGER_MAIN.Info(e2.Message);
            }
            setWaitCursor(false);
        }

        private void IssuePanel_SizeChanged(object sender, EventArgs e)
        {
            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();
            this.Refresh();
        }

        private void BTN_PASSPORT_MANUAL_Click(object sender, EventArgs e)
        {
            PassportInfoForm passForm = new PassportInfoForm(null, m_ArrNationalList);

            //passForm.init(m_ArrNationalList);

            passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_NAME"].Text = TXT_PASSPORT_NAME.Text;
            passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_NO"].Text = TXT_PASSPORT_NO.Text;

            Control tmpCrl = passForm.Controls["LAY_PASSPORT"].Controls["COM_PASSPORT_NAT"];
            if (tmpCrl is MetroComboBox)
            {
                if (TXT_PASSPORT_NAT.Text != null && !string.Empty.Equals(TXT_PASSPORT_NAT.Text.ToString()))
                {
                    ((MetroComboBox)tmpCrl).SelectedValue = TXT_PASSPORT_NAT.Text;
                }
                
            }

            //passForm.Controls["COM_PASSPORT_NAT"]. = TXT_PASSPORT_NAT.Text; 
            if (COM_PASSPORT_SEX.Text != null && !string.Empty.Equals(COM_PASSPORT_SEX.Text.ToString()))
            {
                passForm.Controls["LAY_PASSPORT"].Controls["COM_PASSPORT_SEX"].Text = COM_PASSPORT_SEX.Text;
            }
            //passForm.Controls["TXT_PASSPORT_BIRTH"].Text = (string.Empty.Equals(TXT_PASSPORT_BIRTH.Text) || TXT_PASSPORT_BIRTH.Text.Length <8) ? "": TXT_PASSPORT_BIRTH.Text.Substring(0, 4) + "-" + TXT_PASSPORT_BIRTH.Text.Substring(4, 2) + "-" + TXT_PASSPORT_BIRTH.Text.Substring(6);
            //passForm.Controls["TXT_PASSPORT_EXP"].Text = (string.Empty.Equals(TXT_PASSPORT_EXP.Text) || TXT_PASSPORT_EXP.Text.Length < 8) ? "" :TXT_PASSPORT_EXP.Text.Substring(0, 4) + "-" + TXT_PASSPORT_EXP.Text.Substring(4, 2) + "-" + TXT_PASSPORT_EXP.Text.Substring(6);

            passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_BIRTH"].Text = (string.Empty.Equals(TXT_PASSPORT_BIRTH.Text) || TXT_PASSPORT_BIRTH.Text.Length < 10) ? "" : TXT_PASSPORT_BIRTH.Text.Replace("-", "/");
            passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_EXP"].Text = (string.Empty.Equals(TXT_PASSPORT_EXP.Text) || TXT_PASSPORT_EXP.Text.Length < 10) ? "" : TXT_PASSPORT_EXP.Text.Replace("-", "/");

            DialogResult bResult = passForm.ShowDialog(this);
            if (bResult == DialogResult.OK)
            {
                //팝업에서 얻어온 정보를 화면에 세팅
                TXT_PASSPORT_NAME.Text = passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_NAME"].Text;
                TXT_PASSPORT_NO.Text = passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_NO"].Text;
                tmpCrl = passForm.Controls["LAY_PASSPORT"].Controls["COM_PASSPORT_NAT"];
                if (tmpCrl is MetroComboBox)
                {
                    //COM_PASSPORT_NAT.Text = ((MetroComboBox)tmpCrl).SelectedValue.ToString();
                    TXT_PASSPORT_NAT.Text = ((MetroComboBox)tmpCrl).SelectedValue.ToString();
                    //TXT_PASSPORT_NAT_NAME.Text = this.searchNatonalityName(((MetroComboBox)tmpCrl).SelectedValue.ToString());
                }
                COM_PASSPORT_SEX.Text = passForm.Controls["LAY_PASSPORT"].Controls["COM_PASSPORT_SEX"].Text;
                TXT_PASSPORT_BIRTH.Text = passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_BIRTH"].Text;//.Replace("-","").Replace("/", "");
                TXT_PASSPORT_EXP.Text = passForm.Controls["LAY_PASSPORT"].Controls["TXT_PASSPORT_EXP"].Text;//.Replace("-", "").Replace("/", "");
            }
        }


        private void setWaitCursor(Boolean bWait)
        {
            FocusDummy(bWait);
            if (bWait)
            {
                //Cursor.Current = Cursors.WaitCursor;
                this.UseWaitCursor = true;
            }
            else
            {
                //Cursor.Current = Cursors.Default;
                this.UseWaitCursor = false;
            }
        }

        private void COM_REFUND_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        ////Background 로 거래 처리 될 수 있도록
        //public Boolean ASyncTran(string strType)
        //{
        //    Boolean bRet = true;
        //    if ("code".Equals(strType))
        //    {
        //        Transaction tran = new Transaction();
        //        tran.SearchUserInfo(Constants.USER_ID, Constants.MERCHANT_NO, Constants.DESK_ID, "code");
        //    }
        //    else if ("bin".Equals(strType))
        //    {
        //        Transaction tran = new Transaction();
        //        tran.SearchUserInfo(Constants.USER_ID, Constants.MERCHANT_NO, Constants.DESK_ID, "bin");
        //    }
        //    return bRet;
        //}

        private void TXT_RCT_NO_Leave(object sender, EventArgs e)
        {
            //TXT_RCT_NO.Text = string.Format(TXT_RCT_NO.Text, "#####0");
        }



        private Boolean validationCheck(Boolean bPassPort, Boolean bItem)
        {
            //네트워크 체크
            if(!Constants.ONLINE_STATUS)
            {
                MetroMessageBox.Show(this, Constants.getMessage("ERROR_NETWORK"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //데이터 미입력
            if (bPassPort)
            {
                if (TXT_PASSPORT_NAME.Text == null || string.Empty.Equals(TXT_PASSPORT_NAME.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (TXT_PASSPORT_NO.Text == null || string.Empty.Equals(TXT_PASSPORT_NO.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (COM_PASSPORT_NAT.Text == null || string.Empty.Equals(COM_PASSPORT_NAT.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (COM_PASSPORT_SEX.Text == null || string.Empty.Equals(COM_PASSPORT_SEX.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (TXT_PASSPORT_BIRTH.Text == null || string.Empty.Equals(TXT_PASSPORT_BIRTH.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (TXT_PASSPORT_EXP.Text == null || string.Empty.Equals(TXT_PASSPORT_EXP.Text.Trim()))
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (bItem)
            {
                calAccAmt(true,true);//금액 재계산

                int nStdNight = Int32.Parse(COM_STD_NIGHT.Text);
                int nSutNight = Int32.Parse(COM_SUT_NIGHT.Text);

                int nStdSalesAmt = Int32.Parse(TXT_STD_SALES_AMT.Text.Replace(",",""));
                int nSutSalesAmt = Int32.Parse(TXT_SUT_SALES_AMT.Text.Replace(",", ""));

                int nRefundAmt = Int32.Parse(TXT_REFUND_AMT.Text.Replace(",", ""));
                

                //숙박일 체크
                if ((nStdNight + nSutNight) <= 0 || (nStdNight + nSutNight) > 30)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_NIGHT"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //일반룸 최대금액 세팅값 체크 (2019.11.01)
                if(nStdNight != 0)
                {
                    if ((nStdSalesAmt / nStdNight) > Constants.STANDARD_SELL_PRICE && Constants.STANDARD_SELL_PRICE != 0)
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("STDSALESAMT_CONFIRM"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                //스위트룸 최대금액 세팅값 체크 (2019.11.01)
                if (nSutNight != 0)
                {
                    if ((nSutSalesAmt / nSutNight) > Constants.SUITE_SELL_PRICE && Constants.SUITE_SELL_PRICE != 0)
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("SUTSALESAMT_CONFIRM"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                //금액 체크
                if ((nStdSalesAmt + nSutSalesAmt) < 30000)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_SALES_AMT"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if(nStdNight > 0  && nStdSalesAmt == 0)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_STD"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (nSutNight > 0 && nSutSalesAmt == 0)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_SUT"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if(nRefundAmt == 0)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("ERROR_SALES_AMT"), "issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            //갯수제한 체크. 입력시 체크하고 있기 때문에 여기서는 제외
            //if (GRD_ITEMS.Rows.Count > 10)
            //{
            //    MetroMessageBox.Show(this, Constants.getMessage("ITEM_MAX"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //데이터 체크
            return true;

        }

        private void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            SCREEN_CLEAR();
        }

        private void SCREEN_CLEAR()
        {
            //초기 정보
            TXT_REFUND_DATE.Value = System.DateTime.Now;
            //여권정보 CLEAR
            TXT_PASSPORT_NAME.Text = string.Empty;
            TXT_PASSPORT_NO.Text = string.Empty;
            TXT_PASSPORT_NAT.Text = string.Empty;
            COM_PASSPORT_SEX.SelectedIndex = 0;
            TXT_PASSPORT_BIRTH.Text = string.Empty;
            TXT_PASSPORT_EXP.Text = string.Empty;
            TXT_PASSPORT_NAT_NAME.Text = string.Empty;

            //판매액 정보 클리어 
            TXT_SALES_AMT.Text = "0";
            TXT_TAX_AMT.Text = "0";
            TXT_REFUND_AMT.Text = "0";
            TXT_VAT_AMT.Text = "0";
            TXT_SCT_AMT.Text = "0";
            TXT_ET_AMT.Text = "0";
            TXT_STD_TAX_AMT.Text = "0";
            TXT_SUT_TAX_AMT.Text = "0";
            TXT_REMARK.Text = string.Empty;

            //숙박정보 클리어
            COM_STD_NIGHT.SelectedIndex = 0;
            COM_SUT_NIGHT.SelectedIndex = 0;

            COM_PAYMENT.SelectedIndex = 0; //2018.02.20 현금결제 초기값

            if (PIC_SIGN.Image != null)
            {
                PIC_SIGN.Image.Dispose();
                PIC_SIGN.Image = null;
            }
            TXT_SIGN_DATA.Text = string.Empty;
            BTN_SCAN.Focus();
        }

        private string searchNatonalityName(string strNatCode)
        {
            string strRet = "";
            if (m_ArrNationalList != null)
            {
                for (int i = 0; i < m_ArrNationalList.Count; i++)
                {
                    JObject tempObj = (JObject)m_ArrNationalList[i];
                    IList<string> keys = tempObj.Properties().Select(p => p.Name).ToList();
                    for (int j = 0; j < keys.Count; j++)
                    {
                        if (strNatCode.Equals(keys[j].ToString()))
                        {
                            strRet = tempObj[keys[j].ToString()].ToString();
                        }
                    }
                }
            }
            return strRet;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            //Keys key = keyData & ~(Keys.Shift | Keys.Control);
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Alt | Keys.A:
                        BTN_SUBMIT_Click(null, null);
                        return true;
                    case Keys.F1:
                        BTN_SCAN_Click(null, null);
                        return true;
                    case Keys.F2:
                        BTN_PASSPORT_MANUAL_Click(null, null);
                        return true;
                    case Keys.F5:
                        SCREEN_CLEAR();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }



        private void GRD_ITEMS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FocusDummy(Boolean bFocus)
        {
            //if (bFocus)
            //{
            //    TXT_DUMMY.Visible = true;
            //    TXT_DUMMY.Focus();
            //}else
            //{
            //    TXT_DUMMY.Visible = false;
            //}
        }

        private void TXT_REFUND_TYPE_KEY_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public JObject getSubmitJson()
        {
            JObject objJson = null;

            return objJson;
        }

        private void BTN_SIGN_Click(object sender, EventArgs e)
        {
            if (Constants.SIGN_PAD_TYPE <= 0)
            {
                MetroMessageBox.Show(this, Constants.getMessage("SIGNPAD_NOTHING"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (Constants.SIGN_PAD_TYPE == 1)
            {
                try {
                    string filePath = Directory.GetCurrentDirectory() + "/signimg/signtest.bmp";
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    Utils gtfUtil = new Utils();
                    int input_amt = 0;          //결제 금액 - 싸인패드에 표시
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

                    if (resultCode >= 0)
                    {
                        PIC_SIGN.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/../Image/signtest.bmp");
                        byte[] buff = File.ReadAllBytes(Directory.GetCurrentDirectory() + "/../Image/signtest.bmp");
                        TXT_SIGN_DATA.Text = System.Convert.ToBase64String(buff);

                    }
                    else
                    {
                        MetroMessageBox.Show(this, Constants.getMessage("SIGNPAD_DAU_NOTFOUND"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }catch(Exception ex)
                {
                    MetroMessageBox.Show(this, Constants.getMessage("SIGNPAD_ERROR"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_Logger.Error("다우 사인패드 출력 오류", ex);
                }
            }
        }

        private void COM_STD_NIGHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (COM_STD_NIGHT.SelectedIndex <= 0)
            {
                TXT_STD_SALES_AMT.Text = "0";
                TXT_STD_TAX_AMT.Text = "0";
                TXT_STD_SALES_AMT.Enabled = false;
            }
            else
            {
                TXT_STD_SALES_AMT.Enabled = true;
                TXT_STD_SALES_AMT.Focus();
                TXT_STD_SALES_AMT.SelectAll();
            }
        }

        private void COM_SUT_NIGHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (COM_SUT_NIGHT.SelectedIndex <= 0)
            {
                TXT_SUT_SALES_AMT.Text = "0";
                TXT_SUT_TAX_AMT.Text = "0";
                TXT_SUT_SALES_AMT.Enabled = false;
            }
            else
            {
                TXT_SUT_SALES_AMT.Enabled = true;
                TXT_SUT_SALES_AMT.Focus();
                TXT_SUT_SALES_AMT.SelectAll();
            }
        }

        private void TXT_STD_SALES_AMT_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = TXT_STD_SALES_AMT.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop
                TXT_STD_SALES_AMT.TextChanged -= TXT_STD_SALES_AMT_TextChanged;
                //Format the text as currency
                string tmp_value = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", ul);
                TXT_STD_SALES_AMT.Text = tmp_value.Replace("$", "");
                TXT_STD_SALES_AMT.TextChanged += TXT_STD_SALES_AMT_TextChanged;
                TXT_STD_SALES_AMT.Select(TXT_STD_SALES_AMT.Text.Length, 0);

                TXT_STD_TAX_AMT.TextChanged -= TXT_STD_TAX_AMT_TextChanged;
                TXT_SUT_TAX_AMT.TextChanged -= TXT_SUT_TAX_AMT_TextChanged;
                calAccAmt(false, true);
                TXT_STD_TAX_AMT.TextChanged += TXT_STD_TAX_AMT_TextChanged;
                TXT_SUT_TAX_AMT.TextChanged += TXT_SUT_TAX_AMT_TextChanged;
            }
        }

        private void TXT_SUT_SALES_AMT_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = TXT_SUT_SALES_AMT.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop
                TXT_SUT_SALES_AMT.TextChanged -= TXT_SUT_SALES_AMT_TextChanged;
                //Format the text as currency
                string tmp_value = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", ul);
                TXT_SUT_SALES_AMT.Text = tmp_value.Replace("$", "");
                TXT_SUT_SALES_AMT.TextChanged += TXT_SUT_SALES_AMT_TextChanged;
                TXT_SUT_SALES_AMT.Select(TXT_SUT_SALES_AMT.Text.Length, 0);
                TXT_STD_TAX_AMT.TextChanged -= TXT_STD_TAX_AMT_TextChanged;
                TXT_SUT_TAX_AMT.TextChanged -= TXT_SUT_TAX_AMT_TextChanged;
                calAccAmt(true, false);
                TXT_STD_TAX_AMT.TextChanged += TXT_STD_TAX_AMT_TextChanged;
                TXT_SUT_TAX_AMT.TextChanged += TXT_SUT_TAX_AMT_TextChanged;
            }
        }

        private void calAccAmt(Boolean bSTDTaxChange = false, Boolean bSUTTaxChange = false)
        {
            long nTotalAmt = 0;
            long nTaxAmt = 0;
            long nVatAmt = 0;
            long nRefundAmt = 0;
            long nEtAmt = 0;
            long nSctAmt = 0;

            //일반룸
            long nStdAmt = 0;
            long nStdTaxAmt = 0;
            if (COM_STD_NIGHT.SelectedIndex >= 0)
            {
                //nStdAmt = Int64.Parse(COM_STD_NIGHT.Text.ToString()) * Int64.Parse(TXT_STD_SALES_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
                nStdAmt = Int64.Parse(TXT_STD_SALES_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
                if (!bSTDTaxChange)
                {
                    TXT_STD_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", (nStdAmt / 11)).Replace("$", "");
                }
                nStdTaxAmt = Int64.Parse(TXT_STD_TAX_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
            }

            long nSutAmt = 0;
            long nSutTaxAmt = 0;
            if (COM_SUT_NIGHT.SelectedIndex >= 0)
            {
                //nSutAmt = Int64.Parse(COM_SUT_NIGHT.Text.ToString()) * Int64.Parse(TXT_SUT_SALES_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
                nSutAmt = Int64.Parse(TXT_SUT_SALES_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
                if (!bSUTTaxChange)
                {
                    TXT_SUT_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", (nSutAmt / 11)).Replace("$", "");
                }
                nSutTaxAmt = Int64.Parse(TXT_SUT_TAX_AMT.Text.Replace(",", "").Replace("$", "").Replace(".", ""));
            }

            nTotalAmt = nStdAmt + nSutAmt;
            //nTaxAmt = nTotalAmt / 11;
            nTaxAmt = nStdTaxAmt + nSutTaxAmt;
            nVatAmt = nTaxAmt;
            Utils util = new Utils();
            nRefundAmt = util.getRefundAmount(nTotalAmt);
            //nRefundAmt = nVatAmt * 9 / 10;
            //nRefundAmt = nRefundAmt - nRefundAmt % 1000;

            //Check we are indeed handling a number
            TXT_SALES_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nTotalAmt).Replace("$", "");
            TXT_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nTaxAmt).Replace("$", ""); 
            TXT_REFUND_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nRefundAmt).Replace("$", "");
            TXT_VAT_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nVatAmt).Replace("$", ""); 
            TXT_SCT_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nSctAmt).Replace("$", ""); 
            TXT_ET_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", nEtAmt).Replace("$", ""); 

        }

        private void TXT_SUT_SALES_AMT_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void TXT_PASSPORT_NAT_Click(object sender, EventArgs e)
        {

        }

        private void TXT_STD_TAX_AMT_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = TXT_STD_TAX_AMT.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop
                TXT_STD_TAX_AMT.TextChanged -= TXT_STD_TAX_AMT_TextChanged;
                //Format the text as currency
                string tmp_value = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", ul);
                TXT_STD_TAX_AMT.Text = tmp_value.Replace("$", "");
                TXT_STD_TAX_AMT.TextChanged += TXT_STD_TAX_AMT_TextChanged;
                TXT_STD_TAX_AMT.Select(TXT_STD_TAX_AMT.Text.Length, 0);
                calAccAmt(true,true);
            }
        }

        private void TXT_SUT_TAX_AMT_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = TXT_SUT_TAX_AMT.Text.Replace(",", "")
                .Replace("$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop
                TXT_SUT_TAX_AMT.TextChanged -= TXT_SUT_TAX_AMT_TextChanged;
                //Format the text as currency
                string tmp_value = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", ul);
                TXT_SUT_TAX_AMT.Text = tmp_value.Replace("$", "");
                TXT_SUT_TAX_AMT.TextChanged += TXT_SUT_TAX_AMT_TextChanged;
                TXT_SUT_TAX_AMT.Select(TXT_SUT_TAX_AMT.Text.Length, 0);
                calAccAmt(true, true);
            }
        }
    }
}
