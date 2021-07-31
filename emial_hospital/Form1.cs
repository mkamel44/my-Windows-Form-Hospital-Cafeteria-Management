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
    public partial class Form1 : Form
    {
        Form19 ff = null;

        public Form1(Form19 ff)
        {
            this.ff = ff;

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dd = new Form2();

            dd.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 dd = new Form18();

            dd.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 dd = new Form15();

            dd.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form22 dd = new Form22();

            dd.ShowDialog(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBase.addLogout(Form19.login_user["id"].ToString());

            Form19.login_user = null;

            ff.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form27 dd = new Form27();

            dd.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form30 dd = new Form30();

            dd.ShowDialog(this);
        }


    }
}
