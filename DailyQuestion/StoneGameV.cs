namespace DailyQuestion
{
    public class StoneGameV
    {
        public int StoneGameV(int[] stoneValues)
        {
            int totalStoneCount = stoneValues.Length;

            if (totalStoneCount <= 1)
            {
                return 0;
            }

            int[] cumulativeStoneValueSum = new int[totalStoneCount + 1];

            for (int stoneIndex = 0; stoneIndex < totalStoneCount; stoneIndex++)
            {
                cumulativeStoneValueSum[stoneIndex + 1] = cumulativeStoneValueSum[stoneIndex] + stoneValues[stoneIndex];
            }

            int[,] maximumAchievableScore = new int[totalStoneCount, totalStoneCount];

            for (int subarrayLength = 2; subarrayLength <= totalStoneCount; subarrayLength++)
            {
                for (int subarrayStartIndex = 0; subarrayStartIndex + subarrayLength <= totalStoneCount; subarrayStartIndex++)
                {
                    int subarrayEndIndex = subarrayStartIndex + subarrayLength - 1;

                    for (int partitionIndex = subarrayStartIndex; partitionIndex < subarrayEndIndex; partitionIndex++)
                    {
                        int leftPartitionSum = cumulativeStoneValueSum[partitionIndex + 1] - cumulativeStoneValueSum[subarrayStartIndex];

                        int rightPartitionSum = cumulativeStoneValueSum[subarrayEndIndex + 1] - cumulativeStoneValueSum[partitionIndex + 1];

                        if (leftPartitionSum < rightPartitionSum)
                        {
                            maximumAchievableScore[subarrayStartIndex, subarrayEndIndex] = Math.Max(maximumAchievableScore[subarrayStartIndex, subarrayEndIndex], leftPartitionSum + maximumAchievableScore[subarrayStartIndex, partitionIndex]);
                        }
                        else if (leftPartitionSum > rightPartitionSum)
                        {
                            maximumAchievableScore[subarrayStartIndex, subarrayEndIndex] =
                                Math.Max(maximumAchievableScore[subarrayStartIndex, subarrayEndIndex], rightPartitionSum + maximumAchievableScore[partitionIndex + 1, subarrayEndIndex]);
                        }
                        else
                        {
                            maximumAchievableScore[subarrayStartIndex, subarrayEndIndex] =
                                Math.Max(
                                    maximumAchievableScore[subarrayStartIndex, subarrayEndIndex],
                                    Math.Max(
                                        leftPartitionSum + maximumAchievableScore[subarrayStartIndex, partitionIndex],

                                        rightPartitionSum + maximumAchievableScore[partitionIndex + 1, subarrayEndIndex]
                                    ));
                        }
                    }
                }
            }

            return maximumAchievableScore[0, totalStoneCount - 1];
        }
    }
}