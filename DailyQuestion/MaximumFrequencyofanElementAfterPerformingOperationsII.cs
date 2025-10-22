namespace DailyQuestion
{
    public class MaximumFrequencyofanElementAfterPerformingOperationsII
    {
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            int numbersLength = nums.Length;
            if(numbersLength == 0)
            {
                return 0;
            }

            var valueFrequencyInDictionary = new Dictionary<long, int>();
            foreach(var x in nums)
            {
                long lossGrades = x;
                if(!valueFrequencyInDictionary.ContainsKey(lossGrades))
                {
                    valueFrequencyInDictionary[lossGrades] = 0;
                }
                
                valueFrequencyInDictionary[lossGrades]++;
            }

            var eventsOccurence = new Dictionary<long, long>();

            foreach(var x in nums)
            {
                long start = (long)x - k;
                long endPlusOne = (long)x + k + 1L;

                if(!eventsOccurence.ContainsKey(start))
                {
                    eventsOccurence[start] = 0;
                }
                
                eventsOccurence[start] += 1;

                if(!eventsOccurence.ContainsKey(endPlusOne))
                {
                    eventsOccurence[endPlusOne] = 0;
                }
                
                eventsOccurence[endPlusOne] -= 1;
            }

            var positions = new List<long>();

            positions.AddRange(eventsOccurence.Keys);
            positions.AddRange(valueFrequencyInDictionary.Keys);
            positions = positions.Distinct().ToList();
            positions.Sort();

            long currentValueCoverage = 0;
            int best = 0;
            int maxCoverageAnyPoint = 0;

            foreach(var eventPosition in positions)
            {
                if(eventsOccurence.TryGetValue(eventPosition, out long delta))
                {
                    currentValueCoverage += delta;
                }

                if(currentValueCoverage > maxCoverageAnyPoint)
                {
                    maxCoverageAnyPoint = (int)currentValueCoverage;
                }

                int equals = 0;
                if(valueFrequencyInDictionary.TryGetValue(eventPosition, out int e))
                {
                    equals = e;
                }

                long convertible = currentValueCoverage - equals;
                if(convertible < 0)
                {
                    convertible = 0;
                }

                int addable = (int)Math.Min((long)numOperations, convertible);
                int candidate = equals + addable;

                if(candidate > best)
                {
                    best = candidate;
                }
            }

            best = Math.Max(best, Math.Min(numOperations, maxCoverageAnyPoint));

            return best;
        }
    }
}