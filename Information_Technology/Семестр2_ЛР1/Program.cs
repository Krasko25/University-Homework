using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Семестр2_ЛР1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthentificationForm f = new AuthentificationForm();

            //Application.Run(new AuthentificationForm());

            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new OrganiserForm());
            }
        }
    }
}
