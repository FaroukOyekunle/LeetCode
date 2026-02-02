namespace DailyQuestion
{
    public class DivideanArrayIntoSubarraysWithMinimumCostII
    {
        public long CalculateMinimumCostWithConstraints(int[] inputNumbers, int maxSelectedCount, int distanceConstraint)
        {
            int arrayLength = inputNumbers.Length;
            long currentWindowSum = 0;

            var selectedQueue = new PriorityQueue<int, int>();
            var candidateQueue = new PriorityQueue<int, int>();

            var selectedElementCounts = new Dictionary<int, int>();
            var candidateElementCounts = new Dictionary<int, int>();

            int selectedElementCount = 0;

            void AddElement(PriorityQueue<int, int> priorityQueue, Dictionary<int, int> elementCounts, int value)
            {
                priorityQueue.Enqueue(value, value);
                elementCounts[value] = elementCounts.GetValueOrDefault(value) + 1;
            }

            void RemoveElement(Dictionary<int, int> elementCounts, int value)
            {
                if (--elementCounts[value] == 0)
                {
                    elementCounts.Remove(value);
                }
            }

            int? GetMaximumSelectedElement()
            {
                while (selectedQueue.Count > 0)
                {
                    int topElement = selectedQueue.Peek();
                    if (selectedElementCounts.ContainsKey(topElement))
                    {
                        return -topElement;
                    }
                    selectedQueue.Dequeue();
                }
                return null;
            }

            for (int index = 1; index <= Math.Min(distanceConstraint + 1, arrayLength - 1); index++)
            {
                currentWindowSum += inputNumbers[index];
                AddElement(selectedQueue, selectedElementCounts, -inputNumbers[index]);

                selectedElementCount++;
            }

            while (selectedElementCount > maxSelectedCount - 1)
            {
                int maximumValue = GetMaximumSelectedElement().Value;
                selectedQueue.Dequeue();

                RemoveElement(selectedElementCounts, -maximumValue);

                selectedElementCount--;
                currentWindowSum -= maximumValue;

                AddElement(candidateQueue, candidateElementCounts, maximumValue);
            }

            long minimumWindowSum = currentWindowSum;

            for (int index = distanceConstraint + 2; index < arrayLength; index++)
            {
                int outOfScopeElement = inputNumbers[index - distanceConstraint - 1];

                if (selectedElementCounts.ContainsKey(-outOfScopeElement))
                {
                    currentWindowSum -= outOfScopeElement;
                    selectedElementCount--;

                    RemoveElement(selectedElementCounts, -outOfScopeElement);
                }
                else
                {
                    RemoveElement(candidateElementCounts, outOfScopeElement);
                }

                int? maximumSelectedElement = GetMaximumSelectedElement();
                if (maximumSelectedElement == null || inputNumbers[index] < maximumSelectedElement)
                {
                    currentWindowSum += inputNumbers[index];
                    selectedElementCount++;

                    AddElement(selectedQueue, selectedElementCounts, -inputNumbers[index]);
                }
                else
                {
                    AddElement(candidateQueue, candidateElementCounts, inputNumbers[index]);
                }

                while (selectedQueue.Count > 0 && !selectedElementCounts.ContainsKey(selectedQueue.Peek()))
                {
                    selectedQueue.Dequeue();
                }

                while (candidateQueue.Count > 0 && !candidateElementCounts.ContainsKey(candidateQueue.Peek()))
                {
                    candidateQueue.Dequeue();
                }

                while (selectedElementCount < maxSelectedCount - 1 && candidateQueue.Count > 0)
                {
                    int minimumCandidate = candidateQueue.Peek();
                    candidateQueue.Dequeue();

                    RemoveElement(candidateElementCounts, minimumCandidate);

                    currentWindowSum += minimumCandidate;
                    selectedElementCount++;

                    AddElement(selectedQueue, selectedElementCounts, -minimumCandidate);
                }

                while (selectedElementCount > maxSelectedCount - 1)
                {
                    int maximumValue = GetMaximumSelectedElement().Value;
                    selectedQueue.Dequeue();

                    RemoveElement(selectedElementCounts, -maximumValue);

                    selectedElementCount--;
                    currentWindowSum -= maximumValue;

                    AddElement(candidateQueue, candidateElementCounts, maximumValue);
                }

                minimumWindowSum = Math.Min(minimumWindowSum, currentWindowSum);
            }

            return inputNumbers[0] + minimumWindowSum;
        }
    }
}