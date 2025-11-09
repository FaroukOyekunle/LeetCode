namespace DailyQuestion
{
    public class CountOperationsToObtainZero
    {
        public int CountOperationsToZero(int valueA, int valueB)
        {
            int operationCount = 0;

            while(valueA > 0 && valueB > 0)
            {
                if(valueA >= valueB)
                {
                    valueA -= valueB;
                }

                else
                {
                    valueB -= valueA;
                }
                operationCount++;
            }

            return operationCount;
        }
    }
}