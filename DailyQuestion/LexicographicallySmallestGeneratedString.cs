namespace DailyQuestion
{
    public class LexicographicallySmallestGeneratedString
    {
        public string ConstructStringUsingKmpAndConstraints(string patternConstraints, string requiredSubstring)
        {
            int[] ComputePrefixFunction(string pattern)
            {
                int[] longestPrefixSuffix = new int[pattern.Length];
                Array.Fill(longestPrefixSuffix, -1);

                int previousMatchLength = -1;

                for (int currentIndex = 1; currentIndex < pattern.Length; currentIndex++)
                {
                    while (previousMatchLength > -1 &&
                        pattern[previousMatchLength + 1] != pattern[currentIndex])
                    {
                        previousMatchLength = longestPrefixSuffix[previousMatchLength];
                    }

                    if (pattern[previousMatchLength + 1] == pattern[currentIndex])
                    {
                        previousMatchLength++;
                    }

                    longestPrefixSuffix[currentIndex] = previousMatchLength;
                }

                return longestPrefixSuffix;
            }

            int constraintLength = patternConstraints.Length;
            int substringLength = requiredSubstring.Length;

            char[] candidateCharacters = Enumerable.Repeat('*', constraintLength + substringLength - 1).ToArray();

            int[] substringPrefixArray = ComputePrefixFunction(requiredSubstring);

            int previousTrueConstraintIndex = -substringLength;

            for (int constraintIndex = 0; constraintIndex < constraintLength; constraintIndex++)
            {
                if (patternConstraints[constraintIndex] != 'T')
                {
                    continue;
                }

                int distanceFromPrevious = constraintIndex - previousTrueConstraintIndex;

                if (distanceFromPrevious < substringLength)
                {
                    if (substringPrefixArray[substringLength - 1] + 1 ==
                        substringLength - distanceFromPrevious)
                    {
                        for (int overlapOffset = 0; overlapOffset < distanceFromPrevious; overlapOffset++)
                        {
                            candidateCharacters[(previousTrueConstraintIndex + substringLength) + overlapOffset] = requiredSubstring[substringLength - distanceFromPrevious + overlapOffset];
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    for (int substringOffset = 0; substringOffset < substringLength; substringOffset++)
                    {
                        candidateCharacters[constraintIndex + substringOffset] = requiredSubstring[substringOffset];
                    }
                }

                previousTrueConstraintIndex = constraintIndex;
            }

            List<char> combinedPatternAndCandidate = new List<char>();

            combinedPatternAndCandidate.AddRange(requiredSubstring);
            combinedPatternAndCandidate.Add('#');
            combinedPatternAndCandidate.AddRange(candidateCharacters);

            List<int> placeholderIndices = new List<int>();

            for (int combinedIndex = substringLength + 1; combinedIndex < combinedPatternAndCandidate.Count; combinedIndex++)
            {
                if (combinedPatternAndCandidate[combinedIndex] == '*')
                {
                    combinedPatternAndCandidate[combinedIndex] = 'a';
                    placeholderIndices.Add(combinedIndex);
                }
            }

            int[] combinedPrefixArray = ComputePrefixFunction(new string(combinedPatternAndCandidate.ToArray()));

            LinkedList<int> candidateReplacementIndices = new LinkedList<int>();

            int placeholderPointer = 0;

            for (int windowStartIndex = substringLength + 1; windowStartIndex - (substringLength + 1) < constraintLength;)
            {
                while (candidateReplacementIndices.Count > 0 && candidateReplacementIndices.First.Value < windowStartIndex)
                {
                    candidateReplacementIndices.RemoveFirst();
                }

                while (placeholderPointer < placeholderIndices.Count && placeholderIndices[placeholderPointer] <= windowStartIndex + (substringLength - 1))
                {
                    candidateReplacementIndices.AddLast(placeholderIndices[placeholderPointer]);
                    placeholderPointer++;
                }

                if (windowStartIndex + (substringLength - 1) >= combinedPrefixArray.Length)
                {
                    break;
                }

                if (patternConstraints[windowStartIndex - (substringLength + 1)] == 'F' && combinedPrefixArray[windowStartIndex + (substringLength - 1)] + 1 == substringLength)
                {
                    if (candidateReplacementIndices.Count == 0)
                    {
                        return "";
                    }

                    int indexToModify = candidateReplacementIndices.Last.Value;

                    combinedPatternAndCandidate[indexToModify] = 'b';

                    windowStartIndex += substringLength;
                }
                else
                {
                    windowStartIndex++;
                }
            }

            return new string(combinedPatternAndCandidate
                    .Skip(substringLength + 1)
                    .ToArray()
            );
        }
    }
}