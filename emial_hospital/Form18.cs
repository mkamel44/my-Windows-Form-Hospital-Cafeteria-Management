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
    public partial class Form18 : Form
    {

        public Form18()
        {
            InitializeComponent();

            lvFolders.Name = "0";

            getAllParts(lvFolders.Name);

            getAllReq(lvFolders.Name);

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
            Form20 ff = new Form20();

            ff.num = lvFolders.Name;

            ff.ShowDialog(this);

            getAllParts(lvFolders.Name);

            getAllReq(lvFolders.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                DialogResult result = MessageBox.Show(this, "هل أنت متأكد من الحذف؟", "تأكيد", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                    {
                        DBase.deletePart1(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());

                        ArrayList listr = DBase.getAllReq(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());

                        for (int o = 0; o < listr.Count; o++)
                        {
                            Hashtable ff = listr[o] as Hashtable;

                            DBase.deleteAllQcreqFromReqID(ff["id"].ToString());
                        }

                        DBase.deleteAllReqFromPart(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());
                    }
                    else
                    {
                        DBase.deleteReq(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());

                        DBase.deleteAllQcreqFromReqID(((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString());
                    }

                    getAllParts(lvFolders.Name);

                    getAllReq(lvFolders.Name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                if (!((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    Form20 ff = new Form20();

                    ff.forUpdate(lvFolders.SelectedItems[0].Tag as Hashtable);

                    ff.ShowDialog(this);

                    getAllParts(lvFolders.Name);

                    getAllReq(lvFolders.Name);
                }
                else
                {
                    Form34 ff = new Form34(lvFolders.SelectedItems[0]);

                    ff.ShowDialog(this);

                    getAllParts(lvFolders.Name);

                    getAllReq(lvFolders.Name);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form33 dd = new Form33();

            dd.num = lvFolders.Name;

            dd.ShowDialog(this);

            getAllParts(lvFolders.Name);

            getAllReq(lvFolders.Name);
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
                }else
                {
                    button4_Click(sender, e);
                }
            }
            catch (Exception sss) { }
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

        private void button7_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            Form37 ff = new Form37(list, 0);

            ff.ShowDialog(this);

            if (list.Count != 0)
            {
                Form20 fff = new Form20();

                fff.forAddDirect(list, 0);

                fff.num = lvFolders.Name;

                fff.ShowDialog(this);

                getAllParts(lvFolders.Name);

                getAllReq(lvFolders.Name);
            }
        }


    }
}