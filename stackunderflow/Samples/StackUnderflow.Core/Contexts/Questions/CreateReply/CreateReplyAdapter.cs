using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions;
using Access.Primitives.IO;
using StackUnderflow.EF.Models;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReply
{
    public class CreateReplyAdapter : Adapter<CreateReplyCmd,CreateReplyResult.ICreateReplyResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(CreateReplyCmd cmd, CreateReplyResult.ICreateReplyResult result, QuestionWriteContext state )
        {
           
            return Task.CompletedTask;

        }
        
        public async override Task<CreateReplyResult.ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var questionWriteContext = (QuestionWriteContext)state;
            var questionDependencies = (QuestionDependencies)dependencies;

            if (!questionWriteContext.Posts.Any(p => p.PostId == cmd.QuestionId))
                return new CreateReplyResult.ReplyNotCreated($"Cannot find question with id{cmd.QuestionId}");
            Post question = questionWriteContext.Posts.First(p => p.PostId == cmd.QuestionId);

            var reply = new Post()
            {
                PostText = cmd.Reply
            };
            question.InversePostNavigation.Add(reply);
            return new CreateReplyResult.ReplyCreated(reply);
        }
        
    }
}
