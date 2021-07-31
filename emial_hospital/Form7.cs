﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace emial_hospital
{
    public partial class Form7 : Form
    {
        DataGridView data = null;

        public Form7(DataGridView data)
        {
            this.data = data;

            InitializeComponent();

            textBox1.Text = data.SelectedCells[1].Value.ToString();

            textBox2.Text = data.SelectedCells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء التأكد من الحقل");
            }
            else
            {

                data.SelectedCells[1].Value = textBox1.Text;

                data.SelectedCells[2].Value = textBox2.Text;

                for (int u = 0; u < data.SelectedCells.Count; u++)
                {
                    data.SelectedCells[u].Style.BackColor = Color.Gray;
                }

                data.SelectedCells[3].Value = "up";

                Close();
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


        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}