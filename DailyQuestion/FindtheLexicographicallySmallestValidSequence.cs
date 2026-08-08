namespace DailyQuestion
{
    public class FindtheLexicographicallySmallestValidSequence
    {
        public int[] ValidSequence(string sourceWord, string targetWord)
        {
            int sourceWordLength = sourceWord.Length;
            int targetWordLength = targetWord.Length;

            List<int>[] characterPositionsByLetter = new List<int>[26];

            for (int characterIndex = 0; characterIndex < 26; characterIndex++)
            {
                characterPositionsByLetter[characterIndex] = new List<int>();
            }

            for (int sourceIndex = 0; sourceIndex < sourceWordLength; sourceIndex++)
            {
                int sourceCharacterIndex = sourceWord[sourceIndex] - 'a';

                characterPositionsByLetter[sourceCharacterIndex].Add(sourceIndex);
            }

            int[] latestExactMatchPosition = new int[targetWordLength + 1];

            Array.Fill(latestExactMatchPosition, -1);

            latestExactMatchPosition[targetWordLength] = sourceWordLength;

            int sourceSearchIndex = sourceWordLength - 1;

            for (int targetIndex = targetWordLength - 1; targetIndex >= 0; targetIndex--)
            {
                while (sourceSearchIndex >= 0 && sourceWord[sourceSearchIndex] != targetWord[targetIndex])
                {
                    sourceSearchIndex--;
                }

                if (sourceSearchIndex < 0)
                {
                    break;
                }

                latestExactMatchPosition[targetIndex] = sourceSearchIndex;

                sourceSearchIndex--;
            }

            int[] consecutiveCharacterRunStart = new int[sourceWordLength];

            for (int sourceIndex = 0; sourceIndex < sourceWordLength; sourceIndex++)
            {
                if (sourceIndex > 0 && sourceWord[sourceIndex] == sourceWord[sourceIndex - 1])
                {
                    consecutiveCharacterRunStart[sourceIndex] = consecutiveCharacterRunStart[sourceIndex - 1];
                }
                else
                {
                    consecutiveCharacterRunStart[sourceIndex] = sourceIndex;
                }
            }

            int[] latestOneMismatchMatchPosition = new int[targetWordLength + 1];

            Array.Fill(latestOneMismatchMatchPosition, -1);

            latestOneMismatchMatchPosition[targetWordLength] = sourceWordLength;

            latestOneMismatchMatchPosition[targetWordLength - 1] = sourceWordLength - 1;

            for (int targetIndex = targetWordLength - 2; targetIndex >= 0; targetIndex--)
            {
                int latestValidSourcePosition = -1;

                int exactMatchSearchBoundary = latestOneMismatchMatchPosition[targetIndex + 1] - 1;

                if (exactMatchSearchBoundary >= 0)
                {
                    int targetCharacterIndex = targetWord[targetIndex] - 'a';

                    int latestMatchingSourcePosition = FindLastOccurrence(characterPositionsByLetter[targetCharacterIndex], exactMatchSearchBoundary);

                    latestValidSourcePosition = Math.Max(latestValidSourcePosition, latestMatchingSourcePosition);
                }

                int mismatchSearchBoundary = latestExactMatchPosition[targetIndex + 1] - 1;

                if (mismatchSearchBoundary >= 0)
                {
                    int latestMismatchingSourcePosition;

                    if (sourceWord[mismatchSearchBoundary] != targetWord[targetIndex])
                    {
                        latestMismatchingSourcePosition = mismatchSearchBoundary;
                    }
                    else
                    {
                        latestMismatchingSourcePosition = consecutiveCharacterRunStart[mismatchSearchBoundary] - 1;
                    }

                    latestValidSourcePosition = Math.Max(latestValidSourcePosition, latestMismatchingSourcePosition);
                }

                latestOneMismatchMatchPosition[targetIndex] = latestValidSourcePosition;
            }

            int[] selectedSourceIndices = new int[targetWordLength];

            int previousSelectedSourceIndex = -1;

            bool mismatchHasAlreadyBeenUsed = false;

            for (int targetIndex = 0; targetIndex < targetWordLength; targetIndex++)
            {
                bool targetCharacterWasMatched = false;

                for (int candidateSourceIndex = previousSelectedSourceIndex + 1; candidateSourceIndex < sourceWordLength; candidateSourceIndex++)
                {
                    bool candidateCharactersMatch = sourceWord[candidateSourceIndex] == targetWord[targetIndex];

                    int remainingTargetStartIndex = targetIndex + 1;

                    if (mismatchHasAlreadyBeenUsed)
                    {
                        if (candidateCharactersMatch && latestExactMatchPosition[remainingTargetStartIndex] > candidateSourceIndex)
                        {
                            selectedSourceIndices[targetIndex] = candidateSourceIndex;

                            previousSelectedSourceIndex = candidateSourceIndex;

                            targetCharacterWasMatched = true;

                            break;
                        }
                    }
                    else
                    {
                        if (candidateCharactersMatch)
                        {
                            if (latestOneMismatchMatchPosition[remainingTargetStartIndex] > candidateSourceIndex)
                            {
                                selectedSourceIndices[targetIndex] = candidateSourceIndex;

                                previousSelectedSourceIndex = candidateSourceIndex;

                                targetCharacterWasMatched = true;

                                break;
                            }
                        }
                        else
                        {
                            if (latestExactMatchPosition[remainingTargetStartIndex] > candidateSourceIndex)
                            {
                                selectedSourceIndices[targetIndex] = candidateSourceIndex;

                                previousSelectedSourceIndex = candidateSourceIndex;

                                mismatchHasAlreadyBeenUsed = true;

                                targetCharacterWasMatched = true;

                                break;
                            }
                        }
                    }
                }

                if (!targetCharacterWasMatched)
                {
                    return Array.Empty<int>();
                }
            }

            return selectedSourceIndices;
        }

        private int FindLastOccurrence(List<int> sortedCharacterPositions, int maximumAllowedSourceIndex)
        {
            if (maximumAllowedSourceIndex < 0 || sortedCharacterPositions.Count == 0)
            {
                return -1;
            }

            int leftSearchBoundary = 0;
            int rightSearchBoundary = sortedCharacterPositions.Count - 1;

            int latestValidPosition = -1;

            while (leftSearchBoundary <= rightSearchBoundary)
            {
                int middleSearchIndex = leftSearchBoundary + (rightSearchBoundary - leftSearchBoundary) / 2;

                if (sortedCharacterPositions[middleSearchIndex] <= maximumAllowedSourceIndex)
                {
                    latestValidPosition = sortedCharacterPositions[middleSearchIndex];

                    leftSearchBoundary = middleSearchIndex + 1;
                }
                else
                {
                    rightSearchBoundary = middleSearchIndex - 1;
                }
            }

            return latestValidPosition;
        }
    }
}