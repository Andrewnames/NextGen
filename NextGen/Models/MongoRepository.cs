using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// ADD THIS PART TO YOUR CODE

using MongoDB.Driver;
using System.Security.Authentication;
using MongoDB.Bson;
using System.Diagnostics;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.Options;

namespace NextGen.Models
{
    public class MongoRepository : IRepository
    {

        private string dbName = "NextGenDB";
        private string collectionName = "Devices";
        public MongoClient MongoClient;





        public MongoRepository()
        {

            string connectionString = @"mongodb://nextgendb:FZoGg1HmPCs3Zic1C1dNv33WVYGSrha2K9drOrnvMPUjwQMphRj5XkamnkM4e55LKKhPIxRQfBUIiqP7NR4hAw==@nextgendb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            MongoClient = new MongoClient(settings);
           
        }




        public BsonDocument GetInjectorRecords()
        {
            BsonClassMap.RegisterClassMap<DeviceRecord>();
            var filter = Builders<BsonDocument>.Filter.Eq("device", "injector");
            var collection = MongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
            return collection.Find(filter).FirstOrDefault();
        }
        public void InsertRecord()
        {
            BsonClassMap.RegisterClassMap<DeviceRecord>(cm =>
            {
                cm.AutoMap();
                var customDictionarySerializer = new DictionaryInterfaceImplementerSerializer<Dictionary<string, string>>(
                    dictionaryRepresentation: DictionaryRepresentation.Document,
                    keySerializer: new StringSerializer(BsonType.String),
                    valueSerializer: BsonSerializer.SerializerRegistry.GetSerializer<string>());
                cm.GetMemberMap(c => c.models).SetSerializer(customDictionarySerializer);
            });

            var collection = MongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
            var document = new DeviceRecord
            { Id = new ObjectId(),
                device = "injector",
                models =
                                   new Dictionary<string, string> {
                                  {  "stellant", "https://www.radiologysolutions.bayer.com/static/media/images/content/medrad.jpg"  },
                                   { "mrxp", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzonl3K7icIGwBLaWdG0X4KOJQweCgRafemz29v-SKG8Bb_3I-1g" },
                                   { "centargo", "https://i.gyazo.com/0138e1bfd26d7598f23881243eedd4f8.png" }
                                   }
                                  
                                };
            collection.InsertOne(document.ToBsonDocument());
        
    }
    }
}
