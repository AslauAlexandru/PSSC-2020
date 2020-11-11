using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.ComponentModel.DataAnnotations;

namespace Tema6.Inputs
{
    public class CheckLanguageCmd
    {
        [Required]
        public string Text { get; }
        public CheckLanguageCmd(string text)
        {
            Text = text;
        }
    }
}
