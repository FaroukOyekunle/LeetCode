namespace DailyQuestion
{
    public class NumberofUniqueXORTripletsII
    {
        public int UniqueXorTriplets(int[] nums)
        {
            const int MaximumPossibleXorValue = 2048;

            bool[][] reachableXorStatesBySelectionCount = new bool[4][];

            for (int selectedElementCount = 0; selectedElementCount <= 3; selectedElementCount++)
            {
                reachableXorStatesBySelectionCount[selectedElementCount] = new bool[MaximumPossibleXorValue];
            }

            reachableXorStatesBySelectionCount[0][0] = true;

            foreach (int currentNumber in nums)
            {
                bool[][] nextReachableXorStatesBySelectionCount = new bool[4][];

                for (int selectedElementCount = 0; selectedElementCount <= 3; selectedElementCount++)
                {
                    nextReachableXorStatesBySelectionCount[selectedElementCount] = (bool[])reachableXorStatesBySelectionCount[selectedElementCount].Clone();
                }

                for (int currentXorValue = 0; currentXorValue < MaximumPossibleXorValue; currentXorValue++)
                {
                    if (reachableXorStatesBySelectionCount[0][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[1][currentXorValue ^ currentNumber] = true;
                    }

                    if (reachableXorStatesBySelectionCount[1][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[2][currentXorValue ^ currentNumber] = true;
                    }

                    if (reachableXorStatesBySelectionCount[2][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[3][currentXorValue ^ currentNumber] = true;
                    }
                }

                for (int currentXorValue = 0; currentXorValue < MaximumPossibleXorValue; currentXorValue++)
                {
                    if (reachableXorStatesBySelectionCount[0][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[2][currentXorValue] = true;
                    }

                    if (reachableXorStatesBySelectionCount[1][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[3][currentXorValue] = true;
                    }
                }

                for (int currentXorValue = 0; currentXorValue < MaximumPossibleXorValue; currentXorValue++)
                {
                    if (reachableXorStatesBySelectionCount[0][currentXorValue])
                    {
                        nextReachableXorStatesBySelectionCount[3][currentXorValue ^ currentNumber] = true;
                    }
                }

                reachableXorStatesBySelectionCount = nextReachableXorStatesBySelectionCount;
            }

            int uniqueTripletXorValueCount = 0;

            for (int currentXorValue = 0; currentXorValue < MaximumPossibleXorValue; currentXorValue++)
            {
                if (reachableXorStatesBySelectionCount[3][currentXorValue])
                {
                    uniqueTripletXorValueCount++;
                }
            }

            return uniqueTripletXorValueCount;
        }
    }
}