using System;
using Xunit;

namespace Doubler.Tests
{
    public class LogicTest
    {
        [Fact]
        public void Should_doubling_symbols_in_first_string_that_contained_in_second_correctly_when_in_second_string_letter()
        {
            var expectedString = "�����";
            var str = "����";
            var str1 = "�";
            var actualString = Logic.SymbolDoubling(str, str1);
            Assert.Equal(actualString, expectedString);
        }

        [Fact]
        public void Should_doubling_symbols_in_first_string_that_contained_in_second_correctly_when_in_second_string_sentence()
        {
            var expectedString = "���������  ��  �������  ��������  �  �����";
            var str = "������� � ����� ������ � ����";
            var str1 = "� �� ���� ���� �";
            var actualString = Logic.SymbolDoubling(str, str1);
            Assert.Equal(actualString, expectedString);
        }
    }
}
