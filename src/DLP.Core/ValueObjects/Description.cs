using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class Description : ValueObject
    {
        private const int MAX_DESCRIPTION_LENGTH = 1000;
        
        private Description(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Description, Error> Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_DESCRIPTION_LENGTH)
                return Errors.General.ValueIsInvalid();

            return new Description(value);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
