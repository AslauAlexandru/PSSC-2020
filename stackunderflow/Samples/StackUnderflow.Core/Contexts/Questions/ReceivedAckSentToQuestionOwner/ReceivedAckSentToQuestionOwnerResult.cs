using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
    public partial class ReceivedAckSentToQuestionOwnerResult
    {

        public interface IReceivedAckSentToQuestionOwnerResult { };
        public class AckSentToQuestionOwnerResult : IReceivedAckSentToQuestionOwnerResult
        {
            
            public int QuestionId { get; }
            
            public int QuestionOwnerId { get; }

            public AckSentToQuestionOwnerResult(int questionId, int questionOwnerId)
            {
                QuestionId = questionId;
                QuestionOwnerId = questionOwnerId;
            }

        }
        public class ReceivedAckNotSentToQuestionOwnerResult : IReceivedAckSentToQuestionOwnerResult
        {
            public string ErrorMessage { get; private set; }

            public ReceivedAckNotSentToQuestionOwnerResult(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}
