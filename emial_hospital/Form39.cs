using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace emial_hospital
{
    public partial class Form39 : Form
    {

        public int myid = 0;

        public Form39()
        {
            InitializeComponent();

            getAll();
        }

        public void getAll()
        {
            ArrayList list = DBase.getAllParts2();

            lolo sss = new lolo();

            sss.end = 0;

            sss.tabe["name"] = "الروت";

            comboBox1.Items.Add(sss);

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                lolo ss = new lolo();

                ss.end = int.Parse(tb["id"].ToString());

                ss.tabe["name"] = tb["name"].ToString();

                comboBox1.Items.Add(ss);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lolo kk = comboBox1.SelectedItem as lolo;

            DBase.updateMPart(myid.ToString(), kk.end.ToString());

            Close();
        }
    }
}