using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorDay12
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NullOrWhiteSpace(numbers))
            {
                return 0;
            }
            var numbersWithSlashesRemoved = RemoveUnneccessaryCharacters(numbers);
            string[] numberStorage = SplitNumbers(numbersWithSlashesRemoved);

            var negativeNumbers = numberStorage.Where(x => int.Parse(x) < 0);
            if(negativeNumbers.Any())
            {
                throw new Exception($"Negatives are Not Allowed {JoinNegativeNumbers(negativeNumbers)}");
            }
            var sum = CalculateSum(numberStorage);
            return sum;
        }

        private string JoinNegativeNumbers(IEnumerable<string> negativeNumbers)
        {
            return string.Join(" ", negativeNumbers);
        }

        private int CalculateSum(string[] numberStorage)
        {
            return numberStorage.Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
        }

        private string[] SplitNumbers(string numbersWithSlashesRemoved)
        {
            return numbersWithSlashesRemoved.Split(new char[] { ',', '\n', ';','*','%'}, StringSplitOptions.RemoveEmptyEntries);
        }

        private string RemoveUnneccessaryCharacters(string numbers)
        {
            return numbers.Replace("//", string.Empty).Replace("[",string.Empty).Replace("]",string.Empty);
        }

        private bool NullOrWhiteSpace(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }
    }
}
