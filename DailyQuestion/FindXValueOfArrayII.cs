namespace DailyQuestion
{
    public class FindXValueOfArrayII
    {
        public int[] ResultArray(int[] numbers, int divisor, int[][] queries)
        {
            int arrayLength = numbers.Length;

            int[] segmentProductRemainders = new int[arrayLength * 4];

            int[] segmentPrefixRemainderCounts = new int[arrayLength * 4 * divisor];

            BuildSegmentTree(currentNode: 1, segmentStartIndex: 0, segmentEndIndex: arrayLength - 1, numbers, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);

            int[] queryResults = new int[queries.Length];

            for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
            {
                int updateIndex = queries[queryIndex][0];
                int updatedValue = queries[queryIndex][1];
                int queryStartIndex = queries[queryIndex][2];
                int targetProductRemainder = queries[queryIndex][3];

                int updatedValueRemainder = updatedValue % divisor;

                UpdateSegmentTree(currentNode: 1, segmentStartIndex: 0, segmentEndIndex: arrayLength - 1, updateIndex, updatedValueRemainder, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);

                int[] accumulatedPrefixRemainderCounts = new int[divisor];

                int accumulatedProductRemainder = 1 % divisor;

                CollectSuffixPrefixCounts(currentNode: 1, segmentStartIndex: 0, segmentEndIndex: arrayLength - 1, queryStartIndex, divisor, segmentProductRemainders, segmentPrefixRemainderCounts, accumulatedPrefixRemainderCounts, ref accumulatedProductRemainder);

                queryResults[queryIndex] = accumulatedPrefixRemainderCounts[targetProductRemainder];
            }

            return queryResults;
        }

        private void BuildSegmentTree(int currentNode, int segmentStartIndex, int segmentEndIndex, int[] numbers, int divisor, int[] segmentProductRemainders, int[] segmentPrefixRemainderCounts)
        {
            if (segmentStartIndex == segmentEndIndex)
            {
                int currentNumberRemainder = numbers[segmentStartIndex] % divisor;

                segmentProductRemainders[currentNode] = currentNumberRemainder;

                int currentNodePrefixCountOffset = currentNode * divisor;

                segmentPrefixRemainderCounts[currentNodePrefixCountOffset + currentNumberRemainder] = 1;

                return;
            }

            int middleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

            int leftChildNode = currentNode * 2;
            int rightChildNode = currentNode * 2 + 1;

            BuildSegmentTree(leftChildNode, segmentStartIndex, middleIndex, numbers, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);

            BuildSegmentTree(rightChildNode, middleIndex + 1, segmentEndIndex, numbers, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);

            MergeNodes(leftChildNode, rightChildNode, currentNode, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);
        }

        private void UpdateSegmentTree(int currentNode, int segmentStartIndex, int segmentEndIndex, int updateIndex, int updatedRemainder, int divisor, int[] segmentProductRemainders, int[] segmentPrefixRemainderCounts)
        {
            if (segmentStartIndex == segmentEndIndex)
            {
                segmentProductRemainders[currentNode] = updatedRemainder;

                int currentNodePrefixCountOffset = currentNode * divisor;

                for (int remainderValue = 0; remainderValue < divisor; remainderValue++)
                {
                    segmentPrefixRemainderCounts[currentNodePrefixCountOffset + remainderValue] = 0;
                }

                segmentPrefixRemainderCounts[currentNodePrefixCountOffset + updatedRemainder] = 1;

                return;
            }

            int middleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

            int leftChildNode = currentNode * 2;
            int rightChildNode = currentNode * 2 + 1;

            if (updateIndex <= middleIndex)
            {
                UpdateSegmentTree(leftChildNode, segmentStartIndex, middleIndex, updateIndex, updatedRemainder, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);
            }
            else
            {
                UpdateSegmentTree(rightChildNode, middleIndex + 1, segmentEndIndex, updateIndex, updatedRemainder, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);
            }

            MergeNodes(leftChildNode, rightChildNode, currentNode, divisor, segmentProductRemainders, segmentPrefixRemainderCounts);
        }

        private void MergeNodes(int leftChildNode, int rightChildNode, int parentNode, int divisor, int[] segmentProductRemainders, int[] segmentPrefixRemainderCounts)
        {
            int leftSegmentProductRemainder = segmentProductRemainders[leftChildNode];

            int rightSegmentProductRemainder = segmentProductRemainders[rightChildNode];

            segmentProductRemainders[parentNode] = (leftSegmentProductRemainder * rightSegmentProductRemainder) % divisor;

            int leftNodePrefixCountOffset = leftChildNode * divisor;

            int rightNodePrefixCountOffset = rightChildNode * divisor;

            int parentNodePrefixCountOffset = parentNode * divisor;

            for (int remainderValue = 0; remainderValue < divisor; remainderValue++)
            {
                segmentPrefixRemainderCounts[parentNodePrefixCountOffset + remainderValue] = 0;
            }

            for (int leftPrefixRemainder = 0; leftPrefixRemainder < divisor; leftPrefixRemainder++)
            {
                segmentPrefixRemainderCounts[parentNodePrefixCountOffset + leftPrefixRemainder] += segmentPrefixRemainderCounts[leftNodePrefixCountOffset + leftPrefixRemainder];
            }

            for (int rightPrefixRemainder = 0; rightPrefixRemainder < divisor; rightPrefixRemainder++)
            {
                int combinedPrefixRemainder = (leftSegmentProductRemainder * rightPrefixRemainder) % divisor;

                segmentPrefixRemainderCounts[parentNodePrefixCountOffset + combinedPrefixRemainder] += segmentPrefixRemainderCounts[rightNodePrefixCountOffset + rightPrefixRemainder];
            }
        }

        private void CollectSuffixPrefixCounts(int currentNode, int segmentStartIndex, int segmentEndIndex, int queryStartIndex, int divisor, int[] segmentProductRemainders, int[] segmentPrefixRemainderCounts, int[] accumulatedPrefixRemainderCounts, ref int accumulatedProductRemainder)
        {
            if (segmentEndIndex < queryStartIndex)
            {
                return;
            }

            if (queryStartIndex <= segmentStartIndex)
            {
                int currentNodePrefixCountOffset = currentNode * divisor;

                for (int segmentPrefixRemainder = 0; segmentPrefixRemainder < divisor; segmentPrefixRemainder++)
                {
                    int combinedProductRemainder = (accumulatedProductRemainder * segmentPrefixRemainder) % divisor;

                    accumulatedPrefixRemainderCounts[combinedProductRemainder] += segmentPrefixRemainderCounts[currentNodePrefixCountOffset + segmentPrefixRemainder];
                }

                accumulatedProductRemainder = (accumulatedProductRemainder * segmentProductRemainders[currentNode]) % divisor;

                return;
            }

            int middleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

            int leftChildNode = currentNode * 2;
            int rightChildNode = currentNode * 2 + 1;

            CollectSuffixPrefixCounts(leftChildNode, segmentStartIndex, middleIndex, queryStartIndex, divisor, segmentProductRemainders, segmentPrefixRemainderCounts, accumulatedPrefixRemainderCounts, ref accumulatedProductRemainder);

            CollectSuffixPrefixCounts(rightChildNode, middleIndex + 1, segmentEndIndex, queryStartIndex, divisor, segmentProductRemainders, segmentPrefixRemainderCounts, accumulatedPrefixRemainderCounts, ref accumulatedProductRemainder);
        }
    }
}