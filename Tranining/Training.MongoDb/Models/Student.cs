using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training.MongoDBService;

namespace Training.MongoDb.Models
{
    [BsonIgnoreExtraElements]
    public class Student : IAggregateRoot
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "This field could be null.")]
        public string Name { get; set; }

        public string Class { get; set; }
    }
}
