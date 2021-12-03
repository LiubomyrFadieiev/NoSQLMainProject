using System;
using System.Collections.Generic;
using System.Text;
using MongoDal.Objects;
using DynamoDal.DAL;
using DynamoDal.Objects;

namespace WinFormApp.BusinessLogic
{
    public partial class BLogic
    {
        public List<DynamoPost> GetPostsForStream(MongoUser user)
        {
            List<DynamoPost> posts = new List<DynamoPost>();
            List<string> people = user.follows;
            people.Add(user.nickname);
            foreach(string u in people)
            {
                posts.AddRange(dpDal.GetUserPosts(u));
            }
            posts.Sort(delegate (DynamoPost p1, DynamoPost p2) {
                DateTime d1 = DateTime.Parse(p1.ModifiedDT, null, System.Globalization.DateTimeStyles.RoundtripKind);
                DateTime d2 = DateTime.Parse(p2.ModifiedDT, null, System.Globalization.DateTimeStyles.RoundtripKind);
                return DateTime.Compare(d1, d2);
                });
            return posts;
        }
        public List<DynamoPost> GetUserPosts(string nickname)
        {
            List<DynamoPost> posts = new List<DynamoPost>();
            posts.AddRange(dpDal.GetUserPosts(nickname));
            return posts;
        }
        public bool InsertPost(MongoUser user, string body)
        {
            string guid = dpDal.CreatePost(user.nickname, body);
            guid = "POST#" + guid;
            mpDal.InsertPost(guid);
            return true;
        }
        public bool InsertComment(DynamoPost post, MongoUser user, string body)
        {
            string guid = dpDal.CreateComment(body, post, user.nickname);
            guid = "COMMENT#" + guid;
            mpDal.InsertPost(guid);
            return true;
        }
        public (bool, DynamoPost) GetParentPost(DynamoPost comment)
        {
            List<DynamoPost> posts = dpDal.GetParentPost(comment);
            if (posts.Count != 0)
            {
                if(posts[0].PK != comment.PK)
                {
                    return (true, posts[0]);
                }
            }
            return (false, new DynamoPost());
        }
        public List<DynamoComment> GetPostsComments(DynamoPost post)
        {
            return dpDal.GetCommentsForPost(post);
        }
        public bool UpdateComment(DynamoComment comment, string body)
        {
            return dpDal.UpdateComment(comment, body);
        }
        public bool UpdatePost(DynamoPost post, string body)
        {
            return dpDal.UpdatePost(post, body);
        }
    }
}
