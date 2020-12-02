using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner;

namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("backoffice")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public QuestionsController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("{questionId}/reply")]
        public async Task<IActionResult> CreateReply(int questionId)
        {
            //database
            var questionWriteContext = new QuestionWriteContext(new List<Post>() //ctx
            {
                new Post()
                {
                    PostId=10,
                    PostText="Intrebare?"
                }
            });
           
            var questionDependencies = new QuestionDependencies();//dependencies
            questionDependencies.GenerateConfirmationEmail = () => Guid.NewGuid().ToString();
            questionDependencies.SentEmail = (LogInForQuestions login) => async () => new ConfirmationEmail(Guid.NewGuid().ToString());


            var expr = from replyResult in QuestionsDomain.CreateReply(questionId, "8989")
                       select replyResult;


            //CreateReplyResult.ICreateReplyResult result = await _interpreter.Interpret(expr, Unit.Default, new object());
            CreateReplyResult.ICreateReplyResult result = await _interpreter.Interpret(expr, questionWriteContext, questionDependencies);
            return result.Match( created=>(IActionResult)Ok(created),
                  notCreated=>BadRequest(notCreated),
                  invalidRequest=>ValidationProblem()
               );
        }
    }
}

