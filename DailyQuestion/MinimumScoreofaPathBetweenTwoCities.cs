namespace DailyQuestion
{
    public class MinimumScoreofaPathBetweenTwoCities
    {
        public int MinScore(int totalCityCount, int[][] roads)
        {
            List<(int ConnectedCity, int RoadDistance)>[] adjacencyList = new List<(int, int)>[totalCityCount + 1];

            for (int cityNumber = 1; cityNumber <= totalCityCount; cityNumber++)
            {
                adjacencyList[cityNumber] = new List<(int, int)>();
            }

            foreach (int[] road in roads)
            {
                int firstCity = road[0];
                int secondCity = road[1];
                int roadDistance = road[2];

                adjacencyList[firstCity].Add((secondCity, roadDistance));
                adjacencyList[secondCity].Add((firstCity, roadDistance));
            }

            bool[] visitedCities = new bool[totalCityCount + 1];

            Stack<int> depthFirstSearchStack = new Stack<int>();

            depthFirstSearchStack.Push(1);
            visitedCities[1] = true;

            int minimumRoadDistanceInConnectedComponent = int.MaxValue;

            while (depthFirstSearchStack.Count > 0)
            {
                int currentCity = depthFirstSearchStack.Pop();

                foreach ((int connectedCity, int roadDistance) in adjacencyList[currentCity])
                {
                    minimumRoadDistanceInConnectedComponent = Math.Min(minimumRoadDistanceInConnectedComponent, roadDistance);

                    if (!visitedCities[connectedCity])
                    {
                        visitedCities[connectedCity] = true;

                        depthFirstSearchStack.Push(connectedCity);
                    }
                }
            }

            return minimumRoadDistanceInConnectedComponent;
        }
    }
}