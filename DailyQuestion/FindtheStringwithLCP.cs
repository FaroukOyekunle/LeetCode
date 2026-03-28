namespace DailyQuestion
{
    public class FindtheStringwithLCP
    {
        public string ReconstructLexicographicallySmallestStringFromLcpMatrix(int[][] longestCommonPrefixMatrix)
        {
            int stringLength = longestCommonPrefixMatrix.Length;

            for (int firstIndex = 0; firstIndex < stringLength; firstIndex++)
            {
                if (longestCommonPrefixMatrix[firstIndex][firstIndex] != stringLength - firstIndex)
                {
                    return "";
                }

                for (int secondIndex = 0; secondIndex < stringLength; secondIndex++)
                {
                    if (longestCommonPrefixMatrix[firstIndex][secondIndex] != longestCommonPrefixMatrix[secondIndex][firstIndex])
                    {
                        return "";
                    }
                }
            }

            int[] parentRepresentative = new int[stringLength];

            for (int index = 0; index < stringLength; index++)
            {
                parentRepresentative[index] = index;
            }

            int FindRepresentative(int elementIndex)
            {
                if (parentRepresentative[elementIndex] != elementIndex)
                {
                    parentRepresentative[elementIndex] = FindRepresentative(parentRepresentative[elementIndex]);
                }

                return parentRepresentative[elementIndex];
            }

            void UnionIndices(int indexA, int indexB)
            {
                int rootA = FindRepresentative(indexA);
                int rootB = FindRepresentative(indexB);

                if (rootA != rootB)
                {
                    parentRepresentative[rootB] = rootA;
                }
            }

            for (int firstIndex = 0; firstIndex < stringLength; firstIndex++)
            {
                for (int secondIndex = firstIndex + 1; secondIndex < stringLength; secondIndex++)
                {
                    if (longestCommonPrefixMatrix[firstIndex][secondIndex] > 0)
                    {
                        UnionIndices(firstIndex, secondIndex);
                    }
                }
            }

            Dictionary<int, char> groupRepresentativeToCharacterMap = new Dictionary<int, char>();

            char nextAvailableCharacter = 'a';

            char[] reconstructedCharacters = new char[stringLength];

            for (int index = 0; index < stringLength; index++)
            {
                int groupRepresentative = FindRepresentative(index);

                if (!groupRepresentativeToCharacterMap.ContainsKey(groupRepresentative))
                {
                    if (nextAvailableCharacter > 'z')
                    {
                        return "";
                    }

                    groupRepresentativeToCharacterMap[groupRepresentative] = nextAvailableCharacter++;
                }

                reconstructedCharacters[index] = groupRepresentativeToCharacterMap[groupRepresentative];
            }

            string reconstructedString = new string(reconstructedCharacters);

            int[][] recomputedLcpMatrix = new int[stringLength][];

            for (int rowIndex = 0; rowIndex < stringLength; rowIndex++)
            {
                recomputedLcpMatrix[rowIndex] = new int[stringLength];
            }

            for (int firstIndex = stringLength - 1; firstIndex >= 0; firstIndex--)
            {
                for (int secondIndex = stringLength - 1; secondIndex >= 0; secondIndex--)
                {
                    if (reconstructedString[firstIndex] == reconstructedString[secondIndex])
                    {
                        if (firstIndex + 1 < stringLength && secondIndex + 1 < stringLength)
                        {
                            recomputedLcpMatrix[firstIndex][secondIndex] = 1 + recomputedLcpMatrix[firstIndex + 1][secondIndex + 1];
                        }
                        else
                        {
                            recomputedLcpMatrix[firstIndex][secondIndex] = 1;
                        }
                    }
                    else
                    {
                        recomputedLcpMatrix[firstIndex][secondIndex] = 0;
                    }

                    if (recomputedLcpMatrix[firstIndex][secondIndex] != longestCommonPrefixMatrix[firstIndex][secondIndex])
                    {
                        return "";
                    }
                }
            }

            return reconstructedString;
        } 
    }
}