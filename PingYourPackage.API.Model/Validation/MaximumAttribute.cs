using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.API.Model.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaximumAttribute : ValidationAttribute
    {
        private readonly int _maximumValue;
        public MaximumAttribute(int maximum) : base(errorMessage: "The {0} field value must be maximum {1}")
        {
            _maximumValue = maximum;
        }

        public override string FormatErrorMessage(string name) => string.Format(
            CultureInfo.CurrentCulture,
            base.ErrorMessageString,
            name,
            _maximumValue);

        public override bool IsValid(object value)
        {

            int intValue;
            if (value != null && int.TryParse(value.ToString(), out intValue))
            {

                return (intValue <= _maximumValue);
            }

            return false;
        }
    }
}
