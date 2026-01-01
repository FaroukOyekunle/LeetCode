namespace DailyQuestion
{
    public class PlusOne
    {
        public int[] PlusOne(int[] digitArray)
        {
            for(int digitIndex = digitArray.Length - 1; digitIndex >= 0; digitIndex--)
            {
                if(digitArray[digitIndex] < 9)
                {
                    digitArray[digitIndex]++;
                    return digitArray;
                }

                digitArray[digitIndex] = 0;
            }

            int[] incrementedResult = new int[digitArray.Length + 1];
            incrementedResult[0] = 1;

            return incrementedResult;
        }
    }
}