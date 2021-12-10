using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DynamoDal.Objects;
using RedisDAL.Objects;
using StackExchange.Redis;

namespace RedisDAL.DAL
{
    public class RedisDal
    {
        ConnectionMultiplexer connection;
        public RedisDal(string host)
        {
            this.connection = ConnectionMultiplexer.Connect("localhost, abortConnect = false, connectTimeout = 30000, responseTimeout = 30000");
        }
        public string SetPostDraft(DraftPost post, int? time = null)
        {
            TimeSpan? expireTime = null;
            if(time != null) { expireTime = TimeSpan.FromSeconds(Convert.ToDouble(time)); }
            var db = connection.GetDatabase();
            var jsonReadyPost = JsonSerializer.Serialize<DraftPost>(post);
            string key = Guid.NewGuid().ToString();
            db.StringSet(key, jsonReadyPost, expireTime);
            return key;
        }
        public (bool,DraftPost) GetPostDraft(string key)
        {
            var db = connection.GetDatabase();
            var value = db.StringGet(key);
            if (value.IsNull)
            {
                DraftPost post = new DraftPost();
                return (false, post);
            }
            else
            {
                var jsonPost = value.ToString();
                DraftPost post = JsonSerializer.Deserialize<DraftPost>(jsonPost);
                return (true, post);
            }
        }
        public bool DeleteDraft(string key)
        {
            var db = connection.GetDatabase();
            return db.KeyDelete(key);
        }
    }
}
