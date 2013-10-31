using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbModel
{
    public class Connector
    {
        public static MongoDatabase GetDb(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            MongoDatabase db = server.GetDatabase(dbName);

            return db;
        }
    }
}
