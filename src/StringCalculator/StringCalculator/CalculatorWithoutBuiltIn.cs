using System;

namespace StringCalculator
{
    public static class CalculatorWithoutBuiltIn
    {
        public static int Add(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            string negatives = null;
            int sum = 0;
            string memory = string.Empty;
            char separator;
            int startIndex;
            ParseSeparator(value, out separator, out startIndex);

            for (int i = startIndex; i < value.Length; i++)
            {
                bool parseMemory = false;
                char character = value[i];
                if (character == '\n' || character == '\r' || character == separator)
                    parseMemory = true;
                else
                    memory += character;

                if (i == value.Length - 1)
                    parseMemory = true;

                if (parseMemory)
                {
                    int result = ParseWholeNumber(memory);
                    if (result < 0)
                        negatives += $"{result};";
                    else if (result <= 1000)
                        sum += result;

                    memory = string.Empty;
                    continue;
                }
            }

            if (negatives != null)
                throw new NotSupportedException($"Negatives not supported: {negatives}");

            return sum;
        }

        private static void ParseSeparator(string value, out char separator, out int startIndex)
        {
            separator = ',';
            startIndex = 0;

            if (value.Length > 3 && value[0] == '/' && value[1] == '/' && value[3] == '\n')
            {
                separator = value[2];
                startIndex = 4;
            }
        }

        private static int ParseWholeNumber(string number)
        {
            int result = 0;
            bool negative = false;

            for (int i = 0; i < number.Length; i++)
            {
                var character = number[i];
                if (i == 0 && character == '-' && number.Length > 1)
                {
                    negative = true;
                }
                else
                {
                    result = result * 10;
                    var digit = ParseDigit(character);
                    result += digit;
                }
            }

            if (negative)
                result *= -1;

            return result;
        }

        private static int ParseDigit(char digit)
        {
            switch (digit)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default:
                    throw new FormatException($"Invalid character, not a digit {digit}.");
            }
        }
    }
}
