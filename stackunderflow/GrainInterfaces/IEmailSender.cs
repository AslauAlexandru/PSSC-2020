using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IEmailSender : Orleans.IGrainWithIntegerKey
    {
        Task<string> SendEmailAsync(string message);
    }
}
