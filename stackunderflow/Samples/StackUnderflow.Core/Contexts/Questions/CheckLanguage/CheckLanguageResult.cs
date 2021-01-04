using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguage
{
    //[AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { };
        public class TextChecked : ICheckLanguageResult
        {
            public int Certainty { get; set; }

            public TextChecked(int certainty)
            {
                Certainty = certainty;
            }
        }
        public class TextCheckedFailed : ICheckLanguageResult
        {
            public string ErrorMessage { get;  set; }

            public TextCheckedFailed(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }

    }
}
