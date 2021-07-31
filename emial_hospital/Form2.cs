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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            lvFolders.Name = "0";

            getAllParts(lvFolders.Name);

            getAllM(lvFolders.Name);

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public void getAllParts(string num)
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllParts(num);

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["name"].ToString();
                item.ImageIndex = 0;
                item.Tag = list[i];
                lvFolders.Items.Add(item);
            }
        }

        public void getAllM(string part_id)
        {
            ArrayList list = DBase.getAllM(part_id);

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["name"].ToString();
                if (((Hashtable)list[i])["typeme"].ToString().Equals("0"))
                {
                    item.ImageIndex = 1;
                }
                else if (((Hashtable)list[i])["typeme"].ToString().Equals("1"))
                {
                    item.ImageIndex = 2;
                }
                else if (((Hashtable)list[i])["typeme"].ToString().Equals("2"))
                {
                    item.ImageIndex = 3;
                }

                item.Tag = list[i];
                lvFolders.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();

            ff.num = lvFolders.Name;

            ff.ShowDialog(this);

            getAllParts(lvFolders.Name);

            getAllM(lvFolders.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 dd = new Form4();

            dd.num = lvFolders.Name;

            dd.ShowDialog(this);

            getAllParts(lvFolders.Name);

            getAllM(lvFolders.Name);
        }

        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (((Hashtable) lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    this.Text = "المستودعات" + " - " + ((Hashtable) lvFolders.SelectedItems[0].Tag)["name"].ToString();

                    lvFolders.Name = ((Hashtable) lvFolders.SelectedItems[0].Tag)["id"].ToString();

                    getAllParts(lvFolders.Name);

                    getAllM(lvFolders.Name);
                }
                else
                {
                    button4_Click(sender, e);
                }

            }
            catch (Exception sss) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                DialogResult result = MessageBox.Show(this, "هل أنت متأكد من الحذف؟", "تأكيد", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                    {
                        DBase.deletePart(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());

                        DBase.deleteAllMFromPart(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());
                    }
                    else
                    {
                        DBase.deleteM(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());
                    }

                    getAllParts(lvFolders.Name);

                    getAllM(lvFolders.Name);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                if (!((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    if (((Hashtable)lvFolders.SelectedItems[0].Tag)["typeme"].Equals("2"))
                    {
                        Form12 ff = new Form12(lvFolders.SelectedItems[0]);

                        ff.ShowDialog(this);

                        getAllParts(lvFolders.Name);

                        getAllM(lvFolders.Name);
                    }
                    else
                    {
                        Form6 ff = new Form6(lvFolders.SelectedItems[0]);

                        ff.ShowDialog(this);

                        getAllParts(lvFolders.Name);

                        getAllM(lvFolders.Name);
                    }
                }
                else
                {
                    Form9 ff = new Form9(lvFolders.SelectedItems[0]);

                    ff.ShowDialog(this);

                    getAllParts(lvFolders.Name);

                    getAllM(lvFolders.Name);
                }
            }
            else
            {
                MessageBox.Show("الرجاء التأكد من تحديد مادة");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!lvFolders.Name.Equals("0"))
            {
                Hashtable table = DBase.getFatherOfPart(lvFolders.Name);

                lvFolders.Name = table["num"].ToString();

                getAllParts(lvFolders.Name);

                getAllM(lvFolders.Name);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 ff = new Form10();

            ff.num = lvFolders.Name;

            ff.ShowDialog(this);

            getAllParts(lvFolders.Name);

            getAllM(lvFolders.Name);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                if (!((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    Form39 dd = new Form39();

                    dd.myid = int.Parse(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());

                    dd.ShowDialog(this);

                    getAllParts(lvFolders.Name);

                    getAllM(lvFolders.Name);
                }
                else
                {
                  
                }
            }
            else
            {
                MessageBox.Show("الرجاء التأكد من تحديد مادة");
            }

           
        }


    }
}