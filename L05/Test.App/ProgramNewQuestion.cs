using LanguageExt;
using LanguageExt.Common;
using Profile.Domain.CreateProfileWorkflow;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;
using static Question.Domain.CreateNewQuestionWorkflow.VerifyNewQuestionBodyDescription;
//using static Profile.Domain.CreateProfileWorkflow.EmailAddress;
using static Question.Domain.CreateNewQuestionWorkflow.PostedNewQuestionService;
using static Question.Domain.CreateNewQuestionWorkflow.VotesService;


namespace Test.App
{
    class ProgramNewQuestion
    {
        static void Main(string[] args)
        {

            List<string> tags = new List<string>()
            { 
               "Swift",
               "Coding",
               "Version"

            };

        var result = UnverifiedNewQuestion.Create("What is Swift? Can I use for?  ",tags);//UnverifiedNewQuestion din VerifyNewQuestionBodyDescription


            result.Match(
                    Succ: question =>
                    {
                        VoteQuestionNew(question);

                        Console.WriteLine("Question is prepare for voting.");
                        return Unit.Default;
                    },
                    Fail: ex =>
                    {
                        Console.WriteLine($"Invalid question,not posted. Reason: {ex.Message}");
                        return Unit.Default;
                    }
                );


            Console.ReadLine();
        }

        private static void VoteQuestionNew(UnverifiedNewQuestion question)
        {    // am pus in comentarii deoarece nu imi recunoaste si imi apare eroare la PostedNewQuestionService() si VotesService() desi le am
             // var verifiedNewQuestionResult = new PostedNewQuestionService().PostedNewQuestion(question);
             // verifiedNewQuestionResult.Match(
             //        VoteQuestionNew =>
             //      {
             //         new VotesService().Vote(VoteQuestionNew);
             //       return Unit.Default;
             //  },
             //  ex =>
             // {
             //     Console.WriteLine("Question could not be verified");
             //       return Unit.Default;
             //   }
             // );
        }
    }
}
