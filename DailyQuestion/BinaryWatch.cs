namespace DailyQuestion
{
    public class BinaryWatch
    {
        public IList<string> GenerateBinaryWatchTimes(int numberOfLedsTurnedOn)
        {
            var possibleTimes = new List<string>();

            for (int currentHour = 0; currentHour < 12; currentHour++)
            {
                for (int currentMinute = 0; currentMinute < 60; currentMinute++)
                {
                    int totalLedCount = CountSetBits(currentHour) + CountSetBits(currentMinute);

                    if (totalLedCount == numberOfLedsTurnedOn)
                    {
                        possibleTimes.Add($"{currentHour}:{currentMinute:D2}");
                    }
                }
            }

            return possibleTimes;
        }

        private int CountSetBits(int inputNumber)
        {
            int setBitCount = 0;

            while (inputNumber > 0)
            {
                setBitCount += inputNumber & 1; 
                inputNumber >>= 1;        
            }

            return setBitCount;
        }
    }
}