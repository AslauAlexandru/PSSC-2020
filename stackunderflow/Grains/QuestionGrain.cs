using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using LanguageExt;
using static LanguageExt.Prelude;
using Remote.Linq;
using Microsoft.Extensions.Logging;
using Orleans;
using Access.Primitives.Extensions;
using Orleans.Streams;
using GrainInterfaces;
using Access.Primitives.Extensions.Cloning;
using Microsoft.EntityFrameworkCore;

namespace Grains
{
  public  class QuestionGrain:Orleans.Grain, IQuestionGrain, IAsyncObserver<Post>
    {
        //un fel de varianta de test pentru Post dar mai optionala,nu e obligatorie
        private readonly StackUnderflowContext _dbContext;
        private readonly StackUnderflowContext _stackUnderflowContext;
        private IList<Post> _questions;
        private readonly int _tenantId = 1;

       

       /* public QuestionGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;

        }*/
        public QuestionGrain(StackUnderflowContext stackUnderflowContext = null)
        {
            _stackUnderflowContext = stackUnderflowContext;

        }

        
       
        public async Task<IEnumerable<Post>> GetQuestionSummaryAsync()
        {
            return _questions; //.Where(p => p.ParentPostId == null);
        }

        public async Task<IEnumerable<Post>> GetQuestionSummaryAsync(int questionId)
        {
            return _questions.Where(p => p.PostId == questionId);
        }

        public override async Task OnActivateAsync()
        {
            //todo get tenant id 
            //grain identity {organizationGuid}/{tenantId}/questionProjection
            IAsyncStream<Post> stream = this.GetStreamProvider("SMSProvider").GetStream<Post>(Guid.Empty, "questions");
            await stream.SubscribeAsync(this);

            //_questions = await _stackUnderflowContext.Post.Include(i=>i.Vote).Where(p => p.TenantId == _tenantId).ToListAsync();
            _questions = new List<Post>() {
                new Post
                {
                    PostId = 1,
                    PostText ="Question"
                }
            };
        }

        public async Task OnNextAsync(Post item, StreamSequenceToken token = null)
        {
            //_questions.Add(item)
            //_questions = await _stackUnderflowContext.Post.Include(i => i.Vote).Where(p => p.TenantId == _tenantId).ToListAsync();
            _questions.Add(item); //= new List<Post>();
        }

        public Task OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnErrorAsync(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}

