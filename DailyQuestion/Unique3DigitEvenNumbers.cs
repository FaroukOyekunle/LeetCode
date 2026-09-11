namespace DailyQuestion
{
    public class Unique3DigitEvenNumbers
    {
        public int TotalNumbers(int[] availableDigits)
        {
            int[] digitFrequency = new int[10];

            foreach (int currentDigit in availableDigits)
            {
                digitFrequency[currentDigit]++;
            }

            int totalValidNumbers = 0;

            for (int lastDigit = 0; lastDigit <= 8; lastDigit += 2)
            {
                if (digitFrequency[lastDigit] == 0)
                {
                    continue;
                }

                digitFrequency[lastDigit]--;

                for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
                {
                    if (digitFrequency[firstDigit] == 0)
                    {
                        continue;
                    }

                    digitFrequency[firstDigit]--;

                    for (int middleDigit = 0; middleDigit <= 9; middleDigit++)
                    {
                        if (digitFrequency[middleDigit] > 0)
                        {
                            totalValidNumbers++;
                        }
                    }

                    digitFrequency[firstDigit]++;
                }

                digitFrequency[lastDigit]++;
            }

            return totalValidNumbers;
        }
    }
}