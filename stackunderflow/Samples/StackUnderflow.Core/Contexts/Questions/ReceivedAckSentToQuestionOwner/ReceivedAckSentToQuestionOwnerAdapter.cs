using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner  ;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner.ReceivedAckSentToQuestionOwnerResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.ReceivedAckSentToQuestionOwner
{
    class ReceivedAckSentToQuestionOwnerAdapter: Adapter<ReceivedAckSentToQuestionOwnerResult, IReceivedAckSentToQuestionOwnerResult, QuestionWriteContext, QuestionDependencies>
    {
        private readonly IClusterClient clusterClient;

        public ReceivedAckSentToQuestionOwnerAdapter(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        
        public override Task PostConditions(ReceivedAckSentToQuestionOwnerResult cmd, IReceivedAckSentToQuestionOwnerResult result, QuestionWriteContext state)
        {
            throw new NotImplementedException();
        }

        public async Task<IReceivedAckSentToQuestionOwnerResult> Work(ReceivedAckSentToQuestionOwnerCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>(0);
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync("email@address.com");

            return new AckSentToQuestionOwnerResult(1, 2);
        }

        public override async Task<IReceivedAckSentToQuestionOwnerResult> Work(ReceivedAckSentToQuestionOwnerResult cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>(0);
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync("email@address.com");

            return new AckSentToQuestionOwnerResult(1, 2);
        }
    }
}
