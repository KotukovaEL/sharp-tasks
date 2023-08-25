using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Averages.Tests
{
    public class LogicTests
    {
        [Fact]
        public void Should_calculate_avarage_lenght_string_correctly_when_complex_sentence()
        {
            var expectedAverageLength = 4.0;
            var str = "���� - ��� �����!";
            var actualAverageLength = Logic.AverageWordLength(str);
            Assert.Equal(expectedAverageLength, actualAverageLength);
        }

        [Fact]
        public void Should_calculate_avarage_lenght_string_correctly_when_simple_sentence()
        {
            var expectedAverageLength = 4.0;
            var str = "��� ������ ����� �� ����!";
            var actualAverageLength = Logic.AverageWordLength(str);
            Assert.Equal(expectedAverageLength, actualAverageLength);
        }

        [Fact]
        public void Should_calculate_avarage_lenght_string_correctly_when_direct_speech()
        {
            var expectedAverageLength = 5.1;
            var eps = 0.05;
            var str = "\"���, �����, � ������� ����, � �� ������� ��������\"";
            var actualAverageLength = Logic.AverageWordLength(str);
            Assert.True(Math.Abs(expectedAverageLength - actualAverageLength) <= eps);
        }
    }
}
