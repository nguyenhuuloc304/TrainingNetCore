using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Training.DependencyInjection.Services
{
    public interface IEmailService
    {
        void SendEmail(string toEmail, string subject, string content);
    }
}
