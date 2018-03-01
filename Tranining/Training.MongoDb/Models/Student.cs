using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.MongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
