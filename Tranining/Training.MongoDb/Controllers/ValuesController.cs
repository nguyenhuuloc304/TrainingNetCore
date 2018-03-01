using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Training.MongoDb.Models;
using Training.MongoDBService;

namespace Training.MongoDb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMongoDbWriteRepository _writeRepository;
        public ValuesController(IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var collection = _writeRepository.GetCollection<Student>();
            _writeRepository.Create(new Student() { Id = "baacs", Name = "Nguyen a" });
                
            var collection1 = _writeRepository.GetCollection<Student>();
            collection1.InsertOne(new Student() { Id = "bacsasa", Name = "Nguyen b" });


            //var filter = Builders<Student>.Filter.Where(it => it.Id == "445ab111-33d2-4909-89dc-c5c44ea57b60");
            //var stus = collection.Find(filter).ToList();

            return Ok();
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
