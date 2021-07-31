using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace emial_hospital
{
    public partial class Form30 : Form
    {

        public Form30()
        {
            InitializeComponent();

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;

            ArrayList list = DBase.getAllUsers();

            for (int i = 0; i < list.Count; i++)
            {
                lolo ss = new lolo();

                ss.tabe = ((Hashtable)list[i]);

                comboBox1.Items.Add(ss);

                comboBox1.SelectedIndex = 0;
            }

            list = DBase.getAllPeople();

            for (int i = 0; i < list.Count; i++)
            {
                lolo ss = new lolo();
                ss.tabe = ((Hashtable)list[i]);

                comboBox2.Items.Add(ss);

                comboBox2.SelectedIndex = 0;
            }

            list = DBase.getAllReq();

            for (int i = 0; i < list.Count; i++)
            {
                comboBox4.Items.Add(list[i] as lolo);

                comboBox4.SelectedIndex = 0;
            }

            dateTimePicker1.Text = DateTime.Now.AddDays(0).ToString();

            dateTimePicker2.Text = DateTime.Now.AddDays(1).ToString();

            comboBox3.SelectedIndex = 0;

        }

        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Hashtable tb = ((Hashtable)lvFolders.SelectedItems[0].Tag);

                Form38 ff = new Form38(tb);

                ff.ShowDialog(this);
            }
            catch (Exception yy) { }
        }

        public void jojo()
        {
            //----

            double allhader = 0;

            ArrayList list = DBase.getAllMHader();

            for (int i = 0; i < list.Count; i++)
            {

                ArrayList list2 = ((list[i] as Hashtable)["qcm"]) as ArrayList;

                for (int ii = 0; ii < list2.Count; ii++)
                {
                    Hashtable tt = list2[ii] as Hashtable;

                    allhader += double.Parse(tt["cost"].ToString());
                }

            }

            //----

            double allhader2 = 0;

            double allhader3 = 0;

            Form30 ww = new Form30();

            ww.search("select * from bill where opened='true'");

            for (int yy = 0; yy < ww.lvFolders.Items.Count; yy++)
            {

                Hashtable ttt = ww.lvFolders.Items[yy].Tag as Hashtable;

                Form38 rr = new Form38(ttt);

                allhader2 += double.Parse(rr.textBox7.Text);

                allhader3 += double.Parse(rr.textBox8.Text);

            }

            //----

            double allhader4 = 0;

            Form30 www = new Form30();

            www.search("select * from bill where opened='false'");

            for (int yy = 0; yy < www.lvFolders.Items.Count; yy++)
            {

                Hashtable ttt = www.lvFolders.Items[yy].Tag as Hashtable;

                Form38 rr = new Form38(ttt);

                allhader4 += double.Parse(rr.textBox7.Text);

            }

            double gg = allhader + allhader2 + allhader3;

            string hh = "-" + gg;

            gg = double.Parse(hh);

            MessageBox.Show("مبلغ الهدر هو : " + (gg + allhader4));

        }


        public void search(string sql)
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllBillByQueary(sql);

            double ee = 0;

            int ee1 = 0;

            double ee2 = 0;

            int number = 0;

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["num"].ToString();
                item.ImageIndex = 1;
                item.Tag = list[i];

                if (checkBox1.Checked)
                {
                    Form38 dd = new Form38((Hashtable)list[i], ((lolo)comboBox4.SelectedItem).tabe["id"].ToString());

                    number += dd.number;
                }


                Hashtable tbbb = (Hashtable)list[i];

                ArrayList list2 = ((ArrayList)tbbb["billq"]);

                for (int ii = 0; ii < list2.Count; ii++)
                {
                    Hashtable tt = ((Hashtable)list2[ii]);

                    Hashtable dd = DBase.getReq_back(tt["bill_id"].ToString(), tt["req_id"].ToString());

                    ee += (double.Parse(tt["q"].ToString()) * double.Parse(tt["cost"].ToString()));

                    ee1 += int.Parse(dd["hader"].ToString()) * int.Parse(tt["q"].ToString());

                    Form20 ff = new Form20();

                    ff.forUpdate2(tt["bill_id"].ToString(), dd);

                    ee2 += double.Parse(doSumAll(tt, ff, list2));


                }

                lvFolders.Items.Add(item);

            }


            textBox2.Text = ee.ToString("#.####");

            textBox3.Text = ee1.ToString("#.####");

            textBox4.Text = ee2.ToString("#.####");

            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                textBox5.Text = (double.Parse(textBox2.Text) - double.Parse(textBox3.Text) - double.Parse(textBox4.Text)).ToString("#.####");
            }

            if (checkBox1.Checked)
            {
                MessageBox.Show("العدد من هذه المادة هو : " + number);
            }
        }

        public string doSumAll(Hashtable tt, Form20 ff, ArrayList list2)
        {
            int qq = 0;

            ArrayList list = new ArrayList();

            for (int i = 0; i < list2.Count; i++)
            {
                Hashtable ttt = ((Hashtable)list2[i]);

                list.Add(ttt["req_id"].ToString());
            }

            for (int i = 0; i < list.Count; i++)
            {
                string uu = list[i].ToString();

                if (uu.Equals(tt["req_id"].ToString()))
                {
                    ++qq;
                }

            }

            return ((double.Parse(tt["q"].ToString()) * double.Parse(ff.textBox2.Text)) / qq).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new Thread(new ThreadStart(lolo)).Start();
            lolo();
        }

        public void lolo()
        {
            string ss = "select * from bill where 1=1 ";

            if (checkBox2.Checked)
            {
                ss += " and user_id=" + ((lolo)comboBox1.SelectedItem).tabe["id"].ToString() + " ";
            }

            if (checkBox3.Checked)
            {
                ss += " and person_id=" + ((lolo)comboBox2.SelectedItem).tabe["id"].ToString() + " ";
            }

            if (checkBox6.Checked)
            {
                ss += " and datee BETWEEN #" + dateTimePicker1.Text + "# and #" + dateTimePicker2.Text + "# ";
            }

            if (checkBox4.Checked)
            {
                ss += " and opened='" + (comboBox3.SelectedIndex == 0 ? "false" : "true") + "' ";
            }

            ss += " order by id";

            search(ss);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(jojo)).Start();
            //jojo();
        }

    }
}