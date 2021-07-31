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
    public partial class Form27 : Form
    {

        public Form27()
        {
            InitializeComponent();

            getAllPeople();

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;

        }

        public void getAllPeople()
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllPeople();

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
            Form28 f = new Form28();

            f.ShowDialog(this);

            getAllPeople();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                Form129 f = new Form129(lvFolders.SelectedItems[0]);

                f.ShowDialog(this);

                getAllPeople();
            }
            else
            {
                MessageBox.Show("الرجاء التأكد من تحديد مستخدم");
            }
        }

    }
}