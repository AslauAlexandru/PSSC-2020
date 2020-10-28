using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;
using CSharp.Choices;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [AsChoice]
    public static partial class VotesVerify
    {
        public interface IVotes { }

        public class UnverifiedNrVotes : IVotes
        {
            public int Votes { get; private set; }

            private UnverifiedNrVotes(int votes)
            {
                Votes=votes;
            }

            public static Result<UnverifiedNrVotes> Create(int votes)
            {
                if (IsVotesValid(votes))
                {
                    return new UnverifiedNrVotes(votes);
                }
                else
                {
                    return new Result<UnverifiedNrVotes>(new InvalidVotesException(votes));
                }
            }

            private static bool IsVotesValid(int votes)
            {
                

                //validate 
                if (votes !=0)
                {
                    return true;
                }
                return false;
            }
        }
        public class VerifiedNrVotes : IVotes
        {
            public int Votes { get; private set; }

            internal VerifiedNrVotes(int votes)
            {
                Votes = votes;
            }
        }


    }
}
