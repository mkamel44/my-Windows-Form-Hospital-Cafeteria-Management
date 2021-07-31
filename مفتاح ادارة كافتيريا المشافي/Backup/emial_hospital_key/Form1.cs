using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Globalization;

namespace emial_hospital_key
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox2.Text = getSID();
                }
                else
                {
                    MessageBox.Show("الرجاء التأكد من ادخال الرقم", "خطأ");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ان الرقم الذي أدخلته خاطئ", "خطأ");
            }
        }

        private void save()
        {
            RegistryKey win32 = Registry.CurrentUser.CreateSubKey("win32");
            win32.SetValue("win", getTID());
        }

        public bool chech()
        {
            RegistryKey win32 = Registry.CurrentUser.OpenSubKey("win32");
            if (win32 != null)
            {
                string ss = (string)win32.GetValue("win");
                if (ss != null)
                {
                    if (ss.Equals(getTID()))
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }


        public string getTID()
        {

            string gg = getSID();

            Int64 ss = Int64.Parse(gg);

            ss = ss * 876;

            ss = ss / 111;

            string sss = "" + ss;

            if (sss.Length > 10)
            {
                sss = sss.Substring(0, 10);
            }


            return sss;
        }


        private string getSID()
        {

            string gg = textBox1.Text;

            Int64 ss = Int64.Parse(gg);

            ss = ss * 876;

            ss = ss / 111;

            string sss = "" + ss;

            if (sss.Length > 10)
            {
                sss = sss.Substring(0, 10);
            }


            return sss;
        }


        private string getFID()
        {
            string result = "";

            string num = GetVolumeSerial().Trim();
            char[] tt = num.ToCharArray(0, num.Length);
            for (int i = 0; i < tt.Length; i++)
            {

                Int64 ii = tt[i];

                result += ii;


            }

            if (result.Length > 15)
            {
                result = result.Substring(0, 15);
            }


            Int64 nom = Int64.Parse(result, NumberStyles.HexNumber);

            string sss = "" + nom;

            if (sss.Length > 10)
            {

                sss = sss.Substring(0, 10);

            }


            return sss;
        }

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        public string GetVolumeSerial()
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            string strDriveLetter = "C:\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            return Convert.ToString(Math.Abs(serNum));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }


    public class HardDrive
    {
        private string model = null;
        private string type = null;
        private string serialNo = null;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
    }
}
