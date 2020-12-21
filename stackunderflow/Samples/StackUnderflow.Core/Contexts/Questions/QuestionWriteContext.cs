using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.EF.Models;
using StackUnderflow.DatabaseModel.Models;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
   public class QuestionWriteContext
    {
        public ICollection<Post> Posts { get; }

        public QuestionWriteContext(ICollection<Post> posts)
        {
            Posts = posts;
        }

        public ICollection<Question> Question { get; }
        public QuestionWriteContext(ICollection<Question> question)
        {
            Question = question ?? new List<Question>();
        }
    }
}
