using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace emial_hospital
{
    public partial class Form31 : Form
    {
        TextBox textbox = null;

        public Form31(TextBox textbox)
        {
            this.textbox = textbox;
          
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textbox.Text = textBox1.Text;
            
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); ;
            }
            catch (Exception rr) 
            {
               
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
