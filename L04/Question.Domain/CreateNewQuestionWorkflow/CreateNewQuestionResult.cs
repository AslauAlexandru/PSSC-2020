using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CSharp.Choices;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    //[AsChoice]
    public static partial class CreateNewQuestionResult
    {
        public interface ICreateNewQuestionResult { }
        public class NewQuestionCreated : ICreateNewQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }

            public string Body { get; private set; }
  
            public string Tags { get; private set; }

            public NewQuestionCreated(Guid questionId, string title,string body,string tags)
            {
                this.QuestionId = QuestionId;
                this.Title =Title;
                this.Body = Body;
                this.Tags = Tags;
            }
        }
        public class NewQuestionNotCreated : ICreateNewQuestionResult
        {
            public string Reason { get; set; }

            public NewQuestionNotCreated(string reason)
            {
                Reason = reason;
            }
        }

        public class NewQuestionValidationFailed : ICreateNewQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public NewQuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }

    }
}
