# stringcalculator.net

The String Calculator

- Create a simple String calculator with a method int Add(string numbers)
- The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example &quot;&quot; or &quot;1&quot; or &quot;1,2&quot;
- Start with the simplest test case of an empty string, then move to one and two numbers
- Allow the Add method to handle an unknown amount of numbers
- Allow the Add method to handle new lines between numbers (in addition to commas).
- the following input is ok: &quot;1\n2,3&quot; (will equal 6)
- the following input DOES NOT need to be handled: &quot;1,\n&quot; (no need to prove it - just clarifying)
- Support different delimiters
- To change a delimiter, the beginning of the string will contain a separate line specifying the custom delimiter. This input looks like this: &quot;//{delimiter}\n{numbers…}&quot; (Note that the curly braces are representing the sections of the input and are not input formatting).
- For example: &quot;//;\n1;2&quot; should return a result of 3 because the delimiter is now ‘;’.
- The first line is optional (all existing scenarios should still be supported).
- Do not worry about supporting the specification of ‘\n’ as an explicit custom delimiter. New lines should always be supported as delimiters in your number string.
- Calling Add with a negative number will throw an exception &quot;negatives not allowed&quot; - and the negative that was passed, if there are multiple negatives, show all of them in the exception message
- Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2

Indications:
Use TTD

Requirements:
- .Net Core 3.1

Notes:
- didn't handle floating point numbers
- didn't know how to handle concatenated separators (eg 1,2,,\n). Treated like empy strings (eg 1,2, , \n ~= 1,2,0,0 = 3).
- didn't know if the separator can be multiple characters or just a single charactor. From examples assumed just single character separator.
