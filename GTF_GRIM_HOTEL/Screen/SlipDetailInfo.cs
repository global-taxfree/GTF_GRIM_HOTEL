using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;

using GTF_STFM.Util;
using GTF_STFM.Tran;
using log4net;
using System.Globalization;
using MetroFramework;

namespace GTF_STFM.Screen
{
    public partial class SlipDetailInfo : MetroForm
    {
        ILog m_Logger = null;
        string m_buy_serial_no = String.Empty;

        Int64 m_nPrintCnt = 0;
        public SlipDetailInfo(string strBuySerialNo ,  ILog logger = null)
        {
            m_Logger = logger;
            m_buy_serial_no = strBuySerialNo;

            InitializeComponent();
        }
        

        private void BTN_CLOSE_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_REFUND_Click(object sender, EventArgs e)
        {
            MessageSmallForm msgSmallForm = new MessageSmallForm(Constants.getMessage("REFUND_COMPLETE") , null);
            msgSmallForm.ShowDialog(this);
            string refunddt = System.DateTime.Now.ToString("yy'/'MM'/'dd HH:mm:ss");
            Transaction tran = new Transaction();//거래내용 조회
            JObject tempObj = new JObject();
            JObject tempObj2 = new JObject();
            tempObj.Add("SLIP_NO", m_buy_serial_no);
            tempObj2.Add("SLIP_STATUS_CODE", "02");
            tempObj2.Add("REFUNDDT", refunddt);

            if(m_nPrintCnt == 0)
            {
                tempObj2.Add(Constants.PRINT_CNT, "1"); 
            }

            tran.UpdateSlip(tempObj, tempObj2);
            tempObj.RemoveAll();
            tempObj2.RemoveAll();
            tempObj = null;
            tempObj2 = null;
            tran = null;
            
            TXT_BIZ_PERMIT_NO.Text = Constants.getScreenText("COMBO_ITEM_REFUND");
        }

        private void SlipDetailInfo_Load(object sender, EventArgs e)
        {
            try {
                JObject sendObj = new JObject();
                sendObj.Add("buy_serial_no", m_buy_serial_no);
                sendObj.Add("tml_id", Constants.TML_ID);
                Transaction tran = new Transaction();//거래내용 조회
                m_Logger.Debug("SlipDetailInfo_Load 1");
                JObject retSlip = tran.sendServer_object(sendObj.ToString(), tran.url_Slip_Info, 60, true, true);

                //환급전 상태가 아니면 출력 및 재인쇄 동작 안함
                if (!"01".Equals(retSlip["slip_status_code"].ToString()))
                {
                    BTN_PRINT.Visible = false;
                    BTN_CANCEL.Visible = false;
                }
                else
                {
                    BTN_PRINT.Visible = true;
                    BTN_CANCEL.Visible = true;
                }
                //개발이면 재출력
                //if(Constants.IS_DEV)
                //    BTN_PRINT.Visible = true;

                if (retSlip["passport_name_mask"] != null)
                    TXT_PASS_NAME.Text = retSlip["passport_name_mask"].ToString();
                if (retSlip["passport_no_mask"] != null)
                    TXT_PASS_NO.Text = retSlip["passport_no_mask"].ToString();
                if (retSlip["passport_nat"] != null)
                    TXT_PASS_NAT.Text = retSlip["passport_nat"].ToString();
                if (retSlip["passport_sex"] != null)
                    TXT_PASS_SEX.Text = retSlip["passport_sex"].ToString();

                if (retSlip["passport_birth"] != null)
                {
                    string strBirth = retSlip["passport_birth"].ToString();
                    strBirth = strBirth.Length < 6 ? strBirth : strBirth.Substring(0, 4) + "-" + strBirth.Substring(4, 2) + "-" + strBirth.Substring(6);
                    TXT_PASS_BIRTH.Text = strBirth;
                }
                if (retSlip["passport_expire"] != null)
                { 
                    string strExp = retSlip["passport_expire"].ToString();
                    strExp = strExp.Length < 6 ? strExp : strExp.Substring(0, 4) + "-" + strExp.Substring(4, 2) + "-" + strExp.Substring(6);
                    TXT_PASS_EXP.Text = strExp;
                }

                string strBuySerialNo = retSlip["buy_serial_no"].ToString();
                strBuySerialNo = strBuySerialNo.Substring(0, 2)
                       + "-" + strBuySerialNo.Substring(2, 5)
                       + "-" + strBuySerialNo.Substring(7, 5)
                       + "-" + strBuySerialNo.Substring(12, 2)
                       + "-" + strBuySerialNo.Substring(14);

                TXT_BUY_SERIAL_NO.Text = strBuySerialNo;
                string sale_date = retSlip["sale_date"].ToString();
                sale_date = sale_date.Length < 6 ? sale_date : sale_date.Substring(0, 4) + "-" + sale_date.Substring(4, 2) + "-" + sale_date.Substring(6,2);

                TXT_SELL_DATE.Text = sale_date;

                if ("01".Equals(retSlip["slip_status_code"].ToString()))
                {
                    TXT_SLIP_STATUS.Text =  "환급전";
                }
                else if ("02".Equals(retSlip["slip_status_code"].ToString()))
                {
                    TXT_SLIP_STATUS.Text = "환급완료";
                }
                else if ("03".Equals(retSlip["slip_status_code"].ToString()))
                {
                    TXT_SLIP_STATUS.Text = "취소";
                }


                String strBizPermitNo = retSlip["biz_permit_no"].ToString();
                strBizPermitNo = strBizPermitNo.Substring(0, 3) + "-"+ strBizPermitNo.Substring(3, 2) + "-" + strBizPermitNo.Substring(5);

                TXT_BIZ_PERMIT_NO.Text = strBizPermitNo;
                TXT_SHOP_NAME.Text = retSlip["shop_name"].ToString();
                TXT_COMPANY_NO.Text = retSlip["company_reg_no"].ToString();

                TXT_SALES_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(retSlip["sales_amount"].ToString()));
                TXT_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(retSlip["tax_amount"].ToString()));
                TXT_VAT_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(retSlip["tax_amount"].ToString()));
                TXT_REFUND_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(retSlip["refund_amount"].ToString()));

                if (retSlip["buyList"] is JArray)
                {
                    JArray arrBuyList = (JArray)retSlip["buyList"];
                    for(int i=0; i < arrBuyList.Count; i++)
                    {
                        JObject tempObj = (JObject)arrBuyList[i];

                        //일반룸
                        if ("40".Equals(tempObj["items_code"].ToString()))
                        {
                            TXT_STD_QTY.Text = tempObj["qty"].ToString() + " 박";
                            TXT_STD_SELL_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(tempObj["sales_amount"].ToString()));
                            TXT_STD_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(tempObj["tax_amount"].ToString()));
                        }
                        //스위트룸
                        else if ("41".Equals(tempObj["items_code"].ToString()))
                        {
                            TXT_SUT_QTY.Text = tempObj["qty"].ToString() + " 박";
                            TXT_SUT_SELL_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(tempObj["sales_amount"].ToString()));
                            TXT_SUT_TAX_AMT.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(tempObj["tax_amount"].ToString()));
                        }
                    }
                }


                TXT_REMARK.Text = retSlip["remark"].ToString(); 
                retSlip = null;

                BTN_CLOSE.Focus();
                m_Logger.Debug("SlipDetailInfo_Load 3");
            }
            catch(Exception ex)
            {
                m_Logger.Error(ex.StackTrace);
            }
        }

        private void BTN_PRINT_Click(object sender, EventArgs e)
        {
            DialogResult dRet = MetroMessageBox.Show(this, Constants.getMessage("REPRINT_CONFIRM") , "상세조회", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRet != DialogResult.Yes)
            {
                return;
            }

            Transaction tran = new Transaction();
            JObject sebdObj = new JObject();
            sebdObj.Add("buy_serial_no", TXT_BUY_SERIAL_NO.Text.Replace("-", ""));
            sebdObj.Add("tml_id", Constants.TML_ID);

            try
            {
                JObject objRet = tran.sendServer_object(sebdObj.ToString(), tran.url_Slip_Info, 60, true, true);
                PrintUtil pu = new PrintUtil();
                pu.PrintRefundSlip(objRet);
            }
            catch (Exception ex2)
            {
                MetroMessageBox.Show(this, Constants.getMessage("ERROR_PRINT"), "상세조회", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //취소버튼 입력 
        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            DialogResult dRet = MetroMessageBox.Show(this, Constants.getMessage("CANCEL_CONFIRM") , "상세조회", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRet != DialogResult.Yes)
            {
                return;
            }

            Transaction tran = new Transaction();
            JObject sebdObj = new JObject();
            sebdObj.Add("buy_serial_no", TXT_BUY_SERIAL_NO.Text.Replace("-","") );
            sebdObj.Add("tmld_id", Constants.TML_ID);
            
            JObject objRet = tran.sendServer_object(sebdObj.ToString(), tran.url_Slip_Cancel, 60, true, true);
            if (objRet != null && "S".Equals(objRet["result"].ToString()))
            {
                MetroMessageBox.Show(this, "\n정상적으로 취소되었습니다.", "상세조회", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTN_PRINT.Visible = false;
                BTN_CANCEL.Visible = false;
                TXT_SLIP_STATUS.Text = "취소";
            }
            else
            {
                MetroMessageBox.Show(this, "\n취소가 되지 않았습니다. \n전표상태를 확인해보시기 바랍니다.", "상세조회", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TXT_COMPANY_NO_Click(object sender, EventArgs e)
        {

        }
    }
}
