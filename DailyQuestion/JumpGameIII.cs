namespace DailyQuestion
{
    public class JumpGameIII
    {
        public bool CanReach(int[] jumpValues, int startingIndex)
        {
            bool[] hasVisitedIndex = new bool[jumpValues.Length];

            Queue<int> indicesToExploreQueue = new Queue<int>();

            indicesToExploreQueue.Enqueue(startingIndex);

            while (indicesToExploreQueue.Count > 0)
            {
                int currentIndex = indicesToExploreQueue.Dequeue();

                if (hasVisitedIndex[currentIndex])
                {
                    continue;
                }

                hasVisitedIndex[currentIndex] = true;

                if (jumpValues[currentIndex] == 0)
                {
                    return true;
                }

                int forwardReachableIndex = currentIndex + jumpValues[currentIndex];

                int backwardReachableIndex = currentIndex - jumpValues[currentIndex];

                bool canJumpForward = forwardReachableIndex < jumpValues.Length && !hasVisitedIndex[forwardReachableIndex];

                if (canJumpForward)
                {
                    indicesToExploreQueue.Enqueue(forwardReachableIndex);
                }

                bool canJumpBackward = backwardReachableIndex >= 0 && !hasVisitedIndex[backwardReachableIndex];

                if (canJumpBackward)
                {
                    indicesToExploreQueue.Enqueue(backwardReachableIndex);
                }
            }

            return false;
        }
    }
}