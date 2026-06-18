namespace DailyQuestion
{
    public class AngleBetweenHandsofaClock
    {
        public double AngleClock(int hourValue, int minuteValue)
        {
            double hourHandAngleInDegrees = (hourValue % 12) * 30 + (minuteValue * 0.5);

            double minuteHandAngleInDegrees = minuteValue * 6;

            double absoluteAngleDifference = Math.Abs(hourHandAngleInDegrees - minuteHandAngleInDegrees);

            double smallerClockAngle = Math.Min(absoluteAngleDifference, 360 - absoluteAngleDifference);

            return smallerClockAngle;
        }
    }
}