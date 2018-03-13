using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.Automapper.Models
{
    public class StudentRequest
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Year { get; set; }
    }
}
