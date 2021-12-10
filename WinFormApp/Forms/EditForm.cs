using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormApp.BusinessLogic;
using DynamoDal.Objects;

namespace WinFormApp.Forms
{
    public partial class EditForm : Form
    {
        private DynamoPost editPost;
        private BLogic bl;
        public EditForm(BLogic bl, DynamoPost post)
        {
            InitializeComponent();
            this.bl = bl;
            editPost = post;
            postTextBox.Text = editPost.PostText;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editPost.PK.Contains("POST"))
            {
                bl.UpdatePost(editPost, postTextBox.Text);
            }
            else
            {
                bl.UpdateComment((DynamoComment)editPost, postTextBox.Text);
            }
        }
    }
}
