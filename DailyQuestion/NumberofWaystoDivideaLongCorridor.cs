namespace DailyQuestion
{
    public class NumberofWaystoDivideaLongCorridor
    {
        public int NumberOfWays(string corridorLayout)
        {
            const int MODULO_CONSTANT = 1_000_000_007;

            int totalSeatCount = 0;
            foreach(char currentPosition in corridorLayout)
            {
                if(currentPosition == 'S')
                {
                    totalSeatCount++;
                }
            }

            if(totalSeatCount == 0 || totalSeatCount % 2 != 0)
            {
                return 0;
            }

            long totalWays = 1;
            int currentSeatCount = 0;
            int currentPlantCount = 0;

            foreach(char currentPosition in corridorLayout)
            {
                if(currentPosition == 'S')
                {
                    currentSeatCount++;

                    if(currentSeatCount > 2 && currentSeatCount % 2 == 1)
                    {
                        totalWays = (totalWays * (currentPlantCount + 1)) % MODULO_CONSTANT;
                        currentPlantCount = 0;
                    }
                }

                else if(currentSeatCount >= 2 && currentSeatCount % 2 == 0)
                {
                    currentPlantCount++;
                }
            }

            return (int)totalWays;
        }
    }
}