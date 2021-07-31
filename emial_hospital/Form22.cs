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
    public partial class Form22 : Form
    {

        public Form22()
        {
            InitializeComponent();

            getAll_Bills_not_closed();

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        Form19 ff = null;

        public Form22(Form19 ff)
        {
            this.ff = ff;

            InitializeComponent();

            this.ClientSize = Screen.PrimaryScreen.WorkingArea.Size;

            getAll_Bills_not_closed();
        }

        public void getAll_Bills_not_closed()
        {
            lvFolders.Items.Clear();

            ArrayList list = DBase.getAllBills1(Form19.login_user["id"].ToString());

            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Hashtable)list[i])["num"].ToString() + " " + ((Hashtable)list[i])["note2"].ToString();
                item.ImageIndex = 1;
                item.Tag = list[i];
                lvFolders.Items.Add(item);
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            ArrayList list2 = new ArrayList();

            ArrayList list = null;

            if (sender.GetType().Equals(typeof(ArrayList)))
            {
                list = sender as ArrayList;
            }
            else
            {
                list = new ArrayList();
            }

            Form23 ff = new Form23(list);

            ff.ShowDialog(this);

            if (list.Count != 0)
            {
                Form25 dd = new Form25(list2, list);

                if (e.GetType().Equals(typeof(koko)))
                {
                    dd.koko(e as koko);
                }

                dd.ShowDialog(this);

                getAll_Bills_not_closed();

            }

            if (list2.Count != 0)
            {
                button2_Click(list, e);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ff != null)
            {
                DBase.addLogout(Form19.login_user["id"].ToString());

                Form19.login_user = null;

                ff.Visible = true;
            }
        }

        private void lvFolders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Hashtable tb = ((Hashtable)lvFolders.SelectedItems[0].Tag);

                Form38 ff = new Form38(tb);

                ff.ShowDialog(this);
            }
            catch (Exception yy) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count != 0)
            {
                ArrayList list4 = new ArrayList();

                Hashtable tb = ((Hashtable)lvFolders.SelectedItems[0].Tag);

                ArrayList list3 = tb["billq"] as ArrayList;

                for (int o = 0; o < list3.Count; o++)
                {
                    Hashtable gg = list3[o] as Hashtable;

                    lolo ss = new lolo();

                    ss.tabe = DBase.getReq(gg["req_id"].ToString());

                    ss.q = int.Parse(gg["q"].ToString());

                    ss.cost = double.Parse(gg["cost"].ToString());

                    ss.end = -1;

                    list4.Add(ss);
                }

                koko ass = new koko();

                ass.bill_id = tb["id"].ToString();

                ass.note2 = tb["note2"].ToString();

                ass.notee = tb["notee"].ToString();

                button2_Click(list4, ass);
            }
        }

    }
}