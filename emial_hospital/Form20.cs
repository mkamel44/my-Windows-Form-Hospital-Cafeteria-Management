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
    public partial class Form20 : Form
    {
        public string my_id = null;

        public string num = null;

        public int number = 0;

        public Form20()
        {
            InitializeComponent();
        }

        public void forAddDirect(ArrayList list, int typ)
        {
            for (int i = 0; i < list.Count; i++)
            {
                lolo uu = list[i] as lolo;

                if (typ == 0)
                {
                    textBox1.Text = uu.tabe["name"].ToString();

                    int row = dataGridView1.Rows.Add(new object[] { uu.tabe, uu.tabe["name"].ToString(), "1", "", "new" });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView1_CellEndEdit(null, sds);

                }
                else
                {
                    textBox1.Text = uu.tabe["name"].ToString();

                    int row = dataGridView1.Rows.Add(new object[] { uu.tabe, uu.tabe["name"].ToString(), "1", "", "new" });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView3_CellEndEdit(null, sds);

                }
            }
        }

        public void forUpdate2(string bill_id,Hashtable table)
        {
            button1.Text = "تعديل";

            my_id = table["id"].ToString();

            textBox1.Text = table["name"].ToString();

            textBox3.Text = table["hader"].ToString();

            textBox7.Text = table["num1"].ToString();

            textBox6.Text = table["num2"].ToString();

            textBox5.Text = table["num3"].ToString();

            ArrayList list = table["qcreq"] as ArrayList;

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                Hashtable rr = DBase.getM_back(bill_id,tb["m_id"].ToString());

                if (rr["typeme"].Equals("0"))
                {
                    int row = dataGridView1.Rows.Add(new object[] { rr, rr["name"].ToString(), tb["qua"].ToString(), "", "added", tb["id"].ToString() });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView1_CellEndEdit(null, sds);
                }
                else
                {
                    int row = dataGridView3.Rows.Add(new object[] { rr, rr["name"].ToString(), tb["qua"].ToString(), "", "added", tb["id"].ToString() });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView3_CellEndEdit(null, sds);
                }

            }

        }

        public void forUpdate(Hashtable table)
        {
            button1.Text = "تعديل";

            my_id = table["id"].ToString();

            textBox1.Text = table["name"].ToString();

            textBox3.Text = table["hader"].ToString();

            textBox7.Text = table["num1"].ToString();

            textBox6.Text = table["num2"].ToString();

            textBox5.Text = table["num3"].ToString();

            ArrayList list = table["qcreq"] as ArrayList;

            for (int i = 0; i < list.Count; i++)
            {
                Hashtable tb = list[i] as Hashtable;

                Hashtable rr = DBase.getM(tb["m_id"].ToString());

                if (rr["typeme"].Equals("0"))
                {
                    int row = dataGridView1.Rows.Add(new object[] { rr, rr["name"].ToString(), tb["qua"].ToString(), "", "added", tb["id"].ToString() });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView1_CellEndEdit(null, sds);
                }
                else
                {
                    int row = dataGridView3.Rows.Add(new object[] { rr, rr["name"].ToString(), tb["qua"].ToString(), "", "added", tb["id"].ToString() });

                    DataGridViewCellEventArgs sds = new DataGridViewCellEventArgs(2, row);

                    dataGridView3_CellEndEdit(null, sds);
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form21 ff = new Form21(dataGridView1, 0);

            ff.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                Hashtable table = dataGridView1.Rows[e.RowIndex].Cells[0].Value as Hashtable;


                ArrayList list = table["qcm"] as ArrayList;

                double result = 0;

                int rr = a;

                for (int i = 0; i < list.Count; i++)
                {
                    Hashtable ss = list[i] as Hashtable;

                    double yyyy = double.Parse(ss["qua"].ToString());

                    double one = double.Parse(ss["cost"].ToString()) / double.Parse(ss["qua"].ToString());

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
                    MessageBox.Show("لا توجد كميات كافية لهذه المادة الرجاء التأكد من المستودعات");
                    //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = "0";
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "up";
                        for (int u = 0; u < dataGridView1.Rows[e.RowIndex].Cells.Count; u++)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                        }
                    }

                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = result;
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "up";
                        for (int u = 0; u < dataGridView1.Rows[e.RowIndex].Cells.Count; u++)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                        }
                    }
                }

                sum_All();

            }
            catch (Exception ee)
            {
                //MessageBox.Show("الرجاء ادخال أرقام فقط");
                try
                {
                    int qwaq = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                catch (Exception eee)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }

                dataGridView1.Rows[e.RowIndex].Cells[3].Value = "0";
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = "up";
                    for (int u = 0; u < dataGridView1.Rows[e.RowIndex].Cells.Count; u++)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (my_id == null)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Cells[0].RowIndex);
                    }
                }
            }
            else
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int rrr = dataGridView1.SelectedRows.Count;

                    for (int i = 0; i < rrr; i++)
                    {

                        if (dataGridView1.SelectedRows[i].Cells[4].Value.ToString().Equals("added"))
                        {
                            dataGridView1.SelectedRows[i].Cells[4].Value = "del";

                            for (int u = 0; u < dataGridView1.SelectedRows[i].Cells.Count; u++)
                            {
                                dataGridView1.SelectedRows[i].Cells[u].Style.BackColor = Color.Red;
                            }
                        }
                        else
                            if (dataGridView1.SelectedRows[i].Cells[4].Value.ToString().Equals("new"))
                            {
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Cells[0].RowIndex);
                            }
                            else
                                if (dataGridView1.SelectedRows[i].Cells[4].Value.ToString().Equals("up"))
                                {
                                    dataGridView1.SelectedRows[i].Cells[4].Value = "del";

                                    for (int u = 0; u < dataGridView1.SelectedRows[i].Cells.Count; u++)
                                    {
                                        dataGridView1.SelectedRows[i].Cells[u].Style.BackColor = Color.Red;
                                    }
                                }


                    }
                }
            }


        }


        private void button8_Click(object sender, EventArgs e)
        {
            Form21 ff = new Form21(dataGridView3, 2);

            ff.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (my_id == null)
            {
                if (dataGridView3.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView3.SelectedRows.Count; i++)
                    {
                        dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[i].Cells[0].RowIndex);
                    }
                }
            }
            else
            {
                if (dataGridView3.Rows.Count != 0)
                {
                    int rrr = dataGridView3.SelectedRows.Count;

                    for (int i = 0; i < rrr; i++)
                    {
                        if (dataGridView3.SelectedRows[i].Cells[4].Value.ToString().Equals("added"))
                        {
                            dataGridView3.SelectedRows[i].Cells[4].Value = "del";

                            for (int u = 0; u < dataGridView3.SelectedRows[i].Cells.Count; u++)
                            {
                                dataGridView3.SelectedRows[i].Cells[u].Style.BackColor = Color.Red;
                            }
                        }
                        else
                            if (dataGridView3.SelectedRows[i].Cells[4].Value.ToString().Equals("new"))
                            {
                                dataGridView3.Rows.RemoveAt(dataGridView3.SelectedRows[i].Cells[0].RowIndex);
                            }
                            else
                                if (dataGridView3.SelectedRows[i].Cells[4].Value.ToString().Equals("up"))
                                {
                                    dataGridView3.SelectedRows[i].Cells[4].Value = "del";

                                    for (int u = 0; u < dataGridView3.SelectedRows[i].Cells.Count; u++)
                                    {
                                        dataGridView3.SelectedRows[i].Cells[u].Style.BackColor = Color.Red;
                                    }
                                }
                    }
                }
            }
        }

        public void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                Hashtable table = dataGridView3.Rows[e.RowIndex].Cells[0].Value as Hashtable;

                //table.Add("id", reader["id"].ToString());

                //table.Add("name", reader["name"].ToString());

                //table.Add("part_id", reader["part_id"].ToString());

                //table.Add("typeme", reader["typeme"].ToString());

                //table.Add("qcm", getAllQCMForM(reader["id"].ToString()));

                ////////////// table.Add("id", reader["id"].ToString());

                //////////////table.Add("m_id", reader["m_id"].ToString());

                //////////////table.Add("qua", reader["qua"].ToString());

                //////////////table.Add("cost", reader["cost"].ToString());

                //////////////table.Add("points", reader["points"].ToString());

                ArrayList list = table["qcm"] as ArrayList;

                double result = 0;

                int rr = a;

                for (int i = 0; i < list.Count; i++)
                {
                    Hashtable ss = list[i] as Hashtable;

                    double yyyy = double.Parse(ss["points"].ToString());

                    double one = double.Parse(ss["cost"].ToString()) / double.Parse(ss["points"].ToString());

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
                    MessageBox.Show("لا توجد نقاط كافية لهذه الكمية الرجاء التأكد من المستودعات");
                    //dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    dataGridView3.Rows[e.RowIndex].Cells[3].Value = "0";
                    if (dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                    {
                        dataGridView3.Rows[e.RowIndex].Cells[4].Value = "up";
                        for (int u = 0; u < dataGridView3.Rows[e.RowIndex].Cells.Count; u++)
                        {
                            dataGridView3.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                        }
                    }
                }
                else
                {
                    dataGridView3.Rows[e.RowIndex].Cells[3].Value = result;
                    if (dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                    {
                        dataGridView3.Rows[e.RowIndex].Cells[4].Value = "up";
                        for (int u = 0; u < dataGridView3.Rows[e.RowIndex].Cells.Count; u++)
                        {
                            dataGridView3.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                        }
                    }
                }

                sum_All();
            }
            catch (Exception ee)
            {
                //MessageBox.Show("الرجاء ادخال أرقام فقط");
                try
                {
                    int qwaq = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
                catch (Exception eee)
                {
                    dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }

                dataGridView3.Rows[e.RowIndex].Cells[3].Value = "0";
                if (dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("added") || dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("del"))
                {
                    dataGridView3.Rows[e.RowIndex].Cells[4].Value = "up";
                    for (int u = 0; u < dataGridView3.Rows[e.RowIndex].Cells.Count; u++)
                    {
                        dataGridView3.Rows[e.RowIndex].Cells[u].Style.BackColor = Color.Gray;
                    }
                }
            }
        }

        public void sum_All()
        {
            try
            {

                double sum = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double ii = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());

                    sum += ii;
                }

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    double ii = double.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString());

                    sum += ii;
                }

                textBox2.Text = sum.ToString();
            }
            catch (Exception rr)
            {

            }

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

        private void txtType11_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int num = 0;

                for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
                {
                    if (((TextBox)sender).Text.ToCharArray()[i].ToString().Equals("."))
                    {
                        ++num;
                    }
                }

                if (e.KeyChar.ToString().Equals("."))
                {
                    ++num;
                }


                if (num > 1)
                {
                    e.Handled = true;
                }


                if (e.KeyChar.ToString().Equals(".") || e.KeyChar.Equals('\b'))
                {

                }
                else
                {
                    double yyy = double.Parse(e.KeyChar.ToString());
                }
            }
            catch (Exception ee)
            {
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("الرجاء التأكد من اسم المادة");
            }
            else
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("الرجاء التأكد من تكلفة الهدر ");
                }
                else
                {

                    if (my_id == null)
                    {
                        string req_id = DBase.addReq(num, textBox1.Text, textBox3.Text, textBox7.Text, textBox6.Text, textBox5.Text);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            Hashtable cell = dataGridView1.Rows[i].Cells[0].Value as Hashtable;

                            DBase.addQcreq(req_id, cell["id"].ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                        }


                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {
                            Hashtable cell = dataGridView3.Rows[i].Cells[0].Value as Hashtable;

                            DBase.addQcreq(req_id, cell["id"].ToString(), dataGridView3.Rows[i].Cells[2].Value.ToString());
                        }

                    }
                    else
                    {
                        DBase.updateReq(my_id, textBox1.Text, textBox3.Text, textBox7.Text, textBox6.Text, textBox5.Text);

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            Hashtable cell = dataGridView1.Rows[i].Cells[0].Value as Hashtable;

                            string cell4 = dataGridView1.Rows[i].Cells[4].Value.ToString();

                            if (cell4.Equals("new"))
                            {
                                DBase.addQcreq(my_id, cell["id"].ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                            }

                            if (cell4.Equals("up"))
                            {
                                DBase.updateQcreq(dataGridView1.Rows[i].Cells[5].Value.ToString(), my_id, cell["id"].ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                            }

                            if (cell4.Equals("del"))
                            {
                                DBase.deleteQcreq(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            }
                        }


                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {

                            Hashtable cell = dataGridView3.Rows[i].Cells[0].Value as Hashtable;

                            string cell4 = dataGridView3.Rows[i].Cells[4].Value.ToString();

                            if (cell4.Equals("new"))
                            {
                                DBase.addQcreq(my_id, cell["id"].ToString(), dataGridView3.Rows[i].Cells[2].Value.ToString());
                            }

                            if (cell4.Equals("up"))
                            {
                                DBase.updateQcreq(dataGridView3.Rows[i].Cells[5].Value.ToString(), my_id, cell["id"].ToString(), dataGridView3.Rows[i].Cells[2].Value.ToString());
                            }

                            if (cell4.Equals("del"))
                            {
                                DBase.deleteQcreq(dataGridView3.Rows[i].Cells[5].Value.ToString());
                            }
                        }

                    }


                    Close();
                }
        }

        public bool getTrue(DataGridView grid)
        {
            try
            {
                if (string.IsNullOrEmpty(grid.Rows[0].Cells[2].Value.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception uu)
            {
                return true;
            }

        }


    }
}