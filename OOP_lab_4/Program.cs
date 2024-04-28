using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_lab_4
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
            FormMain mainForm = new FormMain();
            Application.Run(mainForm);
            // Panel panel2 = new Panel();
            // panel2.Width = 1500;
            // panel2.Height = 700;
            // panel2.Location = new Point(0, 0);
            // mainForm.Controls.Add(panel2);
            // mainForm.g = mainForm.panel2.CreateGraphics();
            // mainForm.DrawObjects();
            
        }
    }
}