namespace DailyQuestion
{
    public class TheTwoSneakyNumbersofDigitville
    {
        public int[] GetSneakyNumbers(int[] nums)
        {
            var seen = new HashSet<int>();
            var result = new List<int>();

            foreach(var num in nums)
            {
                if(!seen.Add(num))
                {
                    result.Add(num);
                    if(result.Count == 2)
                    {
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}