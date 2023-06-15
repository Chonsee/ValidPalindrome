using System.Text.RegularExpressions;

namespace System.Runtime
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// This is a extensionmethod that will determine if a string is a palindrome given various different criteria
        /// </summary>
        /// <param name="phrase">the string being looked at</param>
        /// <param name="normalizeCase">Defaults to true. This will make a case insensitive comparison when true. 
        /// When false a == A would disqualify this from being considered a palindrome. </param>
        /// <param name="desiredRegexOptions">RegexOptions that can be applied to filter out unwanted characters before
        /// the comparison is made.</param>
        /// <returns>true | false</returns>
        public static bool IsPalindrome(this string phrase, bool normalizeCase = true, bool ignoreWhiteSpace = true)
        {
            string palindrome = normalizeCase ? phrase.ToLower() : phrase;
            string pattern = ignoreWhiteSpace ? @"[^a-zA-Z0-9]" : @"[^a-zA-Z0-9\s-]";
            Regex regex = new Regex(pattern, RegexOptions.None);

            if(new Regex(@"([^\w\s-])+$", RegexOptions.None).IsMatch(palindrome))
            {
                //The pattern only contains values that are non-alphanumeric characters (excluding whitespaces), disqualifying it from being a palindrome.
                return false;
            }

            palindrome = regex.Replace(palindrome, "");
            
            var forward = palindrome.ToCharArray();
            var backward = palindrome.ToCharArray().Reverse().ToArray();

            for (int i = 0; i < forward.Length; i++)
            {
                if (forward[i] != backward[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
