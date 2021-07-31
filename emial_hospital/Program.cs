using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace emial_hospital
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

            Application.Run(new Form36());

            Form35 dd = new Form35();

            if (dd.chech())
            {
                Application.Run(new Form19());
            }
            else
            {
                Application.Run(dd);
            }

        }

    }
}