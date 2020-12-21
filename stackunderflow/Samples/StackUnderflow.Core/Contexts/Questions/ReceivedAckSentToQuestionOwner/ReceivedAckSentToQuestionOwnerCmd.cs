using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
   public partial class ReceivedAckSentToQuestionOwnerCmd
    { 
        public int QuestionId { get; }
        
        public int QuestionOwnerId { get; }

        public ReceivedAckSentToQuestionOwnerCmd(int questionId, int questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }
    }
}
