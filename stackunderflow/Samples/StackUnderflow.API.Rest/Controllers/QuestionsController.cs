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
using Microsoft.Extensions.Logging;
using Orleans;
using System.ComponentModel.DataAnnotations;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion.CreateQuestionResult;
using StackUnderflow.DatabaseModel.Models;
using LanguageExt.ClassInstances;
using StackUnderflow.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Orleans.Configuration;
using Orleans.Hosting;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;


namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("backoffice")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly DatabaseContext _db_Context;
        private readonly IClusterClient _clusterClient;

        public QuestionsController(IInterpreterAsync interpreter, StackUnderflowContext dbContext, DatabaseContext db_Context, IClusterClient clusterClient)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _db_Context = db_Context;
            _clusterClient = clusterClient;
        }

        //crearea intrebari varianta 1 
        [HttpPost("Create")]
        public async Task<IActionResult> CreateQuestion()
        {
            //presupunem ca am creat intrebarea
            //await _interpreter.Interpret(expr, QuestionWriteContext);
            var stream = _clusterClient.GetStreamProvider("SMSProvider")
                .GetStream<CreateQuestionResult.ICreateQuestionResult>(Guid.Empty, "1/questions");
            await stream.OnNextAsync(new CreateQuestionResult.QuestionPosted(new Guid("1"), "titlu", "corp", "Tag"));

            return Ok();
        }
        [HttpPost("{questionId}/reply")]
        public async Task<IActionResult> CreateReply([FromBody] int questionId)
        {
            //database
            var posts = _dbContext.Post.ToList();

            var questionWriteContext = new QuestionWriteContext(new EFList<Post>(_dbContext.Post));

            /*var questionWriteContext = new QuestionWriteContext(new List<Post>() //ctx
            {
                new Post()
                {
                    PostId=10,
                    PostText="Intrebare?"
                }
            });*/

            //var questionDependencies = new QuestionDependencies();//dependencies
            //questionDependencies.GenerateConfirmationEmail = () => Guid.NewGuid().ToString();
            //questionDependencies.SentEmail = (LogInForQuestions login) => async () => new ConfirmationEmail(Guid.NewGuid().ToString());


            var expr = from replyResult in QuestionsDomain.CreateReply(questionId, "8989")
                       select replyResult;
           

            var result = await _interpreter.Interpret(expr, questionWriteContext /*Unit.Default*/, new object());
            //CreateReplyResult.ICreateReplyResult result = await _interpreter.Interpret(expr, questionWriteContext, questionDependencies);
            await _dbContext.SaveChangesAsync();
            return  result.Match(created=>(IActionResult)Ok(created),
                  notCreated=>BadRequest(notCreated),
                  invalidRequest=>ValidationProblem()
               );
        }

        //crearea intrebari varianta 2
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd cmd)
        {
            
            var questionDependencies = new QuestionDependencies();

            //var questionWriteContext= await _db_Context.Question.ToList();


            var questionWriteContext = new QuestionWriteContext(new EFList<Question>(_db_Context.Question));


            var expr = from createQuestionResult in QuestionsDomain.CreateQuestion(cmd)
                       from checkLanguageResult in QuestionsDomain.CheckLanguage(new CheckLanguageCmd(cmd.Body))
                       from sendAckToQuestionOwnerCmd in QuestionsDomain.SendAckToQuestionOwner(new ReceivedAckSentToQuestionOwnerCmd(1, 2))
                       select createQuestionResult;

             var result = await _interpreter.Interpret(expr, questionWriteContext, new object());

            // var result = await _interpreter.Interpret(expr, questionWriteContext, questionDependencies);

            _db_Context.Question.Add(new DatabaseModel.Models.Question { QuestionId = 1, Title = cmd.Title, Body = cmd.Body, Tags = cmd.Tags });
            // var question = await _dbContext.Question.Where(r => r.QuestionId == 1).SingleOrDefaultAsync();

           // _dbContext.Question.Update(question);

            await _dbContext.SaveChangesAsync();


            return result.Match(created => (IActionResult)Ok(created),
                  notCreated => BadRequest(notCreated),
                  invalidRequest => ValidationProblem()
               );
        }
    
    }
}

