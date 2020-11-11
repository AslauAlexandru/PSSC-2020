using System;
using System.Collections.Generic;
using System.Text;
using Tema6.Models;
using Tema6.Inputs;
using CSharp.Choices;


namespace Tema6.Outputs
{
    [AsChoice]
    public partial class CreateReplyResult
    {
        public interface IValidateReplyResult { };
        public class ValidateReply : IValidateReplyResult
        {
            public ValidateReply(Reply reply)
            {
                Reply = reply;
            }

            public Reply Reply { get; }

        }

        public class InvalidateReply : IValidateReplyResult
        { 
            public string Reasons { get; }

            public InvalidateReply(string reasons)
            {
                Reasons = reasons;
            }
        }
        public class InvalidateRequest : IValidateReplyResult
        {
            public InvalidateRequest(string validationErrors)
            {
                ValidationErrors = validationErrors;
                
            }

            public string ValidationErrors { get; }
            

            
        }

    }
}
