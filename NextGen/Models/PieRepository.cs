using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ADD THIS PART TO YOUR CODE

using MongoDB.Driver;
using System.Security.Authentication;
using Microsoft.Azure.Documents;
using MongoDB.Bson;

namespace NextGen.Models
{
    public class PieRepository : IPieRepository
    {

        private string dbName = "Exams";
        private string collectionName = "injections";
        MongoClient mongoClient;



        public PieRepository()
        {

            string connectionString = @"mongodb://nextgendb:FZoGg1HmPCs3Zic1C1dNv33WVYGSrha2K9drOrnvMPUjwQMphRj5XkamnkM4e55LKKhPIxRQfBUIiqP7NR4hAw==@nextgendb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            mongoClient = new MongoClient(settings);
           
        }

       

      

        public void InsertRecord()
        {


            var collection = mongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);

            var document = new BsonDocument
                                {
                                    { "item", "canvas" },
                                    { "qty", 100 },
                                    { "tags", new BsonArray { "cotton" } },
                                    { "size", new BsonDocument { { "h", 28 }, { "w", 35.5 }, { "uom", "cm" } } }
                                };
            collection.InsertOne(document);

        }



    }
}
