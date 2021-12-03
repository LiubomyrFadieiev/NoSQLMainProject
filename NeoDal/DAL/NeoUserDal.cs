using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using Neo4j.Driver;
using NeoDal.Objects;

namespace NeoDal.DAL
{
    public class NeoUserDal
    {
        private string connString;
        private string username;
        private string password;
        public NeoUserDal(string connString, string username, string password)
        {
            this.connString = connString;
            this.username = username;
            this.password = password;
        }
        public List<NeoUser> GetFollowers(string name)
        {
            List<String> followers = new List<string>();

            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            string query = String.Format("(user:User {{nickname: '{0}'}})<-[f:FOLLOWS]-(follower)", name);
            var result = graphClient.Cypher
                .Match("(user: User {nickname: {username} })<-[f: FOLLOWS]-(follower)")
                .WithParam("username", name)
                .Return(follower => follower.As<NeoUser>()).Results;
            return result.ToList<NeoUser>();
        }
        public List<NeoUser> GetFollows(string name)
        {
            List<String> followers = new List<string>();

            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            string query = String.Format("(user:User {{nickname: '{0}'}})<-[f:FOLLOWS]-(follower)", name);
            var result = graphClient.Cypher
                .Match("(user: User {nickname: {username} })-[f: FOLLOWS]->(follows)")
                .WithParam("username", name)
                .Return(follows => follows.As<NeoUser>()).Results;
            return result.ToList<NeoUser>();
        }
        public void SetFollower(string user, string follower)
        {
            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            graphClient.Cypher
                .Match("(f:User {nickname: {follower} }), (u:User {nickname: {user} })")
                .WithParam("follower", follower)
                .WithParam("user", user)
                .Create("(f)-[:FOLLOWS]->(u)")
                .ExecuteWithoutResults();
        }
        public void DeleteFollower(string user, string follower)
        {
            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            graphClient.Cypher
                .Match("(f:User {nickname : {follower} })-[r:FOLLOWS]->(u:User {nickname: {user} })")
                .WithParam("follower", follower)
                .WithParam("user", user)
                .Delete("r")
                .ExecuteWithoutResults();
        }
        public void DeleteUser(string user)
        {
            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            graphClient.Cypher
                .Match("(user:User {nickname: {user} })")
                .WithParam("user", user)
                .OptionalMatch("(user)-[r]-()")
                .Delete("r,user")
                .ExecuteWithoutResults();
        }
        public void CreateUser(NeoUser user)
        {
            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            graphClient.Cypher
                .Create("(newuser:User {newUser})")
                .WithParam("newUser", user)
                .ExecuteWithoutResults();
        }
        public int FollowLength(string user1, string user2)
        {
            var graphClient = new GraphClient(new Uri(connString), username, password);
            graphClient.Connect();
            int result = graphClient.Cypher
                .Match("(u:User {nickname: {user1} }),(f:User {nickname: {user2} }), p = ShortestPath((u)-[*]-(f))")
                .WithParam("user1", user1)
                .WithParam("user2", user2)
                .Return(p => Return.As<int>("length(p)")).Results.FirstOrDefault();
            return result;
        }
    }
}