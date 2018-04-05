using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Training.UploadFile.Services.AzureBlod;
using System.IO;
using Training.UploadFile.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.UploadFile.WebAPI
{
    [Route("files")]
    [Consumes("multipart/form-data")]
    public class FilesController : Controller
    {
        private readonly IAzureBlobProvider _azureBlobProvider;
        //private readonly IWorkContextProvider _workContextProvider;

        public FilesController(
            IAzureBlobProvider azureBlobProvider)
        {
            _azureBlobProvider = azureBlobProvider;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> UploadFilesAsync([FromForm]ICollection<IFormFile> files)
        {
            if (!files.Any())
            {
                ModelState.AddModelError("files", "The Files field is required.");
                return BadRequest(ModelState);
            }

            List<string> filePaths = new List<string>();

            foreach (IFormFile file in files)
            {
                string fileName = Guid.NewGuid().ToString("N");
                Stream fileStream = file.OpenReadStream();

                string containerName = "sites";
                string blobName = "files" + Path.GetExtension(file.FileName);

                Uri fileUri = await _azureBlobProvider.CreateBlobAsync(containerName, blobName, fileStream);
                filePaths.Add(fileUri.AbsolutePath);
            }

            UploadFilesResponseModel response = new UploadFilesResponseModel()
            {
                BaseUrl = _azureBlobProvider.GetBlobEndpoint(),
                Paths = filePaths.ToArray()
            };

            return Ok(response);
        }
    }
}
