using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDatSanBongDaMini
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            //Application.Run(new DangNhap());
            //Application.Run(new DatSan());
            Application.Run(new QuanLyHoaDon());
=======
            Application.Run(new DangNhap());

>>>>>>> 09e15ed8fed09e89ba3e0e46e39261c49ba8f52e
        }
    }
}
