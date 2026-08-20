namespace DailyQuestion
{
    public class DistributeElementsIntoTwoArrayI
    {
        public int[] ResultArray(int[] nums)
        {
            List<int> firstResultArray = new List<int> { nums[0] };
            List<int> secondResultArray = new List<int> { nums[1] };

            for (int currentIndex = 2; currentIndex < nums.Length; currentIndex++)
            {
                int currentNumber = nums[currentIndex];

                int lastNumberInFirstArray = firstResultArray[firstResultArray.Count - 1];

                int lastNumberInSecondArray = secondResultArray[secondResultArray.Count - 1];

                if (lastNumberInFirstArray > lastNumberInSecondArray)
                {
                    firstResultArray.Add(currentNumber);
                }
                else
                {
                    secondResultArray.Add(currentNumber);
                }
            }

            return firstResultArray
                .Concat(secondResultArray)
                .ToArray();
        }
    }
}