namespace DailyQuestion
{
    public class MinimumCostPathwithTeleportations
    {
        public int FindMinimumCostPathWithTeleportations(int[][] grid, int maxTeleportations)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;
            int Infinity = int.MaxValue / 4;

            int[,,] minimumDistances = new int[rowCount, columnCount, maxTeleportations + 1];
            
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    for (int teleportationCount = 0; teleportationCount <= maxTeleportations; teleportationCount++)
                    {
                        minimumDistances[rowIndex, columnIndex, teleportationCount] = Infinity;
                    }
                }
            }

            var cellList = new List<(int cellValue, int rowIndex, int columnIndex)>();
            
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    cellList.Add((grid[rowIndex][columnIndex], rowIndex, columnIndex));
                }
            }

            cellList.Sort((firstCell, secondCell) => firstCell.cellValue.CompareTo(secondCell.cellValue));

            int[] teleportationPointers = new int[maxTeleportations + 1];

            var priorityQueue = new PriorityQueue<(int rowIndex, int columnIndex, int teleportationCount), int>();
            minimumDistances[0, 0, 0] = 0;
            priorityQueue.Enqueue((0, 0, 0), 0);

            while(priorityQueue.Count > 0)
            {
                var (currentRow, currentColumn, currentTeleportationCount) = priorityQueue.Dequeue();
                int currentDistance = minimumDistances[currentRow, currentColumn, currentTeleportationCount];

                if(currentDistance != minimumDistances[currentRow, currentColumn, currentTeleportationCount]) 
                {
                    continue;
                }

                if(currentRow + 1 < rowCount)
                {
                    int newDistance = currentDistance + grid[currentRow + 1][currentColumn];
                    
                    if(newDistance < minimumDistances[currentRow + 1, currentColumn, currentTeleportationCount])
                    {
                        minimumDistances[currentRow + 1, currentColumn, currentTeleportationCount] = newDistance;
                        priorityQueue.Enqueue((currentRow + 1, currentColumn, currentTeleportationCount), newDistance);
                    }
                }

                if (currentColumn + 1 < columnCount)
                {
                    int newDistance = currentDistance + grid[currentRow][currentColumn + 1];
                    
                    if(newDistance < minimumDistances[currentRow, currentColumn + 1, currentTeleportationCount])
                    {
                        minimumDistances[currentRow, currentColumn + 1, currentTeleportationCount] = newDistance;
                        priorityQueue.Enqueue((currentRow, currentColumn + 1, currentTeleportationCount), newDistance);
                    }
                }

                if (currentTeleportationCount < maxTeleportations)
                {
                    while (teleportationPointers[currentTeleportationCount] < cellList.Count && cellList[teleportationPointers[currentTeleportationCount]].cellValue <= grid[currentRow][currentColumn])
                    {
                        var (_, teleportRow, teleportColumn) = cellList[teleportationPointers[currentTeleportationCount]];
                        
                        if(currentDistance < minimumDistances[teleportRow, teleportColumn, currentTeleportationCount + 1])
                        {
                            minimumDistances[teleportRow, teleportColumn, currentTeleportationCount + 1] = currentDistance;
                            priorityQueue.Enqueue((teleportRow, teleportColumn, currentTeleportationCount + 1), currentDistance);
                        }
                        teleportationPointers[currentTeleportationCount]++;
                    }
                }
            }

            int minimumCost = Infinity;
            
            for(int teleportationCount = 0; teleportationCount <= maxTeleportations; teleportationCount++)
            {
                minimumCost = Math.Min(minimumCost, minimumDistances[rowCount - 1, columnCount - 1, teleportationCount]);
            }

            return minimumCost;
        }
    }
}