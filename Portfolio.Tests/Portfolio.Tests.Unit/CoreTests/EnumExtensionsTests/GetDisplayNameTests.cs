using NUnit.Framework;
using Portfolio.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Tests.Unit.CoreTests.EnumExtensionsTests
{
    public class GetDisplayNameTests
    {
        private const string testDisplayName = "abcd";

        internal enum EnumTest
        {
            [Display(Name = testDisplayName)] DisplayName = 1,
            [Display(Name = "")] EmptyDisplayName = 2,
            NoDisplayName = 3
        }

        [Test]
        public void DisplayNameProvided_DisplayNameReturned()
        {
            var enumDisplayNameValue = EnumTest.DisplayName.GetDisplayName();
            Assert.AreEqual(testDisplayName, enumDisplayNameValue);
        }

        [Test]
        public void DisplyNameEmpty_EmptyDisplayNameReturned()
        {
            var enumDisplayNameValue = EnumTest.EmptyDisplayName.GetDisplayName();
            Assert.AreEqual("", enumDisplayNameValue);
        }

        [Test]
        public void NoDisplayName_PropertyNameReturned()
        {
            var enumDisplayNameValue = EnumTest.NoDisplayName.GetDisplayName();
            Assert.AreEqual(EnumTest.NoDisplayName.ToString(), enumDisplayNameValue);
        }
    }
}