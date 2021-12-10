using DynamoDal.Objects;
using RedisDAL.DAL;
using RedisDAL.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormApp.BusinessLogic
{
    partial class BLogic
    {

        public List<DraftPost> GetAllDraft()
        {
            List<DraftPost> posts = new List<DraftPost>();
            foreach(string key in keys)
            {
                var post = rpDal.GetPostDraft(key);
                if (post.Item1)
                {
                    posts.Add(post.Item2);
                }
            }
            return posts;
        }
        public (bool,DraftPost) GetSelectedPost(string key)
        {
            return rpDal.GetPostDraft(key);
        }
        public void AddDraft(DraftPost post, int? time)
        {
            string key;
            if(time != null)
            {
                key = rpDal.SetPostDraft(post, time);
            }
            else
            {
                key = rpDal.SetPostDraft(post);
            }
            keys.Add(key);
        }
        public bool DeleteDraft(int index)
        {
            bool result = rpDal.DeleteDraft(keys[index]);
            if (result)
            {
                keys.RemoveAt(index);
            }
            return result;
        }
    }
}
