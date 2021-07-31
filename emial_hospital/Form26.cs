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
    public partial class Form26 : Form
    {

        lolo list = null;

        ArrayList list_New_Items = null;

        public Form26(lolo list, ArrayList list_New_Items)
        {
            this.list = list;

            this.list_New_Items = list_New_Items;

            InitializeComponent();

            button1.Text = "السعر الأول:" + list.tabe["num1"].ToString();

            button1.Name = list.tabe["num1"].ToString();

            button2.Text = "السعر الثاني:" + list.tabe["num2"].ToString();

            button2.Name = list.tabe["num2"].ToString();

            button3.Text = "السعر الثالث:" + list.tabe["num3"].ToString();

            button3.Name = list.tabe["num3"].ToString();

            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;

            button1_Click(null, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            list.cost = double.Parse(button1.Name);
            button1.ForeColor = Color.Red;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            list.cost = double.Parse(button2.Name);
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Red;
            button3.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            list.cost = double.Parse(button3.Name);
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء التأكد من الكمية المطلوبة");
            }
            else
                if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
                {
                    MessageBox.Show("الرجاء اختيار السعر");
                }
                else
                {
                    list.q = int.Parse(textBox2.Text);

                    if (choosesss(list.q, list.tabe))
                    {
                        Close();
                    }

                }
        }

        public bool choosesss(int num_rr, Hashtable table)
        {
            ArrayList list = table["qcreq"] as ArrayList;


            bool boo = true;

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                Hashtable tbs = DBase.getM(tb["m_id"].ToString());

                if (tbs["typeme"].Equals("0"))
                {
                    boo = a000(list, tbs, tb, table["name"].ToString(), num_rr);
                }

                if (tbs["typeme"].Equals("2"))
                {
                    boo = a222(list, tbs, tb, table["name"].ToString(), num_rr);
                }

                if (boo == false)
                {
                    return false;
                }

            }

            return boo;

        }

        public bool a222(ArrayList list, Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            int qwqwqw = 0;

            for (int u = 0; u < list.Count; u++)
            {
                for (int i = 0; i < list_New_Items.Count; i++)
                {
                    lolo k = list_New_Items[i] as lolo;

                    ArrayList sss = k.tabe["qcreq"] as ArrayList;

                    for (int ii = 0; ii < sss.Count; ii++)
                    {
                        Hashtable rrr = sss[ii] as Hashtable;

                        Hashtable eee = ((Hashtable)list[u]);

                        if (!DBase.getM(eee["m_id"].ToString())["typeme"].Equals("0"))
                        {

                            if (rrr["m_id"].Equals(eee["m_id"]))
                            {
                                int hh = (int.Parse(rrr["qua"].ToString()) * k.q);

                                qwqwqw += hh;

                            }
                        }
                    }

                }

            }


            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["points"].ToString());

                yyyy -= qwqwqw;

                qwqwqw = yyyy;

                double one = 0;

                try
                {
                    one = double.Parse(ss["cost"].ToString()) / double.Parse(ss["points"].ToString());
                }
                catch (Exception ee)
                {

                }

                for (int ii = 0; ii < yyyy; ii++)
                {
                    if (rr > 0)
                    {
                        --qwqwqw;

                        //DBase.updateQCM(ss["qua"].ToString(), (qwqwqw * one).ToString(), ss["id"].ToString(), qwqwqw.ToString());

                        --rr;
                    }
                }
            }


            if (list2.Count == 0 || rr > 0)
            {
                MessageBox.Show("ان هذا الطلب يحتوي على مادة نقاط ليس لها كمية كافية في المستودع" + "\n" + tbs["name"]);

                return false;
            }

            return true;

        }

        public bool a000(ArrayList list, Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            int qwqwqw = 0;

            for (int u = 0; u < list.Count; u++)
            {
                for (int i = 0; i < list_New_Items.Count; i++)
                {
                    lolo k = list_New_Items[i] as lolo;

                    ArrayList sss = k.tabe["qcreq"] as ArrayList;

                    for (int ii = 0; ii < sss.Count; ii++)
                    {
                        Hashtable rrr = sss[ii] as Hashtable;

                        Hashtable eee = ((Hashtable)list[u]);

                        if (DBase.getM(eee["m_id"].ToString())["typeme"].Equals("0"))
                        {

                            if (rrr["m_id"].Equals(eee["m_id"]))
                            {
                                int hh = (int.Parse(rrr["qua"].ToString()) * k.q);

                                qwqwqw += hh;

                            }
                        }
                    }

                }

            }

            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["qua"].ToString());

                yyyy -= qwqwqw;

                qwqwqw = yyyy;

                double one = 0;

                try
                {
                    one = double.Parse(ss["cost"].ToString()) / double.Parse(ss["qua"].ToString());
                }
                catch (Exception ee)
                {

                }


                for (int ii = 0; ii < yyyy; ii++)
                {
                    if (rr > 0)
                    {
                        --qwqwqw;

                        //   DBase.updateQCM(qwqwqw.ToString(), (qwqwqw * one).ToString(), ss["id"].ToString(), 0.ToString());

                        --rr;
                    }
                }

            }


            if (list2.Count == 0 || rr > 0)
            {
                MessageBox.Show("ان هذا الطلب يحتوي على مادة عادية ليس لها كمية كافية في المستودع" + "\n" + tbs["name"]);

                return false;
            }

            return true;

        }


        private void button6_Click(object sender, EventArgs e)
        {
            list.end = 0;

            Close();
        }

        private void txtType1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int yyy = int.Parse(e.KeyChar.ToString());
            }
            catch (Exception ee)
            {
                e.Handled = true;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form31 ff = new Form31(textBox2);

            ff.ShowDialog(this);
        }

    

      


    }
}