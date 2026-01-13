namespace DailyQuestion
{
    public class SeparateSquaresI
    {
        public double SeparateSquares(int[][] squareDetails)
        {
            double minimumYCoordinate = double.MaxValue;
            double maximumYCoordinate = double.MinValue;

            foreach(var square in squareDetails)
            {
                minimumYCoordinate = Math.Min(minimumYCoordinate, square[1]);
                maximumYCoordinate = Math.Max(maximumYCoordinate, square[1] + square[2]);
            }

            for(int iteration = 0; iteration < 80; iteration++)
            {
                double midYCoordinate = (minimumYCoordinate + maximumYCoordinate) / 2.0;
                double areaDifference = CalculateAreaDifference(squareDetails, midYCoordinate);

                if(areaDifference > 0)
                {
                    minimumYCoordinate = midYCoordinate;
                } 
                else
                {
                    maximumYCoordinate = midYCoordinate;  
                }
            }

            return minimumYCoordinate;
        }

        private double CalculateAreaDifference(int[][] squareDetails, double yCoordinate)
        {
            double totalAreaDifference = 0;

            foreach(var square in squareDetails)
            {
                double bottomYCoordinate = square[1];
                double topYCoordinate = square[1] + square[2];
                double squareWidth = square[2];

                if(yCoordinate <= bottomYCoordinate)
                {
                    totalAreaDifference += squareWidth * squareWidth;
                }

                else if(yCoordinate >= topYCoordinate)
                {
                    totalAreaDifference -= squareWidth * squareWidth;
                }
                
                else
                {
                    double areaAbove = (topYCoordinate - yCoordinate) * squareWidth;
                    double areaBelow = (yCoordinate - bottomYCoordinate) * squareWidth;
                    totalAreaDifference += areaAbove - areaBelow;
                }
            }

            return totalAreaDifference;
        }
    }
}