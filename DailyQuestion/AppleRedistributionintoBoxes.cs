namespace DailyQuestion
{
    public class AppleRedistributionintoBoxes
    {
        public int MinimumBoxes(int[] applesPerBox, int[] boxCapacities)
        {
            int totalApples = 0;
            foreach(var applesInBox in applesPerBox)
            {
                totalApples += applesInBox;
            }

            Array.Sort(boxCapacities);
            Array.Reverse(boxCapacities);

            int totalBoxesUsed = 0;
            int accumulatedCapacity = 0;

            foreach(var currentBoxCapacity in boxCapacities)
            {
                accumulatedCapacity += currentBoxCapacity;
                totalBoxesUsed++;

                if(accumulatedCapacity >= totalApples)
                {
                    return totalBoxesUsed;
                }
            }

            return totalBoxesUsed;
        }
    }
}