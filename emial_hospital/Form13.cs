using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace emial_hospital
{
    public partial class Form13 : Form
    {
        DataGridView data = null;

        public Form13(DataGridView data)
        {
            this.data = data;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء التأكد من الحقل");
            }
            else
            {
                int row_num = data.Rows.Add(new string[] { "", textBox1.Text, textBox2.Text, "add" , textBox3.Text });

                data.Rows[row_num].Cells[1].Style.BackColor = Color.Green;
                data.Rows[row_num].Cells[2].Style.BackColor = Color.Green;
                data.Rows[row_num].Cells[4].Style.BackColor = Color.Green;

                Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}