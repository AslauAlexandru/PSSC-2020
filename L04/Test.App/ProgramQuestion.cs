using Question.Domain.CreateNewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new CreateNewQuestionCmd("Title1", "Body1", "F#");
            var result = CreateNewQuestion(cmd);

           // result.Match(
             //       ProcessNewQuestionCreated,
               //     ProcessNewQuestionNotCreated,
                //    ProcessInvalidNewQuestion
                //);

            Console.ReadLine();
        }
        private static ICreateNewQuestionResult ProcessInvalidNewQuestion(NewQuestionValidationFailed validationErrors)
        {
            Console.WriteLine("New question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateNewQuestionResult ProcessNewQuestionNotCreated(NewQuestionNotCreated newQuestionNotCreatedResult)
        {
            Console.WriteLine($"New question not created: {newQuestionNotCreatedResult.Reason}");
            return newQuestionNotCreatedResult;
        }

        private static ICreateNewQuestionResult ProcessNewQuestionCreated(NewQuestionCreated newQuestion)
        {
            Console.WriteLine($"Profile {newQuestion.QuestionId}");
            return newQuestion;
        }

        public static ICreateNewQuestionResult CreateNewQuestion(CreateNewQuestionCmd createNewQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(createNewQuestionCommand.Title) || string.IsNullOrWhiteSpace(createNewQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invalid title or body" };
                return new NewQuestionValidationFailed(errors);
            }

            if (string.IsNullOrWhiteSpace(createNewQuestionCommand.Tags))
            {
                var errors = new List<string>() { "Invalid tags" };
                return new NewQuestionValidationFailed(errors);
            }

            if (new Random().Next(10) > 1)
            {
                return new NewQuestionNotCreated("New question could not be verified");
            }

            var newQuestionId = Guid.NewGuid();
            var result = new NewQuestionCreated(newQuestionId, createNewQuestionCommand.Title, createNewQuestionCommand.Body, createNewQuestionCommand.Tags);

            //execute logic
            return result;
        }
    }
}
