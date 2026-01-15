namespace DailyQuestion
{
    public class MaximizeAreaofSquareHoleinGrid
    {
        public int MaximizeSquareHoleArea(int gridRows, int gridColumns, int[] horizontalBars, int[] verticalBars)
        {
            int maximumHorizontalGap = CalculateMaximumConsecutiveGap(horizontalBars);
            int maximumVerticalGap = CalculateMaximumConsecutiveGap(verticalBars);

            int squareSideLength = Math.Min(maximumHorizontalGap, maximumVerticalGap);
            return squareSideLength * squareSideLength;
        }

        private int CalculateMaximumConsecutiveGap(int[] barPositions)
        {
            Array.Sort(barPositions);

            int maximumGap = 1;
            int currentGap = 1;

            for(int index = 1; index < barPositions.Length; index++)
            {
                if(barPositions[index] == barPositions[index - 1] + 1)
                {
                    currentGap++;
                }
                else
                {
                    currentGap = 1;
                }

                maximumGap = Math.Max(maximumGap, currentGap);
            }

            return maximumGap + 1;
        }
    }
}