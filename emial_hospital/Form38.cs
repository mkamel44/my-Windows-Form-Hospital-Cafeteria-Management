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
    public partial class Form38 : Form
    {
        public int number = 0;

        public Form38(Hashtable list,string num32)
        {

            InitializeComponent();

            textBox1.Text = list["num"].ToString();

            textBox4.Text = list["person_id"].ToString().Equals("0") ? "البيع مباشر" : " بواسطة " + DBase.getPeople(list["person_id"].ToString())["name"].ToString();

            textBox6.Text = DBase.getUser(list["user_id"].ToString())["name"].ToString();

            textBox3.Text = list["notee"].ToString();

            textBox5.Text = (list["opened"].ToString().Equals("false") ? "فاتورة عادية" : "فاتورة هدر");

            ArrayList list2 = ((ArrayList)list["billq"]);

            for (int i = 0; i < list2.Count; i++)
            {
                Hashtable tt = ((Hashtable)list2[i]);

                Hashtable dd = DBase.getReq_back(tt["bill_id"].ToString(), tt["req_id"].ToString());

                Form20 ff = new Form20();

                ff.forUpdate2(tt["bill_id"].ToString(), dd);

                if(num32.Equals(dd["id"].ToString()))
                {
                    number += int.Parse(tt["q"].ToString());
                }

                dataGridView1.Rows.Add(new string[] { dd["name"].ToString(), tt["q"].ToString(), (double.Parse(tt["q"].ToString()) * double.Parse(tt["cost"].ToString())).ToString(), (int.Parse(dd["hader"].ToString()) * int.Parse(tt["q"].ToString())).ToString(), doSumAll(tt, ff, list2) });
            }

            double uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[2].Value.ToString());
            }

            textBox2.Text = uu.ToString();

            uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[3].Value.ToString());
            }

            textBox7.Text = uu.ToString();

            uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[4].Value.ToString());
            }

            textBox8.Text = uu.ToString();

        }

        public Form38(Hashtable list)
        {

            InitializeComponent();

            textBox1.Text = list["num"].ToString();

            textBox4.Text = list["person_id"].ToString().Equals("0") ? "البيع مباشر" : " بواسطة " + DBase.getPeople(list["person_id"].ToString())["name"].ToString();

            textBox6.Text = DBase.getUser(list["user_id"].ToString())["name"].ToString();

            textBox3.Text = list["notee"].ToString();

            textBox5.Text = (list["opened"].ToString().Equals("false") ? "فاتورة عادية" : "فاتورة هدر");

            ArrayList list2 = ((ArrayList)list["billq"]);

            for (int i = 0; i < list2.Count; i++)
            {
                Hashtable tt = ((Hashtable)list2[i]);

                Hashtable dd = DBase.getReq_back(tt["bill_id"].ToString(), tt["req_id"].ToString());

                Form20 ff = new Form20();

                ff.forUpdate2(tt["bill_id"].ToString(),dd);

                dataGridView1.Rows.Add(new string[] { dd["name"].ToString(), tt["q"].ToString(), (double.Parse(tt["q"].ToString()) * double.Parse(tt["cost"].ToString())).ToString(), (int.Parse(dd["hader"].ToString()) * int.Parse(tt["q"].ToString())).ToString(), doSumAll(tt, ff, list2) });
            }

            double uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[2].Value.ToString());
            }

            textBox2.Text = uu.ToString();

            uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[3].Value.ToString());
            }

            textBox7.Text = uu.ToString();

            uu = 0;

            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                uu += double.Parse(dataGridView1.Rows[y].Cells[4].Value.ToString());
            }

            textBox8.Text = uu.ToString();

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

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}