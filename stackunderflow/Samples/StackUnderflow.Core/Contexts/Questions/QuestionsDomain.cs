using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using static PortExt;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner;


namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionsDomain
    {
        public static Port<CreateReplyResult.ICreateReplyResult> CreateReply(int questionId, string reply)
         => NewPort<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>(new CreateReplyCmd(questionId, reply));
        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(string text)
         => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(new CheckLanguageCmd(text));
        public static Port<ReceivedAckSentToQuestionOwnerResult.IReceivedAckSentToQuestionOwnerResult> SendAckToQuestionOwner(int authorid, int questionid, string reply)
       => NewPort<ReceivedAckSentToQuestionOwnerCmd, ReceivedAckSentToQuestionOwnerResult.IReceivedAckSentToQuestionOwnerResult>(new ReceivedAckSentToQuestionOwnerCmd(authorid, questionid, reply));

        public static Port<Unit> SendAckToReplyOwner(object safeReply)
        => NewPort<Unit, Unit>(Unit.Default);

    }
}
