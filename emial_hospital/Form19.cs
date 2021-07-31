using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace emial_hospital
{
    public partial class Form19 : Form
    {
        public static Hashtable login_user = null;

        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login_user = DBase.checkUserNameAndPass(textBox1.Text, textBox2.Text);

            if (login_user.Count == 0)
            {
                MessageBox.Show("الرجاء التأكد من الاسم وكلمة السر");
            }
            else
            {
                textBox1.Text = "";

                textBox2.Text = "";

                Visible = false;

                DBase.addLogin(login_user["id"].ToString());

                if (login_user["typeme"].Equals("0"))
                {
                    Form1 ff = new Form1(this);

                    ff.ShowDialog();
                }
                else
                {
                    Form22 ff = new Form22(this);

                    ff.button3.Text = "تسجيل الخروج";

                    ff.button3.Size = new System.Drawing.Size(132, 44);

                    ff.ShowDialog();
                }


            }
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            string hhh = Path.GetDirectoryName(Application.ExecutablePath);

            if (!Directory.Exists("backup_db"))
            {
                Directory.CreateDirectory(hhh + "\\backup_db");
            }

            string jj = DBase.getMyDateWithSeconds() + " dbase.mdb";

            jj = jj.Replace(":", "and");

            jj = jj.Replace("/", "-");

            jj = jj.Replace(" ", "_");

            string uu = hhh + "\\backup_db\\" + jj;

            if (File.Exists(uu))
            {
                File.Delete(uu);
            }

            File.Copy("dbase.mdb", uu);

            if (Directory.Exists("backup_db"))
            {
                string[] ss = Directory.GetFiles("backup_db");

                int backup_number = 3;

                if (ss.Length > (backup_number - 1))
                {
                    int y = ss.Length - backup_number;

                    for (int i = 0; i < y; i++)
                    {
                        File.Delete(hhh + "\\" + ss[i]);
                    }
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                string hhh = Path.GetDirectoryName(Application.ExecutablePath);

                if (!Directory.Exists("copy_of_db"))
                {
                    Directory.CreateDirectory(hhh + "\\copy_of_db");
                }

                if (Directory.Exists(hhh + "\\copy_of_db\\dbase.mdb"))
                {
                    File.Delete(hhh + "\\copy_of_db\\dbase.mdb");
                }

                File.Copy("dbase.mdb", hhh + "\\copy_of_db\\dbase.mdb");
            }
            catch (Exception eee) { }

        }


    }
}