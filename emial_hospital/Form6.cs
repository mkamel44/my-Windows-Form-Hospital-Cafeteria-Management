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
    public partial class Form6 : Form
    {
        ListViewItem Item;

        public Form6(ListViewItem Item)
        {
            this.Item = Item;

            InitializeComponent();

            textBox1.Text = ((Hashtable)Item.Tag)["name"].ToString();

            comboBox1.SelectedIndex = int.Parse(((Hashtable)Item.Tag)["typeme"].ToString());

            ArrayList list = ((ArrayList)((Hashtable)Item.Tag)["qcm"]);
            
            for (int i = 0; i < list.Count; i++)
            {
                Hashtable table = ((Hashtable)list[i]);

                dataGridView1.Rows.Add(table["id"].ToString(), table["qua"].ToString(), table["cost"].ToString(), "");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("الرجاء التأكد من اسم المادة");

                textBox1.Focus();
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("الرجاء التأكد من نوع المادة");

                textBox1.Focus();
            }
            else
            {
                DBase.updateM(((Hashtable)Item.Tag)["id"].ToString(), textBox1.Text, comboBox1.SelectedIndex.ToString());

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value.ToString().Equals("add"))
                    {
                        DBase.addQCM(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), ((Hashtable)Item.Tag)["id"].ToString(), 0.ToString());
                    }
                    else
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString().Equals("up"))
                        {
                            DBase.updateQCM(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString(), 0.ToString());
                        }
                        else
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString().Equals("del"))
                            {
                                DBase.deleteQCM(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            }

                }

                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 ff = new Form8(dataGridView1);

            ff.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                for (int ii = 0; ii < dataGridView1.SelectedRows.Count; ii++)
                {
                    int i = dataGridView1.SelectedRows[ii].Cells[0].RowIndex;

                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(""))
                    {
                        dataGridView1.Rows.RemoveAt(i);

                    }else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "del";

                        dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;

                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;

                        dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.Red;

                    }

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                Form7 ff = new Form7(dataGridView1);

                ff.ShowDialog(this);
            }
        }

      
    }
}