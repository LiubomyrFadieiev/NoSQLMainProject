using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDal.Objects
{
    [DynamoDBTable("Stream")]
    public class DynamoComment : DynamoPost
    {
        [DynamoDBProperty("CommentId")]
        public string CommentId { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey]
        [DynamoDBProperty("GSI1PK")]
        public string GSI1PK { get; set; }
        [DynamoDBGlobalSecondaryIndexRangeKey]
        [DynamoDBProperty("GSI1SK")]
        public string GSI1SK { get; set; }
    }
}
