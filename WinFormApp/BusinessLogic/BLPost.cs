using System;
using System.Collections.Generic;
using System.Text;
using DynamoDal.Objects;
using MongoDal.Objects;

namespace WinFormApp.BusinessLogic
{
    public class BLPost
    {
        public DynamoPost mainPost;
        public MongoPost addPost;

        public BLPost(DynamoPost dPost, MongoPost post)
        {
            mainPost = dPost;
            addPost = post;
        }
        public override string ToString()
        {
            return mainPost.ToString();
        }

        public List<string> GetLikes()
        {
            return addPost.likes;
        }
        public void ChangeLike(string nickname)
        {
            if(addPost.likes.IndexOf(nickname) == -1)
            {
                addPost.likes.Add(nickname);
            }
            else
            {
                addPost.likes.Remove(nickname);
            }
        }
    }
}
