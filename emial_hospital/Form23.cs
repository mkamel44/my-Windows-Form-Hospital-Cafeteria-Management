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
    public partial class Form23 : Form
    {
        ArrayList list = null;

        public Form23(ArrayList list)
        {
            this.list = list;

            InitializeComponent();

            lvFolders.Name = "0";

            getAllParts(lvFolders.Name);

            getAllReq(lvFolders.Name);

            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i]);
            }

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;
        }


        public void getAllParts(string num)
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllParts1(num);

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["name"].ToString();
                item.ImageIndex = 0;
                item.Tag = list[i];
                lvFolders.Items.Add(item);
            }
        }


        public void getAllReq(string num)
        {
            ArrayList list = DBase.getAllReq(num);

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (list[i] as Hashtable)["name"].ToString();
                item.ImageIndex = 1;
                item.Tag = list[i];

                lvFolders.Items.Add(item);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Clear();

            for (int ii = 0; ii < listBox1.Items.Count; ii++)
            {
                lolo ss = listBox1.Items[ii] as lolo;

                list.Add(ss);
            }

            Close();
        }

        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    this.Text = "الطلبات" + " - " + ((Hashtable)lvFolders.SelectedItems[0].Tag)["name"].ToString();

                    lvFolders.Name = ((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString();

                    getAllParts(lvFolders.Name);

                    getAllReq(lvFolders.Name);
                }
                else
                {
                    bool boo = true;

                    lolo ss = new lolo();

                    ss.tabe = lvFolders.SelectedItems[0].Tag as Hashtable;

                    //for (int ii = 0; ii < listBox1.Items.Count; ii++)
                    //{
                    //    string id1 = ((lolo)listBox1.Items[ii]).tabe["id"].ToString();

                    //    string id2 = ss.tabe["id"].ToString();

                    //    if (id1.Equals(id2))
                    //    {
                    //        boo = false;
                    //        break;
                    //    }
                    //}

                    if (boo)
                    {
                        ArrayList ddd = new ArrayList();

                        for (int i = 0; i < listBox1.Items.Count;i++ )
                        {
                            ddd.Add(listBox1.Items[i]);
                        }

                        Form26 ff = new Form26(ss, ddd);

                        ff.ShowDialog(this);

                        if (ss.end != 0)
                        {
                            listBox1.Items.Add(ss);
                        }
                    }
                }
            }
            catch (Exception eeee) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (listBox1.Items.Count != 0 && listBox1.SelectedIndices.Count != 0)
                {
                    int ii = listBox1.SelectedIndices.Count;

                    for (int i = (ii - 1); i > -1; i--)
                    {
                        listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                    }


                }
            }
            catch (Exception dd) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!lvFolders.Name.Equals("0"))
            {
                Hashtable table = DBase.getFatherOfPart1(lvFolders.Name);

                lvFolders.Name = table["num"].ToString();

                getAllParts(lvFolders.Name);

                getAllReq(lvFolders.Name);
            }
        }


    }
}