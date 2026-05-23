namespace DailyQuestion
{
    public class CheckifArrayIsSortedandRotated
    {
        public bool Check(int[] circularArray)
        {
            int totalDescendingTransitions = 0;

            int totalElements = circularArray.Length;

            for (int currentIndex = 0; currentIndex < totalElements; currentIndex++)
            {
                int nextCircularIndex = (currentIndex + 1) % totalElements;

                int currentValue = circularArray[currentIndex];

                int nextValue = circularArray[nextCircularIndex];

                bool isDescendingTransition = currentValue > nextValue;

                if (isDescendingTransition)
                {
                    totalDescendingTransitions++;
                }

                bool hasMoreThanOneDescendingTransition = totalDescendingTransitions > 1;

                if (hasMoreThanOneDescendingTransition)
                {
                    return false;
                }
            }

            return true;
        }
    }
}