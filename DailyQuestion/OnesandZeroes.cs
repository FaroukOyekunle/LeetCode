namespace DailyQuestion
{
    public class OnesAndZeroes
    {
        public int FindMaxSubsetWithinLimits(string[] binaryStrings, int maxZeros, int maxOnes)
        {
            int[,] dpTable = new int[maxZeros + 1, maxOnes + 1];

            foreach(var binary in binaryStrings)
            {
                int zeroCount = 0;
                int oneCount = 0;

                foreach(char ch in binary)
                {
                    if (ch == '0')
                    {
                        zeroCount++;
                    }

                    else
                    {
                        oneCount++;
                    }
                }

                for(int zerosAvailable = maxZeros; zerosAvailable >= zeroCount; zerosAvailable--)
                {
                    for(int onesAvailable = maxOnes; onesAvailable >= oneCount; onesAvailable--)
                    {
                        dpTable[zerosAvailable, onesAvailable] = Math.Max(dpTable[zerosAvailable, onesAvailable], dpTable[zerosAvailable - zeroCount, onesAvailable - oneCount] + 1);
                    }
                }
            }

            return dpTable[maxZeros, maxOnes];
        }
    }
}