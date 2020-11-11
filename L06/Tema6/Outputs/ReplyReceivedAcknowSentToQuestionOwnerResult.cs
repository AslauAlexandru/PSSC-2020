using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    public static partial class ReplyReceivedAcknowSentToQuestionOwnerResult
    {
        public interface IReplyReceivedAcknowSentToQuestionOwnerResult { };
        public class ReplyReceived : IReplyReceivedAcknowSentToQuestionOwnerResult
        {
            public string ReplyText { get; private set; }

            public ReplyReceived(string replyText)
            {
                ReplyText = replyText;
            }
        }
        public class InvalidReplyReceived : IReplyReceivedAcknowSentToQuestionOwnerResult
        {
            public string ErrorMessage { get; private set; }

            public InvalidReplyReceived(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }


    }
}
