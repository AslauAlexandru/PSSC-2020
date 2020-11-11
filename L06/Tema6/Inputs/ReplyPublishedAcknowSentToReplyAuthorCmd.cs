using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.ComponentModel.DataAnnotations;

namespace Tema6.Inputs
{
    class ReplyPublishedAcknowSentToReplyAuthorCmd
    {

        [Required]
        //[MinLength(10)]
        //[MaxLength(500)]
        public int ReplyId {get;}

        [Required]
        public int QuestionId { get; }

        [Required]
        public string Answer { get; }

        public ReplyPublishedAcknowSentToReplyAuthorCmd(int replyId, int questionId, string answer)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            Answer = answer;
        }

    }
}
