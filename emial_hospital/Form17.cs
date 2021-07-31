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
    public partial class Form117 : Form
    {

        ListViewItem Item;

        public Form117( ListViewItem Item)
        {
            this.Item = Item;

            InitializeComponent();

            textBox1.Text = ((Hashtable)Item.Tag)["name"].ToString();

            textBox2.Text = ((Hashtable)Item.Tag)["pass"].ToString();

            comboBox1.SelectedIndex = int.Parse(((Hashtable)Item.Tag)["typeme"].ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("الرجاء تعبئة جميع الحقول");

            }
            else 
            {

                DBase.updateUser(((Hashtable)Item.Tag)["id"].ToString(), textBox1.Text, textBox2.Text, comboBox1.SelectedIndex.ToString());

                Close();  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}