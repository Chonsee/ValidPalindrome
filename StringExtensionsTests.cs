using NUnit.Framework;
using System.Runtime;

namespace ValidPalindrome
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void TestParams()
        {
            string phrase = "A man, a plan, a canal: Panama";

            //"amanaplanacanalpanama" is a palindrome.
            Assert.IsTrue(phrase.IsPalindrome());

            //"AmanaplanacanalPanama" is not a palindrome.
            Assert.IsFalse(phrase.IsPalindrome(normalizeCase: false));

            //"a man a plan a canal panama" is not a palindrome.
            Assert.IsFalse(phrase.IsPalindrome(normalizeCase: true, ignoreWhiteSpace: false));
        }

        [Test]
        public void TestIsPalindromeExpectations()
        {
            string phrase = "A man, a plan, a canal: Panama";

            //"amanaplanacanalpanama" is a palindrome.
            Assert.IsTrue(phrase.IsPalindrome());

            phrase = "race a car";
            //"raceacar" is not a palindrome.
            Assert.IsFalse(phrase.IsPalindrome());

            phrase = "racecar";
            //"racecar" is a palindrome.
            Assert.IsTrue(phrase.IsPalindrome());

            //since an empty string reads the same forward and backward, it is a palindrome.
            phrase = " ";
            Assert.IsTrue(phrase.IsPalindrome());
            phrase = "";
            Assert.IsTrue(phrase.IsPalindrome());

            //numeric characters are compared correctly
            phrase = "0001000";
            Assert.IsTrue(phrase.IsPalindrome());

            phrase = "1234567890";
            Assert.IsFalse(phrase.IsPalindrome());

            //special characters
            phrase = "<?:!!!!!!";
            Assert.IsFalse(phrase.IsPalindrome());
            phrase = "&#&";
            Assert.IsFalse(phrase.IsPalindrome());

            phrase = "& %^$&";
            //Would only recognize the entire string as being non alphanumeric, so it is not a palindrome
            Assert.IsFalse(phrase.IsPalindrome());
        }
    }
}
