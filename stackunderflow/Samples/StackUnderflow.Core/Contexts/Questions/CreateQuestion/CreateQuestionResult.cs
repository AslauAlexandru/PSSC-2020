using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    public class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }
        public class QuestionPosted: ICreateQuestionResult
        {
            

            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }

           public string Body { get;private set; }

            public string Tags { get;private set; }
            public QuestionPosted(Guid questionId, string title, string body, string tags)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
            }

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
            private string message;

            public IEnumerable<string> ValidationErrorsMessages { get; private set; }

            public QuestionValidFailed(IEnumerable<string> validationErrorsMessages)
            {
                ValidationErrorsMessages = validationErrorsMessages;
            }

            public QuestionValidFailed(string message)
            {
                this.message = message;
            }
        }
    }
}
