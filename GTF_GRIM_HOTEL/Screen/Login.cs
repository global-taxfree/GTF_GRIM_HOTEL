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
using MetroFramework;
using GTF_STFM.Tran;
using GTF_STFM.Util;
using GTF_STFM.Properties;
using Newtonsoft.Json.Linq;
using log4net;

namespace GTF_STFM.Screen
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        private Boolean m_bStart = false;
        public string m_strID = string.Empty;
        public string m_strPassword = string.Empty;
        
        private Login(ILog Logger = null)
        {
            InitializeComponent();
            this.ActiveControl = TXT_ID;
        }

        public Login(Boolean bStart = true, String strID = "", String strPassword = "")
        {
            InitializeComponent();

            m_bStart = bStart;          //초기 load 여부
            m_strID = strID;            //초기 load : localdb에 저장된 마지막 로그인 id , 중간 load : 접속한 id
            m_strPassword = strPassword;//초기 load : localdb에 저장된 마지막 로그인 password , 중간 load : 접속한 password

        }

        private void Login_Load(object sender, EventArgs e)
        {
            ControlManager ctlManager = new ControlManager(this);
            ctlManager.ChageLabel(this);//Label 변경

            if (!m_bStart)
            {
                //ID 비활성화 , ID 입력
                TXT_ID.Enabled = false;
                TXT_ID.Text = m_strID;
                CHK_OFFLINE.Enabled = false;
            }
            UpdateProgressBar(0, Constants.getMessage("LOGIN_BEFORE"));
            Activate();
            if (Constants.CONF_MANAGER.getAppValue("LOGIN_ID") != null && !string.Empty.Equals(Constants.CONF_MANAGER.getAppValue("LOGIN_ID").ToString()))
            {
                TXT_ID.Text  = Constants.CONF_MANAGER.getAppValue("LOGIN_ID");
                TXT_PASSWORD.Text = Constants.CONF_MANAGER.getAppValue("LOGIN_PW");
            }
        }

        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            //Confirm 메시지박스 호출
            DialogResult bResult = MetroMessageBox.Show(this, Constants.getMessage("EXIT_CONFIRM"), "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if(bResult.Equals(DialogResult.Yes))
            {
                this.Visible = false;
                //프로그램 종료
                Application.ExitThread();
                Environment.Exit(0);
            }
            
        }

        private void BTN_LOGIN_Click(object sender, EventArgs e)
        {

            //try {
            //    //단말기 초기 Load 시 창 호출하는 경우에는 전문처리
            //    setWaitCursor(true);
            //    if (m_bStart && !CHK_OFFLINE.Checked)
            //    {
            //        if (TXT_ID.Text == null || string.Empty.Equals(TXT_ID.Text.Trim())) // PASSWORD 아무것도 입력 안한 경우에는 return
            //        {
            //            setWaitCursor(false);
            //            MetroMessageBox.Show(this, Constants.getMessage("EMPTY_ID"), "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            TXT_ID.Focus();
            //            return;
            //        }

            //        if (TXT_PASSWORD.Text == null || string.Empty.Equals(TXT_PASSWORD.Text.Trim())) // PASSWORD 아무것도 입력 안한 경우에는 return
            //        {
            //            setWaitCursor(false);
            //            MetroMessageBox.Show(this, Constants.getMessage("EMPTY_PASSWORD"), "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            TXT_PASSWORD.Focus();
            //            return;
            //        }

            //        //창닫기

            //        //m_strID = string.Empty.Equals(TEXT_ID.Text.Trim()) ? "User Name" : TEXT_ID.Text.Trim();
            //        //m_strPassword = TEXT_PASSWORD.Text;
            //        //this.Close();
            //        //return;

            //        UpdateProgressBar(10, Constants.getMessage("LOGIN_ID"));
            //        Transaction login_tran = new Transaction();
            //        JObject jsonRsult = login_tran.Login(TXT_ID.Text, TXT_PASSWORD.Text);
            //        //로그인성공시
            //        //사용자 정보 가져옴
            //        if (jsonRsult != null && "S".Equals(jsonRsult["login"].ToString()))
            //        {
            //            UpdateProgressBar(20, Constants.getMessage("LOGIN_SHOP") /*"가맹점 정보 로딩 중"*/);
            //            m_strID = string.Empty.Equals(TXT_ID.Text.Trim()) ? "User Name" : TXT_ID.Text.Trim();
            //            m_strPassword = TXT_PASSWORD.Text;

            //            Constants.USER_ID = m_strID;
            //            Constants.CLOSING_YN = "Y".Equals(jsonRsult["closeYn"] == null ? "" : jsonRsult["closeYn"].ToString());//마감여부 추가

            //            //위탁형
            //            if (((JObject)jsonRsult["userInfo"])["deskId"] != null && !string.Empty.Equals(((JObject)jsonRsult["userInfo"])["deskId"].ToString()))
            //            {
            //                Constants.USER_AUTH = "01";
            //                Constants.DESK_ID = ((JObject)jsonRsult["userInfo"])["deskId"].ToString();
            //            }
            //            //일반형
            //            else
            //            {
            //                Constants.USER_AUTH = "02";
            //                if (((JObject)jsonRsult["userInfo"])["merchantNo"] != null)
            //                {
            //                    Constants.MERCHANT_NO = ((JObject)jsonRsult["userInfo"])["merchantNo"].ToString();
            //                }
            //                //if (((JObject)jsonRsult["userInfo"])["deskId"] != null)
            //                //    Constants.DESK_ID = "";
            //            }

                        

            //            Constants.LOGGER_MAIN.Info(":start");

            //            //가맹점정보
            //            login_tran.SearchUserInfo(((JObject)jsonRsult["userInfo"])["userId"].ToString(), Constants.MERCHANT_NO
            //                , Constants.DESK_ID, "merchant");
            //            Constants.LOGGER_MAIN.Info(":merchant");

            //            //최초 로그인 시에는 CODE 테이블 있는지 확인하고 있으면 여기서 업데이트. 있으면 한행씩 업데이트
            //            if(!Constants.LDB_MANAGER.ExitsTable("CODE"))
            //            {
            //                UpdateProgressBar(40, Constants.getMessage("LOGIN_CODE"));
            //                login_tran.SearchUserInfo(Constants.USER_ID, Constants.MERCHANT_NO, Constants.DESK_ID, "code");
            //                Constants.CODE_DOWNLOAD = true;
            //            }

            //            Constants.LOGIN_YN = true;

            //            //item
            //            UpdateProgressBar(60, Constants.getMessage("LOGIN_ITEM"));
            //            login_tran.SearchUserInfo(((JObject)jsonRsult["userInfo"])["userId"].ToString(), Constants.MERCHANT_NO
            //                , Constants.DESK_ID, "item");
            //            DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.mmm]");
            //            Constants.LOGGER_MAIN.Info(":item");
            //            //세무서리스트
            //            UpdateProgressBar(80, Constants.getMessage("LOGIN_CUSTOMS"));
            //            login_tran.SearchUserInfo(((JObject)jsonRsult["userInfo"])["userId"].ToString(), Constants.MERCHANT_NO
            //                , Constants.DESK_ID, "taxoffice");
            //            DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.mmm]");
            //            Constants.LOGGER_MAIN.Info(":taxoffice");
            //            //ads
            //            UpdateProgressBar(90, Constants.getMessage("LOGIN_ADS"));
            //            login_tran.SearchUserInfo(((JObject)jsonRsult["userInfo"])["userId"].ToString(), Constants.MERCHANT_NO
            //                , Constants.DESK_ID, "ads");
            //            DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss.mmm]");
            //            Constants.LOGGER_MAIN.Info(":ads");
            //            UpdateProgressBar(100, Constants.getMessage("LOGIN_END"));
            //            /*
            //            */
            //            setWaitCursor(false);
            //            this.Close();
            //        }
            //        else {
            //            Control tempCon = this.ActiveControl;//직전 포커스 가지고 있는 컨트롤 저장
            //            setWaitCursor(false);
            //            string strErrMsg = "";
            //            if (jsonRsult != null && "F".Equals(jsonRsult["login"].ToString()) && jsonRsult["login_msg"] != null )
            //            {
            //                strErrMsg = jsonRsult["login_msg"].ToString();
            //            }
            //            else
            //            {
            //                strErrMsg = Constants.getMessage("ERROR_LOGIN");
            //            }
                       
            //            //실패 시 
            //            MetroMessageBox.Show(this, strErrMsg, "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            UpdateProgressBar(0, Constants.getMessage("LOGIN_BEFORE"));
            //            if (tempCon != null)//포커스 복귀
            //                tempCon.Focus();
            //            return;
            //        }
            //    }
            //    else //사용중 로그인창 뜬 경우에는 password 검증 처리
            //    {
            //        string strPassword = TXT_PASSWORD.Text;
            //        if (strPassword == null || string.Empty.Equals(strPassword.Trim())) // PASSWORD 아무것도 입력 안한 경우에는 return
            //        {
            //            setWaitCursor(false);
            //            MetroMessageBox.Show(this, Constants.getMessage("EMPTY_PASSWORD"), "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            TXT_PASSWORD.Focus();
            //            return;
            //        }
            //        if (strPassword.Equals(m_strPassword))
            //        {
            //            //로그인성공
            //        }
            //        else
            //        {
            //            Control tempCon = this.ActiveControl;//직전 포커스 가지고 있는 컨트롤 저장
            //                                                 //로그인실패
            //            MetroMessageBox.Show(this, Constants.getMessage("ERROR_LOGIN"), "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            if (tempCon != null)//포커스 복귀
            //                tempCon.Focus();
            //        }
            //    }
            //}catch(Exception ex)
            //{
            //    Constants.LOGGER_MAIN.Info(ex.Message);
            //    MetroMessageBox.Show(this, Constants.getMessage("ERROR_LOGIN_CRITICAL"), "Loigin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Visible = false;
            //    Application.ExitThread();
            //    Environment.Exit(0);
            //}
            //finally
            //{
            //    setWaitCursor(false);
            //}
            
        }

        private void CHK_OFFLINE_CheckedChanged(object sender, EventArgs e)
        {
            //체크박스 클릭하였을 때는            
            //체크박스 해제시에는
        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void BTN_APPEND_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateProgressBar(int nValue , string strMessage)
        {
            LBL_PROGRESS.Text = strMessage;
            Login_ProgressBar.Value = nValue;
        }

        private void setWaitCursor(Boolean bWait)
        {
            try {
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
            }catch(Exception ex)
            {
                Constants.LOGGER_MAIN.Info(ex.Message);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData))
            {
                // 여기에 처리코드를 넣는다.
                if (keyData.Equals(Keys.Enter))//만약 Enter 키가 눌리면
                {
                    if (!string.Empty.Equals(TXT_ID.Text.Trim()) && !string.Empty.Equals(TXT_PASSWORD.Text.Trim())) // PASSWORD 아무것도 입력 안한 경우에는 return
                    {
                        BTN_LOGIN_Click(null, null);
                        return true;
                    }
                    //else {
                    //    if (this.ActiveControl is TextBox)
                    //    {
                    //        this.SelectNextControl((Control)this.ActiveControl, true, true, true, true);
                    //    }
                    //}
                }
                else if (keyData.Equals(Keys.Escape))//만약 Esc키가 눌리면
                {
                    BTN_CANCEL_Click(null, null);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            //TEXT_ID.Select();
            //TEXT_ID.Focus();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
