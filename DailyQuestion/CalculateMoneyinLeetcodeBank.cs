namespace DailyQuestion
{
    public class CalculateMoneyinLeetcodeBank
    {
        public int TotalMoney(int n)
        {
            int total = 0;
            int fullWeeks = n / 7;
            int remainingDays = n % 7;

            for(int week = 0; week < fullWeeks; week++)
            {
                total += 28 + (7 * week);
            }

            for(int day = 0; day < remainingDays; day++)
            {
                total += (fullWeeks + 1) + day;
            }

            return total;
        }
    }
}