namespace DailyQuestion
{
    public class CountSquareSumTriples
    {
        public int CountTriples(int n)
        {
            int tripleCount = 0;

            for(int sideA = 1; sideA <= n; sideA++)
            {
                for(int sideB = 1; sideB <= n; sideB++)
                {
                    int sumOfSquares = sideA * sideA + sideB * sideB;
                    int hypotenuse = (int)Math.Sqrt(sumOfSquares);

                    if(hypotenuse <= n && hypotenuse * hypotenuse == sumOfSquares)
                    {
                        tripleCount++;
                    }
                }
            }

            return tripleCount;

        }
    }
}