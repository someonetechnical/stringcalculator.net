using System;

namespace StringCalculator
{
    public static class CalculatorWithBuiltIn
    {
        public static int Add(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            char separator;
            SimpleParseSeparator(value, out value, out separator);
            var splits = value.Split(new char[] { separator, '\r', '\n' }, value.Length, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;
            var negatives = string.Empty;

            foreach (var item in splits)
            {
                if (item.Length == 1 && (item[0] == separator || item[0] == '\r' || item[0] == '\n'))
                    continue;

                var number = int.Parse(item);
                if (number < 0)
                    negatives += $"{number};";
                else if (number < 1001)
                    sum += number;
            }

            if (string.IsNullOrEmpty(negatives) == false)
                throw new NotSupportedException($"Negatives not supported: {negatives}");

            return sum;
        }

        private static void SimpleParseSeparator(string value, out string newValue, out char separator)
        {
            newValue = value;
            separator = ',';

            if (value.Length > 3 && value[0] == '/' && value[1] == '/' && value[3] == '\n')
            {
                separator = value[2];
                newValue = value.Substring(4);
            }
        }
    }
}
