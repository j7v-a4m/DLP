using CSharpFunctionalExtensions;
using DLP.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DLP.Core.ValueObjects
{
    public class ContactInfo: ValueObject
    {
        private const string phoneRegex = @"^(\+998|998)?(\d{2})?(\d{7})$";
        
        private ContactInfo(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
        private ContactInfo(string phoneNumber, string telegramLink)
        {
            PhoneNumber = phoneNumber;
            TelegramLink = telegramLink;
        }
        private ContactInfo(string phoneNumber, string telegramLink, string webSiteUrl, string youTubeUrl)
        {
            PhoneNumber = phoneNumber;
            TelegramLink = telegramLink;
            WebSiteUrl = webSiteUrl;
            YouTubeUrl = youTubeUrl;
        }

        public string PhoneNumber { get; }
        public string? TelegramLink { get; }
        public string? WebSiteUrl { get; }
        public string? YouTubeUrl { get; }

        public static Result<ContactInfo, Error> Create(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || Regex.IsMatch(phoneNumber, phoneRegex) == false)
                return Errors.General.ValueIsInvalid();

            return new ContactInfo(phoneNumber);
        }
        public static Result<ContactInfo, Error> Create(string phoneNumber, string telegramLink)
        {
            if (string.IsNullOrEmpty(phoneNumber) || Regex.IsMatch(phoneNumber, phoneRegex) == false)
                return Errors.General.ValueIsInvalid();

            if (string.IsNullOrEmpty(telegramLink))
                return Errors.General.ValueIsRequired();

            return new ContactInfo(phoneNumber, telegramLink);
        }
        public static Result<ContactInfo, Error> Create(string phoneNumber, string telegramLink, string webSiteUrl, string youTubeUrl)
        {
            if (string.IsNullOrEmpty(phoneNumber) || Regex.IsMatch(phoneNumber, phoneRegex) == false)
                return Errors.General.ValueIsInvalid();

            if (string.IsNullOrEmpty(telegramLink))
                return Errors.General.ValueIsRequired();

            if (string.IsNullOrEmpty(webSiteUrl))
                return Errors.General.ValueIsRequired();

            if (string.IsNullOrEmpty(youTubeUrl))
                return Errors.General.ValueIsRequired();

            return new ContactInfo(phoneNumber, telegramLink, webSiteUrl, youTubeUrl);
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return PhoneNumber;
            yield return TelegramLink;
            yield return WebSiteUrl;
            yield return YouTubeUrl;
        }
    }
}
