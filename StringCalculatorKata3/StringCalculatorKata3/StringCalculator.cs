using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata3
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            var replaceNewLine = ReplaceUnwantedDelimiters(numbers);
            string[] numbersArray = replaceNewLine.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var negativeNumbers = numbersArray.Where(x => int.Parse(x) < 0);
            CheckNegativeNumbers(negativeNumbers);
            var sum = numbersArray.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
            return sum;
        }

        private static string ReplaceUnwantedDelimiters(string numbers)
        {
            return numbers.Replace('\n', ',').Replace("//", string.Empty);
        }

        private static void CheckNegativeNumbers(IEnumerable<string> negativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($" Negatives Not Allowed {string.Join(" ", negativeNumbers)}");
            }
        }
    }
}
