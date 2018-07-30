using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKataDay7
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NumberIsEmptyOrNull(numbers))
            {
                return 0;
            }
            var numbersWithBracketsRemoved = numbers.Replace("[", string.Empty).Replace("]", string.Empty);
            int[] numberStorage = SplitNumbers(numbersWithBracketsRemoved);
            var negativeNumbers = numberStorage.Where(x => x < 0);
            var joinedNegativeNumbers = string.Join(" ", negativeNumbers);
            CheckForNegativeNumbers(negativeNumbers, joinedNegativeNumbers);
            var sum = GetSum(numberStorage);
            return sum;
        }
        private int GetSum(int[] numberStorage)
        {
            return numberStorage.Where(x => x <= 1000).Sum(x => x);
        }
        private void CheckForNegativeNumbers(IEnumerable<int> negativeNumbers, string joinedNegativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives Not Allowed {joinedNegativeNumbers}");
            }
        }
        private int[] SplitNumbers(string numbers)
        {
            return numbers.Split(new char[] { ',', '\n', ';', '/','*','%'}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
        private bool NumberIsEmptyOrNull(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }
    }
}
