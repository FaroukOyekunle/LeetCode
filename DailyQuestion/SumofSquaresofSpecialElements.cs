namespace DailyQuestion
{
    public class SumofSquaresofSpecialElements
    {
        public int SumOfSquares(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;
            int sumOfSpecialElementSquares = 0;

            for (int oneBasedElementPosition = 1; oneBasedElementPosition <= totalNumberOfElements; oneBasedElementPosition++)
            {
                if (totalNumberOfElements % oneBasedElementPosition == 0)
                {
                    int currentSpecialElement = numbers[oneBasedElementPosition - 1];

                    sumOfSpecialElementSquares += currentSpecialElement * currentSpecialElement;
                }
            }

            return sumOfSpecialElementSquares;
        }
    }
}