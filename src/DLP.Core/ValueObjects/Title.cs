using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class Title : ValueObject
    {
        private const int MAX_TITLE_LENGTH = 100;

        private Title(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Title, Error> Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_TITLE_LENGTH)
                return Errors.General.ValueIsInvalid();

            return new Title(value);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
