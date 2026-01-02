namespace DailyQuestion
{
    public class NRepeatedElementinSize2NArray
    {
        public int RepeatedNTimes(int[] numbers)
        {
            var uniqueNumbers = new HashSet<int>();

            foreach (var number in numbers)
            {
                if (!uniqueNumbers.Add(number))
                {
                    return number;
                }
            }

            return -1;
        }
    }
}