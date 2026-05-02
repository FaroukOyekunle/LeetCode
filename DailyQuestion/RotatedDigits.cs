namespace DailyQuestion
{
    public class RotatedDigits
    {
        public int CountValidRotatedNumbers(int upperLimit)
        {
            int validRotatedNumberCount = 0;

            for (int currentNumber = 1; currentNumber <= upperLimit; currentNumber++)
            {
                if (IsNumberValidAfterRotation(currentNumber))
                {
                    validRotatedNumberCount++;
                }
            }

            return validRotatedNumberCount;
        }

        private bool IsNumberValidAfterRotation(int numberToCheck)
        {
            bool containsDigitThatChangesAfterRotation = false;

            while (numberToCheck > 0)
            {
                int currentDigit = numberToCheck % 10;

                if (currentDigit == 3 || currentDigit == 4 || currentDigit == 7)
                {
                    return false;
                }

                if (currentDigit == 2 || currentDigit == 5 || currentDigit == 6 || currentDigit == 9)
                {
                    containsDigitThatChangesAfterRotation = true;
                }

                numberToCheck /= 10; 
            }

            return containsDigitThatChangesAfterRotation;
        }
    }
}