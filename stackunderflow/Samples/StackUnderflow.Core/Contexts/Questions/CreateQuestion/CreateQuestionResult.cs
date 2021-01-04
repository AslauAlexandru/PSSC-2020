using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }
        public class QuestionPosted: ICreateQuestionResult
        {
           


            // public int QuestionId { get;  }
            public Guid QuestionId { get;  }
            public string Title { get;  }

           public string Body { get; }

            public string Tags { get; }
             public QuestionPosted(Guid questionId, string title, string body, string tags)
             {
               QuestionId = questionId;
               Title = title;
               Body = body;
               Tags = tags;
             }

            /* public QuestionPosted(int questionId, string title, string body, string tags)
             {
                 QuestionId = questionId;
                 Title = title;
                 Body = body;
                 Tags = tags;
             }*/

        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; }

            public QuestionNotCreated(string reason)
            {
                Reason = reason;
            }
        }
        public class QuestionValidFailed : ICreateQuestionResult
        {
            public string Message { get; }

            public QuestionValidFailed(string message)
            {
                Message = message;
            }
        }
    }
}
