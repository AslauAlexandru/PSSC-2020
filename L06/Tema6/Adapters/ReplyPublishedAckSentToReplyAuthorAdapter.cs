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
    class ReplyPublishedAckSentToReplyAuthorAdapter : Adapter<ReplyPublishedAcknowSentToReplyAuthorCmd, ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult, Unit>
    {

        public override Task PostConditions(ReplyPublishedAcknowSentToReplyAuthorCmd cmd, ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult result, Unit state)
        {
            return Task.CompletedTask;
        }
        public override async Task<ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult> Work(ReplyPublishedAcknowSentToReplyAuthorCmd cmd, Unit state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from authorResult in AuthorResult(cmd, state)
                     select authorResult;
            return await wf.Match(
                     Succ: author => author,
                     Fail: ex => new ReplyPublishedAcknowSentToReplyAuthorResult.InvalidReplyPublished(ex.ToString()));
        }
        private TryAsync<ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult> AuthorResult(ReplyPublishedAcknowSentToReplyAuthorCmd cmd, Unit state)
        {

            return TryAsync<ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult>(async () =>
            {
                return new ReplyPublishedAcknowSentToReplyAuthorResult.ReplyPublished(cmd.Answer);
            });
        }
    }
}
