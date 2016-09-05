using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MysteryBoxWorkaround
{

    static class Program
    {
        public static GUI MainForm;
        public static Safetycs Safetyfrm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new GUI();
            Safetyfrm = new Safetycs();
            Application.Run(MainForm);
        }
    }
}
