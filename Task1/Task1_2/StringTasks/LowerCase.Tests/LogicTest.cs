using System;
using Xunit;

namespace LowerCase.Tests
{
    public class LogicTest
    {
        private readonly Logic _logic;

        public LogicTest()
        {
            _logic = new Logic();
        }

        [Fact]
        public void Should_count_number_words_starting_with_small_letter_correctly_when_separators_spaces()
        {
            var expectedString = 4;
            var str = "Антон выпил кофе и послушал Стинга";
            var actualString = _logic.CountWordsWithSmallLetter(str);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_count_number_words_starting_with_small_letter_correctly_when_various_separators()
        {
            var expectedString = 7;
            var str = "Я знал: это не может продолжаться слишком долго";
            var actualString = _logic.CountWordsWithSmallLetter(str);
            Assert.Equal(actualString, expectedString);
        }
    }
}
