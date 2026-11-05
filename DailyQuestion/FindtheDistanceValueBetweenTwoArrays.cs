using System;

namespace DailyQuestion
{
    public class FindtheDistanceValueBetweenTwoArrays
    {
        public int FindTheDistanceValue(int[] firstArray, int[] secondArray, int maximumAllowedDistance)
        {
            Array.Sort(secondArray);

            int totalElementsWithoutNearbyMatches = 0;

            foreach (int currentFirstArrayValue in firstArray)
            {
                int searchStartIndex = 0;
                int searchEndIndex = secondArray.Length - 1;
                bool hasElementWithinAllowedDistance = false;

                while (searchStartIndex <= searchEndIndex)
                {
                    int middleIndex = searchStartIndex + (searchEndIndex - searchStartIndex) / 2;

                    if (secondArray[middleIndex] < currentFirstArrayValue - maximumAllowedDistance)
                    {
                        searchStartIndex = middleIndex + 1;
                    }
                    else if (secondArray[middleIndex] > currentFirstArrayValue + maximumAllowedDistance)
                    {
                        searchEndIndex = middleIndex - 1;
                    }
                    else
                    {
                        hasElementWithinAllowedDistance = true;
                        break;
                    }
                }

                if (!hasElementWithinAllowedDistance)
                {
                    totalElementsWithoutNearbyMatches++;
                }
            }

            return totalElementsWithoutNearbyMatches;
        }
    }
}