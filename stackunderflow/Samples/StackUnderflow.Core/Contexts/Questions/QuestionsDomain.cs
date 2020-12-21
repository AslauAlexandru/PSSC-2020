using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using static PortExt;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using static StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner.ReceivedAckSentToQuestionOwnerResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionsDomain
    {
        public static Port<CreateReplyResult.ICreateReplyResult> CreateReply(int questionId, string reply)
         => NewPort<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>(new CreateReplyCmd(questionId, reply));
        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd)
         => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(checkLanguageCmd);
     public static Port<ReceivedAckSentToQuestionOwnerResult.IReceivedAckSentToQuestionOwnerResult> SendAckToQuestionOwner(ReceivedAckSentToQuestionOwnerCmd receivedAckSentToQuestionOwnerCmd)
       => NewPort<ReceivedAckSentToQuestionOwnerCmd,IReceivedAckSentToQuestionOwnerResult>(receivedAckSentToQuestionOwnerCmd);

        public static Port<CreateQuestionResult.ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd)
         => NewPort<CreateQuestionCmd,CreateQuestionResult.ICreateQuestionResult>(createQuestionCmd);
        public static Port<Unit> SendAckToReplyOwner(object safeReply)
        => NewPort<Unit, Unit>(Unit.Default);

    }
}
