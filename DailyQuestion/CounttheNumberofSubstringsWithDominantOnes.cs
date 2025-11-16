namespace DailyQuestion
{
    public class CounttheNumberofSubstringsWithDominantOnes
    {
        public int NumberOfSubstrings(string s)
        {
            int length = s.Length;

            List<int> zeroPositions = new List<int>();
            for(int index = 0; index < length; index++)
            {
                if(s[index] == '0')
                {
                    zeroPositions.Add(index);
                }
            }

            long totalCount = 0;

            long consecutiveOnes = 0;
            for(int index = 0; index < length; index++)
            {
                if(s[index] == '1')
                {
                    consecutiveOnes++;
                }

                else
                {
                    totalCount += consecutiveOnes * (consecutiveOnes + 1) / 2;
                    consecutiveOnes = 0;
                }
            }
            totalCount += consecutiveOnes * (consecutiveOnes + 1) / 2;

            int zeroCount = zeroPositions.Count;
            if(zeroCount == 0)
            {
                return (int)totalCount;
            }

            for(int zerosInGroup = 1; ; zerosInGroup++)
            {
                long minSubstringLength = 1L * zerosInGroup * zerosInGroup + zerosInGroup;
                if(minSubstringLength > length)
                {
                    break;
                }

                if(zerosInGroup > zeroCount)
                {
                    break;
                }

                for(int leftZeroIndex = 0; leftZeroIndex + zerosInGroup - 1 < zeroCount; leftZeroIndex++)
                {
                    int rightZeroIndex = leftZeroIndex + zerosInGroup - 1;
                    int zeroPosLeft = zeroPositions[leftZeroIndex];
                    int zeroPosRight = zeroPositions[rightZeroIndex];

                    int startLowerBound = (leftZeroIndex == 0) ? 0 : zeroPositions[leftZeroIndex - 1] + 1;
                    int endUpperBound = (rightZeroIndex == zeroCount - 1) ? length - 1 : zeroPositions[rightZeroIndex + 1] - 1;

                    long startMin = startLowerBound;
                    long startMax = zeroPosLeft;
                    long endMin = zeroPosRight;
                    long endMax = endUpperBound;

                    if(startMin > startMax || endMin > endMax)
                    {
                        continue;
                    }

                    long earliestStartForTypeA = zeroPosRight - (minSubstringLength - 1);
                    long startA_min = startMin;
                    long startA_max = Math.Min(startMax, earliestStartForTypeA);

                    long countTypeA = 0;
                    if(startA_max >= startA_min)
                    {
                        long startChoices = (startA_max - startA_min + 1);
                        long endChoices = (endMax - endMin + 1);
                        countTypeA = startChoices * endChoices;
                    }

                    long startB_min = Math.Max(startMin, earliestStartForTypeA + 1);
                    long startB_max = Math.Min(startMax, endMax - (minSubstringLength - 1));

                    long countTypeB = 0;
                    if(startB_max >= startB_min)
                    {
                        long startRangeCount = startB_max - startB_min + 1;

                        long sumStartRange = (startB_min + startB_max) * startRangeCount / 2;
                        countTypeB = startRangeCount * (endMax - minSubstringLength + 2) - sumStartRange;
                    }

                    totalCount += countTypeA + countTypeB;
                }
            }

            return (int)totalCount;
        }
    }
}