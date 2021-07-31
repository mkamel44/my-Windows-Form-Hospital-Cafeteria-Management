﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace emial_hospital
{
    public partial class Form3 : Form
    {
        public string num = "0";

        public Form3()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
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
                string m_id = DBase.addM(textBox1.Text, comboBox1.SelectedIndex.ToString(), num);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DBase.addQCM(dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), m_id,0.ToString());
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
            Form5 ff = new Form5(dataGridView1);

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