namespace DailyQuestion
{
    public class CircleAndRectangleOverlapping
    {
        public bool CheckOverlap(int circleRadius, int circleCenterX, int circleCenterY, int rectangleLeftX, int rectangleBottomY, int rectangleRightX, int rectangleTopY)
        {
            int closestPointX = Math.Max(rectangleLeftX, Math.Min(circleCenterX, rectangleRightX));

            int closestPointY = Math.Max(rectangleBottomY, Math.Min(circleCenterY, rectangleTopY));

            int horizontalDistanceFromCircleCenter = circleCenterX - closestPointX;

            int verticalDistanceFromCircleCenter = circleCenterY - closestPointY;

            int squaredDistanceFromCircleCenterToClosestPoint =
                (horizontalDistanceFromCircleCenter * horizontalDistanceFromCircleCenter) + (verticalDistanceFromCircleCenter * verticalDistanceFromCircleCenter);

            int squaredCircleRadius = circleRadius * circleRadius;

            return squaredDistanceFromCircleCenterToClosestPoint <= squaredCircleRadius;
        }
    }
}