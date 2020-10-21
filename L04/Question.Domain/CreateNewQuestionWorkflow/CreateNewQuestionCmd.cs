using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateNewQuestionWorkflow
{
    public struct CreateNewQuestionCmd
    {
        //[Required]
        public string Title { get; private set; }
       
        //[Required]
        public string Body { get; private set; }
       // [Required]
   
        public string Tags { get; private set; }
        public CreateNewQuestionCmd(string title,string body,string tags)
        {
            this.Title = title;
            this.Body = body;
            this.Tags = tags;

        
        }
    }
}
