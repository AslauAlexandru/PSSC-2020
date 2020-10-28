using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [Serializable]
    public class InvalidNewQuestionException : Exception
    {
        public InvalidNewQuestionException()
        {
        }

        public InvalidNewQuestionException(string NewQuestion) : base($"The value \"{NewQuestion}\" is not more than 1000 characters.")
        {
        }

    }
}
