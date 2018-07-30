using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorDay5
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }
            string slashRemover = RemoveUnneccessaryCharacters(numbers);
            string[] numberStorage = SplitNumbers(slashRemover);
            var convertedNumbers = ConvertNumbersToInteger(numberStorage);
            var negativeNumbers = convertedNumbers.Where(x => x < 0);
            CheckNegativeNumbers(negativeNumbers);
            var sum = CalculateSum(convertedNumbers);
            return sum;
        }

        private static void CheckNegativeNumbers(IEnumerable<int> negativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives Not Allowed {string.Join(" ", negativeNumbers)}");
            }
        }

        private static string RemoveUnneccessaryCharacters(string numbers)
        {
            return numbers.Replace("//", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
        }

        private static int CalculateSum(int[] convertedNumbers)
        {
            return convertedNumbers.Where(x => x <= 1000).Sum(x => x);
        }

        private static int[] ConvertNumbersToInteger(string[] numberStorage)
        {
            return numberStorage.Select(x => int.Parse(x)).ToArray();
        }

        private static string[] SplitNumbers(string slashRemover)
        {
            return slashRemover.Split(new char[] { ',', '\n', ';','*','%'}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
