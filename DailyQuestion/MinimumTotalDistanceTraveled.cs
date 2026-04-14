namespace DailyQuestion
{
    public class MinimumTotalDistanceTraveled
    {
        public long ComputeMinimumTotalDistanceToFactories(IList<int> robotPositions, int[][] factories)
        {
            var sortedRobotPositions = robotPositions.OrderBy(position => position).ToList();

            Array.Sort(factories, (factoryA, factoryB) => factoryA[0].CompareTo(factoryB[0]));

            var expandedFactoryPositions = new List<int>();

            foreach (var factory in factories)
            {
                int factoryPosition = factory[0];
                int capacityLimit = factory[1];

                for (int slotIndex = 0; slotIndex < capacityLimit; slotIndex++)
                {
                    expandedFactoryPositions.Add(factoryPosition);
                }
            }

            int robotCount = sortedRobotPositions.Count;
            int totalFactorySlots = expandedFactoryPositions.Count;

            long[,] minimumDistanceDp = new long[robotCount + 1, totalFactorySlots + 1];

            long infinityValue = (long)1e18;

            for (int robotIndex = 0; robotIndex <= robotCount; robotIndex++)
            {
                for (int slotIndex = 0; slotIndex <= totalFactorySlots; slotIndex++)
                {
                    minimumDistanceDp[robotIndex, slotIndex] = infinityValue;
                }
            }

            for (int slotIndex = 0; slotIndex <= totalFactorySlots; slotIndex++)
            {
                minimumDistanceDp[0, slotIndex] = 0;
            }

            for (int robotIndex = 1; robotIndex <= robotCount; robotIndex++)
            {
                for (int slotIndex = 1; slotIndex <= totalFactorySlots; slotIndex++)
                {
                    minimumDistanceDp[robotIndex, slotIndex] = minimumDistanceDp[robotIndex, slotIndex - 1];

                    long assignmentCost = Math.Abs(sortedRobotPositions[robotIndex - 1] - expandedFactoryPositions[slotIndex - 1]);

                    minimumDistanceDp[robotIndex, slotIndex] = Math.Min(minimumDistanceDp[robotIndex, slotIndex], minimumDistanceDp[robotIndex - 1, slotIndex - 1] + assignmentCost);
                }
            }

            return minimumDistanceDp[robotCount, totalFactorySlots];
        }
    }
}