namespace DailyQuestion
{
    public class NumberOfSubstringsWithOnlyOnes
    {
        public int CountSubstringsOfOnes(string binaryString)
        {
            const int Modulo = 1_000_000_007;
            long consecutiveOnes = 0;
            long totalSubstrings = 0;

            foreach(char ch in binaryString)
            {
                if (ch == '1')
                {
                    consecutiveOnes++;
                }
                
                else
                {
                    totalSubstrings = (totalSubstrings + consecutiveOnes * (consecutiveOnes + 1) / 2) % Modulo;
                    consecutiveOnes = 0;
                }
            }

            totalSubstrings = (totalSubstrings + consecutiveOnes * (consecutiveOnes + 1) / 2) % Modulo;

            return (int)totalSubstrings;
        }
    }
}