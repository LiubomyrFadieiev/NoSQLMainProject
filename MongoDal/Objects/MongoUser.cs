using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDal.Objects
{
    public class MongoUser
    {
        [BsonId]
        [BsonElement("id")]
        public ObjectId id { get; set; }
        [BsonElement("nickname")]
        public string nickname { get; set; }
        [BsonElement("firstName")]
        public string firstName { get; set; }
        [BsonElement("lastName")]
        public string lastName { get; set; }
        [BsonElement("eMail")]
        public string eMail { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("interests")]
        public List<string> interests { get; set; }
        [BsonElement("follows")]
        public List<string> follows { get; set; }

        public MongoUser()
        {
            firstName = "";
            lastName = "";
        }
    }
}