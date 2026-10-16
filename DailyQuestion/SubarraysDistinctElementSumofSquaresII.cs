using System.Collections.Generic;

namespace DailyQuestion
{
    public class SubarraysDistinctElementSumofSquaresII
    {
        public int SumCounts(int[] numbers)
        {
            const long ModuloDivisor = 1_000_000_007;

            int totalNumberOfElements = numbers.Length;

            long[] distinctCountSumsBySegment = new long[4 * totalNumberOfElements];
            long[] squaredDistinctCountSumsBySegment = new long[4 * totalNumberOfElements];
            long[] pendingLazyIncrementsByNode = new long[4 * totalNumberOfElements];

            Dictionary<int, int> mostRecentIndexByNumber = new Dictionary<int, int>();

            long sumOfSquaredDistinctCountsAcrossAllSubarrays = 0;

            void ApplyIncrementToSegment(int segmentTreeNodeIndex, int segmentStartIndex, int segmentEndIndex, long distinctCountIncrement)
            {
                long segmentLength = segmentEndIndex - segmentStartIndex + 1L;

                squaredDistinctCountSumsBySegment[segmentTreeNodeIndex] = (squaredDistinctCountSumsBySegment[segmentTreeNodeIndex] + 2 * distinctCountIncrement * distinctCountSumsBySegment[segmentTreeNodeIndex] + distinctCountIncrement * distinctCountIncrement % ModuloDivisor * segmentLength) % ModuloDivisor;

                distinctCountSumsBySegment[segmentTreeNodeIndex] = (distinctCountSumsBySegment[segmentTreeNodeIndex] + distinctCountIncrement * segmentLength) % ModuloDivisor;

                pendingLazyIncrementsByNode[segmentTreeNodeIndex] = (pendingLazyIncrementsByNode[segmentTreeNodeIndex] + distinctCountIncrement) % ModuloDivisor;
            }

            void PropagatePendingIncrementToChildren(int segmentTreeNodeIndex, int segmentStartIndex, int segmentEndIndex)
            {
                if (pendingLazyIncrementsByNode[segmentTreeNodeIndex] == 0 || segmentStartIndex == segmentEndIndex)
                {
                    return;
                }

                int segmentMiddleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

                long pendingDistinctCountIncrement = pendingLazyIncrementsByNode[segmentTreeNodeIndex];

                ApplyIncrementToSegment(segmentTreeNodeIndex * 2, segmentStartIndex, segmentMiddleIndex, pendingDistinctCountIncrement);

                ApplyIncrementToSegment(segmentTreeNodeIndex * 2 + 1, segmentMiddleIndex + 1, segmentEndIndex, pendingDistinctCountIncrement);

                pendingLazyIncrementsByNode[segmentTreeNodeIndex] = 0;
            }

            void IncrementDistinctCountsInRange(int segmentTreeNodeIndex, int segmentStartIndex, int segmentEndIndex, int queryStartIndex, int queryEndIndex)
            {
                if (queryStartIndex <= segmentStartIndex && segmentEndIndex <= queryEndIndex)
                {
                    ApplyIncrementToSegment(segmentTreeNodeIndex, segmentStartIndex, segmentEndIndex, 1);

                    return;
                }

                PropagatePendingIncrementToChildren(segmentTreeNodeIndex, segmentStartIndex, segmentEndIndex);

                int segmentMiddleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

                if (queryStartIndex <= segmentMiddleIndex)
                {
                    IncrementDistinctCountsInRange(segmentTreeNodeIndex * 2, segmentStartIndex, segmentMiddleIndex, queryStartIndex, queryEndIndex);
                }

                if (queryEndIndex > segmentMiddleIndex)
                {
                    IncrementDistinctCountsInRange(segmentTreeNodeIndex * 2 + 1, segmentMiddleIndex + 1, segmentEndIndex, queryStartIndex, queryEndIndex);
                }

                squaredDistinctCountSumsBySegment[segmentTreeNodeIndex] = (squaredDistinctCountSumsBySegment[segmentTreeNodeIndex * 2] + squaredDistinctCountSumsBySegment[segmentTreeNodeIndex * 2 + 1]) % ModuloDivisor;

                distinctCountSumsBySegment[segmentTreeNodeIndex] = (distinctCountSumsBySegment[segmentTreeNodeIndex * 2] + distinctCountSumsBySegment[segmentTreeNodeIndex * 2 + 1]) % ModuloDivisor;
            }

            for (int currentRightEndpointIndex = 0; currentRightEndpointIndex < totalNumberOfElements; currentRightEndpointIndex++)
            {
                int currentNumber = numbers[currentRightEndpointIndex];

                int previousOccurrenceIndex = mostRecentIndexByNumber.TryGetValue(currentNumber, out int lastOccurrenceIndex) ? lastOccurrenceIndex : -1;

                int firstAffectedSubarrayStartIndex = previousOccurrenceIndex + 1;

                IncrementDistinctCountsInRange(1, 0, totalNumberOfElements - 1, firstAffectedSubarrayStartIndex, currentRightEndpointIndex);

                mostRecentIndexByNumber[currentNumber] = currentRightEndpointIndex;

                sumOfSquaredDistinctCountsAcrossAllSubarrays = (sumOfSquaredDistinctCountsAcrossAllSubarrays + squaredDistinctCountSumsBySegment[1]) % ModuloDivisor;
            }

            return (int)sumOfSquaredDistinctCountsAcrossAllSubarrays;
        }
    }
}