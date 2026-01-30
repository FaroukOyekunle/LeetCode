namespace DailyQuestion
{
    public class MinimumCosttoConvertStringII
    {
        public long CalculateMinimumCostToConvertString(string sourceString, string targetString, string[] originalStrings, string[] changedStrings, int[] conversionCosts)
        {
            const long Infinity = long.MaxValue / 4;
            int stringLength = sourceString.Length;

            var uniqueStrings = new HashSet<string>();

            foreach (var originalString in originalStrings) 
            {
                uniqueStrings.Add(originalString);
            }
            foreach (var changedString in changedStrings) 
            {
                uniqueStrings.Add(changedString);
            }

            var uniqueStringList = uniqueStrings.ToList();
            int uniqueStringCount = uniqueStringList.Count;

            var stringToIndexMap = new Dictionary<string, int>();

            for (int index = 0; index < uniqueStringCount; index++) 
            {
                stringToIndexMap[uniqueStringList[index]] = index;
            }

            long[,] minimumConversionCosts = new long[uniqueStringCount, uniqueStringCount];

            for (int sourceIndex = 0; sourceIndex < uniqueStringCount; sourceIndex++)
            {
                for (int targetIndex = 0; targetIndex < uniqueStringCount; targetIndex++)
                {
                    minimumConversionCosts[sourceIndex, targetIndex] = sourceIndex == targetIndex ? 0 : Infinity;
                }
            }

            for (int conversionIndex = 0; conversionIndex < originalStrings.Length; conversionIndex++) 
            {
                int sourceIndex = stringToIndexMap[originalStrings[conversionIndex]];
                int targetIndex = stringToIndexMap[changedStrings[conversionIndex]];

                minimumConversionCosts[sourceIndex, targetIndex] = Math.Min(minimumConversionCosts[sourceIndex, targetIndex], conversionCosts[conversionIndex]);
            }

            for (int intermediateIndex = 0; intermediateIndex < uniqueStringCount; intermediateIndex++)
            {
                for (int sourceIndex = 0; sourceIndex < uniqueStringCount; sourceIndex++)
                {
                    for (int targetIndex = 0; targetIndex < uniqueStringCount; targetIndex++)
                    {
                        if (minimumConversionCosts[sourceIndex, intermediateIndex] + minimumConversionCosts[intermediateIndex, targetIndex] < minimumConversionCosts[sourceIndex, targetIndex])
                        {
                            minimumConversionCosts[sourceIndex, targetIndex] = minimumConversionCosts[sourceIndex, intermediateIndex] + minimumConversionCosts[intermediateIndex, targetIndex];
                        }
                    }
                }
            }

            var conversionsByLength = new Dictionary<int, List<(int sourceIndex, int targetIndex, long conversionCost)>>();

            for (int sourceIndex = 0; sourceIndex < uniqueStringCount; sourceIndex++) 
            {
                for (int targetIndex = 0; targetIndex < uniqueStringCount; targetIndex++) 
                {
                    if (minimumConversionCosts[sourceIndex, targetIndex] >= Infinity) 
                    {
                        continue;
                    }

                    int stringLength = uniqueStringList[sourceIndex].Length;

                    if (uniqueStringList[targetIndex].Length != stringLength) 
                    {
                        continue;
                    }

                    if (!conversionsByLength.ContainsKey(stringLength))
                    {
                        conversionsByLength[stringLength] = new List<(int, int, long)>();
                    }

                    conversionsByLength[stringLength].Add((sourceIndex, targetIndex, minimumConversionCosts[sourceIndex, targetIndex]));
                }
            }

            long[] minimumCosts = new long[stringLength + 1];
            Array.Fill(minimumCosts, Infinity);
            
            minimumCosts[stringLength] = 0;

            for (int currentIndex = stringLength - 1; currentIndex >= 0; currentIndex--) 
            {
                if (sourceString[currentIndex] == targetString[currentIndex])
                {
                    minimumCosts[currentIndex] = minimumCosts[currentIndex + 1];
                }

                foreach (var conversionGroup in conversionsByLength) 
                {
                    int substringLength = conversionGroup.Key;

                    if (currentIndex + substringLength > stringLength) 
                    {
                        continue;
                    }

                    var sourceSubstring = sourceString.AsSpan(currentIndex, substringLength);
                    var targetSubstring = targetString.AsSpan(currentIndex, substringLength);

                    foreach (var (sourceIndex, targetIndex, conversionCost) in conversionGroup.Value) 
                    {
                        if (sourceSubstring.SequenceEqual(uniqueStringList[sourceIndex]) && targetSubstring.SequenceEqual(uniqueStringList[targetIndex])) 
                        {
                            minimumCosts[currentIndex] = Math.Min(minimumCosts[currentIndex], conversionCost + minimumCosts[currentIndex + substringLength]);
                        }
                    }
                }
            }

            return minimumCosts[0] >= Infinity ? -1 : minimumCosts[0];
        }
    }
}