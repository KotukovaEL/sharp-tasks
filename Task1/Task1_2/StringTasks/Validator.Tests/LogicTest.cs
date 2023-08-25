using System;
using Xunit;

namespace Validator.Tests
{
    public class LogicTest
    {
        [Fact]
        public void Should_replace_first_letter_first_word_in_sentence_with_uppercase_letter_correctly()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? sdf svcd scvds.";
            char[] endSigns = { '.', '!', '?' };
            var actualString = Logic.Validator(str, endSigns);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_replace_first_letter_first_word_in_sentence_with_uppercase_letter_when_Single_part_sentence_correctly()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Fds. Sdfd. Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? fds. sdfd. sdf svcd scvds.";
            char[] endSigns = { '.', '!', '?' };
            var actualString = Logic.Validator(str, endSigns);
            Assert.Equal(actualString, expectedString);
        }
    }
}
