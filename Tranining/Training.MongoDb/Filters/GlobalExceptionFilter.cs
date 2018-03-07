using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.MongoDb.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public GlobalExceptionFilter(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {

                // do nothing
                return;
            }
            System.IO.File.WriteAllText("LogFile.txt", context.Exception.Message);

            var response = new ErrorResponseModel()
            {
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
                DeclaredType = typeof(ErrorResponseModel)
            };            
        }

        public class ErrorResponseModel
        {
            /// <summary>
            /// Gets or sets the message.
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Gets or sets the stack trace.
            /// </summary>
            public string StackTrace { get; set; }
        }
    }
}
