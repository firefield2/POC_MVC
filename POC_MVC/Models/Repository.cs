using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_API.Models
{
    public class Repository<T> where T : IBson
    {
        IMongoCollection<T> collection;
        IMongoClient client;
        IMongoDatabase database;
        public Repository(string collectionName)
        {
            client = new MongoClient("mongodb://admin:Thespartans1_@test-shard-00-00-ghbkj.mongodb.net:27017,test-shard-00-01-ghbkj.mongodb.net:27017,test-shard-00-02-ghbkj.mongodb.net:27017/test?ssl=true&replicaSet=Test-shard-0&authSource=admin");
            database = client.GetDatabase("test");
            //database.DropCollection(collectionName);
            GetCollection(collectionName);

        }

        public IEnumerable<T> List()
        {
            return collection.Find(new BsonDocument()).ToEnumerable();
        }

        public IMongoCollection<T> GetCollection(string collectionName)
        {
            return collection = database.GetCollection<T>(collectionName);
        }

        public T FindById(ObjectId id)
        {
            return collection.Find(x => x._id == id).FirstOrDefault();
        }

        public void Add (T element)
        {
            collection.InsertOne(element);
        }

        public void Update(T element)
        {
            collection.ReplaceOne(x=> x._id ==element._id, element);
        }
        public void Delete(ObjectId id)
        {
            collection.DeleteOne(x => x._id == id);
        }
    }
}