using System;
using Xunit;

namespace Validator.Tests
{
    public class LogicTest
    {
        private readonly Logic _logic;

        public LogicTest()
        {
            _logic = new Logic();
        }
        [Fact]
        public void Should_make_sentence_start_letter_uppercase_correctly()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? sdf svcd scvds.";
            var actualString = _logic.Validator(str);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_make_sentence_start_letter_uppercase_correctly_when_single_part_sentence()
        {
            var expectedString = "Dasddas adsa. D dcsd hg! Hihih? Fds. Sdfd. Sdf svcd scvds.";
            var str = "dasddas adsa. d dcsd hg! hihih? fds. sdfd. sdf svcd scvds.";
            var actualString = _logic.Validator(str);
            Assert.Equal(actualString, expectedString);
        }
    }
}
