namespace DailyQuestion
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int maxArea = 0;
            
            while(left < right) 
            {
                int currentHeight = Math.Min(height[left], height[right]);

                int width = right - left;

                int currentArea = currentHeight * width;
                maxArea = Math.Max(maxArea, currentArea);
                
                if(height[left] < height[right])
                {
                    left++;
                }
                    
                else
                {
                    right--;
                }
                    
            }
            
            return maxArea;
        }
    }
}