using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Outputs;
using static PortExt;
using Primitives.IO;

namespace Tema6
{
   public static class DomainBoundedContextDSL
    {

       

        public static Port<CreateReplyResult.IValidateReplyResult> ValidateReply(int questionId, int authorId, string answer)
            => NewPort<CreateReplyCmd, CreateReplyResult.IValidateReplyResult>(new CreateReplyCmd(authorId, questionId, answer));
        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(string text)
           => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(new CheckLanguageCmd(text));
        public static Port<ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult> SendAckToQuestionOwner(int authorid, int questionid, string reply)
         => NewPort<ReplyPublishedAcknowSentToReplyAuthorCmd, ReplyReceivedAcknowSentToQuestionOwnerResult.IReplyReceivedAcknowSentToQuestionOwnerResult>(new ReplyPublishedAcknowSentToReplyAuthorCmd(authorid, questionid, reply));

        public static Port<ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult> SendAckToReplyAuthor(int replyid, int questionid, string reply)
       => NewPort<ReplyPublishedAcknowSentToReplyAuthorCmd, ReplyPublishedAcknowSentToReplyAuthorResult.IReplyPublishedAcknowSentToReplyAuthorResult>(new ReplyPublishedAcknowSentToReplyAuthorCmd(replyid, questionid, reply));
        public static Port<Unit> SendAckToReplyOwner(object safeReply)
     => NewPort<Unit,Unit>(Unit.Default);
        public static Port<Unit> SendAckToReplyAuthor(object problematicReply)
       => NewPort<Unit,Unit>(Unit.Default);
    }
}
