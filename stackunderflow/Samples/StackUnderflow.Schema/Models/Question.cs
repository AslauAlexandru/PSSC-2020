﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackUnderflow.DatabaseModel.Models
{
    [Table("Question")]
    public partial class Question
    {
        [Key]
         public Guid QuestionId { get; set; }
        //public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }

    }
}
