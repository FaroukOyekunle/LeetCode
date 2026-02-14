namespace DailyQuestion
{
    public class ChampagneTower
    {
        public double CalculateChampagneInGlass(int pouredAmount, int targetRow, int targetGlass)
        {
            double[,] champagneTower = new double[101, 101];

            champagneTower[0, 0] = pouredAmount;

            for (int currentRow = 0; currentRow < targetRow; currentRow++)
            {
                for (int currentGlass = 0; currentGlass <= currentRow; currentGlass++)
                {
                    if (champagneTower[currentRow, currentGlass] > 1.0)
                    {
                        double overflowAmount = (champagneTower[currentRow, currentGlass] - 1.0) / 2.0;

                        champagneTower[currentRow + 1, currentGlass] += overflowAmount;
                        champagneTower[currentRow + 1, currentGlass + 1] += overflowAmount;

                        champagneTower[currentRow, currentGlass] = 1.0;
                    }
                }
            }

            return Math.Min(1.0, champagneTower[targetRow, targetGlass]);
        }
    }
}