namespace DailyQuestion
{
    public class FinalValueofVariableAfterPerformingOperations
    {
        public int FinalValueAfterOperations(string[] operations)
        {
            int X = 0;

            foreach(var valueOperations in operations)
            {
                if(valueOperations.Contains("++"))
                {
                    X++;
                }

                else
                {
                    X--;
                }

            }

            return X;
        }
    }
}