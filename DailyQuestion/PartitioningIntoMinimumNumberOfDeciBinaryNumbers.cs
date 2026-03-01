namespace DailyQuestion
{
    public class PartitioningIntoMinimumNumberOfDeciBinaryNumbers
    {
        public int CalculateMinimumPartitions(string decimalString)
        {
            int maximumDigit = 0;

            foreach (char character in decimalString)
            {
                int currentDigit = character - '0';
                if (currentDigit > maximumDigit)
                {
                    maximumDigit = currentDigit;
                    
                    if (maximumDigit == 9)
                    {
                        return 9;
                    }
                }
            }

            return maximumDigit;
        }
    }
}