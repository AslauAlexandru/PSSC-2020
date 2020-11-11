using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Tema6.Adapters;
using Tema6.Outputs;
using Primitives.IO;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;

namespace Tema6
{
    class ProgramTema6
    {
         static async Task Main(string[] args)
        {
            
            var wf = from createReplyResult in DomainBoundedContextDSL.ValidateReply(1, 1, "Respose")
                     let validReply = (CreateReplyResult.ValidateReply)createReplyResult
                     from checkLanguageResult in DomainBoundedContextDSL.CheckLanguage(validReply.Reply.Answer)
                     from ownerAck in DomainBoundedContextDSL.SendAckToQuestionOwner(1, 1, "Respose")
                     from authorAck in DomainBoundedContextDSL.SendAckToReplyAuthor(12, 1, "Respose")
                     select (validReply, checkLanguageResult, ownerAck, authorAck);

            var serviceProvider = new ServiceCollection()
                     .AddOperations(typeof(ValidateReplyAdapter).Assembly)
                     .AddOperations(typeof(CheckLanguageAdapter).Assembly)
                     .AddOperations(typeof(ReplyPublishedAckSentToReplyAuthorAdapter).Assembly)
                     .AddOperations(typeof(ReplyReceivedAckSentToQuestionOwnerAdapter).Assembly)
                     .AddTransient<IInterpreterAsync>(sp => new LiveInterpreterAsync(sp))
                     .BuildServiceProvider();

            var interpreter = serviceProvider.GetService<IInterpreterAsync>();
            var writeContext = new QuestionWriteContext(new List<int>() { 1, 2, 3 }, new List<int>() { 191, 192, 193 });
            var result = await interpreter.Interpret(wf, writeContext);


            Console.WriteLine("Hello World!");


        }

    }
    internal interface IReplyPosted
    {

    }
}

