namespace DailyQuestion
{
    public class TrionicArrayI
    {
        public bool IsTrionicArray(int[] inputArray)
        {
            int arrayLength = inputArray.Length;
            if (arrayLength < 3) 
            {
                return false;
            }

            int currentIndex = 0;

            while (currentIndex + 1 < arrayLength && inputArray[currentIndex] < inputArray[currentIndex + 1])
            {
                currentIndex++;
            }

            if (currentIndex == 0) 
            {
                return false;
            }

            int peakIndex = currentIndex;

            while (currentIndex + 1 < arrayLength && inputArray[currentIndex] > inputArray[currentIndex + 1])
            {
                currentIndex++;
            }

            if (currentIndex == peakIndex) 
            {
                return false;
            }

            int valleyIndex = currentIndex;

            while (currentIndex + 1 < arrayLength && inputArray[currentIndex] < inputArray[currentIndex + 1])
            {
                currentIndex++;
            }

            return currentIndex == arrayLength - 1 && valleyIndex < arrayLength - 1;
        }
    }
}