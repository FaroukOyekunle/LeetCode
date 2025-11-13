namespace DailyQuestion
{
    public class MaximumNumberOfOperationsToMoveOnesToEnd
    {
        public int ComputeMaxOperationsToMoveOnes(string binaryString)
        {
            long totalOperations = 0;
            int runningOneCount = 0;
            int length = binaryString.Length;

            for(int index = 0; index < length; index++)
            {
                if(binaryString[index] == '1')
                {
                    runningOneCount++;
                }

                else
                {
                    if(index == length - 1 || binaryString[index + 1] == '1')
                    {
                        totalOperations += runningOneCount;
                    }
                }
            }

            return (int)totalOperations;
        }
    }
}