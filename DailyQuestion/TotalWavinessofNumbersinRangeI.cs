namespace DailyQuestion
{
    public class TotalWavinessofNumbersinRangeI
    {
        public int TotalWaviness(int rangeStartNumber, int rangeEndNumber)
        {
            int totalWavinessAcrossRange = 0;

            for (int currentNumberInRange = rangeStartNumber; currentNumberInRange <= rangeEndNumber; currentNumberInRange++)
            {
                totalWavinessAcrossRange += CalculateNumberWaviness(currentNumberInRange);
            }

            return totalWavinessAcrossRange;
        }

        private int CalculateNumberWaviness(int numberToEvaluate)
        {
            string digitSequence = numberToEvaluate.ToString();

            if (digitSequence.Length < 3)
            {
                return 0;
            }

            int wavinessPointCount = 0;

            for (int currentDigitIndex = 1; currentDigitIndex < digitSequence.Length - 1; currentDigitIndex++)
            {
                int previousDigit = digitSequence[currentDigitIndex - 1] - '0';
                int currentDigit = digitSequence[currentDigitIndex] - '0';
                int nextDigit = digitSequence[currentDigitIndex + 1] - '0';

                bool isLocalPeak = currentDigit > previousDigit && currentDigit > nextDigit;

                bool isLocalValley = currentDigit < previousDigit && currentDigit < nextDigit;

                if (isLocalPeak || isLocalValley)
                {
                    wavinessPointCount++;
                }
            }

            return wavinessPointCount;
        }
    }
}