namespace DailyQuestion
{
    public class MinimumASCIIDeleteSumforTwoStrings
    {
        public int MinimumDeleteSum(string firstString, string secondString)
        {
            int firstStringLength = firstString.Length;
            int secondStringLength = secondString.Length;

            int[,] minimumDeleteSumDP = new int[firstStringLength + 1, secondStringLength + 1];

            for(int firstIndex = 1; firstIndex <= firstStringLength; firstIndex++)
            {
                minimumDeleteSumDP[firstIndex, 0] = minimumDeleteSumDP[firstIndex - 1, 0] + firstString[firstIndex - 1];
            }

            for(int secondIndex = 1; secondIndex <= secondStringLength; secondIndex++)
            {
                minimumDeleteSumDP[0, secondIndex] = minimumDeleteSumDP[0, secondIndex - 1] + secondString[secondIndex - 1];
            }

            for(int firstIndex = 1; firstIndex <= firstStringLength; firstIndex++)
            {
                for(int secondIndex = 1; secondIndex <= secondStringLength; secondIndex++)
                {
                    if(firstString[firstIndex - 1] == secondString[secondIndex - 1])
                    {
                        minimumDeleteSumDP[firstIndex, secondIndex] = minimumDeleteSumDP[firstIndex - 1, secondIndex - 1];
                    }

                    else
                    {
                        minimumDeleteSumDP[firstIndex, secondIndex] = Math.Min(
                            minimumDeleteSumDP[firstIndex - 1, secondIndex] + firstString[firstIndex - 1],
                            minimumDeleteSumDP[firstIndex, secondIndex - 1] + secondString[secondIndex - 1]
                        );
                    }
                }
            }

            return minimumDeleteSumDP[firstStringLength, secondStringLength];
        }
    }
}