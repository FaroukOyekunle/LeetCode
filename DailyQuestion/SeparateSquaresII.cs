namespace DailyQuestion
{
    public class SeparateSquaresII
    {
        private class RectangleEvent
        {
            public long YCoordinate;
            public int StartXIndex, EndXIndex;
            public int EventType;
        }

        public double SeparateSquares(int[][] squareDetails)
        {
            var rectangleEvents = new List<RectangleEvent>();
            var xCoordinates = new List<long>();

            foreach (var square in squareDetails)
            {
                long startX = square[0];
                long startY = square[1];
                long sideLength = square[2];
                long endX = startX + sideLength;
                long endY = startY + sideLength;

                xCoordinates.Add(startX);
                xCoordinates.Add(endX);

                rectangleEvents.Add(new RectangleEvent { YCoordinate = startY, StartXIndex = 0, EndXIndex = 0, EventType = +1 });
                rectangleEvents.Add(new RectangleEvent { YCoordinate = endY, StartXIndex = 0, EndXIndex = 0, EventType = -1 });
            }

            xCoordinates.Sort();
            xCoordinates = xCoordinates.Distinct().ToList();

            int totalXCoordinates = xCoordinates.Count;
            var xCoordinateIndexMap = new Dictionary<long, int>();
            for (int index = 0; index < totalXCoordinates; index++)
            {
                xCoordinateIndexMap[xCoordinates[index]] = index;
            }

            int eventIndex = 0;
            foreach (var square in squareDetails)
            {
                long startX = square[0];
                long startY = square[1];
                long sideLength = square[2];
                long endX = startX + sideLength;
                long endY = startY + sideLength;

                rectangleEvents[eventIndex].StartXIndex = xCoordinateIndexMap[startX];
                rectangleEvents[eventIndex].EndXIndex = xCoordinateIndexMap[endX];
                eventIndex++;

                rectangleEvents[eventIndex].StartXIndex = xCoordinateIndexMap[startX];
                rectangleEvents[eventIndex].EndXIndex = xCoordinateIndexMap[endX];
                eventIndex++;
            }

            rectangleEvents.Sort((firstEvent, secondEvent) => firstEvent.YCoordinate.CompareTo(secondEvent.YCoordinate));

            var segmentTree = new SegmentTree(xCoordinates);
            double totalCoveredArea = 0;

            for (int eventIndex = 0; eventIndex + 1 < rectangleEvents.Count; eventIndex++)
            {
                segmentTree.Update(rectangleEvents[eventIndex].StartXIndex, rectangleEvents[eventIndex].EndXIndex - 1, rectangleEvents[eventIndex].EventType);
                long deltaY = rectangleEvents[eventIndex + 1].YCoordinate - rectangleEvents[eventIndex].YCoordinate;

                if (deltaY > 0)
                {
                    totalCoveredArea += segmentTree.TotalCoveredLength * deltaY;
                }
            }

            double halfCoveredArea = totalCoveredArea / 2.0;
            double accumulatedArea = 0;
            segmentTree.Clear();

            for (int eventIndex = 0; eventIndex + 1 < rectangleEvents.Count; eventIndex++)
            {
                segmentTree.Update(rectangleEvents[eventIndex].StartXIndex, rectangleEvents[eventIndex].EndXIndex - 1, rectangleEvents[eventIndex].EventType);
                long deltaY = rectangleEvents[eventIndex + 1].YCoordinate - rectangleEvents[eventIndex].YCoordinate;
                
                if (deltaY <= 0)
                {
                    continue;
                }

                double currentArea = segmentTree.TotalCoveredLength * deltaY;
                if (accumulatedArea + currentArea >= halfCoveredArea)
                {
                    double remainingArea = halfCoveredArea - accumulatedArea;
                    return rectangleEvents[eventIndex].YCoordinate + remainingArea / segmentTree.TotalCoveredLength;
                }
                accumulatedArea += currentArea;
            }

            return rectangleEvents[^1].YCoordinate;
        }

        private class SegmentTree
        {
            private readonly long[] xCoordinates;
            private readonly int[] coverage;
            private readonly long[] coveredLength;

            public SegmentTree(List<long> xCoordinates)
            {
                this.xCoordinates = xCoordinates.ToArray();
                int treeSize = xCoordinates.Count * 4;
                coverage = new int[treeSize];
                coveredLength = new long[treeSize];
            }

            public double TotalCoveredLength => coveredLength[1];

            public void Clear()
            {
                Array.Clear(coverage, 0, coverage.Length);
                Array.Clear(coveredLength, 0, coveredLength.Length);
            }

            public void Update(int start, int end, int value, int node = 1, int nodeStart = 0, int nodeEnd = -1)
            {
                if (nodeEnd == -1)
                {
                    nodeEnd = xCoordinates.Length - 2;
                }
                if (start > nodeEnd || end < nodeStart)
                {
                    return;
                }

                if (start <= nodeStart && nodeEnd <= end)
                {
                    coverage[node] += value;
                }
                else
                {
                    int mid = (nodeStart + nodeEnd) / 2;
                    Update(start, end, value, node * 2, nodeStart, mid);
                    Update(start, end, value, node * 2 + 1, mid + 1, nodeEnd);
                }

                if (coverage[node] > 0)
                {
                    coveredLength[node] = xCoordinates[nodeEnd + 1] - xCoordinates[nodeStart];
                }
                else if (nodeStart == nodeEnd)
                {
                    coveredLength[node] = 0;
                }
                else
                {
                    coveredLength[node] = coveredLength[node * 2] + coveredLength[node * 2 + 1];
                }
            }
        }
    }
}