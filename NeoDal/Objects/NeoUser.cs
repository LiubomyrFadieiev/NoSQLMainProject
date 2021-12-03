using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;

namespace NeoDal.Objects
{
    public class NeoUser
    {
        [JsonProperty(PropertyName = "nickname")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "fName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "lName")]
        public string lastName { get; set; }
    }
}
