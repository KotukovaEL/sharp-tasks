using System;
using Xunit;

namespace Doubler.Tests
{
    public class LogicTest
    {
        private readonly Logic _logic;

        public LogicTest()
        {
            _logic = new Logic();
        }
      
        [Fact]
        public void Should_double_symbols_in_first_string_that_contained_in_second_correctly_when_second_string_is_letter()
        {
            var expectedString = "ллето";
            var firstStr = "лето";
            var secondStr = "л";
            var actualString = _logic.DoubleSymbol(firstStr, secondStr);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_double_symbols_in_first_string_that_contained_in_second_correctly_when_second_string_is_sentence()
        {
            var expectedString = "ВВечерром  яя  пошшёлл  гулляять  в  паррк";
            var firstStr = "Вечером я пошёл гулять в парк";
            var secondStr = "В яя ррыр злрш с";
            var actualString = _logic.DoubleSymbol(firstStr, secondStr);
            Assert.Equal(actualString, expectedString);
        }
    }
}
