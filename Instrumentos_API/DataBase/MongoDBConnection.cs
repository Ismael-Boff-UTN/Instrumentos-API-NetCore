using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instrumentos_API.DataBase
{
    public class MongoDBConnection
    {
        public MongoClient client;
        public IMongoDatabase mongoDb;

        public MongoDBConnection()
        {
            client = new MongoClient("mongodb+srv://<UserName>:<Password>@myclustermongo.jeyq0.mongodb.net");
            mongoDb = client.GetDatabase("instrumentos_db");
        }

    }
}
