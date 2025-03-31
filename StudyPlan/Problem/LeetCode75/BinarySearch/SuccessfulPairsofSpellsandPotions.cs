namespace StudyPlan.Problem.LeetCode75.BinarySearch
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
                int left = 0, right = m - 1;

                while(left <= right) 
                {
                    int mid = left + (right - left) / 2;
                    if(potions[mid] >= required) 
                    {
                        right = mid - 1; 
                    } 
                    
                    else 
                    {
                        left = mid + 1;  
                    }
                }

                result[i] = m - left;
            }

            return result;
        }
    }
}