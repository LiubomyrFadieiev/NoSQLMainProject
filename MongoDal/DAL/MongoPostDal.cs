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
    public class MongoPostDal
    {
        private string connString;

        public MongoPostDal(string connString)
        {
            this.connString = connString;
        }
        //get posts for tab "Stream" (posts of followed users + this user's posts)
        public List<MongoPost> GetPostForStream(MongoUser currentUser)
        {
            List<string> follows = currentUser.follows;
            follows.Add(currentUser.nickname);
            List<MongoPost> stream = new List<MongoPost>();

            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLDatabase");
            IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
            var filterBuilder = Builders<MongoPost>.Filter;
            FilterDefinition<MongoPost> filter;

            foreach (string str in follows)
            {
                filter = filterBuilder.Eq("author", str);
                var posts = postsCollection.Find(filter).Sort("{time:-1}").ToList<MongoPost>();
                stream.AddRange(posts);
            }

            return stream;
        }
        //get posts of current user
        public List<MongoPost> GetUserPosts(string username)
        {
            List<MongoPost> stream = new List<MongoPost>();

            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLDatabase");
            IMongoCollection<MongoPost> postCollection = database.GetCollection<MongoPost>("posts");
            var filterBuilder = Builders<MongoPost>.Filter;

            var filter = filterBuilder.Eq("author", username);
            var posts = postCollection.Find(filter).Sort("{time:-1}").ToList<MongoPost>();
            stream.AddRange(posts);

            return stream;
        }
        //insert in DB new post
        public void InsertPost(string guid)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLDatabase");
            IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");

            MongoPost insertPost = new MongoPost(guid);

            postsCollection.InsertOne(insertPost);
        }
        //get id of last post
        //public int GetMaxId()
        //{
        //    var client = new MongoClient(connString);
        //    var database = client.GetDatabase("NoSQLTask");
        //    IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
        //    BsonDocument filter = new BsonDocument();

        //    var post = postsCollection.Find(filter).Sort("{id:-1}").FirstOrDefault();
        //    return post.postid;
        //}
        //get patent post (post, for which our post is a comment)
        //public (bool, MongoPost) GetParentPost(MongoPost post)
        //{
        //    var client = new MongoClient(connString);
        //    var database = client.GetDatabase("NoSQLTask");
        //    IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
        //    var filterBuilder = Builders<MongoPost>.Filter;

        //    var filter = filterBuilder.Eq("commentsId", post.postid);
        //    var posts = postsCollection.Find(filter).ToList();

        //    if (posts.Count == 0)
        //    {
        //        return (false, new MongoPost());
        //    }
        //    else
        //    {
        //        return (true, posts[0]);
        //    }
        //}
        //get comments of current post
        //public List<MongoPost> GetPostComments(MongoPost post)
        //{
        //    List<MongoPost> stream = new List<MongoPost>();

        //    var client = new MongoClient(connString);
        //    var database = client.GetDatabase("NoSQLTask");
        //    IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
        //    var filterBuilder = Builders<MongoPost>.Filter;

        //    foreach (int postid in post.comments)
        //    {
        //        var filter = filterBuilder.Eq("id", postid);
        //        var posts = postsCollection.Find(filter).ToList();
        //        stream.AddRange(posts);
        //    }
        //    return stream;
        //}
        //isert new post and add it to our post's comment list
        //public void UpdateComments(MongoPost post, MongoUser user, string body)
        //{
        //    var client = new MongoClient(connString);
        //    var database = client.GetDatabase("NoSQLTask");
        //    IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
        //    var filterBuilder = Builders<MongoPost>.Filter;

        //    MongoPost insertComment = new MongoPost(GetMaxId() + 1, user, body, post.author);
        //    postsCollection.InsertOne(insertComment);

        //    var filter = filterBuilder.Eq("id", post.postid);
        //    var updateDefinition = Builders<MongoPost>.Update.AddToSet("commentsId", insertComment.postid);
        //    var updateResult = postsCollection.UpdateOne(filter, updateDefinition);
        //}
        //set new likes list
        public void SetLikes(MongoPost post)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLDatabase");
            IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
            var filterBuilder = Builders<MongoPost>.Filter;
            var filter = filterBuilder.Eq("id", post.id);

            var updateDefinition = Builders<MongoPost>.Update.Set("likes", post.likes);
            var updateResult = postsCollection.UpdateOne(filter, updateDefinition);
        }
        public MongoPost GetPostById(string id)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLDatabase");
            IMongoCollection<MongoPost> postsCollection = database.GetCollection<MongoPost>("posts");
            var filterBuilder = Builders<MongoPost>.Filter;
            var filter = filterBuilder.Exists("id");
            var posts = postsCollection.Find<MongoPost>(filter).ToList();
            var ourPost = posts.Find(p => p.id == id);
            return ourPost;
        }
    }
}