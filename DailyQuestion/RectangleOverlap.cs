namespace DailyQuestion
{
    public class RectangleOverlap
    {
        public bool IsRectangleOverlap(int[] firstRectangle, int[] secondRectangle)
        {
            bool rectanglesOverlapHorizontally = firstRectangle[0] < secondRectangle[2] && secondRectangle[0] < firstRectangle[2];

            bool rectanglesOverlapVertically = firstRectangle[1] < secondRectangle[3] && secondRectangle[1] < firstRectangle[3];

            return rectanglesOverlapHorizontally && rectanglesOverlapVertically;
        }
    }
}