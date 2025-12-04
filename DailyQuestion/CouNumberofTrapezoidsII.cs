namespace DailyQuestion
{
    public class CouNumberofTrapezoidsII
    {
        public int CountTrapezoids(int[][] points)
        {
            int pointCount = points.Length;
            if(pointCount < 4)
            {
                return 0;
            }

            var slopeToLineCounts = new Dictionary<(int rise, int run), Dictionary<long, int>>();

            for(int i = 0; i < pointCount; i++)
            {
                for(int j = i + 1; j < pointCount; j++)
                {
                    int x1 = points[i][0], y1 = points[i][1];
                    int x2 = points[j][0], y2 = points[j][1];

                    int run = x2 - x1;
                    int rise = y2 - y1;

                    NormalizeSlope(ref rise, ref run);

                    var normalizedSlope = (rise, run);
                    long lineConstant = (long)rise * x1 - (long)run * y1;

                    if(!slopeToLineCounts.TryGetValue(normalizedSlope, out var lineConstantMap))
                    {
                        lineConstantMap = new Dictionary<long, int>();
                        slopeToLineCounts[normalizedSlope] = lineConstantMap;
                    }
                }
            }

            slopeToLineCounts.Clear();

            for(int i = 0; i < pointCount; i++)
            {
                for(int j = i + 1; j < pointCount; j++)
                {
                    int x1 = points[i][0], y1 = points[i][1];
                    int x2 = points[j][0], y2 = points[j][1];

                    int run = x2 - x1;
                    int rise = y2 - y1;

                    NormalizeSlope(ref rise, ref run);

                    var normalizedSlope = (rise, run);
                    long lineConstant = (long)rise * x1 - (long)run * y1;

                    if(!slopeToLineCounts.TryGetValue(normalizedSlope, out var lineConstantMap))
                    {
                        lineConstantMap = new Dictionary<long, int>();
                        slopeToLineCounts[normalizedSlope] = lineConstantMap;
                    }
                }
            }

            var slopeToPointSets = new Dictionary<(int rise, int run), Dictionary<long, HashSet<int>>>();

            for(int i = 0; i < pointCount; i++)
            {
                for(int j = i + 1; j < pointCount; j++)
                {
                    int x1 = points[i][0], y1 = points[i][1];
                    int x2 = points[j][0], y2 = points[j][1];

                    int run = x2 - x1;
                    int rise = y2 - y1;

                    NormalizeSlope(ref rise, ref run);

                    var normalizedSlope = (rise, run);
                    long lineConstant = (long)rise * x1 - (long)run * y1;

                    if(!slopeToPointSets.TryGetValue(normalizedSlope, out var lineMap))
                    {
                        lineMap = new Dictionary<long, HashSet<int>>();
                        slopeToPointSets[normalizedSlope] = lineMap;
                    }

                    if(!lineMap.TryGetValue(lineConstant, out var indexSet))
                    {
                        indexSet = new HashSet<int>();
                        lineMap[lineConstant] = indexSet;
                    }

                    indexSet.Add(i);
                    indexSet.Add(j);
                }
            }

            long totalTrapezoidCandidates = 0;

            foreach(var slopeEntry in slopeToPointSets)
            {
                var lineConstantToPoints = slopeEntry.Value;
                var pointCounts = new List<long>(lineConstantToPoints.Count);

                foreach(var pointSet in lineConstantToPoints.Values)
                {
                    pointCounts.Add(pointSet.Count);
                }

                if(pointCounts.Count < 2)
                {
                    continue;
                }

                long sumChoose2 = 0;
                long sumSquares = 0;

                foreach(var count in pointCounts)
                {
                    long combinations = count * (count - 1) / 2;
                    sumChoose2 += combinations;
                    sumSquares += combinations * combinations;
                }

                long trapezoidContribution = (sumChoose2 * sumChoose2 - sumSquares) / 2;
                totalTrapezoidCandidates += trapezoidContribution;
            }

            var midpointToPairs = new Dictionary<(int mx, int my), List<(int a, int b)>>();

            for(int i = 0; i < pointCount; i++)
            {
                for(int j = i + 1; j < pointCount; j++)
                {
                    int midpointX = points[i][0] + points[j][0];
                    int midpointY = points[i][1] + points[j][1];
                    var midpointKey = (midpointX, midpointY);

                    if (!midpointToPairs.TryGetValue(midpointKey, out var pairList))
                    {
                        pairList = new List<(int, int)>();
                        midpointToPairs[midpointKey] = pairList;
                    }

                    pairList.Add((i, j));
                }
            }

            long parallelogramCount = 0;

            foreach(var midpointEntry in midpointToPairs)
            {
                var pointPairs = midpointEntry.Value;
                int pairCount = pointPairs.Count;

                if(pairCount < 2)
                {
                    continue;
                }

                long totalPairCombinations = (long)pairCount * (pairCount - 1) / 2;

                var diagonalSlopeFrequency = new Dictionary<(int rise, int run), int>();

                foreach(var pair in pointPairs)
                {
                    int indexA = pair.a, indexB = pair.b;

                    int run = points[indexB][0] - points[indexA][0];
                    int rise = points[indexB][1] - points[indexA][1];

                    NormalizeSlope(ref rise, ref run);

                    var diagonalSlope = (rise, run);

                    if(!diagonalSlopeFrequency.ContainsKey(diagonalSlope))
                    {
                        diagonalSlopeFrequency[diagonalSlope] = 0;
                    }

                    diagonalSlopeFrequency[diagonalSlope]++;
                }

                long invalidParallelograms = 0;

                foreach(var freq in diagonalSlopeFrequency.Values)
                {
                    invalidParallelograms += (long)freq * (freq - 1) / 2;
                }

                parallelogramCount += (totalPairCombinations - invalidParallelograms);
            }

            long finalResult = totalTrapezoidCandidates - parallelogramCount;

            if(finalResult < 0) 
            {
                finalResult = 0;
            }

            if(finalResult > int.MaxValue) 
            {
                finalResult = int.MaxValue;
            }

            return (int)finalResult;
        }

        private static void NormalizeSlope(ref int rise, ref int run)
        {
            if(run == 0)
            {
                rise = 1;
                run = 0;
                return;
            }

            if(rise == 0)
            {
                rise = 0;
                run = 1;
                return;
            }

            int gcd = Gcd(Math.Abs(run), Math.Abs(rise));
            run /= gcd;
            rise /= gcd;

            if(run < 0)
            {
                run = -run;
                rise = -rise;
            }
        }

        private static int Gcd(int a, int b)
        {
            while(b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            
            return Math.Abs(a);
        }

    }
}