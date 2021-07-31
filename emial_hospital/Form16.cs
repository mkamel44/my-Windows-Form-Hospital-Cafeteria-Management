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
    public partial class Form16 : Form
    {

        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء تعبئة جميع الحقول");

            }
            else 
            {

                DBase.addUser(textBox1.Text, textBox2.Text, comboBox1.SelectedIndex.ToString());

                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}