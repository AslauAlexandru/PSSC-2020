using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
    public class ConfirmationEmail
    {
        public ConfirmationEmail(string receivedEmail)
        {
            ReceivedEmail = receivedEmail;
        }

        public string ReceivedEmail { get; private set; }

    }
}
