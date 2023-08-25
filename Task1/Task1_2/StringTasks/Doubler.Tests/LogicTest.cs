using System;
using Xunit;

namespace Doubler.Tests
{
    public class LogicTest
    {
        [Fact]
        public void Should_doubling_symbols_in_first_string_that_contained_in_second_correctly_when_in_second_string_letter()
        {
            var expectedString = "ллето";
            var str = "лето";
            var str1 = "л";
            var actualString = Logic.SymbolDoubling(str, str1);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_doubling_symbols_in_first_string_that_contained_in_second_correctly_when_in_second_string_sentence()
        {
            var expectedString = "ВВечерром  яя  пошшёлл  гулляять  в  паррк";
            var str = "Вечером я пошёл гулять в парк";
            var str1 = "В яя ррыр злрш с";
            var actualString = Logic.SymbolDoubling(str, str1);
            Assert.Equal(actualString, expectedString);
        }
    }
}
