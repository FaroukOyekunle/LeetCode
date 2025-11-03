namespace DailyQuestion
{
    public class MinimumTimetoMakeRopeColorful
    {
        public int MinCost(string colors, int[] neededTime)
        {
            int totalCost = 0;

            for(int i = 1; i < colors.Length; i++)
            {
                if(colors[i] == colors[i - 1])
                {
                    if(neededTime[i] < neededTime[i - 1])
                    {
                        totalCost += neededTime[i];
                        neededTime[i] = neededTime[i - 1];
                    }

                    else
                    {
                        totalCost += neededTime[i - 1];
                    }
                }
            }

            return totalCost;
        }
    }
}