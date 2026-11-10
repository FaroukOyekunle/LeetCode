using System;

namespace DailyQuestion
{
    public class ClimbingStairsII
    {
        public int ClimbStairs(int totalStepCount, int[] stepCosts)
        {
            int[] minimumCostToReachStep = new int[totalStepCount + 1];

            for (int currentStepNumber = 1; currentStepNumber <= totalStepCount; currentStepNumber++)
            {
                minimumCostToReachStep[currentStepNumber] = int.MaxValue;

                for (int currentJumpLength = 1; currentJumpLength <= 3; currentJumpLength++)
                {
                    int previousStepNumber = currentStepNumber - currentJumpLength;

                    if (previousStepNumber < 0)
                    {
                        continue;
                    }

                    int currentJumpCost = stepCosts[currentStepNumber - 1] + (currentJumpLength * currentJumpLength);

                    int totalCostToReachCurrentStep = minimumCostToReachStep[previousStepNumber] + currentJumpCost;

                    minimumCostToReachStep[currentStepNumber] = Math.Min(minimumCostToReachStep[currentStepNumber], totalCostToReachCurrentStep);
                }
            }

            return minimumCostToReachStep[totalStepCount];
        }
    }
}