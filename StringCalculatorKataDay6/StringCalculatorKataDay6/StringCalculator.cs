using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKataDay6
{

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NumberIsEmptyOrNull(numbers))
            {
                return 0;
            }
            var replaceBrackets = RemoveBrackets(numbers);
            string[] numberStorage = SplitNumbers(replaceBrackets);
            var convertedNumbers = GetConvertedNumbers(numberStorage);
            var negativeNumbers = convertedNumbers.Where(x => x < 0);
            var joinedNegativeNumbers = string.Join(" ", negativeNumbers);
            CheckNegativeNumbers(negativeNumbers, joinedNegativeNumbers);
            var sum = GetSum(convertedNumbers);
            return sum;
        }

        private static bool NumberIsEmptyOrNull(string numbers)
        {
            return string.IsNullOrWhiteSpace(numbers);
        }

        private static string RemoveBrackets(string numbers)
        {
            return numbers.Replace("[", string.Empty).Replace("]", string.Empty);
        }

        private static void CheckNegativeNumbers(IEnumerable<int> negativeNumbers, string joinedNegativeNumbers)
        {
            if (negativeNumbers.Any())
            {
                throw new Exception($"Negatives Not Allowed {joinedNegativeNumbers}");
            }
        }

        private static int GetSum(int[] convertedNumbers)
        {
            return convertedNumbers.Where( x => x <= 1000).Sum(x => x);
        }

        private static int[] GetConvertedNumbers(string[] numberStorage)
        {
            return numberStorage.Select(x => int.Parse(x)).ToArray();
        }

        private static string[] SplitNumbers(string numbers)
        {
            return numbers.Split( new char[] { ',', '\n', ';', '/','*','%'},StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
