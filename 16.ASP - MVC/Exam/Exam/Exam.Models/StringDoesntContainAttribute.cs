using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringDoesntContainAttribute : ValidationAttribute
    {
        private string text;

        public StringDoesntContainAttribute(string text)
        {
            this.text = text;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return true;
            }

            return !valueAsString.ToLower().Contains(text.ToLower());
        }
    }
}
