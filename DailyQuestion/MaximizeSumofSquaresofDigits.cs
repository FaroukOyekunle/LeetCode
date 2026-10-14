using System.Text;

namespace DailyQuestion
{
    public class MaximumSumofSquaresofDigits
    {
        public string MaxSumOfSquares(int requiredDigitCount, int remainingDigitSum)
        {
            if (remainingDigitSum > 9 * requiredDigitCount)
            {
                return string.Empty;
            }

            var maximumScoreNumber = new StringBuilder(requiredDigitCount);

            while (remainingDigitSum >= 9)
            {
                maximumScoreNumber.Append('9');
                remainingDigitSum -= 9;
                requiredDigitCount--;
            }

            if (remainingDigitSum > 0)
            {
                maximumScoreNumber.Append((char)('0' + remainingDigitSum));
                requiredDigitCount--;
            }

            maximumScoreNumber.Append('0', requiredDigitCount);

            return maximumScoreNumber.ToString();
        }
    }
}