using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
   public class ReceivedAckSentToQuestionOwnerCmd
    {

        [Required]
        public int ReplyId { get; }
        [Required]
        public int QuestionId { get; }
        [Required]
        public string ReplyOrAnswer { get; }
        public ReceivedAckSentToQuestionOwnerCmd(int replyId, int questionId, string replyOrAnswer)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            ReplyOrAnswer = replyOrAnswer;
        }


    }
}
