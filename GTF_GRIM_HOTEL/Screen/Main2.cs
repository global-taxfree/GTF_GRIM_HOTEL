using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTF_STFM.Util;
using GTF_STFM.Tran;
using Newtonsoft.Json.Linq;
using MetroFramework;

namespace GTF_STFM.Screen
{
    public partial class Main2 : MetroFramework.Forms.MetroForm
    {
        //int MAIN_WIDTH = 1360;
        //int MAIN_HEIGHT = 728;
        IssuePanel pIssuePanel = null;
        SearchPanel pSearchPanel = null;
        PreferencesPanel pPreferencesPanel = null;
        public static GTF_STFM.Util.Constants m_Constants;

        ControlManager m_CtlSizeManager = null;

        public Boolean m_bLogin = false;
        public Boolean m_bBin = false;

        public Main2()
        {
            InitializeComponent();
            //this.Enabled = false;
            m_Constants = new Constants(this);
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            /* 2018.01.10 로그인 과정 삭제
            if (!login())
            {
                //System.Windows.Forms.MessageBox.Show("Login Fail");
                //MetroMessageBox.Show(Owner, "Test");
                //Application.Exit();
                Application.ExitThread();
                Environment.Exit(0);
                // this.Close();
            }
            */
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
        }
        //public Boolean login()
        //{
        //    Boolean bRet = true;
        //    Login fLogin = new Login();
        //    fLogin.ShowDialog();
        //    string strTemp = fLogin.m_strID;
        //    string strTemp2 = fLogin.m_strPassword;
        //    fLogin = null;
        //    if (string.Empty.Equals(strTemp) || string.Empty.Equals(strTemp2))
        //    {
        //        bRet = false;
        //        return false;
        //    }
        //    else
        //    {
        //        Constants.USER_ID = strTemp;
        //        TIL_USERNAME.Text = strTemp ;
        //    }
        //    return bRet;
        //}

        private void Main2_Load(object sender, EventArgs e)
        {
            pIssuePanel = new IssuePanel(Constants.LOGGER_SCREEN);
            metroPanel2.Controls.Add(pIssuePanel);

            pSearchPanel = new SearchPanel(Constants.LOGGER_SCREEN);
            metroPanel3.Controls.Add(pSearchPanel);

            pPreferencesPanel = new PreferencesPanel(Constants.LOGGER_SCREEN);
            metroPanel4.Controls.Add(pPreferencesPanel);

            metroPanel2.Location = new Point(119, 43);
            metroPanel3.Location = new Point(119, 43);
            metroPanel4.Location = new Point(119, 43);

            metroPanel2.Size = new Size(900, 680);
            metroPanel3.Size = new Size(900, 680);
            metroPanel4.Size = new Size(900, 680);

            pIssuePanel.Size = new Size(900, 680);
            pSearchPanel.Size = new Size(900, 680);
            pPreferencesPanel.Size = new Size(900, 680);

            
            metroPanel2.Refresh();
            this.Activate();
            //backgroundWorker1.RunWorkerAsync();
            //단말기 초기 세팅 시 환경설정 화면으로 전환

            //Main2_SizeChanged(null,null);

            //최초생성시 좌표, 크기 조정여부 등록함. 화면별로 Manager 를 가진다. 
            this.Size = new Size(1024, 728);
            m_CtlSizeManager = new ControlManager(this);

            //종횡 늘림
            m_CtlSizeManager.addControlMove(metroPanel2, false, false, true, true);
            m_CtlSizeManager.addControlMove(metroPanel3, false, false, true, true);
            m_CtlSizeManager.addControlMove(metroPanel4, false, false, true, true);

            m_CtlSizeManager.addControlMove(pIssuePanel, false, false, true, true);
            m_CtlSizeManager.addControlMove(pSearchPanel, false, false, true, true);
            m_CtlSizeManager.addControlMove(pPreferencesPanel, false, false, true, true);

            //종늘림
            m_CtlSizeManager.addControlMove(TIL_LINE_1, false, false, false, true);
            m_CtlSizeManager.addControlMove(TIL_EMPTY_1, false, false, false, true);

            //종이동
            m_CtlSizeManager.addControlMove(TIL_USERNAME, false, true, false, false);
            m_CtlSizeManager.addControlMove(TIL_NETWORK, false, true, false, false);

            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();

            TIL_VER.Text = "ver." + Properties.Resources.appVer;

            //환경설정 안되어 있으면 설정
            if (Constants.TML_ID.Equals(string.Empty))
            {
                MetroMessageBox.Show(this, Constants.getMessage("SYSTEM_INIT"), "SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TIL_PRE_Click(null, null);
            }
            else
            {
                TIL_SHOP_NAME.Text = Constants.SHOP_NAME;
                TIL_ISSUE_Click(null, null);
                //if (Constants.TML_ID != null && !"".Equals(Constants.TML_ID))
                //{
                //    JObject sendObj = new JObject();
                //    sendObj.Add("tml_id", Constants.TML_ID);
                //    Transaction tran = new Transaction();
                //    JArray arrRet = tran.sendServer_arr(sendObj.ToString(), tran.url_TmlInfo);
                //    if (arrRet != null && arrRet.Count > 0)
                //    {
                //        TIL_SHOP_NAME.Text = arrRet[0]["shop_name"].ToString()+" ";
                //    }
                //}
            }


        }

        private void TIL_ISSUE_Click(object sender, EventArgs e)
        {
            if (Constants.TML_ID.Equals(string.Empty))
            {
                MetroMessageBox.Show(this, Constants.getMessage("SYSTEM_INIT"), "SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            metroPanel2.Visible = true;
            metroPanel3.Visible = false;
            metroPanel4.Visible = false;
            metroPanel2.Refresh();

            //포커스 자동 입력
            for (int i = 0; i < metroPanel2.Controls.Count; i++)
            {
                if (metroPanel2.Controls[i] is IssuePanel)
                {
                    ((IssuePanel)metroPanel2.Controls[i]).Controls["BTN_SCAN"].Focus();
                }
            }
        }

        private void TIL_SEARCH_Click(object sender, EventArgs e)
        {
            if(Constants.TML_ID.Equals(string.Empty))
            {
                MetroMessageBox.Show(this, Constants.getMessage("SYSTEM_INIT"), "SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            metroPanel3.Visible = true;
            metroPanel2.Visible = false;
            metroPanel4.Visible = false;
            metroPanel3.Refresh();
        }

        private void TIL_PRE_Click(object sender, EventArgs e)
        {

            MessageSmallForm tt = new MessageSmallForm("환경설정 비밀번호를 입력하세요",  null);

            DialogResult bResult = tt.ShowDialog(this);
            if (bResult != DialogResult.OK)
            {
                if (Constants.TML_ID.Equals(string.Empty))
                {
                    Application.ExitThread();
                    Environment.Exit(0);
                }else
                {
                    return;//그냥 반환
                }
            }

            //암호 입력 팝업 호출
            //정상이면 화면전환, 아니면 반환
            metroPanel4.Visible = true;
            metroPanel2.Visible = false;
            metroPanel3.Visible = false;
            metroPanel4.Refresh();
        }

        private void initConstant()
        {
            Constants.PASSPORT_TYPE = 1;
        }

        private void Main2_SizeChanged(object sender, EventArgs e)
        {
            if (m_CtlSizeManager != null)
                m_CtlSizeManager.MoveControls();
            this.Refresh();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            //while (true)
            //{
            //    System.Threading.Thread.Sleep(1000);

            //    if (Constants.LOGIN_YN && Constants.LDB_MANAGER != null)
            //    {
            //        //break;

            //        Transaction tran = new Transaction();
            //        JArray arrData = null;
            //        arrData = tran.SearchSlips("20170101", "29990101", "N", "02");
            //        if (arrData != null && arrData.Count > 0)
            //        {
            //            for (int i = 0; i < arrData.Count; i++)
            //            {
            //                if(tran.Submit( tran.BuildSlipDoc(((JObject)arrData[i])["SLIP_NO"].ToString())))
            //                {
            //                    JObject jsonWhere = new JObject();
            //                    JObject jsonUpdate = new JObject();
            //                    jsonUpdate.Add(Constants.SEND_FLAG, "Y");
            //                    jsonWhere.Add("SLIP_NO", ((JObject)arrData[i])["SLIP_NO"].ToString());
            //                    tran.UpdateSlip(jsonWhere, jsonUpdate);
            //                    jsonWhere.RemoveAll();
            //                    jsonUpdate.RemoveAll();
            //                    jsonWhere = null;
            //                    jsonUpdate = null;
            //                }
            //                // tran.send
            //            }
            //            arrData.RemoveAll();
            //        }
                    
            //        arrData = null;
            //        tran = null;
            //    }
            //}
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (true)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    if (m_bLogin && Constants.CODE_DOWNLOAD && m_bBin) //만약 다시 시도하더라도 에러 처리.
            //        break;
            //    if (Constants.LOGIN_YN && !m_bLogin && pIssuePanel != null)
            //    {
            //        m_bLogin = true;
            //        try {
            //            if (!Constants.CODE_DOWNLOAD)
            //            {
            //                Constants.CODE_DOWNLOAD = true;
            //                pIssuePanel.ASyncTran("code");
            //            }
            //            if (!m_bBin)
            //            {
            //                m_bBin = pIssuePanel.ASyncTran("bin");
            //            }
            //        }
            //        catch(Exception ex)
            //        {
            //            Constants.LOGGER_MAIN.Info(ex.StackTrace);
            //            Constants.LOGGER_MAIN.Info(ex.Message);
            //        }
            //        finally
            //        {
                        
            //        }
            //        break;
            //    }
            //}
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            Transaction tran = new Transaction();
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                //ping 성공
                try
                {
                    if (tran.checkNetworkStatus())
                    {
                        TIL_NETWORK.Invoke((MethodInvoker)delegate
                        {
                            this.TIL_NETWORK.TileImage = global::GTF_STFM.Properties.Resources.appbar_network_home;
                            Constants.ONLINE_STATUS = true;
                            TIL_NETWORK.Text = "ONLINE";
                            TIL_NETWORK.ForeColor = Color.FromArgb(255, 255, 255);
                        });
                    }
                    else
                    {
                        TIL_NETWORK.Invoke((MethodInvoker)delegate
                        {
                            this.TIL_NETWORK.TileImage = global::GTF_STFM.Properties.Resources.appbar_network_home_disconnect;
                            Constants.ONLINE_STATUS = false;
                            TIL_NETWORK.Text = "OFFLINE";
                            TIL_NETWORK.ForeColor = Color.FromArgb(255, 216, 0);
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

        }
        private void Main2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, Constants.getMessage("SYSTEM_EXIT_CONFIRM"), "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        Application.ExitThread();
                        Environment.Exit(0);
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
                return;
            }
            if (this.DialogResult == DialogResult.Cancel)
            {
                // Assume that X has been clicked and act accordingly.
                // Confirm user wants to close
                switch (MessageBox.Show(this,Constants.getMessage("SYSTEM_EXIT_CONFIRM"), "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        Application.ExitThread();
                        Environment.Exit(0);
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void Main2_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TIL_CLOSE_Click(object sender, EventArgs e)
        {
            FormClosingEventArgs e2 = new FormClosingEventArgs(CloseReason.UserClosing, false);
            Main2_FormClosing(null, e2);
        }
    }
}
