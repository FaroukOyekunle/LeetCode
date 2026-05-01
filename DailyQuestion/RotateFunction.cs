namespace DailyQuestion
{
    public class RotateFunction
    {
        public int ComputeMaximumRotationFunctionValue(int[] numbers)
        {
            int arrayLength = numbers.Length;

            long totalSumOfElements = 0;
            long currentRotationFunctionValue = 0;

            for (int index = 0; index < arrayLength; index++)
            {
                totalSumOfElements += numbers[index];
                currentRotationFunctionValue += (long)index * numbers[index];
            }

            long maximumRotationFunctionValue = currentRotationFunctionValue;

            for (int rotationIndex = 1; rotationIndex < arrayLength; rotationIndex++)
            {
                int elementMovingToFront = numbers[arrayLength - rotationIndex];

                currentRotationFunctionValue = currentRotationFunctionValue  + totalSumOfElements - (long)arrayLength * elementMovingToFront;

                maximumRotationFunctionValue = Math.Max(maximumRotationFunctionValue, currentRotationFunctionValue);
            }

            return (int)maximumRotationFunctionValue;
        }
    }
}