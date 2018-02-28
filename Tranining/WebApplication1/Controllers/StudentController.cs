using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var listStuString = System.IO.File.ReadAllText("ListStudent.txt");
            var listStu = JsonConvert.DeserializeObject<List<Student>>(listStuString);
            return Ok(listStu);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Student stu)
        {
            var listStu = new List<Student>();
            try
            {
                var listStuString = System.IO.File.ReadAllText("ListStudent.txt");
                listStu = JsonConvert.DeserializeObject<List<Student>>(listStuString);
            }
            catch (Exception)
            {
            }
            
            stu.Id = Guid.NewGuid().ToString();
            listStu.Add(stu);

            string studentString = JsonConvert.SerializeObject(listStu);
            
            System.IO.File.WriteAllText("ListStudent.txt", studentString);
            return Ok();
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
