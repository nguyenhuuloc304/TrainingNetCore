using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.MongoDBService;

namespace Training.MongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class Student : IAggregateRoot
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
