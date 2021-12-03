using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using DynamoDal.Objects;

namespace DynamoDal.DAL
{
    public class DynamoPostCommentDal
    {
        private readonly string tableName = "Stream";
        private readonly AmazonDynamoDBClient client;
        private readonly DynamoDBContext context;
        public DynamoPostCommentDal()
        {
            var credentials = new BasicAWSCredentials("fakeMyAccessKeyId", "fakeSecretAccessKey");
            var config = new AmazonDynamoDBConfig() 
            { 
                ServiceURL = "http://localhost:8000",
                AuthenticationRegion = "eu-central-1"
            };
            client = new AmazonDynamoDBClient(credentials,config);

            context = new DynamoDBContext(client);
        }
        public bool UpdatePost(DynamoPost post, string body)
        {
            string isoUpdateTime = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);

            post.PostText = body;
            post.ModifiedDT = isoUpdateTime;

            try
            {
                var response = context.SaveAsync<DynamoPost>(post);
                response.Wait();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string CreatePost(string userid, string body)
        {
            string guid = Guid.NewGuid().ToString();
            string isoTime = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);

            DynamoPost newPost = new DynamoPost()
            {
                PK = "POST#" + guid,
                SK = "POST#" + guid,
                PostId = guid,
                UserId = userid,
                PostText = body,
                CreatedDT = isoTime,
                ModifiedDT = isoTime
            };

            try
            {
                var responce = context.SaveAsync<DynamoPost>(newPost);
                responce.Wait();
            }
            catch
            {
                return "";
            }
            return guid;
        }
        public bool DeletePost(DynamoPost post)
        {
            var request = new UpdateItemRequest()
            {
                Key = new Dictionary<string, AttributeValue>()
                {
                    {"PK", new AttributeValue(){S = post.PK}}
                },
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    {"#IsDeleted", "IsDeleted"}
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":delete", new AttributeValue(){N = "1"} }
                },
                UpdateExpression = "SET #IsDeleted = :delete"  
            };
            try
            {
                var response = client.UpdateItemAsync(request);
                response.Wait();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateComment(DynamoComment comment, string body)
        {
            string isoUpdateTime = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);

            comment.PostText = body;
            comment.ModifiedDT = isoUpdateTime;
            comment.GSI1SK = isoUpdateTime;

            try
            {
                var response = context.SaveAsync<DynamoComment>(comment);
                response.Wait();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string CreateComment(string body, DynamoPost parentpost, string userid)
        {
            string guid = Guid.NewGuid().ToString();
            string isoTime = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
            DynamoComment newComment = new DynamoComment()
            {
                PK = "COMMENT#" + guid,
                SK = "COMMENT#" + guid,
                CommentId = guid,
                PostId = parentpost.PostId,
                UserId = userid,
                PostText = body,
                CreatedDT = isoTime,
                ModifiedDT = isoTime,
                GSI1PK = "POSTCOMMENT#" + parentpost.PostId,
                GSI1SK = isoTime
            };
            try
            {
                var response = context.SaveAsync<DynamoComment>(newComment);
                response.Wait();
            }
            catch
            {
                return "";
            }
            return guid;
        }
        public bool DeleteComment(DynamoComment comment)
        {
            var request = new UpdateItemRequest()
            {
                Key = new Dictionary<string, AttributeValue>()
                {
                    {"PK", new AttributeValue(){S = comment.PK}}
                },
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    {"#IsDeleted", "IsDeleted"}
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":delete", new AttributeValue(){N = "1"} }
                },
                UpdateExpression = "SET #IsDeleted = :delete"
            };
            try
            {
                var response = client.UpdateItemAsync(request);
                response.Wait();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public List<DynamoPost> GetUserPosts(string user)
        {
            var data = context.ScanAsync<DynamoComment>(new List<ScanCondition>()
            {
                new ScanCondition("UserId",ScanOperator.Equal,user),
                new ScanCondition("CommentId",ScanOperator.IsNull)

            }).GetRemainingAsync();
            data.Wait();
            List<DynamoPost> posts = DynamoPost.ConvertToPost(data.Result);
            return posts;
        }
        //    QueryRequest request = new QueryRequest()
        //    {
        //        TableName = tableName,
        //        IndexName = "GSI1",
        //        FilterExpression = "#user = :id",
        //        ExpressionAttributeNames = new Dictionary<string, string>()
        //        {
        //            { "#user","UserId" }
        //        },
        //        ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
        //        {
        //            {":id", new AttributeValue(){ S = user } }
        //        },
        //        ScanIndexForward = true
        //    };
        //    var data = client.QueryAsync(request);
        //    data.Wait();
        //    var items = data.Result.Items;
        //    List<DynamoPost> posts = new List<DynamoPost>();
        //    foreach (Dictionary<string, AttributeValue> d in items)
        //    {
        //        var post = new DynamoPost()
        //        {
        //            PK = d["PK"].S,
        //            SK = d["SK"].S,
        //            PostId = d["PostId"].S,
        //            UserId = d["UserId"].S,
        //            PostText = d["PostText"].S,
        //            CreatedDT = d["CreatedDT"].S,
        //            ModifiedDT = d["ModifiedDT"].S,
        //        };
        //        posts.Add(post);
        //    }
        //    foreach(DynamoPost p in posts)
        //    {
        //        if (p.PK.Contains("COMMENT#"))
        //        {
        //            posts.Remove(p);
        //        }
        //    }
        //    return posts;
        //}
        public List<DynamoComment> GetUserComments(string user)
        {
                var data = context.ScanAsync<DynamoComment>(new List<ScanCondition>()
            {
                new ScanCondition("UserId",ScanOperator.Equal,user),
                new ScanCondition("CommentId",ScanOperator.IsNotNull)

            }).GetRemainingAsync();
                data.Wait();
                return data.Result;
            }
        public List<DynamoComment> GetCommentsForPost(DynamoPost post)
        {
            string postComment = "POSTCOMMENT#" + post.PostId;
            QueryRequest request = new QueryRequest()
            {
                TableName = tableName,
                IndexName = "GSI1",
                KeyConditionExpression = "#pk = :postcomment",
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    { "#pk","GSI1PK" }
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":postcomment", new AttributeValue(){ S = postComment } }
                },
                ScanIndexForward = true
            };
            var data = client.QueryAsync(request);
            data.Wait();
            var items = data.Result.Items;
            List<DynamoComment> comments = new List<DynamoComment>();
            foreach(Dictionary<string,AttributeValue> d in items)
            {
                var comment = new DynamoComment()
                {
                    PK = d["PK"].S,
                    SK = d["SK"].S,
                    CommentId = d["CommentId"].S,
                    PostId = d["PostId"].S,
                    UserId = d["UserId"].S,
                    PostText = d["PostText"].S,
                    CreatedDT = d["CreatedDT"].S,
                    ModifiedDT = d["ModifiedDT"].S,
                    GSI1PK = d["GSI1PK"].S,
                    GSI1SK = d["GSI1SK"].S
                };
                comments.Add(comment);
            }
            return comments;
        }
        public List<DynamoPost> GetParentPost(DynamoPost comment)
        {
            string pk = "POST#" + comment.PostId;

            var data = context.QueryAsync<DynamoPost>(pk).GetRemainingAsync();

            return data.Result;
        }
    }
}
