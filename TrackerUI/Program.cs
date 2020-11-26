using System;
using System.Windows.Forms;
using Tracker_Library;

namespace TrackerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Database Connections
            Tracker_Library.GlobalConfig.InitializeConnections(DatabaseType.TextFile);

            Application.Run(new CreatePrizeForm());
            // Application.Run(new TournamentDashboardForm());
        }
    }
}
