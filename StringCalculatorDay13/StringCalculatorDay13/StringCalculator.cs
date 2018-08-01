using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorDay13
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NullOrWhiteSpace(numbers))
            {
                return 0;
            }
            var numberStorage = SplitNumbers(numbers);
            var negativeNumbers = numberStorage.Where(x => int.Parse(x) < 0);
            if (NumbersAre(negativeNumbers))
            {
                throw new Exception($"Negatives Not Allowed {JoinNegativeNumbers(negativeNumbers)}");
            }
            var sum = GetSum(numberStorage);
            return sum;
        }

        private int GetSum(string[] numberStorage)
        {
            return numberStorage.Where( x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
        }

        private string[] SplitNumbers(string numbers)
        {
            return numbers.Split(new char[] { ',', '\n', ';', '/','*','[',']','%'}, StringSplitOptions.RemoveEmptyEntries);
        }

        private string JoinNegativeNumbers(IEnumerable<string> negativeNumbers)
        {
            return string.Join(" ", negativeNumbers);
        }

        private bool NumbersAre(IEnumerable<string> negativeNumbers)
        {
            return negativeNumbers.Any();
        }

        private bool NullOrWhiteSpace(string number)
        {
            return string.IsNullOrWhiteSpace(number);
        }
    }
}
