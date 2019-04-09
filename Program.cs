using System;
using System.Windows.Forms;

namespace ComputerConstructor
{
    internal static class Program
    {
        public static MainForm mainForm;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm = new MainForm());
        }
    }
}
