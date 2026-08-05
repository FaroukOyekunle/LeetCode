namespace DailyQuestion
{
    public class RemoveMethodsFromProject
    {
        public IList<int> RemainingMethods(int totalMethodCount, int suspiciousMethod, int[][] methodInvocations)
        {
            List<int>[] invocationGraph = new List<int>[totalMethodCount];

            for (int methodIndex = 0; methodIndex < totalMethodCount; methodIndex++)
            {
                invocationGraph[methodIndex] = new List<int>();
            }

            foreach (int[] invocationRelationship in methodInvocations)
            {
                int sourceMethod = invocationRelationship[0];
                int destinationMethod = invocationRelationship[1];

                invocationGraph[sourceMethod].Add(destinationMethod);
            }

            bool[] isMethodSuspicious = new bool[totalMethodCount];

            Queue<int> suspiciousMethodsToProcess = new Queue<int>();

            suspiciousMethodsToProcess.Enqueue(suspiciousMethod);
            isMethodSuspicious[suspiciousMethod] = true;

            while (suspiciousMethodsToProcess.Count > 0)
            {
                int currentSuspiciousMethod = suspiciousMethodsToProcess.Dequeue();

                foreach (int reachableMethod in invocationGraph[currentSuspiciousMethod])
                {
                    if (isMethodSuspicious[reachableMethod])
                    {
                        continue;
                    }

                    isMethodSuspicious[reachableMethod] = true;

                    suspiciousMethodsToProcess.Enqueue(reachableMethod);
                }
            }

            foreach (int[] invocationRelationship in methodInvocations)
            {
                int sourceMethod = invocationRelationship[0];
                int destinationMethod = invocationRelationship[1];

                if (!isMethodSuspicious[sourceMethod] && isMethodSuspicious[destinationMethod])
                {
                    List<int> allMethodIndices = new List<int>();

                    for (int methodIndex = 0; methodIndex < totalMethodCount; methodIndex++)
                    {
                        allMethodIndices.Add(methodIndex);
                    }

                    return allMethodIndices;
                }
            }

            List<int> remainingNonSuspiciousMethods = new List<int>();

            for (int methodIndex = 0; methodIndex < totalMethodCount; methodIndex++)
            {
                if (!isMethodSuspicious[methodIndex])
                {
                    remainingNonSuspiciousMethods.Add(methodIndex);
                }
            }

            return remainingNonSuspiciousMethods;
        }
    }
}