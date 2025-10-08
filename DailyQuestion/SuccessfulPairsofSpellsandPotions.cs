namespace DailyQuestion
{
    public class SuccessfulPairsofSpellsandPotions
    {
       public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
    
            Array.Sort(potions);  
            int m = potions.Length;
            int n = spells.Length;
            int[] result = new int[n];

            for(int i = 0; i < n; i++) 
            {
                long required = (success + spells[i] - 1L) / spells[i]; 
                int leftPair = 0, rightPair = m - 1;

                while(leftPair <= rightPair) 
                {
                    int mid = leftPair + (rightPair - leftPair) / 2;
                    if(potions[mid] >= required) 
                    {
                        rightPair = mid - 1; 
                    } 
                    
                    else 
                    {
                        leftPair = mid + 1;  
                    }
                }

                result[i] = m - leftPair;
            }

            return result;
        } 
    }
}