using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt;
using LanguageExt.Common;

namespace Question.Domain.CreateNewQuestionWorkflow
{        
    [AsChoice]
    public static partial class VerifyNewQuestionBodyDescription
    {

        public interface INewQuestion { }

        public class UnverifiedNewQuestion : INewQuestion
        {
            public string NewQuestion { get; private set; }
            public List<string> Tags { get; private set; }
            private UnverifiedNewQuestion(string newQuestion, List<string> tags)
            {
                NewQuestion =newQuestion;
                Tags = tags;
            }

            public static Result<UnverifiedNewQuestion> Create(string newQuestion, List<string> tags)
            {
                if (IsNewQuestionValid(newQuestion))
                {
                    if (IsTagsValid(tags))
                    { return new UnverifiedNewQuestion(newQuestion, tags); }
                    else
                    {
                        return new Result<UnverifiedNewQuestion>(new InvalidTagsException(tags));
                    }

                }
                else
                {
                    return new Result<UnverifiedNewQuestion>(new InvalidNewQuestionException(newQuestion));
                }
            }

            private static bool IsNewQuestionValid(string newQuestion)
            {
                

                //validate 
                if (newQuestion.Length <= 1000)
                {
                   
                    return true;
                }
                return false;
            }
            private static bool IsTagsValid(List<string> tags)
            {


                //validate 
                if (tags.Count >=1 && tags.Count <=3)
                {

                    return true;
                }
                return false;
            }
        }

        public class VerifiedNewQuestion : INewQuestion
        {
            public string NewQuestion { get; private set; }
            public List<string> Tags { get; private set; }
            

            internal VerifiedNewQuestion(string newQuestion, List<string> tags)
            {
                NewQuestion =newQuestion;
                Tags = tags;
            }
        }
    }
}
