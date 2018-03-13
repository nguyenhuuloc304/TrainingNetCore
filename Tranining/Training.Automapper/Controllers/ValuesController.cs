using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Automapper.Models;
using AutoMapper;

namespace Training.Automapper.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
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
        public IActionResult Post([FromBody]StudentRequest request)
        {
            var listStuRequest = new List<StudentRequest>();
            listStuRequest.Add(new StudentRequest() { Id = "abc", Name = "nguyen", Class = "Dth4", Year = "2018" });
            listStuRequest.Add(new StudentRequest() { Id = "abd", Name = "nguyen 1", Class = "Dth4", Year = "2012" });
            listStuRequest.Add(new StudentRequest() { Id = "abf", Name = "nguyen 2", Class = "Dth4", Year = "2014" });
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<StudentRequest, StudentResponse>();

            });

            var Mapper = config.CreateMapper();
            var stu = Mapper.Map<List<StudentRequest>, List<StudentResponse>>(listStuRequest);
            return Ok(stu);
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
