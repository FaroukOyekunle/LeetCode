namespace DailyQuestion
{
    public class BinaryPrefixDivisibleBy5
    {
        public IList<bool> PrefixesDivisibleBy5(int[] bits)
        {
            var results = new List<bool>(bits.Length);
            int currentRemainder = 0;

            foreach(var bitValue in bits)
            {
                currentRemainder = ((currentRemainder << 1) + bitValue) % 5;

                results.Add(currentRemainder == 0);
            }

            return results;
        }
    }
}