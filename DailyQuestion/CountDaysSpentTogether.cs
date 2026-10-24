namespace DailyQuestion
{
    public class CountDaysSpentTogether
    {
        public int CountDaysTogether(string aliceArrivalDate, string aliceDepartureDate, string bobArrivalDate, string bobDepartureDate)
        {
            int aliceArrivalDayOfYear = ConvertToDayOfYear(aliceArrivalDate);
            int aliceDepartureDayOfYear = ConvertToDayOfYear(aliceDepartureDate);
            int bobArrivalDayOfYear = ConvertToDayOfYear(bobArrivalDate);
            int bobDepartureDayOfYear = ConvertToDayOfYear(bobDepartureDate);

            int overlappingPeriodStartDay = Math.Max(aliceArrivalDayOfYear, bobArrivalDayOfYear);

            int overlappingPeriodEndDay = Math.Min(aliceDepartureDayOfYear, bobDepartureDayOfYear);

            return Math.Max(0, overlappingPeriodEndDay - overlappingPeriodStartDay + 1);
        }

        private int ConvertToDayOfYear(string dateString)
        {
            int[] daysInEachMonth =
            {
                31, 28, 31, 30, 31, 30,
                31, 31, 30, 31, 30, 31
            };

            int monthNumber = int.Parse(dateString.Substring(0, 2));
            int dayOfMonth = int.Parse(dateString.Substring(3, 2));

            for (int previousMonthIndex = 0; previousMonthIndex < monthNumber - 1; previousMonthIndex++)
            {
                dayOfMonth += daysInEachMonth[previousMonthIndex];
            }

            return dayOfMonth;
        }
    }
}