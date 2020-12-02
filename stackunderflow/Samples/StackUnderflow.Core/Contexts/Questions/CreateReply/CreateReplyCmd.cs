using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.EF.Models;
namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReply
{
    public class CreateReplyCmd
    {

        public int QuestionId { get; }
        public string Reply { get; }

        public CreateReplyCmd(int questionId, string reply)
        {
            QuestionId = questionId;
            Reply = reply;
        }
    }
}
