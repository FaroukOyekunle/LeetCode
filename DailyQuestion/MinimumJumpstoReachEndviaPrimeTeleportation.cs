namespace DailyQuestion
{
    public class MinimumJumpstoReachEndviaPrimeTeleportation
    {
        public int FindMinimumJumpsToReachEnd(int[] numbers)
        {
            int totalElements = numbers.Length;

            if (totalElements == 1)
            {
                return 0;
            }

            const int MAXIMUM_NUMBER_LIMIT = 1_000_000;

            int[] smallestPrimeFactorLookup = BuildSmallestPrimeFactorLookup(MAXIMUM_NUMBER_LIMIT);

            Dictionary<int, List<int>> primeFactorToIndexMap = new();

            for (int currentIndex = 0; currentIndex < totalElements; currentIndex++)
            {
                HashSet<int> uniquePrimeFactorsForCurrentNumber = ExtractUniquePrimeFactors(numbers[currentIndex], smallestPrimeFactorLookup);

                foreach (int primeFactor in uniquePrimeFactorsForCurrentNumber)
                {
                    if (!primeFactorToIndexMap.ContainsKey(primeFactor))
                    {
                        primeFactorToIndexMap[primeFactor] = new List<int>();
                    }

                    primeFactorToIndexMap[primeFactor].Add(currentIndex);
                }
            }

            Queue<int> indicesToVisitQueue = new();

            bool[] visitedIndices = new bool[totalElements];

            indicesToVisitQueue.Enqueue(0);
            visitedIndices[0] = true;

            int totalJumpCount = 0;

            while (indicesToVisitQueue.Count > 0)
            {
                int currentBreadthLevelSize = indicesToVisitQueue.Count;

                for (int processedNodeCount = 0; processedNodeCount < currentBreadthLevelSize; processedNodeCount++)
                {
                    int currentArrayIndex = indicesToVisitQueue.Dequeue();

                    if (currentArrayIndex == totalElements - 1)
                    {
                        return totalJumpCount;
                    }

                    int leftNeighborIndex = currentArrayIndex - 1;

                    if (leftNeighborIndex >= 0 && !visitedIndices[leftNeighborIndex])
                    {
                        visitedIndices[leftNeighborIndex] = true;
                        indicesToVisitQueue.Enqueue(leftNeighborIndex);
                    }

                    int rightNeighborIndex = currentArrayIndex + 1;

                    if (rightNeighborIndex < totalElements && !visitedIndices[rightNeighborIndex])
                    {
                        visitedIndices[rightNeighborIndex] = true;
                        indicesToVisitQueue.Enqueue(rightNeighborIndex);
                    }

                    int currentNumber = numbers[currentArrayIndex];

                    if (IsPrimeNumber(currentNumber, smallestPrimeFactorLookup))
                    {
                        int primeNumber = currentNumber;

                        if (primeFactorToIndexMap.ContainsKey(primeNumber))
                        {
                            foreach (int connectedIndex in primeFactorToIndexMap[primeNumber])
                            {
                                if (!visitedIndices[connectedIndex])
                                {
                                    visitedIndices[connectedIndex] = true;
                                    indicesToVisitQueue.Enqueue(connectedIndex);
                                }
                            }

                            primeFactorToIndexMap.Remove(primeNumber);
                        }
                    }
                }

                totalJumpCount++;
            }

            return -1;
        }

        private int[] BuildSmallestPrimeFactorLookup(int maximumLimit)
        {
            int[] smallestPrimeFactor = new int[maximumLimit + 1];

            for (int currentNumber = 0; currentNumber <= maximumLimit; currentNumber++)
            {
                smallestPrimeFactor[currentNumber] = currentNumber;
            }

            for (int currentPrimeCandidate = 2; currentPrimeCandidate * currentPrimeCandidate <= maximumLimit; currentPrimeCandidate++)
            {
                if (smallestPrimeFactor[currentPrimeCandidate] == currentPrimeCandidate)
                {
                    for (int multiple = currentPrimeCandidate * currentPrimeCandidate; multiple <= maximumLimit; multiple += currentPrimeCandidate)
                    {
                        if (smallestPrimeFactor[multiple] == multiple)
                        {
                            smallestPrimeFactor[multiple] = currentPrimeCandidate;
                        }
                    }
                }
            }

            return smallestPrimeFactor;
        }

        private bool IsPrimeNumber(int numberToCheck, int[] smallestPrimeFactorLookup)
        {
            return numberToCheck > 1 && smallestPrimeFactorLookup[numberToCheck] == numberToCheck;
        }

        private HashSet<int> ExtractUniquePrimeFactors(int numberToFactorize, int[] smallestPrimeFactorLookup)
        {
            HashSet<int> uniquePrimeFactors = new();

            while (numberToFactorize > 1)
            {
                int currentPrimeFactor = smallestPrimeFactorLookup[numberToFactorize];

                uniquePrimeFactors.Add(currentPrimeFactor);

                numberToFactorize /= currentPrimeFactor;
            }

            return uniquePrimeFactors;
        }
    }
}