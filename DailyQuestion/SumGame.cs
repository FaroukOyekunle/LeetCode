namespace DailyQuestion
{
    public class SumGame
    {
        public bool SumGame(string numberString)
        {
            int halfStringLength = numberString.Length / 2;

            int leftHalfDigitSum = 0;
            int rightHalfDigitSum = 0;

            int leftHalfQuestionMarkCount = 0;
            int rightHalfQuestionMarkCount = 0;

            for (int leftHalfIndex = 0; leftHalfIndex < halfStringLength; leftHalfIndex++)
            {
                if (numberString[leftHalfIndex] == '?')
                {
                    leftHalfQuestionMarkCount++;
                }
                else
                {
                    leftHalfDigitSum += numberString[leftHalfIndex] - '0';
                }
            }

            for (int rightHalfIndex = halfStringLength; rightHalfIndex < numberString.Length; rightHalfIndex++)
            {
                if (numberString[rightHalfIndex] == '?')
                {
                    rightHalfQuestionMarkCount++;
                }
                else
                {
                    rightHalfDigitSum += numberString[rightHalfIndex] - '0';
                }
            }

            int totalQuestionMarkCount = leftHalfQuestionMarkCount + rightHalfQuestionMarkCount;

            if (totalQuestionMarkCount % 2 == 1)
            {
                return true;
            }

            if (leftHalfQuestionMarkCount == rightHalfQuestionMarkCount)
            {
                return leftHalfDigitSum != rightHalfDigitSum;
            }

            int digitSumDifference = rightHalfDigitSum - leftHalfDigitSum;

            int questionMarkCountDifference = leftHalfQuestionMarkCount - rightHalfQuestionMarkCount;

            int requiredDigitSumDifference = 9 * questionMarkCountDifference / 2;

            return digitSumDifference != requiredDigitSumDifference;
        }
    }
}