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
            var expectedString = "�����";
            var firstStr = "����";
            var secondStr = "�";
            var actualString = _logic.DoubleSymbol(firstStr, secondStr);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_double_symbols_in_first_string_that_contained_in_second_correctly_when_second_string_is_sentence()
        {
            var expectedString = "���������  ��  �������  ��������  �  �����";
            var firstStr = "������� � ����� ������ � ����";
            var secondStr = "� �� ���� ���� �";
            var actualString = _logic.DoubleSymbol(firstStr, secondStr);
            Assert.Equal(actualString, expectedString);
        }
    }
}
