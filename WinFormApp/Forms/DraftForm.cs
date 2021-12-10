using MongoDal.Objects;
using RedisDAL.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormApp.BusinessLogic;

namespace WinFormApp.Forms
{
    public partial class DraftForm : Form
    {
        BLogic bl;
        MongoUser user;
        List<DraftPost> draftList;
        int listCursor;
        public DraftForm(BLogic bl, MongoUser user)
        {
            this.bl = bl;
            this.user = user;
            draftList = bl.GetAllDraft();
            listCursor = 0;
            InitializeComponent();
            RefreshGrid(listCursor);
        }
        private void RefreshGrid(int cursor)
        {
            if(draftList.Count > 0)
            {
                draft0Text.Text = draftList[Math.Abs((cursor + 0) % draftList.Count)].body;
                if(draftList.Count > 1)
                {
                    draft0Text.Text = draftList[Math.Abs((cursor + 1) % draftList.Count)].body;
                    if (draftList.Count > 2)
                    {
                        draft0Text.Text = draftList[Math.Abs((cursor + 2) % draftList.Count)].body;
                    }
                }
            }
        }
        private void DraftForm_Load(object sender, EventArgs e)
        {

        }

        private void upButton_Click(object sender, EventArgs e)
        {
            RefreshGrid(++listCursor);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            RefreshGrid(--listCursor);
        }

        private void send0Button_Click(object sender, EventArgs e)
        {
            DraftPost post = draftList[Math.Abs((listCursor + 0) % draftList.Count)];
            bl.InsertPost(user, post.body);
            draftList.RemoveAt(Math.Abs((listCursor + 0) % draftList.Count));
            MessageBox.Show("Post was successfully added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DraftPost post = draftList[Math.Abs((listCursor + 1) % draftList.Count)];
            bl.InsertPost(user, post.body);
            draftList.RemoveAt(Math.Abs((listCursor + 1) % draftList.Count));
            MessageBox.Show("Post was successfully added");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DraftPost post = draftList[Math.Abs((listCursor + 2) % draftList.Count)];
            bl.InsertPost(user, post.body);
            draftList.RemoveAt(Math.Abs((listCursor + 2) % draftList.Count));
            MessageBox.Show("Post was successfully added");
        }

        private void delete0Button_Click(object sender, EventArgs e)
        {
            int index = Math.Abs((listCursor + 0) % draftList.Count);
            draftList.RemoveAt(index);
            bool result = bl.DeleteDraft(index);
            if (result)
            {
                MessageBox.Show("Draft was successfully deleted.");
            }
            else
            {
                MessageBox.Show("There was an error while post was being deleted.");
            }
        }

        private void delete1Button_Click(object sender, EventArgs e)
        {
            int index = Math.Abs((listCursor + 1) % draftList.Count);
            draftList.RemoveAt(index);
            bool result = bl.DeleteDraft(index);
            if (result)
            {
                MessageBox.Show("Draft was successfully deleted.");
            }
            else
            {
                MessageBox.Show("There was an error while post was being deleted.");
            }
        }

        private void delete2Button_Click(object sender, EventArgs e)
        {
            int index = Math.Abs((listCursor + 2) % draftList.Count);
            draftList.RemoveAt(index);
            bool result = bl.DeleteDraft(index);
            if (result)
            {
                MessageBox.Show("Draft was successfully deleted.");
            }
            else
            {
                MessageBox.Show("There was an error while post was being deleted.");
            }
        }

        private void draft0Text_TextChanged(object sender, EventArgs e)
        {
            CreateDraftForm form = new CreateDraftForm(bl, user, draft0Text.Text);
        }

        private void draft1Text_TextChanged(object sender, EventArgs e)
        {
            CreateDraftForm form = new CreateDraftForm(bl, user, draft1Text.Text);
        }

        private void draft2Text_TextChanged(object sender, EventArgs e)
        {
            CreateDraftForm form = new CreateDraftForm(bl, user, draft2Text.Text);
        }
    }
}
