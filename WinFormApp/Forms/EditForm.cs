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
        public EditForm(DynamoPost post)
        {
            editPost = post;
            postTextBox.Text = editPost.PostText;
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BLogic bl = new BLogic();
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
