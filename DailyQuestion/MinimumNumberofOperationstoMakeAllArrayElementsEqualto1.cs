namespace DailyQuestion
{
    public class MinimumOperationsToMakeAllElementsOne
    {
        public int CalculateMinOperationsToMakeAllOnes(int[] numbers)
        {
            int length = numbers.Length;
            int countOnes = 0;

            foreach(int value in numbers)
            {
                if(value == 1)
                {
                    countOnes++;
                }
            }

            if(countOnes > 0)
            {
                return length - countOnes;
            }

            int shortestSubarrayWithGcdOne = int.MaxValue;

            for(int start = 0; start < length; start++)
            {
                int currentGcd = numbers[start];

                for(int end = start + 1; end < length; end++)
                {
                    currentGcd = ComputeGcd(currentGcd, numbers[end]);

                    if(currentGcd == 1)
                    {
                        shortestSubarrayWithGcdOne = Math.Min(shortestSubarrayWithGcdOne, end - start + 1);
                        break;
                    }
                }
            }

            if(shortestSubarrayWithGcdOne == int.MaxValue)
            {
                return -1;
            }

            return length + shortestSubarrayWithGcdOne - 2;
        }

        private int ComputeGcd(int x, int y)
        {
            while(y != 0)
            {
                int tmp = y;
                y = x % y;
                x = tmp;
            }
            
            return x;
        }
    }
}