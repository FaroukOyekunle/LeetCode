namespace DailyQuestion
{
    public class NumberofLaserBeaminaBank
    {
        public int NumberOfBeams(string[] bank)
        {
            int totalBeams = 0;
            int previousCount = 0;

            foreach(var row in bank)
            {
                int currentCount = row.Count(c => c == '1');

                if(currentCount > 0)
                {
                    totalBeams += previousCount * currentCount;
                    previousCount = currentCount;
                }
            }

            return totalBeams;
        }
    }
}