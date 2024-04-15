using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class Gender : ValueObject
    {
        public static readonly Gender Male = new(nameof(Male));
        public static readonly Gender Female = new(nameof(Female));
        public static readonly Gender Croissant = new(nameof(Croissant));
        private static readonly Gender[] _all = [Male, Female, Croissant];

        public string Value { get; }

        private Gender(string value)
        {
            Value = value;
        }

        public static Result<Gender, Error> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Errors.General.ValueIsRequired();

            var gender = value.Trim().ToUpper();

            if (_all.Any(g => g.Value.ToUpper() == gender) == false)
                return Errors.General.ValueIsInvalid();

            return new Gender(gender);
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
