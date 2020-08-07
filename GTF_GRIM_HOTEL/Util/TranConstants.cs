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

namespace GTF_STFM.Util
{
    public class TranConstants
    {
        //거래 KEY

        //거래 VALUE
        //거래 파라미터 정의
        public static string PATH_ROOT = "/../";
        public static string PATH_CONFIG = "/./Config/";
        public static string PATH_DB = "/./DB/";

        public static string PATH_CONFIG_FILE = "Config.xml";   //CONFIG 파일명
        public static string PATH_DB_FILE = "STFM.accdb";       //LOCAL DB 파일명

        public static string SYSTEM_LANGUAGE = "KO";            //기본 설정 언어
        public static int PASSPORT_TYPE = -1;                   //여권스캐너
        public static string PRINTER_TYPE = string.Empty;       //프린터 명
        public static string PRINTER_OPOS_TYPE = string.Empty;  //OPOS 연결 프린터 명
        public static int SLIP_TYPE = -1;                       //출력전표 종류

        public static string TML_ID = string.Empty;             //단말기 ID
        public static string USER_ID = string.Empty;            //사용자 ID
        public static string USER_AUTH = string.Empty;          //사용자권한

        public static Boolean IS_DEV { get; set; }              //개발여부

        public static string SERVER_URL { get; set; }           //서버 URL
        public static string SERVER_IP { get; set; }            //서버 IP
        public static string SERVER_PORT { get; set; }          //서버 PORT(TCP/IP)


        public TranConstants()
        {
           

        }
    }
}
