namespace DailyQuestion
{
    public class StoneGameIX
    {
        public bool StoneGameIX(int[] stones)
        {
            int[] remainderFrequencies = new int[3];

            foreach (int stoneValue in stones)
            {
                int remainderAfterDivisionByThree = stoneValue % 3;
                remainderFrequencies[remainderAfterDivisionByThree]++;
            }

            int countOfRemainderZeroStones = remainderFrequencies[0];
            int countOfRemainderOneStones = remainderFrequencies[1];
            int countOfRemainderTwoStones = remainderFrequencies[2];

            if (countOfRemainderZeroStones % 2 == 0)
            {
                return countOfRemainderOneStones > 0 && countOfRemainderTwoStones > 0;
            }

            return Math.Abs(countOfRemainderOneStones - countOfRemainderTwoStones) > 2;
        }
    }
}