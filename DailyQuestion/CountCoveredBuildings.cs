namespace DailyQuestion
{
    public class CountCoveredBuildings
    {
        public int CountCoveredBuildings(int n, int[][] buildings)
        {
            var rowMap = new Dictionary<int, List<int>>();

            var colMap = new Dictionary<int, List<int>>();

            foreach (var building in buildings)
            {
                int xCoord = building[0], yCoord = building[1];

                if(!rowMap.ContainsKey(xCoord))
                {
                    rowMap[xCoord] = new List<int>();
                }
                rowMap[xCoord].Add(yCoord);

                if(!colMap.ContainsKey(yCoord))
                {
                    colMap[yCoord] = new List<int>();
                }
                
                colMap[yCoord].Add(xCoord);
            }

            foreach(var entry in rowMap)
            {
                entry.Value.Sort();
            }

            foreach(var entry in colMap)
            {
                entry.Value.Sort();
            }

            int coveredCount = 0;

            foreach(var building in buildings)
            {
                int xCoord = building[0], yCoord = building[1];

                var buildingsInRow = rowMap[xCoord];
                var buildingsInColumn = colMap[yCoord];

                int rowIndex = buildingsInRow.BinarySearch(yCoord);
                int colIndex = buildingsInColumn.BinarySearch(xCoord);

                bool hasLeftNeighbor = rowIndex > 0;
                bool hasRightNeighbor = rowIndex < buildingsInRow.Count - 1;
                bool hasUpperNeighbor = colIndex > 0;
                bool hasLowerNeighbor = colIndex < buildingsInColumn.Count - 1;

                if(hasLeftNeighbor && hasRightNeighbor && hasUpperNeighbor && hasLowerNeighbor)
                {
                    coveredCount++;
                }
            }

            return coveredCount;
        }
    }
}