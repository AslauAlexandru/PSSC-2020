using Orleans.Streams;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace GrainInterfaces
{
    public interface IQuestionGrain : Orleans.IGrainWithStringKey
    {

        Task<IEnumerable<Post>> GetQuestionSummaryAsync(int page = 0);

    }
}
