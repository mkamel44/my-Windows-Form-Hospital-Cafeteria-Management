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
    public partial class Form15 : Form
    {

        public Form15()
        {
            InitializeComponent();

            getAllUsers();

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;

        }

        public void getAllUsers()
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllUsers();

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["name"].ToString();
                item.ImageIndex = 1;
                item.Tag = list[i];
                lvFolders.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();

            f.ShowDialog(this);

            getAllUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                Form117 f = new Form117(lvFolders.SelectedItems[0]);

                f.ShowDialog(this);

                getAllUsers();
            }
            else
            {
                MessageBox.Show("الرجاء التأكد من تحديد مستخدم");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form32 dd = new Form32();

            dd.ShowDialog(this);
        }

    
       

    }
}