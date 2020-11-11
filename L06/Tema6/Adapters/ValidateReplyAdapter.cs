using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Primitives.IO;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Outputs;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
using Tema6.Models;
//using Primitives.Extensions.ObjectExtensions;

namespace Tema6.Adapters
{
    class ValidateReplyAdapter : Adapter<CreateReplyCmd,CreateReplyResult.IValidateReplyResult, QuestionWriteContext>
    {
        public override Task PostConditions(CreateReplyCmd cmd, CreateReplyResult.IValidateReplyResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<CreateReplyResult.IValidateReplyResult> Work(CreateReplyCmd cmd,QuestionWriteContext state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from validateReply in ValidateReply(cmd, state)
                     select validateReply;
            return await wf.Match(
                     Succ: reply => reply,
                     Fail: ex => new CreateReplyResult.InvalidateRequest(ex.ToString()));
        }

        private TryAsync<CreateReplyResult.IValidateReplyResult> ValidateReply(CreateReplyCmd cmd, QuestionWriteContext state)
        {

            return TryAsync<CreateReplyResult.IValidateReplyResult>(async () =>
            {
                if(!state.AuthorIds.Any(p => p==cmd.AuthorId))
                    return new CreateReplyResult.InvalidateReply("The provided AuthorId does not exist");

                if (!state.QuestionIds.Any(p => p == cmd.QuestionId))
                    return new CreateReplyResult.InvalidateReply($"The provided QUestionId [{cmd.QuestionId}] does not exist");


                return new CreateReplyResult.ValidateReply(new Reply(cmd.AuthorId,cmd.QuestionId,cmd.Reply));
            });
        }



    }
}
