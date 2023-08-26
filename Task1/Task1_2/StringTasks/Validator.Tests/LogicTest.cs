using System;
using Xunit;

namespace Validator.Tests
{
    public class LogicTest
    {
        [Fact]
        public void Should_make_sentence_start_letter_uppercase_correctly()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? sdf svcd scvds.";
            char[] endSigns = { '.', '!', '?' };
            var actualString = Logic.Validator(str, endSigns);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_make_sentence_start_letter_uppercase_correctly_when_single_part_sentence()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Fds. Sdfd. Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? fds. sdfd. sdf svcd scvds.";
            char[] endSigns = { '.', '!', '?' };
            var actualString = Logic.Validator(str, endSigns);
            Assert.Equal(actualString, expectedString);
        }
    }
}
