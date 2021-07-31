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
    public partial class Form37 : Form
    {
        public int typ = 0;

        public ArrayList mytable = null;

        public Form37(ArrayList mytable, int typ)
        {
            InitializeComponent();

            this.typ = typ;

            this.mytable = mytable;

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

                if (typ.ToString().Equals(((Hashtable)list[i])["typeme"].ToString()))
                {
                    lvFolders.Items.Add(item);
                }
            }
        }

        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (((Hashtable)lvFolders.SelectedItems[0].Tag).ContainsKey("num"))
                {
                    this.Text = "المستودعات" + " - " + ((Hashtable)lvFolders.SelectedItems[0].Tag)["name"].ToString();

                    lvFolders.Name = ((Hashtable)lvFolders.SelectedItems[0].Tag)["id"].ToString();

                    getAllParts(lvFolders.Name);

                    getAllM(lvFolders.Name);
                }
                else
                {
                    bool boo = true;

                    lolo ss = new lolo();

                    ss.tabe = lvFolders.SelectedItems[0].Tag as Hashtable;

                    for (int ii = 0; ii < listBox1.Items.Count; ii++)
                    {
                        string id1 = ((lolo)listBox1.Items[ii]).tabe["id"].ToString();

                        string id2 = ss.tabe["id"].ToString();

                        if (id1.Equals(id2))
                        {
                            boo = false;
                            break;
                        }
                    }


                    if (boo)
                    {
                        listBox1.Items.Add(ss);
                    }
                }
            }
            catch (Exception eeee) { }
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

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                mytable.Add(listBox1.Items[i]);
            }
            
            Close();
        }



        private void button1_Click_1(object sender, EventArgs e)
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



    }


}