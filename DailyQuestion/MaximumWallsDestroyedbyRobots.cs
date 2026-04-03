namespace DailyQuestion
{
    public class MaximumWallsDestroyedbyRobots
    {
        public int GetMaximumWallsDestroyed(int[] robotPositions, int[] robotRanges, int[] wallPositions)
        {
            int robotCount = robotPositions.Length;

            var robotsWithRange = new List<(int position, int range)>();
            robotsWithRange.Add((0, 0));

            for (int robotIndex = 0; robotIndex < robotCount; robotIndex++)
            {
                robotsWithRange.Add((robotPositions[robotIndex], robotRanges[robotIndex]));
            }

            robotsWithRange.Sort((left, right) => left.position.CompareTo(right.position));

            robotsWithRange.Add((int.MaxValue, 0));

            Array.Sort(wallPositions);

            int firstWallRightPointer = 0;     
            int rightCoveragePointer = 0;      
            int leftCoveragePointerState0 = 0; 
            int leftCoveragePointerState1 = 0; 

            int[] maxWallsDestroyedUpToPreviousRobot = new int[2];
            int[] maxWallsDestroyedCurrentRobot = new int[2];

            for (int robotIndex = 1; robotIndex < robotsWithRange.Count - 1; robotIndex++)
            {
                int currentRobotPosition = robotsWithRange[robotIndex].position;
                int currentRobotRange = robotsWithRange[robotIndex].range;

                while (firstWallRightPointer < wallPositions.Length && wallPositions[firstWallRightPointer] < currentRobotPosition)
                {
                    firstWallRightPointer++;
                }

                int rightmostReachablePosition = Math.Min(currentRobotPosition + currentRobotRange, robotsWithRange[robotIndex + 1].position - 1);

                while (rightCoveragePointer < wallPositions.Length && wallPositions[rightCoveragePointer] <= rightmostReachablePosition)
                {
                    rightCoveragePointer++;
                }

                maxWallsDestroyedCurrentRobot[1] = Math.Max(maxWallsDestroyedUpToPreviousRobot[0], maxWallsDestroyedUpToPreviousRobot[1]) + (rightCoveragePointer - firstWallRightPointer);

                if (firstWallRightPointer < wallPositions.Length && wallPositions[firstWallRightPointer] == currentRobotPosition)
                {
                    firstWallRightPointer++;
                }

                int leftmostReachableState0 = Math.Max(currentRobotPosition - currentRobotRange, robotsWithRange[robotIndex - 1].position + 1);

                while (leftCoveragePointerState0 < wallPositions.Length && wallPositions[leftCoveragePointerState0] < leftmostReachableState0)
                {
                    leftCoveragePointerState0++;
                }

                int leftmostReachableState1 = Math.Max(
                    Math.Min(robotsWithRange[robotIndex - 1].position + robotsWithRange[robotIndex - 1].range, currentRobotPosition - 1) + 1, 
                    Math.Max(currentRobotPosition - currentRobotRange,  robotsWithRange[robotIndex - 1].position + 1));

                while (leftCoveragePointerState1 < wallPositions.Length && wallPositions[leftCoveragePointerState1] < leftmostReachableState1)
                {
                    leftCoveragePointerState1++;
                }

                maxWallsDestroyedCurrentRobot[0] = Math.Max(maxWallsDestroyedUpToPreviousRobot[0] + (firstWallRightPointer - leftCoveragePointerState0),

                maxWallsDestroyedUpToPreviousRobot[1] + (firstWallRightPointer - leftCoveragePointerState1));

                var temp = maxWallsDestroyedUpToPreviousRobot;
                maxWallsDestroyedUpToPreviousRobot = maxWallsDestroyedCurrentRobot;
                maxWallsDestroyedCurrentRobot = temp;
            }

            return Math.Max(maxWallsDestroyedUpToPreviousRobot[0], maxWallsDestroyedUpToPreviousRobot[1]);
        }
    }
}