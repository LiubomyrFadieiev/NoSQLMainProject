using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDal.Objects;

namespace MongoDal.DAL
{
    public class MongoUserDal
    {
        private string connString;
        public MongoUserDal(string connString)
        {
            this.connString = connString;
        }
        //find user with this login and password (return default-user if not found)
        public MongoUser GetUserByLogIn(string password, string login)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<BsonDocument> usersBsonCollection = database.GetCollection<BsonDocument>("users");
            var filterBuilder = Builders<BsonDocument>.Filter;

            var filter = (filterBuilder.Eq("eMail", login) & filterBuilder.Eq("password", password)) | (filterBuilder.Eq("nickname", login) & filterBuilder.Eq("password", password));
            var posts = usersBsonCollection.Find(filter).ToList();

            if (posts.Count() != 0)
            {
                return BsonSerializer.Deserialize<MongoUser>(posts[0]);
            }
            else
            {
                return new MongoUser();
            }

        }
        //find user by nickname and get only public information (fullname and count of follows)
        //(return default-user if not found)
        public (bool, string[]) GetUserByNickName(string name)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<BsonDocument> usersBsonCollection = database.GetCollection<BsonDocument>("users");
            var filterBuilder = Builders<BsonDocument>.Filter;

            var filter = (filterBuilder.Eq("nickname", name));
            var posts = usersBsonCollection.Find(filter).ToList();
            if (posts.Count == 0)
            {
                return (false, new string[0]);
            }
            else
            {
                MongoUser user = BsonSerializer.Deserialize<MongoUser>(posts[0]);

                string[] ourData = new string[2];
                ourData[0] = user.firstName;
                ourData[1] = user.lastName;
                return (true, ourData);
            }
        }
        //get followers of current user
        public long GetFollowers(string username)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<BsonDocument> usersBsonCollection = database.GetCollection<BsonDocument>("users");
            var filterBuilder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            filter = filterBuilder.Eq("follows", username);
            return usersBsonCollection.CountDocuments(filter);
        }
        //set new follows list for user
        public void SetFollowsList(MongoUser user, List<string> list)
        {
            List<MongoUser> stream = new List<MongoUser>();
            List<BsonDocument> bsonStream = new List<BsonDocument>();
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<MongoUser> usersBsonCollection = database.GetCollection<MongoUser>("users");
            var filterBuilder = Builders<MongoUser>.Filter;
            FilterDefinition<MongoUser> filter;

            filter = filterBuilder.Eq("nickname", user.nickname);
            var updateDefinition = Builders<MongoUser>.Update.Set("follows", list);
            var updateResult = usersBsonCollection.UpdateOne(filter, updateDefinition);
        }
    }
}