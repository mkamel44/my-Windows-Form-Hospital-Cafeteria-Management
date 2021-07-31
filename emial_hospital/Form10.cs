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
    public partial class Form10 : Form
    {
        public string num = "0";

        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("الرجاء التأكد من اسم المادة");

                textBox1.Focus();
            }
            //else if (dataGridView1.Rows.Count == 0)
            //{
            //    MessageBox.Show("الرجاء التأكد من اضافة كمية واحدة على الأقل");

            //    button3.Focus();
            //}
            else
            {
                string m_id = DBase.addM(textBox1.Text,2.ToString(), num);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DBase.addQCM(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), m_id, dataGridView1.Rows[i].Cells[2].Value.ToString());
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
            Form11 ff = new Form11(dataGridView1);

            ff.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            }
        }
    }
}