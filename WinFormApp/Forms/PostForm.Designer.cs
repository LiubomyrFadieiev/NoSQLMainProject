
namespace WinFormApp.Forms
{
    partial class PostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.postMenuLabel = new System.Windows.Forms.Label();
            this.postMenuText = new System.Windows.Forms.TextBox();
            this.postMenuPublish = new System.Windows.Forms.Button();
            this.postMenuUp = new System.Windows.Forms.Button();
            this.postMenuDown = new System.Windows.Forms.Button();
            this.postMenuParent = new System.Windows.Forms.RichTextBox();
            this.postMenuComments = new System.Windows.Forms.RichTextBox();
            this.postMenuThis = new System.Windows.Forms.RichTextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.parentPostLabel = new System.Windows.Forms.Label();
            this.thisPostLabel = new System.Windows.Forms.Label();
            this.likeComment = new System.Windows.Forms.Button();
            this.likePost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.likePost);
            this.splitContainer1.Panel1.Controls.Add(this.likeComment);
            this.splitContainer1.Panel1.Controls.Add(this.postMenuDown);
            this.splitContainer1.Panel1.Controls.Add(this.postMenuUp);
            this.splitContainer1.Panel1.Controls.Add(this.postMenuPublish);
            this.splitContainer1.Panel1.Controls.Add(this.postMenuText);
            this.splitContainer1.Panel1.Controls.Add(this.postMenuLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.thisPostLabel);
            this.splitContainer1.Panel2.Controls.Add(this.parentPostLabel);
            this.splitContainer1.Panel2.Controls.Add(this.commentsLabel);
            this.splitContainer1.Panel2.Controls.Add(this.postMenuThis);
            this.splitContainer1.Panel2.Controls.Add(this.postMenuComments);
            this.splitContainer1.Panel2.Controls.Add(this.postMenuParent);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // postMenuLabel
            // 
            this.postMenuLabel.AutoSize = true;
            this.postMenuLabel.Location = new System.Drawing.Point(73, 35);
            this.postMenuLabel.Name = "postMenuLabel";
            this.postMenuLabel.Size = new System.Drawing.Size(121, 20);
            this.postMenuLabel.TabIndex = 0;
            this.postMenuLabel.Text = "Add a comment";
            // 
            // postMenuText
            // 
            this.postMenuText.Location = new System.Drawing.Point(30, 58);
            this.postMenuText.Name = "postMenuText";
            this.postMenuText.Size = new System.Drawing.Size(206, 26);
            this.postMenuText.TabIndex = 1;
            // 
            // postMenuPublish
            // 
            this.postMenuPublish.Location = new System.Drawing.Point(77, 90);
            this.postMenuPublish.Name = "postMenuPublish";
            this.postMenuPublish.Size = new System.Drawing.Size(117, 33);
            this.postMenuPublish.TabIndex = 2;
            this.postMenuPublish.Text = "Publish";
            this.postMenuPublish.UseVisualStyleBackColor = true;
            this.postMenuPublish.Click += new System.EventHandler(this.postMenuPublish_Click);
            // 
            // postMenuUp
            // 
            this.postMenuUp.Location = new System.Drawing.Point(30, 332);
            this.postMenuUp.Name = "postMenuUp";
            this.postMenuUp.Size = new System.Drawing.Size(63, 50);
            this.postMenuUp.TabIndex = 3;
            this.postMenuUp.Text = "Up";
            this.postMenuUp.UseVisualStyleBackColor = true;
            this.postMenuUp.Click += new System.EventHandler(this.postMenuUp_Click);
            // 
            // postMenuDown
            // 
            this.postMenuDown.Location = new System.Drawing.Point(30, 388);
            this.postMenuDown.Name = "postMenuDown";
            this.postMenuDown.Size = new System.Drawing.Size(63, 50);
            this.postMenuDown.TabIndex = 4;
            this.postMenuDown.Text = "Down";
            this.postMenuDown.UseVisualStyleBackColor = true;
            this.postMenuDown.Click += new System.EventHandler(this.postMenuDown_Click);
            // 
            // postMenuParent
            // 
            this.postMenuParent.Location = new System.Drawing.Point(3, 32);
            this.postMenuParent.Name = "postMenuParent";
            this.postMenuParent.Size = new System.Drawing.Size(515, 118);
            this.postMenuParent.TabIndex = 0;
            this.postMenuParent.Text = "";
            // 
            // postMenuComments
            // 
            this.postMenuComments.Location = new System.Drawing.Point(3, 321);
            this.postMenuComments.Name = "postMenuComments";
            this.postMenuComments.Size = new System.Drawing.Size(515, 117);
            this.postMenuComments.TabIndex = 1;
            this.postMenuComments.Text = "";
            // 
            // postMenuThis
            // 
            this.postMenuThis.Location = new System.Drawing.Point(3, 179);
            this.postMenuThis.Name = "postMenuThis";
            this.postMenuThis.Size = new System.Drawing.Size(515, 116);
            this.postMenuThis.TabIndex = 2;
            this.postMenuThis.Text = "";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(4, 298);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(86, 20);
            this.commentsLabel.TabIndex = 3;
            this.commentsLabel.Text = "Comments";
            // 
            // parentPostLabel
            // 
            this.parentPostLabel.AutoSize = true;
            this.parentPostLabel.Location = new System.Drawing.Point(4, 9);
            this.parentPostLabel.Name = "parentPostLabel";
            this.parentPostLabel.Size = new System.Drawing.Size(92, 20);
            this.parentPostLabel.TabIndex = 4;
            this.parentPostLabel.Text = "Parent Post";
            // 
            // thisPostLabel
            // 
            this.thisPostLabel.AutoSize = true;
            this.thisPostLabel.Location = new System.Drawing.Point(8, 153);
            this.thisPostLabel.Name = "thisPostLabel";
            this.thisPostLabel.Size = new System.Drawing.Size(74, 20);
            this.thisPostLabel.TabIndex = 5;
            this.thisPostLabel.Text = "This Post";
            // 
            // likeComment
            // 
            this.likeComment.Location = new System.Drawing.Point(188, 358);
            this.likeComment.Name = "likeComment";
            this.likeComment.Size = new System.Drawing.Size(75, 52);
            this.likeComment.TabIndex = 5;
            this.likeComment.Text = "Like";
            this.likeComment.UseVisualStyleBackColor = true;
            this.likeComment.Click += new System.EventHandler(this.likeComment_Click);
            // 
            // likePost
            // 
            this.likePost.Location = new System.Drawing.Point(188, 213);
            this.likePost.Name = "likePost";
            this.likePost.Size = new System.Drawing.Size(75, 52);
            this.likePost.TabIndex = 6;
            this.likePost.Text = "Like";
            this.likePost.UseVisualStyleBackColor = true;
            this.likePost.Click += new System.EventHandler(this.likePost_Click);
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PostForm";
            this.Text = "Post";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button postMenuDown;
        private System.Windows.Forms.Button postMenuUp;
        private System.Windows.Forms.Button postMenuPublish;
        private System.Windows.Forms.TextBox postMenuText;
        private System.Windows.Forms.Label postMenuLabel;
        private System.Windows.Forms.Label thisPostLabel;
        private System.Windows.Forms.Label parentPostLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.RichTextBox postMenuThis;
        private System.Windows.Forms.RichTextBox postMenuComments;
        private System.Windows.Forms.RichTextBox postMenuParent;
        private System.Windows.Forms.Button likePost;
        private System.Windows.Forms.Button likeComment;
    }
}