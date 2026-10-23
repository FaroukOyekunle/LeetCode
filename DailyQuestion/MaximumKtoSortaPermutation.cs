namespace DailyQuestion
{
    public class MaximumKtoSortaPermutation
    {
        public int SortPermutation(int[] permutation)
        {
            int maximumAllowedBitwiseAndValue = int.MaxValue;
            bool containsMisplacedElements = false;

            for (int currentIndex = 0; currentIndex < permutation.Length; currentIndex++)
            {
                int currentElement = permutation[currentIndex];

                if (currentElement != currentIndex)
                {
                    maximumAllowedBitwiseAndValue &= currentElement;
                    containsMisplacedElements = true;
                }
            }

            return containsMisplacedElements ? maximumAllowedBitwiseAndValue : 0;
        }
    }
}