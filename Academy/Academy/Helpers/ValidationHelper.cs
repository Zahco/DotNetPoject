using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Academy.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidPostCode(string postCode)
        {
            string pattern = "[0-9]{2}[ ]*[0-9]{3}";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match matcher = regex.Match(postCode);
            return matcher.Success;
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"((\+33|0){1}[0-9])[\. ]*([0-9]{2}[\. ]*){4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match matcher = regex.Match(phoneNumber);
            return matcher.Success;
        }
    }
}