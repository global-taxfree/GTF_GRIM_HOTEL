using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GTF_STFM.Screen;
using System.Diagnostics;

namespace GTF_STFM
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {

            foreach (var process in Process.GetProcessesByName("GTFS_U.exe"))
            {
                process.Kill();
            }

            if (!checkSingleInstance())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Main());
                MetroFramework.Forms.MetroForm mainForm = new Main2();
                //MetroFramework.Forms.MetroForm mainForm = new Login();
                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
           

        }
        static Boolean checkSingleInstance()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            // get the list of all processes by that name

            Process[] processes = Process.GetProcessesByName(procName);

            if (processes.Length > 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
