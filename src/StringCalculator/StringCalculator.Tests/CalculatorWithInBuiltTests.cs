using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorWithInBuiltTests
    {
        [Fact]
        public void Add_PassNull_ThrowsArgumentNullException()
        {
            //Arrange
            string value = null;

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassEmptyString_Returns0()
        {
            //Arrange
            var value = string.Empty;
            var expected = 0;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValue1_Returns1()
        {
            //Arrange
            var value = "1";
            var expected = 1;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValue2_Returns2()
        {
            //Arrange
            var value = "2";
            var expected = 2;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValueEqualTo1000_Returns1000()
        {
            //Arrange
            var value = "1000";
            var expected = 1000;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValueGreaterThen1000_Returns0()
        {
            //Arrange
            var value = "1001";
            var expected = 0;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringNegativeValue_ThrowsException()
        {
            //Arrange
            var value = "-2";

            //Act, Assert
            var exception = Assert.Throws<NotSupportedException>(() => CalculatorWithBuiltIn.Add(value));
            Assert.Contains("-2", exception.Message);
        }

        [Fact]
        public void Add_PassStringNegativeSymbolOnly_ThrowsException()
        {
            //Arrange
            var value = "-";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassStringValueWithNegativeSymbolPlaceIncorectly_ThrowsException()
        {
            //Arrange
            var value = "2-";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassTwoStringValuesSeparetedByComma_ReturnsSum()
        {
            //Arrange
            var value = "2,3";
            var expected = 5;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassTwoStringValuesSeparetedByInvalidSeparator_ThrowArgumentExcetion()
        {
            //Arrange
            var value = "2;3";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassTwoStringNegativeValuesSeparetedByComma_ThrowArgumentExcetion()
        {
            //Arrange
            var value = "-2,-3";

            //Act, Assert
            var exception = Assert.Throws<NotSupportedException>(() => CalculatorWithBuiltIn.Add(value));
            Assert.Contains("-2", exception.Message);
            Assert.Contains("-3", exception.Message);
        }

        [Fact]
        public void Add_PassStringValuesSeparetedByComma_ReturnsSum()
        {
            //Arrange
            var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 31, 45, 55, 100, 121, 521, 997, 1000 };
            var value = string.Join(',', numbers);
            var expected = numbers.Sum();

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValuesStartWithNewLineAndSeparetedByComma_ReturnsSum()
        {
            //Arrange
            var value = "\n12,3";
            var expected = 15;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValuesSeparetedByCommaAndNewLine_ReturnsSum()
        {
            //Arrange
            var value = "1\n2,3";
            var expected = 6;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValuesSeparetedNewLine_ReturnsSum()
        {
            //Arrange
            var value = "1\n2";
            var expected = 3;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassSingleStringValueAndNewLine_ReturnsValue()
        {
            //Arrange
            var value = "1\n";
            var expected = 1;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassMultiLineStringValues_ReturnsSum()
        {
            //Arrange
            var value = $"1{Environment.NewLine}2";
            var expected = 3;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValueAndSeparatorAndNewLine_ReturnsValue()
        {
            //Arrange
            var value = "1,\n";
            var expected = 1;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValueAndMultipleSeparators_ThrowException()
        {
            //Arrange
            var value = "1,,";
            var expected = 1;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassStringValuesSeparetedByCommaAndMultipleNewLines_ReturnsSum()
        {
            //Arrange
            var value = "1\n2,3\n6";
            var expected = 12;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassSeparator_Returns0()
        {
            //Arrange
            var value = ",";
            var expected = 0;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassNewLine_Returns0()
        {
            //Arrange
            var value = Environment.NewLine;
            var expected = 0;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassSeparatorFormatOnly_Returns0()
        {
            //Arrange
            var value = "//;\n";
            var expected = 0;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassIncorrectSeparatorFormatOnly_ThrowsException()
        {
            //Arrange
            var value = "/;\n";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassIncorrectSeparatorMissingNewLineFormatOnly_ThrowsException()
        {
            //Arrange
            var value = "//;";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassSeparatorFormatAndValuesSeparatedByDifferentSeparator_ThrowsArgumentException()
        {
            //Arrange
            var value = "//;\n2,3,4";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassSeparatorFormatAndValuesSeparatedByNewSeparator_ReturnsSum()
        {
            //Arrange
            var value = "//;\n2;3;4";
            var expected = 9;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassSeparatorFormatWhichIsNewLineAndValuesSeparatedByDifferentSeparator_ThrowsException()
        {
            //Arrange
            var value = "//\n\n2;3;4";

            //Act, Assert
            Assert.Throws<FormatException>(() => CalculatorWithBuiltIn.Add(value));
        }

        [Fact]
        public void Add_PassSeparatorFormatWhichIsNewLineAndValuesSeparatedSeparator_ReturnsSum()
        {
            //Arrange
            var value = "//\n\n2\n3\n4";
            var expected = 9;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_PassSeparatorFormatAndValuesSeparatedBySeparatorAndNewLine_ReturnsSum()
        {
            //Arrange
            var value = "//;\n2;3\n4\n";
            var expected = 9;

            //Act
            var result = CalculatorWithBuiltIn.Add(value);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
