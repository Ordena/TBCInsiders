using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBCInsiders.Management.ApplicationCore.Extensions
{
    public static class StringExtensions
    {
        private static String Georgian = @"აბგდევზთიკლმნოპჟრსტუფქღყშჩცძჭხჯჰ";
        private static String Latin = @"abcdefghijklmnopqrstwxyz";

        public static bool IsGeorgian(this string text)
        {
            bool isValid = true;
            var symbols = text.ToLower().ToCharArray();
            
            foreach (var symbol in symbols)
            {
                if (!Georgian.Contains(symbol))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        public static bool IsLatin(this string text)
        {
            bool isValid = true;
            var symbols = text.ToLower().ToCharArray();

            foreach (var symbol in symbols)
            {
                if (!Latin.Contains(symbol))
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

    }
}
