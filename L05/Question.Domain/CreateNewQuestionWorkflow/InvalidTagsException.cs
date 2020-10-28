using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    [Serializable]
    public class InvalidTagsException : Exception
    {
        public InvalidTagsException()
        {
        }

        public InvalidTagsException( List<string> Tags ) : base($"Tags is \"{Tags.Count} \", need to be between >=1 and <=3.")
        {
        }

    }
}
