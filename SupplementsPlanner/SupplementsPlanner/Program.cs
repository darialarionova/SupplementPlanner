using System;
using System.Windows.Forms;
using SupplementsPlanner.Service;

namespace SupplementsPlanner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var service = new RelationInformationService();
            service.SetSupplementsRelationInformation();
        }
    }
}
