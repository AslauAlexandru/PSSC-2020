using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions;
using static LanguageExt.Prelude;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner;
using Microsoft.Extensions.Logging;
using Orleans;
using StackUnderflow.API.Rest.Controllers;

namespace StackUnderflow.API.Rest.Projection
{ 
    [ApiController]
    public class QuestionsProjection: ControllerBase
    {
        private readonly IClusterClient _clusterClient;

        public QuestionsProjection(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }
        [HttpGet("projection/questions")]
        public async Task<IActionResult> Index()
        {
            var grain = _clusterClient.GetGrain<IQuestionsProjectionGrain>($"{Guid.Empty}/1");
            var posts = await grain.GetQuestionSummaryAsync();
            return Ok(posts);

        }


    }
}