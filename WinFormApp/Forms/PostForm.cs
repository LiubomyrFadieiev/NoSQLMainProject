using DynamoDal.Objects;
using MongoDal.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormApp.BusinessLogic;

namespace WinFormApp.Forms
{
    public partial class PostForm : Form
    {
        BLogic bl;
        private MongoUser currentUser;
        private BLPost currentPost;

        private int displayPostComments;
        private List<DynamoComment> streamComments;
        public PostForm(BLogic bl, MongoUser user, DynamoPost post)
        {
            this.bl = bl;
            currentUser = user;
            currentPost = new BLPost(post, bl.GetPostByKey(post.PK));
            displayPostComments = 0;
            (bool, DynamoPost) parentPost = bl.GetParentPost(currentPost.mainPost);
            BLPost parentBLPost = new BLPost(parentPost.Item2);
            InitializeComponent();
            if (parentPost.Item1)
            {
                postMenuParent.Text = parentBLPost.ToString();
            }
            streamComments = bl.GetPostsComments(currentPost.mainPost);
            SetStreamComments(displayPostComments);


            postMenuThis.Text = currentPost.ToString();
            if (currentPost.addPost.likes.IndexOf(currentUser.nickname) != -1)
            {
                likePost.Text = "unlike";
            }
            else
            {
                likePost.Text = "like";
            }

        }
        private void SetStreamComments(int disp)
        {
            int streamlength = streamComments == null ? 0 : streamComments.Count;
            if (streamlength >= 1)
            {
                postMenuComments.Text = streamComments[Math.Abs(disp % streamlength)].ToString();
                DynamoPost searchedPost = streamComments[Math.Abs(disp % streamlength)];
                if (bl.GetPostByKey(searchedPost.PK).likes.IndexOf(currentUser.nickname) != -1)
                {
                    likeComment.Text = "unlike";
                }
                else
                {
                    likeComment.Text = "like";
                }
            }
        }

        private void postMenuUp_Click(object sender, EventArgs e)
        {
            SetStreamComments(--displayPostComments);
        }

        private void postMenuDown_Click(object sender, EventArgs e)
        {
            SetStreamComments(++displayPostComments);
        }

        private void postMenuPublish_Click(object sender, EventArgs e)
        {
            string body = postMenuText.Text;
            bl.InsertPost(currentUser, body);
            bl.InsertComment(currentPost.mainPost, currentUser, body);
            streamComments = bl.GetPostsComments(currentPost.mainPost);
            
        }

        private void likePost_Click(object sender, EventArgs e)
        {
            currentPost.ChangeLike(currentUser.nickname);
            bl.SetLikes(currentPost.addPost);
            UpdatePosts();
            if (likePost.Text == "like")
            {
                likePost.Text = "unlike";
            }
            else if (likePost.Text == "unlike")
            {
                likePost.Text = "like";
            }
        }
        private void UpdatePosts()
        {
            postMenuThis.Text = currentPost.ToString();
            streamComments = bl.GetPostsComments(currentPost.mainPost);
            if (streamComments.Count != 0)
            {
                SetStreamComments(displayPostComments);
            }
        }

        private void likeComment_Click(object sender, EventArgs e)
        {
            DynamoPost comment = streamComments[Math.Abs(displayPostComments % streamComments.Count)];
            BLPost blComment = new BLPost(comment, bl.GetPostByKey(comment.PK));

            blComment.ChangeLike(currentUser.nickname);
            bl.SetLikes(blComment.addPost);
            UpdatePosts();
            if (likeComment.Text == "like")
            {
                likeComment.Text = "unlike";
            }
            else if (likeComment.Text == "unlike")
            {
                likeComment.Text = "like";
            }
        }
    }
}