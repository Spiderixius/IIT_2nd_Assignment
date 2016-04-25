using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIT_2nd_Assignment_admur13.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
