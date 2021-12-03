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
        public List<Post> GetPostForStream(User currentUser)
        {
            List<string> follows = currentUser.follows;
            follows.Add(currentUser.nickname);
            List<Post> stream = new List<Post>();

            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;
            FilterDefinition<Post> filter;

            foreach (string str in follows)
            {
                filter = filterBuilder.Eq("author", str);
                var posts = postsCollection.Find(filter).Sort("{time:-1}").ToList<Post>();
                stream.AddRange(posts);
            }
            foreach (Post p in stream)
            {
                p.TakeTimezonesAway();
            }

            stream.Sort(delegate (Post p1, Post p2) {
                return Convert.ToDateTime(p1.time).CompareTo(Convert.ToDateTime(p2.time));
            });

            return stream;
        }
        //get posts of current user
        public List<Post> GetUserPosts(string username)
        {
            List<Post> stream = new List<Post>();

            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;

            var filter = filterBuilder.Eq("author", username);
            var posts = postCollection.Find(filter).Sort("{time:-1}").ToList<Post>();
            stream.AddRange(posts);
            foreach (Post p in stream)
            {
                p.TakeTimezonesAway();
            }

            return stream;
        }
        //insert in DB new post
        public void InsertPost(User user, string body)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");

            Post insertPost = new Post(GetMaxId() + 1, user, body);

            postsCollection.InsertOne(insertPost);
        }
        //get id of last post
        public int GetMaxId()
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            BsonDocument filter = new BsonDocument();

            var post = postsCollection.Find(filter).Sort("{id:-1}").FirstOrDefault();
            return post.postid;
        }
        //get patent post (post, for which our post is a comment)
        public (bool, Post) GetParentPost(Post post)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;

            var filter = filterBuilder.Eq("commentsId", post.postid);
            var posts = postsCollection.Find(filter).ToList();

            if (posts.Count == 0)
            {
                return (false, new Post());
            }
            else
            {
                return (true, posts[0]);
            }
        }
        //get comments of current post
        public List<Post> GetPostComments(Post post)
        {
            List<Post> stream = new List<Post>();

            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;

            foreach (int postid in post.comments)
            {
                var filter = filterBuilder.Eq("id", postid);
                var posts = postsCollection.Find(filter).ToList();
                stream.AddRange(posts);
            }
            return stream;
        }
        //isert new post and add it to our post's comment list
        public void UpdateComments(Post post, User user, string body)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;

            Post insertComment = new Post(GetMaxId() + 1, user, body, post.author);
            postsCollection.InsertOne(insertComment);

            var filter = filterBuilder.Eq("id", post.postid);
            var updateDefinition = Builders<Post>.Update.AddToSet("commentsId", insertComment.postid);
            var updateResult = postsCollection.UpdateOne(filter, updateDefinition);
        }
        //set new likes list
        public void SetLikes(Post post)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;
            var filter = filterBuilder.Eq("id", post.postid);

            var updateDefinition = Builders<Post>.Update.Set("likes", post.likes);
            var updateResult = postsCollection.UpdateOne(filter, updateDefinition);
        }
        public Post GetPostById(string id)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase("NoSQLTask");
            IMongoCollection<Post> postsCollection = database.GetCollection<Post>("posts");
            var filterBuilder = Builders<Post>.Filter;
            var filter = filterBuilder.Eq("id", id);

            var posts = postsCollection.Find(filter).ToList();
            return posts[0];
        }
    }
}