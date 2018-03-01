using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Training.MongoDb.Models;

namespace Training.MongoDb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var mongoDbConnectionString = "mongodb://orient:orient@ds159235.mlab.com:59235/candidate";
            IMongoClient mongoClient = new MongoClient(mongoDbConnectionString);
            var mongoDatabase = mongoClient.GetDatabase("candidate");

            var collection = mongoDatabase.GetCollection<Student>("Student");
            collection.InsertOne(new Student() { Id = "baacs", Class = "Nguyen a" });

            var collection1 = mongoDatabase.GetCollection<Student>("Students");
            collection1.InsertOne(new Student() { Id = "bacsasa", Class = "Nguyen b" });


            var filter = Builders<Student>.Filter.Where(it => it.Id == "445ab111-33d2-4909-89dc-c5c44ea57b60");
            var stus = collection.Find(filter).ToList();

            return Ok(stus);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
