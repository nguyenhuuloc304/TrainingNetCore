using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.UploadFile.Models
{
    public class UploadFilesResponseModel
    {
        public string BaseUrl { get; set; }

        public string[] Paths { get; set; }
    }
}
