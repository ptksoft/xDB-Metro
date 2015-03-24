using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ZiCure.Log;

namespace xDB2013
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!BaseInitial())
            {
                Console.WriteLine("Cannot INIT BaseInitial()!!!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        static bool BaseInitial()
        {
            //--------- Check UDP Bind Port
            if (!that.CheckRunningInstant_UseUdpBind())
            {
                Console.WriteLine("Application already running (Cannot Bind UDP)");
                return (false);
            }

            //---------- Initalize ZiCureLog
            zLog.isWriteClient = false;
            zLog.isWriteConsole = false;
            zLog.isWriteServer = false;
            zLog.isWriteFile = true;
            if (!zLog.Start())
            {
                Console.WriteLine("Cannot Startup zLOG component!");
                return (false);
            }

            //------------ Clear Old LOG File
            int totalFileClear = zLog.ClearOldLogFile(3);
            zLog.Write("Clear Older Log File = " + totalFileClear.ToString());
            if (totalFileClear < 0) zLog.WriteError("zLog.LastError: " + zLog.LastError);

            //------------- Initialize Config
            if (!that.InitConfig())
            {
                zLog.WriteCritical("Cannot Init Config File/Folder");
                return (false);
            }

            //------------- Initialize PeerToPeer Module
            //if (!P2P.Initialize())
            //{
            //    zLog.WriteCritical("Cannot Init P2P Module");
            //    return (false);
            //}

            //============= Everything OK
            return (true);
        }
    }
}
