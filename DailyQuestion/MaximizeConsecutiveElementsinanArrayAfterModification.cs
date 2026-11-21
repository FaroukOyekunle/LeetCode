using System;

namespace DailyQuestion
{
    public class MaximizeConsecutiveElementsinanArrayAfterModification
    {

        public int MaxSelectedElements(int[] numbers)
        {
            Array.Sort(numbers);

            int maximumElementValue = numbers[numbers.Length - 1];

            int[] maximumSelectedCountByValue = new int[maximumElementValue + 2];

            int maximumSelectedElements = 0;

            foreach (int currentNumber in numbers)
            {
                maximumSelectedCountByValue[currentNumber + 1] = Math.Max(maximumSelectedCountByValue[currentNumber + 1], maximumSelectedCountByValue[currentNumber] + 1);

                maximumSelectedCountByValue[currentNumber] = Math.Max(maximumSelectedCountByValue[currentNumber], maximumSelectedCountByValue[currentNumber - 1] + 1);

                maximumSelectedElements = Math.Max(maximumSelectedElements, Math.Max(maximumSelectedCountByValue[currentNumber], maximumSelectedCountByValue[currentNumber + 1]));
            }

            return maximumSelectedElements;
        }
    }
}