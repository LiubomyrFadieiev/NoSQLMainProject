using DynamoDal.Objects;
using MongoDal.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormApp.BusinessLogic;

namespace WinFormApp.Forms
{
    public partial class MainForm : Form
    {
        BLogic bl;
        private MongoUser currentUser { get; set; }

        private int displayPost;
        private int displaySearchPost;
        private int displayUserPost;
        private List<DynamoPost> stream { get; set; }
        private List<DynamoPost> searchStream { get; set; }
        private List<DynamoPost> userStream { get; set; }
        public MainForm()
        {
            bl = new BLogic();
            while (true)
            {
                displayPost = 0;
                displaySearchPost = 0;
                displayUserPost = 0;
                var login = new LogInForm(bl);
                var log = login.ShowDialog();
                if (log == DialogResult.OK)
                {
                    currentUser = login.currentUser;
                    InitializeComponent();
                    stream = bl.GetPostsForStream(currentUser);
                    SetStreamPosts(stream, displayPost, postBox0, postBox1);
                    SetProfile();
                    break;
                }
            }
        }
        public void SetCurrentUser(MongoUser user)
        {
            this.currentUser = user;
        }
        private void SetStreamPosts(List<DynamoPost> postList, int disp, RichTextBox box0, RichTextBox box1)
        {
            int streamLength = postList.Count();
            box0.Text = postList[Math.Abs(((disp + 0) % streamLength))].ToString();
            box1.Text = postList[Math.Abs(((disp + 1) % streamLength))].ToString();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            SetStreamPosts(stream, --displayPost, postBox0, postBox1);
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            SetStreamPosts(stream, ++displayPost, postBox0, postBox1);
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string username = searchText.Text;
            (bool, string[]) ourData = bl.GetUserByNickname(username);
            if (ourData.Item1)
            {
                long followers = bl.GetFollowers(username);
                string fullName = String.Format("{0} {1}", ourData.Item2[0], ourData.Item2[1]);

                fullNameText.Text = fullName;
                nicknameText.Text = String.Format("@{0}", username);
                followsText.Text = String.Format("{0} follows", bl.GetFollows(username));
                followersText.Text = String.Format("{0} followers", followers);
                friendsButton.Text = "Follow";
                friendsButton.Enabled = true;
                lengthButton.Enabled = true;

                searchStream = bl.GetUserPosts(username);
                SetStreamPosts(searchStream, displaySearchPost, searchText0, searchText1);
            }
            else
            {
                MessageBox.Show("User with this nickname does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (string str in currentUser.follows)
            {
                if (username == str)
                {
                    friendsButton.Text = "Already Follow";
                    break;
                }
            }
            if (username == currentUser.nickname)
            {
                friendsButton.Text = "--";
                friendsButton.Enabled = false;
                lengthButton.Enabled = false;
            }

        }

        private void friendsButton_Click(object sender, EventArgs e)
        {
            string nickname = nicknameText.Text;
            nickname = nickname.Trim('@');
            if (friendsButton.Text == "Follow")
            {
                currentUser.follows.Add(nickname);
                bl.SetFollowsList(currentUser, nickname, "add");
                friendsButton.Text = "Already Follow";
                string[] text = followersText.Text.Split(' ');
                int newfollowers = Int32.Parse(text[0]) + 1;
                followersText.Text = String.Format("{0} followers", newfollowers);
            }
            else if (friendsButton.Text == "Already Follow")
            {
                currentUser.follows.Remove(nickname);
                bl.SetFollowsList(currentUser, nickname, "remove");
                friendsButton.Text = "Follow";
                string[] text = followersText.Text.Split(' ');
                int newfollowers = Int32.Parse(text[0]) - 1;
                followersText.Text = String.Format("{0} followers", newfollowers);
            }
        }

        private void upSearchText_Click(object sender, EventArgs e)
        {
            SetStreamPosts(searchStream, --displaySearchPost, searchText0, searchText1);
        }

        private void downSearchText_Click(object sender, EventArgs e)
        {
            SetStreamPosts(searchStream, ++displaySearchPost, searchText0, searchText1);
        }

        private void SetProfile()
        {
            userFullName.Text = String.Format("{0} {1}", currentUser.firstName, currentUser.lastName);
            userNickname.Text = String.Format("@{0}", currentUser.nickname);
            userFollows.Text = String.Format("{0} follows", bl.GetFollows(currentUser.nickname));
            userFollowers.Text = String.Format("{0} followers", bl.GetFollowers(currentUser.nickname));
            userStream = bl.GetUserPosts(currentUser.nickname);
            SetStreamPosts(userStream, displaySearchPost, userPost0, userPost1);
        }

        private void upUserStream_Click(object sender, EventArgs e)
        {
            SetStreamPosts(userStream, --displaySearchPost, userPost0, userPost1);
        }

        private void downUserStream_Click(object sender, EventArgs e)
        {
            SetStreamPosts(userStream, ++displaySearchPost, userPost0, userPost1);
        }

        private void publishButton_Click(object sender, EventArgs e)
        {
            string body = publishText.Text;
            bl.InsertPost(currentUser, body);
            UpdateStream();
            publishText.Text = "";
        }
        private void UpdateStream()
        {
            stream = bl.GetPostsForStream(currentUser);
            userStream = bl.GetUserPosts(currentUser.nickname);
            SetStreamPosts(stream, displayPost, postBox0, postBox1);
            SetStreamPosts(userStream, displayUserPost, userPost0, userPost1);
        }



        private void post0Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, stream[Math.Abs((displayPost + 0) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void post1Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, stream[Math.Abs((displayPost + 1) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void search0Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, searchStream[Math.Abs((displaySearchPost + 0) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void search1Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, searchStream[Math.Abs((displaySearchPost + 1) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void user0Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, userStream[Math.Abs((displayUserPost + 0) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void user1Button_Click(object sender, EventArgs e)
        {
            PostForm post = new PostForm(bl, currentUser, userStream[Math.Abs((displayUserPost + 1) % stream.Count)]);
            post.Show();
            UpdateStream();
        }

        private void lengthButton_Click(object sender, EventArgs e)
        {
            string nickname = nicknameText.Text;
            nickname = nickname.Trim('@');
            string message = String.Format("Your length with {0} equals {1}",
                fullNameText.Text,
                bl.GetLength(currentUser.nickname, nickname));

            MessageBox.Show(message, "Find Length", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void edit0Button_Click(object sender, EventArgs e)
        {
            EditForm post = new EditForm(bl, userStream[Math.Abs((displayUserPost + 0) % stream.Count)]);
            post.ShowDialog();
            if (post.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("This post was modified successfully");
            }
            UpdateStream();
        }

        private void edit1Button_Click(object sender, EventArgs e)
        {
            EditForm post = new EditForm(bl, userStream[Math.Abs((displayUserPost + 1) % stream.Count)]);
            post.ShowDialog();
            if (post.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("This post was modified successfully");
            }
            UpdateStream();
        }

        private void createDraft_Click(object sender, EventArgs e)
        {

        }

        private void publishText_TextChanged(object sender, EventArgs e)
        {
            publishButton.Enabled = publishText.Text != String.Empty;
            createDraft.Enabled = publishText.Text != String.Empty;

        }
    }
}