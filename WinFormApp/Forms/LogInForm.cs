using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDal.Objects;
using NeoDal.Objects;
using System.Windows.Forms;
using WinFormApp.BusinessLogic;

namespace WinFormApp.Forms
{
    public partial class LogInForm : Form
    {
        public MongoUser currentUser { get; set; }
        private BLogic bl;
        public LogInForm(BLogic bl)
        {
            InitializeComponent();
            this.bl = bl;
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string logIn = logText.Text;
            string pass = passText.Text;
            (bool, MongoUser) ourUser = bl.Authorize(logIn, pass);
            if (ourUser.Item1)
            {
                currentUser = ourUser.Item2;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error: Invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}