namespace DailyQuestion
{
    public class CheckifArrayisGood
    {
        public bool IsGood(int[] numbers)
        {
            int largestNumber = numbers.Max();

            if (numbers.Length != largestNumber + 1)
            {
                return false;
            }

            int[] occurrenceCountByNumber = new int[largestNumber + 1];

            foreach (int currentNumber in numbers)
            {
                if (currentNumber < 1 || currentNumber > largestNumber)
                {
                    return false;
                }

                occurrenceCountByNumber[currentNumber]++;
            }

            for (int expectedNumber = 1; expectedNumber < largestNumber; expectedNumber++)
            {
                if (occurrenceCountByNumber[expectedNumber] != 1)
                {
                    return false;
                }
            }

            return occurrenceCountByNumber[largestNumber] == 2;
        }
    }
}