using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.Forms;
using DynamoDal.DAL;
using DynamoDal.Objects;

namespace NoSQLProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DynamoPostCommentDal dal = new DynamoPostCommentDal();
            dal.GetCommentsForPost(new DynamoPost() { PostId = "f8ab2a9f-e05c-4ce6-8c84-a7feb2cc4619" });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}