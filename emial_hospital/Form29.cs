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
    public partial class Form129 : Form
    {

        ListViewItem Item;

        public Form129( ListViewItem Item)
        {
            this.Item = Item;

            InitializeComponent();

            textBox1.Text = ((Hashtable)Item.Tag)["name"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("الرجاء تعبئة جميع الحقول");

            }
            else 
            {

                DBase.updatePerson(((Hashtable)Item.Tag)["id"].ToString(), textBox1.Text);

                Close();  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}