namespace DailyQuestion
{
    public class MaximumBuildingHeight
    {
        public int MaxBuilding(int totalBuildingCount, int[][] buildingHeightRestrictions)
        {
            List<int[]> normalizedBuildingRestrictions = new List<int[]>();

            normalizedBuildingRestrictions.Add(new[] { 1, 0 });

            foreach (int[] currentRestriction in buildingHeightRestrictions)
            {
                normalizedBuildingRestrictions.Add(new[]
                {
                    currentRestriction[0], currentRestriction[1]
                });
            }

            normalizedBuildingRestrictions.Add(new[]
            {
                totalBuildingCount, totalBuildingCount - 1
            });

            normalizedBuildingRestrictions.Sort((leftRestriction, rightRestriction) => leftRestriction[0].CompareTo(rightRestriction[0]));

            for (int restrictionIndex = 1; restrictionIndex < normalizedBuildingRestrictions.Count; restrictionIndex++)
            {
                int buildingIndexGap = normalizedBuildingRestrictions[restrictionIndex][0] - normalizedBuildingRestrictions[restrictionIndex - 1][0];

                normalizedBuildingRestrictions[restrictionIndex][1] = 
                Math.Min(normalizedBuildingRestrictions[restrictionIndex][1], normalizedBuildingRestrictions[restrictionIndex - 1][1] + buildingIndexGap);
            }

            for (int restrictionIndex = normalizedBuildingRestrictions.Count - 2; restrictionIndex >= 0; restrictionIndex--)
            {
                int buildingIndexGap = normalizedBuildingRestrictions[restrictionIndex + 1][0] - normalizedBuildingRestrictions[restrictionIndex][0];

                normalizedBuildingRestrictions[restrictionIndex][1] =
                Math.Min(normalizedBuildingRestrictions[restrictionIndex][1], normalizedBuildingRestrictions[restrictionIndex + 1][1] + buildingIndexGap);
            }

            int maximumPossibleBuildingHeight = 0;

            for (int restrictionIndex = 1; restrictionIndex < normalizedBuildingRestrictions.Count; restrictionIndex++)
            {
                int leftBoundaryBuildingIndex = normalizedBuildingRestrictions[restrictionIndex - 1][0];

                int leftBoundaryHeight = normalizedBuildingRestrictions[restrictionIndex - 1][1];

                int rightBoundaryBuildingIndex = normalizedBuildingRestrictions[restrictionIndex][0];

                int rightBoundaryHeight = normalizedBuildingRestrictions[restrictionIndex][1];

                int distanceBetweenBuildings = rightBoundaryBuildingIndex - leftBoundaryBuildingIndex;

                int maximumReachablePeakHeight = (leftBoundaryHeight + rightBoundaryHeight + distanceBetweenBuildings) / 2;

                maximumPossibleBuildingHeight = Math.Max(maximumPossibleBuildingHeight, maximumReachablePeakHeight);
            }

            return maximumPossibleBuildingHeight;
        }
    }
}