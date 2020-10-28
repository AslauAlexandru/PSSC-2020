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
    public class PostedNewQuestionService
    {      
        public Result<VerifiedNewQuestion> PostedNewQuestion(UnverifiedNewQuestion question)
        {
            //publicare intrebari sa nu aibe mai mult de 1000 caractere,
            // cel putin 1 tag si cel mult 3 tag-uri

            return new VerifiedNewQuestion(question.NewQuestion, question.Tags);
        }
    }
}
