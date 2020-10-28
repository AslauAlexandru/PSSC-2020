using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    public struct CreateNewQuestionCmd
    {
        [Required]
        public string Title { get; private set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; private set; }
        [Required]

        public List<string> Tags { get; set; }
        public int Votes { get; private set; }
        public CreateNewQuestionCmd(string Title, string Body, List<string> Tags,int Votes)
        {
            this.Title = Title;
            this.Body = Body;
            this.Tags = Tags;
            this.Votes = Votes;

        }
    }
}