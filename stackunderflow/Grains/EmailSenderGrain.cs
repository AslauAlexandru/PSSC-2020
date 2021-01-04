using System;
using System.Collections.Generic;
using System.Text;
using GrainInterfaces;
using System.Threading.Tasks;
using StackUnderflow.EF.Models;
namespace Grains
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {

        private readonly StackUnderflowContext _dbContext;

        public EmailSenderGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<string> SendEmailAsync(string message)
        {

            // send e-mail

            return Task.FromResult(message);
        }
    }
}
