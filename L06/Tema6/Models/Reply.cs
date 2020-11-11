using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Models
{

    public class Reply
    {
        

        public int AuthorId { get; }

        public int QuestionId { get; }

        public string Answer { get; }
        public Reply(int authorId, int questionId, string answer)
        {
            AuthorId = authorId;
            QuestionId = questionId;
            Answer = answer;
        }
    }
        public class Question
    {
        public int Title{ get; }

        public int Body { get; }

        public string[] Tags { get; }

        public Question(int title, int body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }


}
