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
using static LanguageExt.Prelude;
using Remote.Linq;
using Microsoft.Extensions.Logging;
using Orleans;
using Access.Primitives.Orleans;
using Access.Primitives.Extensions;
using Orleans.Streams;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateReply;
using StackUnderflow.Domain.Core.Contexts.Questions;
using GrainInterfaces;


namespace StackUnderflow.API.Rest.Controllers
{
    
    public interface IQuestionsProjectionGrain: Orleans.IGrainWithStringKey,IAsyncObserver<CreateQuestionResult.ICreateQuestionResult>
    {

        Task<IEnumerable<Post>> GetQuestionSummaryAsync(int page = 0);
        
    }

    public class QuestionsProjectionGrain : Orleans.Grain, IQuestionsProjectionGrain
    {
        private readonly StackUnderflowContext _dbContext;
        private List<Post> _posts;
        private const int PageSize = 10;
        private bool _isDirty;

        public QuestionsProjectionGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task OnActivateAsync()
        {


            // _posts = await _dbContext.Post.ToListAsync();
            _isDirty = true;
            await LoadState();
            var id = this.GetPrimaryKeyString();

            var orgId = Guid.Parse(id.Split("/")[0]);
            var tenantId = id.Split("/")[1];

            var stream = this.GetStreamProvider("SMSProvider")//CreateReplyResult.ICreateReplyResult
                .GetStream<CreateQuestionResult.ICreateQuestionResult>(orgId, $"{tenantId}/question");
            await stream.SubscribeAsync(this);
            //await stream.SubscribeAsync(stream);


        }
        private async Task LoadState()
        {
            if (_isDirty)
            {
                _posts = await _dbContext.Post.ToListAsync();
                _isDirty = false;
            }
        }


        public Task<IEnumerable<Post>> GetQuestionSummaryAsync(int page = 0)
        {
            return _posts.Where(p => p.ParentPostId.HasValue)
                .Skip(page * PageSize)
                .Take(PageSize)
                .Select(p=> p.ShallowClone())
                .ToList();
        }

        public async Task OnNextAsync(CreateQuestionResult.ICreateQuestionResult item,StreamSequenceToken token=null)
        {
            //varianta 1
            await item.MatchAsync(async created =>
            {
                _posts = await _dbContext.Post.ToListAsync();
                return created;
            }, async notCreated =>
            {
                return notCreated;

            });

            //varianta 2
             item.Match( created =>
            {
                _isDirty = true;
                return created;
            },  notCreated =>
            {
                return notCreated;

            });

        }
        public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }

       /* public Task StartAsync()
        {
            return Task.CompletedTask;
        }
       */
    }
}