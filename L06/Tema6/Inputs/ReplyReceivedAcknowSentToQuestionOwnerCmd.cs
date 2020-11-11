using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Tema6.Inputs
{
    class ReplyReceivedAcknowSentToQuestionOwnerCmd
    {
        
        [Required]
        public int ReplyId { get; }
        [Required]
        public int QuestionId { get; }
        [Required]
        public string ReplyOrAnswer { get; }
        public ReplyReceivedAcknowSentToQuestionOwnerCmd(int replyId, int questionId, string replyOrAnswer)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            ReplyOrAnswer = replyOrAnswer;
        }


    }
}
