using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Exceptions
{
    static internal class DictionaryExtentions
    {
        public static bool IsNullOrEmpty<TKey, TValue>(this SortedDictionary<TKey, TValue> dict)
        {
            return dict == null || dict.Count == 0;
        }

        public static string throwNullOrEmptyString() { return "Exception: the dictionary is empty or null!"; }
    }

    internal class PhoneExceptions
    {
        protected static Regex phoneChecker = new Regex("\\+\\d{11}$");

        protected static string throwWrongPhoneString() { return "Exception: wrong phone number!"; }
    }
}     //namespace Exceptions
