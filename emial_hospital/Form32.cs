using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace emial_hospital
{
    public partial class Form32 : Form
    {

        public Form32()
        {
            InitializeComponent();

            getAllUsers();
        }

        public void getAllUsers() 
        {
            dataGridView1.Rows.Clear();

            ArrayList list = DBase.getAllLoginUsers();

            for (int i = 0; i < list.Count;i++ ) 
            {
                Hashtable gg = list[i] as Hashtable;

                if(gg["login"].Equals(gg["logout"]))
                {
                    gg["logout"] = "";
                }

                dataGridView1.Rows.Add(new string[] { gg["name"].ToString(), gg["login"].ToString(), gg["logout"].ToString() });
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}