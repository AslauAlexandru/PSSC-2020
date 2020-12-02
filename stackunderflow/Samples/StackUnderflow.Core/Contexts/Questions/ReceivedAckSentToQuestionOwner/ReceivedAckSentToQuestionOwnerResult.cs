using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
    public partial class ReceivedAckSentToQuestionOwnerResult
    {

        public interface IReceivedAckSentToQuestionOwnerResult { };
        public class ReplyReceived : IReceivedAckSentToQuestionOwnerResult
        {
            public string ReplyText { get; private set; }

            public ReplyReceived(string replyText)
            {
                ReplyText = replyText;
            }
        }
        public class InvalidReplyReceived : IReceivedAckSentToQuestionOwnerResult
        {
            public string ErrorMessage { get; private set; }

            public InvalidReplyReceived(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
