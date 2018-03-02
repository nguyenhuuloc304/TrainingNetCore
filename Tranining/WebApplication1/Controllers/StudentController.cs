using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

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
            //var listStudent = new List<Student>();
            //var stu1 = new Student();
            //stu1.Id = 1;
            //stu1.HoTen = "Van A";
            //stu1.Lop = "10";
            //stu1.NamSinh = 2000;

            //var stu2 = new Student();
            //stu2.Id = 2;
            //stu2.HoTen = "Van B";
            //stu2.Lop = "11";
            //stu2.NamSinh = 1999;

            //listStudent.Add(stu1);
            //listStudent.Add(stu2);
            return Ok(listStu);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Student stu)
        {
            //string studentString = JsonConvert.SerializeObject(stu);
            //System.IO.File.WriteAllText("student.txt",studentString);
            //
            var listStu = new List<Student>();
            try
            {
                var listStuString = System.IO.File.ReadAllText("ListStudent.txt");
                listStu = JsonConvert.DeserializeObject<List<Student>>(listStuString);
            }
            catch (Exception)
            {
            }
            //stu.Id = Guid.NewGuid().ToString();

            listStu.Add(stu);

            string studentString = JsonConvert.SerializeObject(listStu);
            System.IO.File.WriteAllText("ListStudent.txt", studentString);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Student stu)
        {
            var listStu = new List<Student>();
            var listStuString = System.IO.File.ReadAllText("ListStudent.txt");
            listStu = JsonConvert.DeserializeObject<List<Student>>(listStuString);

            foreach (var item in listStu)
            {
                if (item.Id == id)
                {
                    item.HoTen = "Nguyen ABC";
                }
            }

            string studentString = JsonConvert.SerializeObject(listStu);
            System.IO.File.WriteAllText("ListStudent.txt", studentString);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var listStu = new List<Student>();
            var listStuString = System.IO.File.ReadAllText("ListStudent.txt");
            listStu = JsonConvert.DeserializeObject<List<Student>>(listStuString);

            var delete = listStu.SingleOrDefault(t => t.Id == id);
            listStu.Remove(delete);

            string studentString = JsonConvert.SerializeObject(listStu);
            System.IO.File.WriteAllText("ListStudent.txt", studentString);
            return Ok();
        }
    }
}
