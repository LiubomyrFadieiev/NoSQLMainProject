﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDal.DAL;
using MongoDal.Objects;

namespace WinFormApp.BusinessLogic
{
    //MongoDB business logic
    public partial class BLogic
    {
        //find user by login and password
        public (bool, User) Authorize(string credit, string password)
        {
            User user = muDal.GetUserByLogIn(password, credit);
            if (user.firstName != "")
            {
                return (true, user);
            }
            else
            {
                return (false, user);
            }
        }
        //public void UpdateComments(Post post, User user, string body)
        //{
        //    mpDal.UpdateComments(post, user, body);
        //}
        public void SetLikes(Post post)
        {
            mpDal.SetLikes(post);
        }
        public (bool,string[]) GetUserByNickname(string nickname)
        {
            return muDal.GetUserByNickName(nickname);
        }
        public Post GetPostByKey(string key)
        {
            return mpDal.GetPostById(key);
        }
    }
}
