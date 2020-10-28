using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateNewQuestionWorkflow
{

    [Serializable]
    public class InvalidVotesException : Exception
    {
        public InvalidVotesException()
        {
        }

        public InvalidVotesException(int Votes) : base($"The value \"{Votes}\" is not corresponding to all individual votes.")
        {
        }

    }
}
