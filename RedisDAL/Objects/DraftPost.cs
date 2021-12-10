using System;
using System.Collections.Generic;
using System.Text;

namespace RedisDAL.Objects
{
    public class DraftPost
    {
        public string body;
        public string user;

        public DraftPost(string user, string body)
        {
            this.body = body;
            this.user = user;
        }
        public DraftPost()
        {
            this.body = string.Empty;
            this.body = string.Empty;
        }
    }
}
