namespace DailyQuestion
{
    public class JumpGameVII
    {
        public bool CanReach(string binaryString, int minimumJumpDistance, int maximumJumpDistance)
        {
            int stringLength = binaryString.Length;

            if (binaryString[stringLength - 1] == '1')
            {
                return false;
            }

            Queue<int> reachablePositionQueue = new Queue<int>();
            reachablePositionQueue.Enqueue(0);

            bool[] visitedPositions = new bool[stringLength];
            visitedPositions[0] = true;

            int farthestProcessedIndex = 0;

            while (reachablePositionQueue.Count > 0)
            {
                int currentPosition = reachablePositionQueue.Dequeue();

                int minimumNextPosition = currentPosition + minimumJumpDistance;

                int maximumNextPosition = Math.Min(currentPosition + maximumJumpDistance, stringLength - 1);

                int scanningStartIndex = Math.Max(
                    minimumNextPosition,
                    farthestProcessedIndex + 1);

                for (int nextPosition = scanningStartIndex; nextPosition <= maximumNextPosition; nextPosition++)
                {
                    bool isReachablePosition = binaryString[nextPosition] == '0';

                    if (isReachablePosition && !visitedPositions[nextPosition])
                    {
                        if (nextPosition == stringLength - 1)
                        {
                            return true;
                        }

                        visitedPositions[nextPosition] = true;
                        reachablePositionQueue.Enqueue(nextPosition);
                    }
                }

                farthestProcessedIndex = Math.Max(farthestProcessedIndex, maximumNextPosition);
            }

            return stringLength == 1;
        }
    }
}