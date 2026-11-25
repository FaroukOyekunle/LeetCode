using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class SmallestUniqueSubarray
    {
        public int SmallestUniqueSubarray(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;

            if (totalNumberOfElements == 1)
            {
                return 1;
            }

            int[] suffixArray = BuildSuffixArray(numbers);

            int[] longestCommonPrefixBySuffixRank = BuildLcpArray(numbers, suffixArray);

            int[] suffixRankByStartIndex = new int[totalNumberOfElements];

            for (int suffixRank = 0; suffixRank < totalNumberOfElements; suffixRank++)
            {
                int suffixStartIndex = suffixArray[suffixRank];

                suffixRankByStartIndex[suffixStartIndex] = suffixRank;
            }

            int minimumUniqueSubarrayLength = totalNumberOfElements;

            for (int subarrayStartIndex = 0; subarrayStartIndex < totalNumberOfElements; subarrayStartIndex++)
            {
                int currentSuffixRank = suffixRankByStartIndex[subarrayStartIndex];

                int maximumCommonPrefixLength = 0;

                if (currentSuffixRank > 0)
                {
                    maximumCommonPrefixLength = Math.Max(maximumCommonPrefixLength, longestCommonPrefixBySuffixRank[currentSuffixRank]);
                }

                if (currentSuffixRank < totalNumberOfElements - 1)
                {
                    maximumCommonPrefixLength = Math.Max(maximumCommonPrefixLength, longestCommonPrefixBySuffixRank[currentSuffixRank + 1]);
                }

                int shortestUniqueSubarrayLength = maximumCommonPrefixLength + 1;

                int remainingSuffixLength = totalNumberOfElements - subarrayStartIndex;

                if (shortestUniqueSubarrayLength > remainingSuffixLength)
                {
                    continue;
                }

                minimumUniqueSubarrayLength = Math.Min(minimumUniqueSubarrayLength, shortestUniqueSubarrayLength);
            }

            return minimumUniqueSubarrayLength;
        }

        private int[] BuildSuffixArray(int[] numbers)
        {
            int totalNumberOfElements = numbers.Length;

            int[] suffixArray = new int[totalNumberOfElements];
            int[] currentSuffixRanks = new int[totalNumberOfElements];
            int[] updatedSuffixRanks = new int[totalNumberOfElements];

            for (int suffixStartIndex = 0; suffixStartIndex < totalNumberOfElements; suffixStartIndex++)
            {
                suffixArray[suffixStartIndex] = suffixStartIndex;
                currentSuffixRanks[suffixStartIndex] = numbers[suffixStartIndex];
            }

            for (int comparisonLength = 1; comparisonLength < totalNumberOfElements; comparisonLength *= 2)
            {
                Array.Sort(suffixArray, (firstSuffixStartIndex, secondSuffixStartIndex) =>
                {
                        int firstSuffixCurrentRank = currentSuffixRanks[firstSuffixStartIndex];

                        int secondSuffixCurrentRank = currentSuffixRanks[secondSuffixStartIndex];

                        if (firstSuffixCurrentRank != secondSuffixCurrentRank)
                        {
                            return firstSuffixCurrentRank.CompareTo(secondSuffixCurrentRank);
                        }

                        int firstSuffixNextRank = firstSuffixStartIndex + comparisonLength < totalNumberOfElements ? currentSuffixRanks[firstSuffixStartIndex + comparisonLength] : -1;

                        int secondSuffixNextRank = secondSuffixStartIndex + comparisonLength < totalNumberOfElements ? currentSuffixRanks[secondSuffixStartIndex + comparisonLength] : -1;

                        return firstSuffixNextRank.CompareTo(secondSuffixNextRank);
                });

                updatedSuffixRanks[suffixArray[0]] = 0;

                for (int suffixRank = 1; suffixRank < totalNumberOfElements; suffixRank++)
                {
                    int previousSuffixStartIndex = suffixArray[suffixRank - 1];
                    int currentSuffixStartIndex = suffixArray[suffixRank];

                    int previousSuffixCurrentRank = currentSuffixRanks[previousSuffixStartIndex];

                    int currentSuffixCurrentRank = currentSuffixRanks[currentSuffixStartIndex];

                    int previousSuffixNextRank = previousSuffixStartIndex + comparisonLength < totalNumberOfElements ? currentSuffixRanks[previousSuffixStartIndex + comparisonLength] : -1;

                    int currentSuffixNextRank = currentSuffixStartIndex + comparisonLength < totalNumberOfElements ? currentSuffixRanks[currentSuffixStartIndex + comparisonLength] : -1;

                    bool currentSuffixDiffersFromPreviousSuffix = previousSuffixCurrentRank != currentSuffixCurrentRank || previousSuffixNextRank != currentSuffixNextRank;

                    updatedSuffixRanks[currentSuffixStartIndex] = updatedSuffixRanks[previousSuffixStartIndex] + (currentSuffixDiffersFromPreviousSuffix ? 1 : 0);
                }

                Array.Copy(updatedSuffixRanks, currentSuffixRanks, totalNumberOfElements);

                if (currentSuffixRanks[suffixArray[totalNumberOfElements - 1]] == totalNumberOfElements - 1)
                {
                    break;
                }
            }

            return suffixArray;
        }

        private int[] BuildLcpArray(int[] numbers, int[] suffixArray)
        {
            int totalNumberOfElements = numbers.Length;

            int[] suffixRankByStartIndex = new int[totalNumberOfElements];

            int[] longestCommonPrefixBySuffixRank = new int[totalNumberOfElements];

            for (int suffixRank = 0; suffixRank < totalNumberOfElements; suffixRank++)
            {
                int suffixStartIndex = suffixArray[suffixRank];

                suffixRankByStartIndex[suffixStartIndex] = suffixRank;
            }

            int currentCommonPrefixLength = 0;

            for (int currentSuffixStartIndex = 0; currentSuffixStartIndex < totalNumberOfElements; currentSuffixStartIndex++)
            {
                int currentSuffixRank = suffixRankByStartIndex[currentSuffixStartIndex];

                if (currentSuffixRank == 0)
                {
                    currentCommonPrefixLength = 0;
                    continue;
                }

                int previousSuffixStartIndex = suffixArray[currentSuffixRank - 1];

                while (currentSuffixStartIndex + currentCommonPrefixLength < totalNumberOfElements && previousSuffixStartIndex + currentCommonPrefixLength < totalNumberOfElements
                    && numbers[currentSuffixStartIndex + currentCommonPrefixLength] == numbers[previousSuffixStartIndex + currentCommonPrefixLength])
                {
                    currentCommonPrefixLength++;
                }

                longestCommonPrefixBySuffixRank[currentSuffixRank] = currentCommonPrefixLength;

                if (currentCommonPrefixLength > 0)
                {
                    currentCommonPrefixLength--;
                }
            }

            return longestCommonPrefixBySuffixRank;
        }
    }
}