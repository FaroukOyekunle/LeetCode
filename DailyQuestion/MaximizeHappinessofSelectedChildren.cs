namespace DailyQuestion
{
    public class MaximizeHappinessofSelectedChildren
    {
        public long MaximumHappinessSum(int[] happinessLevels, int numberOfChildren)
        {
            Array.Sort(happinessLevels, (firstHappiness, secondHappiness) => secondHappiness.CompareTo(firstHappiness));

            long maximumHappinessSum = 0;

            for(int childIndex = 0; childIndex < numberOfChildren; childIndex++)
            {
                int adjustedHappiness = happinessLevels[childIndex] - childIndex;
                if(adjustedHappiness <= 0)
                {
                    break;
                }

                maximumHappinessSum += adjustedHappiness;
            }

            return maximumHappinessSum;
        }
    }
}