using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDal.Objects
{
    public class Post
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId _id { get; set; }
        [BsonElement("id")]
        public int postid { get; set; }
        [BsonElement("isComment")]
        public bool isComment { get; set; }
        [BsonIgnoreIfDefault]
        public string answerTo { get; set; }
        [BsonElement("author")]
        public string author { get; set; }
        [BsonElement("time")]
        public string time { get; set; }
        [BsonElement("body")]
        public string body { get; set; }
        [BsonElement("likes")]
        public List<string> likes { get; set; }
        [BsonElement("commentsId")]
        public List<int> comments { get; set; }
        public Post()
        {
            this.postid = default;
            this.author = default;
            this.time = default;
            this.answerTo = default;
            this.isComment = default;
            this.body = default;
            this.likes = default;

        }
        public Post(int id, User user, string body, string parentAuthor = "")
        {
            this.postid = id;
            this.author = user.nickname;
            this.time = DateTime.UtcNow.ToString();
            this.answerTo = parentAuthor;
            this.isComment = parentAuthor != "";
            this.body = body;
            this.likes = new List<string>();
        }
        public void TakeTimezonesAway()
        {
            string[] newtime = time.Split('G');
            time = newtime[0];
        }
        public string SetString()
        {
            if (!isComment)
            {
                string format = String.Format("@{0}\nWritten at {1}\n{2}\n\t{3} likes", author, time, body, likes.Count());
                return format;
            }
            else
            {
                string format = String.Format("@{0}\nWritten at {1}\nAnswer to: @{2}\n{3}\n\t{4} likes", author, time, answerTo, body, likes.Count());
                return format;
            }
        }
    }
}