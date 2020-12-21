using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions;
using Access.Primitives.IO;
using StackUnderflow.EF.Models;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion.CreateQuestionResult;
using Access.Primitives.Extensions.ObjectExtensions;
using StackUnderflow.DatabaseModel.Models;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion
{
    public class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
       
        

            public override Task PostConditions(CreateQuestionCmd cmd, CreateQuestionResult.ICreateQuestionResult result, QuestionWriteContext state)
            {
                return Task.CompletedTask;
            }

            public async override Task<CreateQuestionResult.ICreateQuestionResult> Work(CreateQuestionCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
            {

                var wf= from valid in cmd.TryValidate()//workflow
                        let t = AddQuestion(state, cmd)
                               select t;
              state.Question.Add(new DatabaseModel.Models.Question { QuestionId =1, Title = "Titlu intrebare", Body = "Descriere", Tags = "Tag intrebare" });

            //state.Question.Add(new DatabaseModel.Models.Question { QuestionId = new Guid("67869"), Title = "Titlu intrebare", Body = "Descriere", Tags = "Tag intrebare" });

            var result = await wf.Match(
                    Succ: r => r,
                    Fail: er => new QuestionValidFailed(er.Message)
                    );

                return result;
            }

            private ICreateQuestionResult AddQuestion(QuestionWriteContext state,object v)
            {
                return new QuestionPosted( new Guid("1"), "titlu", "corp", "Tag");
            }
        //se poate si cu asta
        private object CreateQuestionFromCmd(CreateQuestionCmd cmd)
        {
            return new { };
        }

    }
}
