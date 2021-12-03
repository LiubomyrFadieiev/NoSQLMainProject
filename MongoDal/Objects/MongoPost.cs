using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDal.Objects
{
    public class MongoPost
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId _id { get; set; }
        [BsonElement("id")]
        public string id { get; set; }
        [BsonElement("likes")]
        public List<string> likes { get; set; }
        public MongoPost()
        {
            this.id = default;
            this.likes = default;

        }
        public MongoPost(string guid)
        {
            this.id = guid;
            this.likes = new List<string>();
        }
        public override string ToString()
        {
            return "Likes: " + likes.Count.ToString();
        }
        //public void TakeTimezonesAway()
        //{
        //    string[] newtime = time.Split('G');
        //    time = newtime[0];
        //}
        //public string SetString()
        //{
        //    if (!isComment)
        //    {
        //        string format = String.Format("@{0}\nWritten at {1}\n{2}\n\t{3} likes", author, time, body, likes.Count());
        //        return format;
        //    }
        //    else
        //    {
        //        string format = String.Format("@{0}\nWritten at {1}\nAnswer to: @{2}\n{3}\n\t{4} likes", author, time, answerTo, body, likes.Count());
        //        return format;
        //    }
        //}
    }
}