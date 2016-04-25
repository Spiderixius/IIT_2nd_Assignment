using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIT_2nd_Assignment_admur13.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
