namespace DailyQuestion
{
    public class PartitionArrayAccordingtoGivenPivot
    {
        public int[] PivotArray(int[] inputNumbers, int pivotValue)
        {
            List<int> numbersLessThanPivot = new();
            List<int> numbersEqualToPivot = new();
            List<int> numbersGreaterThanPivot = new();

            foreach (int currentNumber in inputNumbers)
            {
                if (currentNumber < pivotValue)
                {
                    numbersLessThanPivot.Add(currentNumber);
                }
                else if (currentNumber == pivotValue)
                {
                    numbersEqualToPivot.Add(currentNumber);
                }
                else
                {
                    numbersGreaterThanPivot.Add(currentNumber);
                }
            }

            int[] pivotedArray = new int[inputNumbers.Length];

            int nextInsertionIndex = 0;

            foreach (int numberLessThanPivot in numbersLessThanPivot)
            {
                pivotedArray[nextInsertionIndex++] = numberLessThanPivot;
            }

            foreach (int numberEqualToPivot in numbersEqualToPivot)
            {
                pivotedArray[nextInsertionIndex++] = numberEqualToPivot;
            }

            foreach (int numberGreaterThanPivot in numbersGreaterThanPivot)
            {
                pivotedArray[nextInsertionIndex++] = numberGreaterThanPivot;
            }

            return pivotedArray;
        }
    }
}