using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Primitives.IO;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Outputs;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;
//using Primitives.Extensions.ObjectExtensions;


namespace Tema6.Adapters
{
    class CheckLanguageAdapter : Adapter<CheckLanguageCmd,CheckLanguageResult.ICheckLanguageResult,Unit>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, CheckLanguageResult.ICheckLanguageResult result, Unit state)
        {
            return Task.CompletedTask;
        }

        public override async Task<CheckLanguageResult.ICheckLanguageResult> Work(CheckLanguageCmd cmd, Unit state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from checkLanguageResult in CheckLanguageResult(cmd, state)
                     select checkLanguageResult;
            return await wf.Match(
                     Succ: check => check,
                     Fail: ex => new CheckLanguageResult.TextCheckedFailed(ex.ToString()));
        }
        private TryAsync<CheckLanguageResult.ICheckLanguageResult> CheckLanguageResult(CheckLanguageCmd cmd, Unit state)
        {

            return TryAsync<CheckLanguageResult.ICheckLanguageResult>(async () =>
            {
                return new CheckLanguageResult.TextChecked(50);
            });
        }

    }
}
