namespace DailyQuestion
{
    public class NumberofStepstoReduceaNumberinBinaryRepresentationtoOne
    {
        public int CalculateStepsToReduceBinaryNumberToOne(string binaryString)
        {
            int totalSteps = 0;
            int carryOver = 0;

            for (int currentIndex = binaryString.Length - 1; currentIndex > 0; currentIndex--)
            {
                int currentBitValue = (binaryString[currentIndex] - '0') + carryOver;

                if (currentBitValue == 1)
                {
                    totalSteps += 2;
                    carryOver = 1;
                }
                else
                {
                    totalSteps += 1;
                }
            }

            return totalSteps + carryOver;
        }
    }
}