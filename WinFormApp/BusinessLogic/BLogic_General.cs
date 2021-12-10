using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDal.Objects;
using MongoDal.DAL;
using NeoDal.Objects;
using NeoDal.DAL;
using DynamoDal.Objects;
using DynamoDal.DAL;
using RedisDAL.DAL;

namespace WinFormApp.BusinessLogic
{
    public partial class BLogic
    {
        //all dal-elements
        NeoUserDal nuDal;
        MongoUserDal muDal;
        MongoPostDal mpDal;
        DynamoPostCommentDal dpDal;
        RedisDal rpDal;
        List<string> keys;

        //constructor
        public BLogic()
        {
            string connString = ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;
            string neoConnString = ConfigurationManager.ConnectionStrings["neo4j"].ConnectionString;
            string username = ConfigurationManager.ConnectionStrings["neologin"].ConnectionString;
            string password = ConfigurationManager.ConnectionStrings["neopassword"].ConnectionString;

            nuDal = new NeoUserDal(neoConnString, username, password);
            muDal = new MongoUserDal(connString);
            mpDal = new MongoPostDal(connString);
            dpDal = new DynamoPostCommentDal();
            rpDal = new RedisDal("localhost");
            keys = new List<string>();
        }
    }
}
