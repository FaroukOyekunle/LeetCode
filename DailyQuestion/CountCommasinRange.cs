namespace DailyQuestion
{
    public class CountCommasinRange
    {
        public int CountCommas(int maximumNumber)
        {
            const int firstNumberWithComma = 1000;

            if (maximumNumber < firstNumberWithComma)
            {
                return 0;
            }

            int totalNumbersContainingComma = maximumNumber - (firstNumberWithComma - 1);

            return totalNumbersContainingComma;
        }
    }
}