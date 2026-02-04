namespace DailyQuestion
{
    public class TrionicArrayII
    {
        public long CalculateMaximumTrionicSum(int[] inputArray)
        {
            long maximumSum = long.MinValue;

            long leftIndex = 0, peakIndex = 0, valleyIndex = 0;
            long currentPrefixSum = inputArray[0];

            for (long rightIndex = 1; rightIndex < inputArray.Length; rightIndex++)
            {
                currentPrefixSum += inputArray[rightIndex];

                if (inputArray[rightIndex - 1] > inputArray[rightIndex])
                {
                    if (rightIndex - 2 >= 0 && inputArray[rightIndex - 2] < inputArray[rightIndex - 1])
                    {
                        peakIndex = rightIndex - 1;

                        while (leftIndex < valleyIndex || (inputArray[leftIndex] < 0 && leftIndex + 1 < peakIndex))
                        {
                            currentPrefixSum -= inputArray[leftIndex];
                            leftIndex++;
                        }
                    }
                }

                else if (inputArray[rightIndex - 1] < inputArray[rightIndex])
                {
                    if (rightIndex - 2 >= 0 && inputArray[rightIndex - 2] > inputArray[rightIndex - 1])
                    {
                        valleyIndex = rightIndex - 1;
                    }

                    if (leftIndex != peakIndex)
                    {
                        maximumSum = Math.Max(maximumSum, currentPrefixSum);
                    }
                }
                
                else
                {
                    leftIndex = peakIndex = valleyIndex = rightIndex;
                    currentPrefixSum = inputArray[rightIndex];
                }
            }

            return maximumSum;
        }
    }
}