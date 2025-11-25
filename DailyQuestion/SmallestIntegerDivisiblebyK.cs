namespace DailyQuestion
{
    public class SmallestIntegerDivisiblebyK
    {
        public int SmallestRepunitLengthDivisibleBy(int divisor)
        {
            if(divisor % 2 == 0 || divisor % 5 == 0)
            {
                return -1;
            }

            int currentRemainder = 0;

            for(int repunitLength = 1; repunitLength <= divisor; repunitLength++)
            {
                currentRemainder = (currentRemainder * 10 + 1) % divisor;

                if(currentRemainder == 0)
                {
                    return repunitLength;
                }
            }

            return -1;
        }
    }
}