using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDal.Objects;
using NeoDal.Objects;
using NeoDal.DAL;

namespace WinFormApp.BusinessLogic
{
    public partial class BLogic
    {
        public long GetFollowers(string name)
        {
            List<NeoUser> list = nuDal.GetFollowers(name);
            return list.Count();
        }
        public long GetFollows(string name)
        {
            List<NeoUser> list = nuDal.GetFollows(name);
            return list.Count();
        }
        public void SetFollowsList(MongoUser user, string follows, string action)
        {
            if (action == "add")
            {
                nuDal.SetFollower(user.nickname, follows);
            }
            else if (action == "remove")
            {
                nuDal.DeleteFollower(user.nickname, follows);
            }
        }
        public int GetLength(string user1, string user2)
        {
            return nuDal.FollowLength(user1, user2);
        }
    }
}
