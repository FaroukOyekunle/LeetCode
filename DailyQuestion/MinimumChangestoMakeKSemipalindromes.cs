using System;

namespace DailyQuestion
{
    public class CalculateDigitSumofaStrng
    {

        public int MinimumChanges(string inputString, int requiredPartitionCount)
        {
            int totalStringLength = inputString.Length;
            const int UNREACHABLE_STATE_COST = int.MaxValue / 2;

            int[,] substringTransformationCosts = new int[totalStringLength, totalStringLength + 1];

            for (int substringStartIndex = 0; substringStartIndex < totalStringLength; substringStartIndex++)
            {
                for (int substringEndExclusiveIndex = substringStartIndex + 2; substringEndExclusiveIndex <= totalStringLength; substringEndExclusiveIndex++)
                {
                    int currentSubstringLength = substringEndExclusiveIndex - substringStartIndex;
                    int minimumReplacementCount = UNREACHABLE_STATE_COST;

                    for (int candidateDivisor = 1; candidateDivisor < currentSubstringLength; candidateDivisor++)
                    {
                        if (currentSubstringLength % candidateDivisor != 0)
                        {
                            continue;
                        }

                        int replacementCountForCurrentDivisor = 0;
                        int charactersPerSequence = currentSubstringLength / candidateDivisor;

                        for (int sequenceOffset = 0; sequenceOffset < candidateDivisor; sequenceOffset++)
                        {
                            int leftCharacterIndex = substringStartIndex + sequenceOffset;

                            int rightCharacterIndex = leftCharacterIndex + (charactersPerSequence - 1) * candidateDivisor;

                            while (leftCharacterIndex < rightCharacterIndex)
                            {
                                if (inputString[leftCharacterIndex] != inputString[rightCharacterIndex])
                                {
                                    replacementCountForCurrentDivisor++;
                                }

                                leftCharacterIndex += candidateDivisor;
                                rightCharacterIndex -= candidateDivisor;
                            }
                        }

                        minimumReplacementCount = Math.Min(minimumReplacementCount, replacementCountForCurrentDivisor);
                    }

                    substringTransformationCosts[substringStartIndex, substringEndExclusiveIndex] = minimumReplacementCount;
                }
            }

            int[,] minimumChangesByPartitionAndPrefixLength = new int[requiredPartitionCount + 1, totalStringLength + 1];

            for (int completedPartitionCount = 0; completedPartitionCount <= requiredPartitionCount; completedPartitionCount++)
            {
                for (int prefixLength = 0; prefixLength <= totalStringLength; prefixLength++)
                {
                    minimumChangesByPartitionAndPrefixLength[completedPartitionCount, prefixLength] = UNREACHABLE_STATE_COST;
                }
            }

            minimumChangesByPartitionAndPrefixLength[0, 0] = 0;

            for (int completedPartitionCount = 1; completedPartitionCount <= requiredPartitionCount; completedPartitionCount++)
            {
                int minimumPrefixEndIndex = completedPartitionCount * 2;

                for (int currentPrefixEndIndex = minimumPrefixEndIndex; currentPrefixEndIndex <= totalStringLength; currentPrefixEndIndex++)
                {
                    for (int previousPartitionEndIndex = (completedPartitionCount - 1) * 2; previousPartitionEndIndex <= currentPrefixEndIndex - 2; previousPartitionEndIndex++)
                    {
                        int previousPartitionCost = minimumChangesByPartitionAndPrefixLength[completedPartitionCount - 1, previousPartitionEndIndex];

                        if (previousPartitionCost == UNREACHABLE_STATE_COST)
                        {
                            continue;
                        }

                        int currentPartitionTransformationCost = substringTransformationCosts[previousPartitionEndIndex, currentPrefixEndIndex];

                        int totalTransformationCost = previousPartitionCost + currentPartitionTransformationCost;

                        minimumChangesByPartitionAndPrefixLength[completedPartitionCount, currentPrefixEndIndex] = Math.Min(
                            minimumChangesByPartitionAndPrefixLength[completedPartitionCount, currentPrefixEndIndex], totalTransformationCost);
                    }
                }
            }

            return minimumChangesByPartitionAndPrefixLength[requiredPartitionCount, totalStringLength];
        }
    }
}