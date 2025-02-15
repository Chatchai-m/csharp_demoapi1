using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Infra.Email
{
    public interface IEmailProvider
    {
        Task<string> SendEmailAsync(string subject, string message, List<string> recepients);
    }
}
