using AlternativeString;
using Xunit;

namespace AlternativString.Tests
{
    public class ContainsMethodsTests
    {
        [Fact]
        public void Should_return_boolean_value_correctly_when_symbol_is_contained()
        {
            var expectedResult = true;
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Contains('k');
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_boolean_value_correctly_when_symbol_is_not_contained()
        {
            var expectedResult = false;
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Contains('l');
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_boolean_value_correctly_when_string_is_contained()
        {
            var expectedResult = true;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("For");
            var result = customString1.Contains(customString2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_boolean_value_correctly_when_string_is_not_contains()
        {
            var expectedResult = false;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("Fr");
            var result = customString1.Contains(customString2);
            Assert.Equal(expectedResult, result);
        }
    }
}
