namespace DailyQuestion
{
    public class MinimumOperationstoMakeaUniValueGrid
    {
        public int MinOperations(int[][] gridValues, int stepSize)
        {
            List<int> flattenedValues = new List<int>();

            foreach (var rowValues in gridValues)
            {
                foreach (var cellValue in rowValues)
                {
                    flattenedValues.Add(cellValue);
                }
            }

            int expectedRemainder = flattenedValues[0] % stepSize;

            foreach (var currentValue in flattenedValues)
            {
                int currentRemainder = currentValue % stepSize;

                if (currentRemainder != expectedRemainder)
                {
                    return -1;
                }
            }

            flattenedValues.Sort();

            int medianIndex = flattenedValues.Count / 2;
            int targetValue = flattenedValues[medianIndex];

            int totalOperationsRequired = 0;

            foreach (var currentValue in flattenedValues)
            {
                int difference = Math.Abs(currentValue - targetValue);

                int operationsNeededForCell = difference / stepSize;

                totalOperationsRequired += operationsNeededForCell;
            }

            return totalOperationsRequired;
        }
    }
}