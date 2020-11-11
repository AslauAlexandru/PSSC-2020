using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Tema6
{    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    class StringRangeAttribute: ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public StringRangeAttribute(int min, int max) :base($"Reply is between {min} and {max}")
        {
            _min = min;
            _max = max;
        }
        public override bool IsValid(object value)
        {
            return value.ToString().Length > _min && value.ToString().Length < _max;
        }
    }
}
