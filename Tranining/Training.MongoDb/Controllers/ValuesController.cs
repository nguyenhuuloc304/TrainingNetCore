using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Training.MongoDBService;
using Training.MongoDb.Models;

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
            var filter = Builders<Student>.Filter.Empty;
            var listStudent = _writeRepository.Find(filter).ToList();
            return Ok(listStudent);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var student = _writeRepository.Get<Student>(id);

            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student stu)
        {
            _writeRepository.Create(stu);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Student stu)
        {
            var student = _writeRepository.Get<Student>(id);
            if (stu != null)
            {
                stu.Id = student.Id;
            }

            _writeRepository.Replace(stu);

            return Ok(stu);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var student = _writeRepository.Get<Student>(id);

            _writeRepository.Delete(student);
            return Ok();
        }
    }
}
