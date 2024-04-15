using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class UserName : ValueObject
    {
        private const int MAX_USERNAME_LENGTH = 50;

        private UserName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<UserName, Error> Create(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_USERNAME_LENGTH)
                return Errors.General.ValueIsRequired();

            return new UserName(value);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
