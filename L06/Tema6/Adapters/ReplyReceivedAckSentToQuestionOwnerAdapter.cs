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
//using Primitives.Extensions.ObjectExtensions;

namespace Tema6.Adapters
{
    class ReplyReceivedAckSentToQuestionOwnerAdapter : Adapter<ReplyReceivedAcknowSentToQuestionOwnerCmd,ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult, Unit>
    {
        public override Task PostConditions(ReplyReceivedAcknowSentToQuestionOwnerCmd cmd,ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult result, Unit state)
        {
            return Task.CompletedTask;
        }

        public override async Task<ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult> Work(ReplyReceivedAcknowSentToQuestionOwnerCmd cmd, Unit state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from ownerResult in OwnerResult(cmd, state)
                     select ownerResult;
            return await wf.Match(
                     Succ: owner => owner,
                     Fail: ex => new ReplyReceivedAcknowSentToQuestionOwnerResult.InvalidReplyReceived(ex.ToString()));
        }
        private TryAsync<ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult> OwnerResult(ReplyReceivedAcknowSentToQuestionOwnerCmd cmd, Unit state)
        {

            return TryAsync<ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult>(async () =>
            {
                return new ReplyReceivedAcknowSentToQuestionOwnerResult.ReplyReceived(cmd.ReplyOrAnswer);
            });
        }

    }
}
