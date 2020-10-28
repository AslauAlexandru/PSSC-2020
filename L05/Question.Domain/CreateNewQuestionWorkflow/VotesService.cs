using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.CreateNewQuestionWorkflow.CreateNewQuestionResult;
using static Question.Domain.CreateNewQuestionWorkflow.VerifyNewQuestionBodyDescription;
using System.Linq;

namespace Question.Domain.CreateNewQuestionWorkflow
{
   public class VotesService
    {
       
        
            //verificarea voturi
            public Task Vote(VerifiedNewQuestion question)
            {
                return Task.CompletedTask;
            }
        
    }
}
