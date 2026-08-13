namespace DailyQuestion
{
    public class LongestSubstringofOneRepeatingCharacter
    {
        public int[] LongestRepeating(string inputString, string queryCharacters, int[] queryIndices)
        {
            int inputStringLength = inputString.Length;
            int totalQueryCount = queryIndices.Length;

            SegmentTree segmentTree = new SegmentTree(inputString);

            int[] longestRepeatingLengths = new int[totalQueryCount];

            for (int queryIndex = 0; queryIndex < totalQueryCount; queryIndex++)
            {
                int characterPosition = queryIndices[queryIndex];
                char replacementCharacter = queryCharacters[queryIndex];

                segmentTree.Update(characterPosition, replacementCharacter);

                longestRepeatingLengths[queryIndex] = segmentTree.GetLongestLength();
            }

            return longestRepeatingLengths;
        }

        private class SegmentTree
        {
            private readonly Node[] segmentTreeNodes;
            private readonly char[] currentCharacters;
            private readonly int inputStringLength;

            public SegmentTree(string inputString)
            {
                inputStringLength = inputString.Length;
                currentCharacters = inputString.ToCharArray();

                segmentTreeNodes = new Node[inputStringLength * 4];

                BuildTree(1, 0, inputStringLength - 1);
            }

            public void Update(int characterPosition, char replacementCharacter)
            {
                if (currentCharacters[characterPosition] == replacementCharacter)
                {
                    return;
                }

                currentCharacters[characterPosition] = replacementCharacter;

                UpdateTree(1, 0, inputStringLength - 1, characterPosition, replacementCharacter);
            }

            public int GetLongestLength()
            {
                return segmentTreeNodes[1].LongestLength;
            }

            private void BuildTree(int nodeIndex, int segmentStartIndex, int segmentEndIndex)
            {
                if (segmentStartIndex == segmentEndIndex)
                {
                    char segmentCharacter = currentCharacters[segmentStartIndex];

                    segmentTreeNodes[nodeIndex] = new Node
                    {
                        LeftCharacter = segmentCharacter,
                        RightCharacter = segmentCharacter,
                        PrefixLength = 1,
                        SuffixLength = 1,
                        LongestLength = 1,
                        SegmentLength = 1
                    };

                    return;
                }

                int segmentMiddleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

                int leftChildNodeIndex = nodeIndex * 2;
                int rightChildNodeIndex = nodeIndex * 2 + 1;

                BuildTree(leftChildNodeIndex, segmentStartIndex, segmentMiddleIndex);
                BuildTree(rightChildNodeIndex, segmentMiddleIndex + 1, segmentEndIndex);

                segmentTreeNodes[nodeIndex] = MergeNodes(segmentTreeNodes[leftChildNodeIndex], segmentTreeNodes[rightChildNodeIndex]);
            }

            private void UpdateTree(int nodeIndex, int segmentStartIndex, int segmentEndIndex, int targetCharacterPosition, char replacementCharacter)
            {
                if (segmentStartIndex == segmentEndIndex)
                {
                    segmentTreeNodes[nodeIndex] = new Node
                    {
                        LeftCharacter = replacementCharacter,
                        RightCharacter = replacementCharacter,
                        PrefixLength = 1,
                        SuffixLength = 1,
                        LongestLength = 1,
                        SegmentLength = 1
                    };

                    return;
                }

                int segmentMiddleIndex = segmentStartIndex + (segmentEndIndex - segmentStartIndex) / 2;

                int leftChildNodeIndex = nodeIndex * 2;
                int rightChildNodeIndex = nodeIndex * 2 + 1;

                if (targetCharacterPosition <= segmentMiddleIndex)
                {
                    UpdateTree(leftChildNodeIndex, segmentStartIndex, segmentMiddleIndex, targetCharacterPosition, replacementCharacter);
                }
                else
                {
                    UpdateTree(rightChildNodeIndex, segmentMiddleIndex + 1, segmentEndIndex, targetCharacterPosition, replacementCharacter);
                }

                segmentTreeNodes[nodeIndex] = MergeNodes(segmentTreeNodes[leftChildNodeIndex], segmentTreeNodes[rightChildNodeIndex]);
            }

            private static Node MergeNodes(Node leftSegmentNode, Node rightSegmentNode)
            {
                Node mergedSegmentNode = new Node
                {
                    LeftCharacter = leftSegmentNode.LeftCharacter,
                    RightCharacter = rightSegmentNode.RightCharacter,
                    SegmentLength = leftSegmentNode.SegmentLength + rightSegmentNode.SegmentLength,

                    PrefixLength = leftSegmentNode.PrefixLength,
                    SuffixLength = rightSegmentNode.SuffixLength,

                    LongestLength = Math.Max(leftSegmentNode.LongestLength, rightSegmentNode.LongestLength)
                };

                bool boundaryCharactersMatch = leftSegmentNode.RightCharacter == rightSegmentNode.LeftCharacter;

                if (leftSegmentNode.PrefixLength == leftSegmentNode.SegmentLength && boundaryCharactersMatch)
                {
                    mergedSegmentNode.PrefixLength = leftSegmentNode.SegmentLength + rightSegmentNode.PrefixLength;
                }

                if (rightSegmentNode.SuffixLength == rightSegmentNode.SegmentLength && boundaryCharactersMatch)
                {
                    mergedSegmentNode.SuffixLength = rightSegmentNode.SegmentLength + leftSegmentNode.SuffixLength;
                }

                if (boundaryCharactersMatch)
                {
                    int combinedBoundaryLength = leftSegmentNode.SuffixLength + rightSegmentNode.PrefixLength;

                    mergedSegmentNode.LongestLength = Math.Max(mergedSegmentNode.LongestLength, combinedBoundaryLength);
                }

                return mergedSegmentNode;
            }

            private class Node
            {
                public char LeftCharacter { get; set; }
                public char RightCharacter { get; set; }

                public int PrefixLength { get; set; }
                public int SuffixLength { get; set; }
                public int LongestLength { get; set; }
                public int SegmentLength { get; set; }
            }
        }
    }
}