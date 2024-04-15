using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class Email : ValueObject
    {
        private const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email, Error> Create(string value)
        {
            if (string.IsNullOrEmpty(value) || Regex.IsMatch(value, emailRegex) == false)
                return Errors.General.ValueIsInvalid();

            return new Email(value);
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
