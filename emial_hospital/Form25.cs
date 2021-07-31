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
    public partial class Form25 : Form
    {
        koko kokos = null;

        ArrayList list = null;

        ArrayList list2 = null;

        public Form25(ArrayList list2, ArrayList list)
        {
            this.list = list;

            this.list2 = list2;

            InitializeComponent();

            addRows();

            getAllPepole();

            Hashtable tbb = DBase.getFatoraNumber();

            textBox1.Text = tbb["num"] + "-" + tbb["datee"];

            comboBox2.SelectedIndex = 0;

            sum_All();

        }

        public void koko(koko koko) 
        {
            this.kokos = koko;

            textBox4.Text = this.kokos.note2;

            textBox3.Text = this.kokos.notee;

            button2.Visible = true;
        }


        public void sum_All()
        {
            double rr = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                rr += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }

            textBox2.Text = rr.ToString();

        }

        public void getAllPepole()
        {
            ArrayList list = DBase.getAllPeople();

            lolo ss1 = new lolo();

            ss1.tabe.Add("name", "بيع مباشر");

            ss1.tabe.Add("id", "0");

            comboBox1.Items.Add(ss1);

            for (int i = 0; i < list.Count; i++)
            {
                lolo ss = new lolo();

                ss.tabe = list[i] as Hashtable;

                ss.tabe["name"] = " بواسطة " + ss.tabe["name"];

                comboBox1.Items.Add(ss);
            }

            comboBox1.SelectedIndex = 0;

        }

        public void addRows()
        {
            for (int i = 0; i < list.Count; i++)
            {

                lolo aa = list[i] as lolo;

                dataGridView1.Rows.Add(new object[] { aa, aa.ToString(), aa.q, (aa.cost * aa.q).ToString() });

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string added = DBase.addBill1(textBox1.Text, ((lolo)comboBox1.SelectedItem).tabe["id"].ToString(), (comboBox2.SelectedIndex == 0 ? "false" : "true"), Form19.login_user["id"].ToString(), textBox3.Text, textBox4.Text);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lolo tb = dataGridView1.Rows[i].Cells[0].Value as lolo;

                DBase.addBillQ1(added, tb.tabe["id"].ToString(), tb.q.ToString(), tb.cost.ToString());
            }

            if (kokos != null)
            {
                DBase.deleteBill1(kokos.bill_id);

                DBase.deleteAllBillQByBillID1(kokos.bill_id);
            }

            Close();

        }

        public bool a222(Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["points"].ToString());

                int qwqwqw = yyyy;

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

                        DBase.updateQCM(ss["qua"].ToString(), (qwqwqw * one).ToString(), ss["id"].ToString(), qwqwqw.ToString());

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

        public bool a000(Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["qua"].ToString());

                int qwqwqw = yyyy;

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

                        DBase.updateQCM(qwqwqw.ToString(), (qwqwqw * one).ToString(), ss["id"].ToString(), 0.ToString());

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
                    boo = a000(tbs, tb, table["name"].ToString(), num_rr);
                }

                if (tbs["typeme"].Equals("2"))
                {
                    boo = a222(tbs, tb, table["name"].ToString(), num_rr);
                }

                if (boo == false)
                {
                    return false;
                }

            }

            return boo;

        }

        public bool getBillsNotClosed()
        {
            ArrayList list = DBase.getAllBills(Form19.login_user["id"].ToString());

            string ss = ((lolo)comboBox1.SelectedItem).tabe["id"].ToString();

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable aa = list[i] as Hashtable;

                if (aa["person_id"].ToString().Equals(ss))
                {
                    DialogResult sss = MessageBox.Show(this, "إن هذا الشخص عليه فاتورة لم يتم تسديدها بعد هلى تريد المتابعة", "ملاحظة", MessageBoxButtons.YesNo);

                    if (sss == DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }

            return true;

        }


        private void button5_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                this.Enabled = false;

                this.Cursor = Cursors.WaitCursor;

                string added = DBase.addBill(textBox1.Text, ((lolo)comboBox1.SelectedItem).tabe["id"].ToString(), (comboBox2.SelectedIndex == 0 ? "false" : "true"), Form19.login_user["id"].ToString(), textBox3.Text, textBox4.Text);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    lolo tb = dataGridView1.Rows[i].Cells[0].Value as lolo;

                    DBase.addBillQ(added, tb.tabe["id"].ToString(), tb.q.ToString(), tb.cost.ToString());

                    DBase.addReq_back(added, tb.tabe["part_id"].ToString(), tb.tabe["id"].ToString(), tb.tabe["name"].ToString(), tb.tabe["hader"].ToString(), tb.tabe["num1"].ToString(), tb.tabe["num2"].ToString(), tb.tabe["num3"].ToString());

                    for (int io = 0; io < ((ArrayList)tb.tabe["qcreq"]).Count; io++)
                    {
                        Hashtable tr = ((ArrayList)tb.tabe["qcreq"])[io] as Hashtable;

                        DBase.addQcreq_back(added, tr["id"].ToString(), tr["req_id"].ToString(), tr["m_id"].ToString(), tr["qua"].ToString());

                        Hashtable te = DBase.getM(tr["m_id"].ToString());

                        DBase.addM_back(added, te["id"].ToString(), te["name"].ToString(), te["typeme"].ToString(), te["part_id"].ToString());

                        for (int u = 0; u < ((ArrayList)te["qcm"]).Count; u++)
                        {
                            Hashtable gg = ((ArrayList)te["qcm"])[u] as Hashtable;

                            DBase.addQCM_back(added, gg["id"].ToString(), gg["qua"].ToString(), gg["cost"].ToString(), gg["m_id"].ToString(), gg["points"].ToString());
                        }

                    }

                    choosesss(tb.q, tb.tabe);
                }

                DBase.addFatoraNumber(textBox1.Text);

                if (kokos != null)
                {
                    DBase.deleteBill1(kokos.bill_id);

                    DBase.deleteAllBillQByBillID1(kokos.bill_id);
                }

                Close();

            }
            else
            {
                MessageBox.Show("الرجاء التأكد من اختيارك لشخص ما");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list2.Add("");

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBase.deleteBill1(kokos.bill_id);

            DBase.deleteAllBillQByBillID1(kokos.bill_id);

            Close();
        }  


    }
}