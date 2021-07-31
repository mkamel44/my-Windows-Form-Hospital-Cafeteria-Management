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
    public partial class Form24 : Form
    {

        ArrayList list = null;

        bool boo = true;

        int old_int = 0;

        public Form24(ArrayList list)
        {
            this.list = list;

            InitializeComponent();

            addRows();
        }

        public void addRows()
        {
            for (int i = 0; i < list.Count; i++)
            {

                lolo aa = list[i] as lolo;

                boo = true;

                double dd = choose(1, aa.tabe);

                if (boo)
                {
                    dataGridView1.Rows.Add(new object[] { aa, aa.ToString(), 1, dd });
                }
            }

            sum_all();
        }

        public double choose(int num_rr, Hashtable table)
        {
            ArrayList list = table["qcreq"] as ArrayList;

            double result = 0;

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                Hashtable tbs = DBase.getM(tb["m_id"].ToString());

                if (tbs["typeme"].Equals("0"))
                {
                    result += a0(tbs, tb, table["name"].ToString(), num_rr);
                }

                if (tbs["typeme"].Equals("1"))
                {
                    result += a1(tb, num_rr);
                }

                if (tbs["typeme"].Equals("2"))
                {
                    result += a2(tbs, tb, table["name"].ToString(), num_rr);
                }

            }

            return result + (double.Parse(table["profit"].ToString()) * num_rr);
        }

        public void sum_all()
        {
            double all = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                all += double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }

            textBox2.Text = all.ToString();
        }

        public double a0(Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            double result = 0;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["qua"].ToString());

                double one = 0;

                try
                {
                    one = int.Parse(ss["cost"].ToString()) / int.Parse(ss["qua"].ToString());
                }
                catch (Exception ee)
                {

                }

                for (int ii = 0; ii < yyyy; ii++)
                {
                    if (rr > 0)
                    {
                        result += one;

                        --rr;
                    }
                }

            }

            if (rr > 0)
            {
                MessageBox.Show("هناك مواد عادية ضمن الطلب التالي كميته غير متوفرة الرجاء التأكد من الطلب\n" + aa);

                boo = false;
            }

            return result;
        }

        public double a1(Hashtable tbs, int num_rr)
        {
            double result = (double.Parse(tbs["qua"].ToString()) * num_rr);

            return result;
        }

        public double a2(Hashtable tbs, Hashtable tb, string aa, int num_rr)
        {
            ArrayList list2 = tbs["qcm"] as ArrayList;

            double result = 0;

            int rr = (int.Parse(tb["qua"].ToString()) * num_rr);

            for (int o = 0; o < list2.Count; o++)
            {
                Hashtable ss = list2[o] as Hashtable;

                int yyyy = int.Parse(ss["points"].ToString());

                double one = 0;

                try
                {
                    one = int.Parse(ss["cost"].ToString()) / int.Parse(ss["points"].ToString());
                }
                catch (Exception ee)
                {

                }

                for (int ii = 0; ii < yyyy; ii++)
                {
                    if (rr > 0)
                    {
                        result += one;

                        --rr;
                    }
                }
            }

            if (rr > 0)
            {
                MessageBox.Show("هناك مواد نقاط ضمن الطلب التالي كميته غير متوفرة الرجاء التأكد من الطلب\n" + aa);

                boo = false;
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                lolo oo = dataGridView1.Rows[i].Cells[0].Value as lolo;

                choosesss(int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), oo.tabe);
            }

            DBase.deleteAllZeroOfQCM();

            Close();
        }

        public void choosesss(int num_rr, Hashtable table)
        {
            ArrayList list = table["qcreq"] as ArrayList;

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                Hashtable tbs = DBase.getM(tb["m_id"].ToString());

                if (tbs["typeme"].Equals("0"))
                {
                    a000(tbs, tb, table["name"].ToString(), num_rr);
                }

                if (tbs["typeme"].Equals("2"))
                {
                    a222(tbs, tb, table["name"].ToString(), num_rr);
                }

            }

        }

        public void a222(Hashtable tbs, Hashtable tb, string aa, int num_rr)
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
                    one = int.Parse(ss["cost"].ToString()) / int.Parse(ss["points"].ToString());
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


        }

        public void a000(Hashtable tbs, Hashtable tb, string aa, int num_rr)
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
                    one = int.Parse(ss["cost"].ToString()) / int.Parse(ss["qua"].ToString());
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

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                boo = true;

                lolo aa = dataGridView1.Rows[e.RowIndex].Cells[0].Value as lolo;

                double ddd = choose(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), aa.tabe);

                if (boo)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = ddd;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = old_int;
                }

                sum_all();
            }
            catch (Exception ee)
            {
                MessageBox.Show("الرجاء ادخال أرقام فقط");
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "";
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            old_int = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

    }
}