using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionDependencies
    {
        public Func<string> GenerateConfirmationEmail { get; set; }

        public Func<LogInForQuestions, TryAsync<ConfirmationEmail>> SentEmail { get; set; }

    }
}
