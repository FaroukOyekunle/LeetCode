namespace StudyPlan.LeetCode75
{
    public class  CanPlaceFlowers
    {
        int count = 0;
        int length = flowerbed.Length;

        for(int i = 0; i < length; i++) 
        {
            if(flowerbed[i] == 0) 
            {
                bool leftEmpty = (i == 0) || (flowerbed[i - 1] == 0);
                bool rightEmpty = (i == length - 1) || (flowerbed[i + 1] == 0);

                if (leftEmpty && rightEmpty) 
                {
                    flowerbed[i] = 1; 
                    count++;
                    
                    if (count >= n) 
                    {
                        return true;
                    }
                }
            }
        }

        return count >= n;
    }
}