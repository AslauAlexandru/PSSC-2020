using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.EF.Models;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
   public class QuestionWriteContext
    {
        public ICollection<Post> Posts { get; }

        public QuestionWriteContext(ICollection<Post> posts)
        {
            Posts = posts;
        }
    }
}
