using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using CSharp.Choices;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateReply
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult { };
        public class ReplyCreated : ICreateReplyResult
        {
            public Post Post { get; }

            public ReplyCreated(Post post)
            {
                Post = post;
            }
        }
        public class ReplyNotCreated : ICreateReplyResult
        {
            public string Reason { get; }

            public ReplyNotCreated(string reason)
            {
                Reason = reason;
            }
        }
        public class InvalidRequest : ICreateReplyResult
        {
            public CreateReplyCmd Cmd { get; }

            public InvalidRequest(CreateReplyCmd cmd)
            {
                Cmd = cmd;
            }
        }
    }
}
