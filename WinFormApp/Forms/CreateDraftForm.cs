using DynamoDal.Objects;
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
    public partial class CreateDraftForm : Form
    {
        MongoUser user;
        BLogic bl;
        public CreateDraftForm(BLogic bl, MongoUser user, string body = "")
        {
            InitializeComponent();
            this.bl = bl;
            this.user = user;
            draftTextBox.Text = body;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void setTime_CheckedChanged(object sender, EventArgs e)
        {
            minuteNumeric.Enabled = setTime.Checked;
            secondsNumeric.Enabled = setTime.Checked;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            DraftPost post = new DraftPost(user.nickname, draftTextBox.Text);
            int? time;
            if (setTime.Checked)
            {
                int minuteTime = Decimal.ToInt32(minuteNumeric.Value) * 60;
                int secondTime = Decimal.ToInt32(secondsNumeric.Value);
                time = minuteTime + secondTime;
            }
            else
            {
                time = null;
            }
            bl.AddDraft(post, time);

            MessageBox.Show("Draft added successfully.");
        }

        private void draftTextBox_TextChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = draftTextBox.Text != String.Empty;
        }
    }
}
