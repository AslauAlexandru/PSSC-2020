using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    public static partial class ReplyPublishedAcknowSentToReplyAuthorResult
    {
        public interface IReplyPublishedAcknowSentToReplyAuthorResult { };
        public class ReplyPublished: IReplyPublishedAcknowSentToReplyAuthorResult
        {
            public string ConfirmationMessage { get; set; }

            public ReplyPublished(string confirmationMessage)
            {
                ConfirmationMessage = confirmationMessage;
            }
        }

        public class InvalidReplyPublished : IReplyPublishedAcknowSentToReplyAuthorResult
        {
            public string ErrorMessage { get; private set; }

            public InvalidReplyPublished(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
