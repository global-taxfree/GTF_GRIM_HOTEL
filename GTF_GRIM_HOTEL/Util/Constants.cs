using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using GTF_Config;
using System.Windows.Forms;
using GTF_LocalDB;
using MetroFramework;
using System.IO;
using GTF_STFM.Tran;
using Newtonsoft.Json.Linq;

namespace GTF_STFM.Util
{
    public class Constants
    {
        //경로
        public static string PATH_ROOT = "/../";
        public static string PATH_CONFIG = "/./Config/";
        public static string PATH_DB = "/./DB/";
        public static string PATH_TEMP = "/./TEMP/";

        public static string PATH_CONFIG_FILE = "Config.xml";   //CONFIG 파일명
        public static string PATH_DB_FILE = "STFM.accdb";       //LOCAL DB 파일명
        //public static string PATH_DB_FILE = "STFM.mdb";       //LOCAL DB 파일명

        public static string SYSTEM_LANGUAGE = "KO";            //기본 설정 언어
        //public static int PC_NO = -1;                           //일본(PC번호)
        public static int PASSPORT_TYPE = -1;                   //여권스캐너

        public static int PRINTER_SELECT_TYPE = -1;       //프린터 종류. 0 일반프린터, 1영수증 프린터

        public static string PRINTER_TYPE = string.Empty;       //프린터 명
        public static string PRINTER_OPOS_TYPE = string.Empty;  //OPOS 연결 프린터 명
        public static string SLIP_TYPE = string.Empty;                       //출력전표 종류

        public static int SIGN_PAD_TYPE =  -1;                       //출력전표 종류
        //2019.10.31 추가
        public static int STANDARD_SELL_PRICE = 0;              //일반룸 가격 세팅
        public static int SUITE_SELL_PRICE = 0;                 //스위트룸 가격 세팅

        public static string TML_ID = string.Empty;             //단말기 ID
        public static string USER_ID = string.Empty;            //사용자 ID
        public static string DESK_ID = string.Empty;            //데스크 ID

        public static string COMPANY_ID = "000001";             //회사 ID
        public static string LANGUAGECD = "jp";                 //언어구분
        public static string USER_AUTH = string.Empty;          //사용자권한
        public static string MERCHANT_NO = string.Empty;        //매장번호

        public static string OPEN_DATE = string.Empty;          //로그인 날짜

        public static Boolean IS_DEV { get; set; }              //개발여부

        public static string SERVER_URL { get; set; }           //서버 URL
        public static string SERVER_IP { get; set; }            //서버 IP
        public static string SERVER_PORT { get; set; }          //서버 PORT(TCP/IP)

        //logger 생성
        public static ILog LOGGER_DOC { get; set; }             //전문 로그
        public static ILog LOGGER_SCREEN { get; set; }          //화면 액션 로그
        public static ILog LOGGER_MAIN { get; set; }            //전체 로그
        public static GTF_ConfigManager CONF_MANAGER;           //Config Manager
        public static GTF_LocalDBManager LDB_MANAGER;           //Local DB Manager

        public static Boolean LOGIN_YN { get; set; }            //로그인여부
        public static Boolean CODE_DOWNLOAD { get; set; }       //코드데이터 다운로드 여부

        public static int SLIP_SEQ = 0;                         //전표 발행 순번

        public static string TABLE_REFUND_SLIP = "REFUNDSLIP";
        public static string TABLE_SALES_GOODS = "SALES_GOODS";
        public static string SEND_FLAG = "SEND_FLAG";
        public static string PRINT_CNT = "PRINT_CNT";
        public static string FLAG_ALL = "ALL";

        public static Boolean ONLINE_STATUS = false;          //온라인 여부

        public static Boolean PASSPORT_SCAN_OPEN = false;

        public static string filePath_QR = "";
        public static string filePath_LOGO = "";
        public static string filePath_ROUND_LOGO = "";
        public static string filePath_ROUND_LOGO_NORMAL = "";
        public static string filePath_Combine = "";
        public static string filePath_Sign = "";
        public static string SHOP_NAME = "";                       //매장명

        public static JArray ARR_RATE_INFO = null;                 //환급율

        public Constants(Control cParent)
        {
            try {
                ONLINE_STATUS = false;
                LOGIN_YN = false;
                CODE_DOWNLOAD = false;
                string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                PATH_ROOT = appPath + PATH_ROOT;
                PATH_CONFIG = PATH_ROOT + PATH_CONFIG;
                PATH_DB = PATH_ROOT + PATH_DB;
                ////로컬 DB 폴더
                if (!System.IO.Directory.Exists(PATH_DB))
                    System.IO.Directory.CreateDirectory(PATH_DB);
                //TEMP 폴더
                PATH_TEMP = PATH_ROOT + PATH_TEMP;
                if (!System.IO.Directory.Exists(PATH_TEMP))
                    System.IO.Directory.CreateDirectory(PATH_TEMP);

                PATH_CONFIG_FILE = PATH_CONFIG + PATH_CONFIG_FILE;
                //PATH_CONFIG_FILE = "C:/Users/GTF_HCH/workspace/GTF_GRIM_HOTEL/GTF_GRIM_HOTEL/Config/Config.xml";
                PATH_DB_FILE = PATH_DB + PATH_DB_FILE;

                LOGGER_DOC = log4net.LogManager.GetLogger("DOC");
                LOGGER_SCREEN = log4net.LogManager.GetLogger("SCREEN");
                LOGGER_MAIN = log4net.LogManager.GetLogger("MAIN");
                log4net.Config.BasicConfigurator.Configure();

                CONF_MANAGER = GTF_ConfigManager.Instance(LOGGER_MAIN);
                if (!CONF_MANAGER.loadAppConfig(PATH_CONFIG_FILE))
                {
                    MessageBox.Show(cParent, "환결설정 파일을 읽을 수 없습니다.", "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.ExitThread();
                    Environment.Exit(0);
                    return;
                }
                LDB_MANAGER = GTF_LocalDBManager.Instance(LOGGER_MAIN);
                if (!LDB_MANAGER.dbOpen(PATH_DB_FILE))
                {
                    MessageBox.Show(cParent, "로컬 DB 파일을 읽을 수 없습니다.", "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.ExitThread();
                    Environment.Exit(0);
                    return;
                }

                //환경설정 읽음
                TML_ID = LDB_MANAGER.selectConfigData("TML_ID");
                PASSPORT_TYPE = string.Empty.Equals(LDB_MANAGER.selectConfigData("PASSPORT_TYPE")) ? -1 : Int32.Parse(LDB_MANAGER.selectConfigData("PASSPORT_TYPE"));

                PRINTER_SELECT_TYPE = string.Empty.Equals(LDB_MANAGER.selectConfigData("PRINTER_SELECT_TYPE")) ? -1 : Int32.Parse(LDB_MANAGER.selectConfigData("PRINTER_SELECT_TYPE"));

                SIGN_PAD_TYPE = string.Empty.Equals(LDB_MANAGER.selectConfigData("SIGN_PAD_TYPE")) ? -1 : Int32.Parse(LDB_MANAGER.selectConfigData("SIGN_PAD_TYPE"));

                SHOP_NAME = LDB_MANAGER.selectConfigData("SHOP_NAME");
                STANDARD_SELL_PRICE = string.Empty.Equals(LDB_MANAGER.selectConfigData("STANDARD_SELL_PRICE")) ? 0 : Int32.Parse(LDB_MANAGER.selectConfigData("STANDARD_SELL_PRICE"));       //2019.10.31 추가
                SUITE_SELL_PRICE = string.Empty.Equals(LDB_MANAGER.selectConfigData("SUITE_SELL_PRICE")) ? 0 : Int32.Parse(LDB_MANAGER.selectConfigData("SUITE_SELL_PRICE"));    //2019.10.31 추가

                PRINTER_TYPE = LDB_MANAGER.selectConfigData("PRINTER_TYPE");
                PRINTER_OPOS_TYPE = LDB_MANAGER.selectConfigData("PRINTER_OPOS_TYPE");
                SLIP_TYPE = LDB_MANAGER.selectConfigData("SLIP_TYPE");

                //SYSTEM_LANGUAGE = CONF_MANAGER.getAppValue("DEFAULT_LANG"); //터미널 기본언어 세팅
                IS_DEV = "Y".Equals(CONF_MANAGER.getAppValue("DEV"));       //개발여부
                SERVER_URL = CONF_MANAGER.getAppValue("SERVER_URL");
                SERVER_IP = CONF_MANAGER.getAppValue("SERVER_IP");
                SERVER_PORT = CONF_MANAGER.getAppValue("SERVER_PORT");


                //국가별 화면 디스크립트 load
                CONF_MANAGER.loadCustomConfig("ScreenText", PATH_CONFIG + "ScreenText.xml");
                //국가별Message load
                CONF_MANAGER.loadCustomConfig("Message", PATH_CONFIG + "Message.xml");

                filePath_QR = Directory.GetCurrentDirectory() + "/../Image/gtf_qr.bmp";
                filePath_LOGO = Directory.GetCurrentDirectory() + "/../Image/gtf_logo.bmp";
                filePath_ROUND_LOGO = Directory.GetCurrentDirectory() + "/../Image/gtf_logo_round.bmp";

                filePath_ROUND_LOGO_NORMAL = Directory.GetCurrentDirectory() + "/../Image/gtf_logo_round_normal.bmp";
                filePath_Combine = Directory.GetCurrentDirectory() + "/../Image/combine_QR.jpg";
                filePath_Sign = Directory.GetCurrentDirectory() + "/../Image/signprint.jpg";
                Boolean bInit = false;
                //환급율 조회
                try {
                    
                    Transaction tran = new Transaction();
                    JObject obj = new JObject();
                    obj.Add("tax_type_code", "1");
                    JArray rateArr = tran.sendServer_arr(obj.ToString(), tran.url_RefundRate, 60, false);
                    if(rateArr != null && rateArr.Count > 0)
                    {
                        ARR_RATE_INFO = rateArr;
                        bInit = true;
                    }
                    else
                    {
                        bInit = false;
                    }
                    
                }
                catch(Exception ee)
                {
                    bInit = false;
                }
                finally
                {
                    if (!bInit)
                    {
                        MessageBox.Show(cParent, "\n초기 기동에 실패하였습니다. \n계속해서 동일한 현상이 발생하면 네트워크 상태를 확인해보시기 바랍니다.", "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.ExitThread();
                        Environment.Exit(0);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(cParent, "\n초기 기동에 실패하였습니다. \n계속해서 동일한 현상이 발생하면 네트워크 상태를 확인해보시기 바랍니다.", "Config", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Debug.WriteLine("에러 : " + ex);
                Application.ExitThread();
                Environment.Exit(0);
                return;
            }
        }
        public static string getMessage(string strKey)
        {
           return CONF_MANAGER.getCustomValue("Message", Constants.SYSTEM_LANGUAGE + "/" + strKey).Replace("\\n", System.Environment.NewLine);
        }

        public static string getScreenText(string strKey)
        {
            return CONF_MANAGER.getCustomValue("ScreenText", Constants.SYSTEM_LANGUAGE + "/" + strKey).Replace("\\n", System.Environment.NewLine);
        }
    }
}
