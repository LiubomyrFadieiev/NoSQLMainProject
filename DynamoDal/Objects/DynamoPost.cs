using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDal.Objects
{
    [DynamoDBTable("Stream")]
    public class DynamoPost
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("PK")]
        public string PK { get; set; }
        [DynamoDBRangeKey]
        [DynamoDBProperty("SK")]
        public string SK { get; set; }
        [DynamoDBProperty("PostId")]
        public string PostId { get; set; }
        [DynamoDBProperty("UserId")]
        public string UserId { get; set; }
        [DynamoDBProperty("PostText")]
        public string PostText { get; set; }
        [DynamoDBProperty("CreatedDT")]
        public string CreatedDT { get; set; }
        [DynamoDBProperty("ModifiedDT")]
        public string ModifiedDT { get; set; }

        public override string ToString()
        {
            return String.Format($"Written by @{UserId}\n{PostText}\nLast modified at{ModifiedDT}");
        }
    }
}
