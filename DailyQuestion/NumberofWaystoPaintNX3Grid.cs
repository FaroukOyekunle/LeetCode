namespace DailyQuestion
{
    public class NumberofWaystoPaintNX3Grid
    {
        public int NumOfWays(int gridRows)
        {
            const int MODULO = 1000000007;

            long sameColorPatterns = 6;
            long differentColorPatterns = 6;

            for(int currentRow = 2; currentRow <= gridRows; currentRow++)
            {
                long newSameColorPatterns = (sameColorPatterns * 3 + differentColorPatterns * 2) % MODULO;
                long newDifferentColorPatterns = (sameColorPatterns * 2 + differentColorPatterns * 2) % MODULO;

                sameColorPatterns = newSameColorPatterns;
                differentColorPatterns = newDifferentColorPatterns;
            }

            return (int)((sameColorPatterns + differentColorPatterns) % MODULO);
        }
    }
}