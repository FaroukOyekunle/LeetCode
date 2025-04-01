namespace StudyPlan.Problem.LeetCode75.TwoPointers
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int leftArea = 0, rightArea = height.Length - 1;
            int maxArea = 0;

            while(leftArea < rightArea)
            {
                int currentHeight = Math.Min(height[leftArea], height[rightArea]);

                int width = rightArea - leftArea;

                int currentArea = currentHeight * width;

                maxArea = Math.Max(maxArea, currentArea);

                if(height[leftArea] < height[rightArea])
                {
                    leftArea++;
                }

                else
                {
                    rightArea--;
                }

            }

            return maxArea;
        }
    }
}