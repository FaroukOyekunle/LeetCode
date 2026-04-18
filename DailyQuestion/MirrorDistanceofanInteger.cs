namespace DailyQuestion
{
    public class MirrorDistanceofanInteger
    {
        public int CalculateMirrorDistance(int inputNumber)
        {
            int originalNumber = inputNumber;
            int reversedNumber = 0;

            while (inputNumber > 0)
            {
                int lastDigit = inputNumber % 10;

                reversedNumber = reversedNumber * 10 + lastDigit;

                inputNumber /= 10;
            }

            int mirrorDistance = Math.Abs(originalNumber - reversedNumber);

            return mirrorDistance;
        }
    }
}