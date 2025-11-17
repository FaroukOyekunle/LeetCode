namespace DailyQuestion
{
    public class CheckIfAll1sAreatLeastLengthKPlaceAway
    {
        public bool AreOnesAtLeastKPlacesApart(int[] values, int minDistance)
        {
            int previousOneIndex = -1;

            for(int index = 0; index < values.Length; index++)
            {
                if(values[index] == 1)
                {
                    if(previousOneIndex != -1 && index - previousOneIndex - 1 < minDistance)
                    {
                        return false;
                    }

                    previousOneIndex = index;
                }
            }

            return true;
        }
    }
}