namespace DailyQuestion
{
    public class LongestCommonSuffixQueries
    {
        class TrieNode
        {
            public TrieNode[] ChildNodes = new TrieNode[26];

            public int BestMatchingWordIndex = -1;

            public int ShortestMatchingWordLength = int.MaxValue;
        }

        public int[] StringIndices(string[] containerWords, string[] queryWords)
        {
            TrieNode trieRootNode = new TrieNode();

            for (int containerWordIndex = 0; containerWordIndex < containerWords.Length; containerWordIndex++)
            {
                string currentContainerWord = containerWords[containerWordIndex];

                InsertWordIntoTrie(trieRootNode, currentContainerWord, containerWordIndex);
            }

            int[] bestMatchingIndices = new int[queryWords.Length];

            for (int queryWordIndex = 0; queryWordIndex < queryWords.Length; queryWordIndex++)
            {
                bestMatchingIndices[queryWordIndex] = FindBestMatchingWordIndex(trieRootNode, queryWords[queryWordIndex]);
            }

            return bestMatchingIndices;
        }

        private void InsertWordIntoTrie(TrieNode trieRootNode, string wordToInsert, int wordIndex)
        {
            TrieNode currentTrieNode = trieRootNode;

            UpdateBestMatchingCandidate(currentTrieNode, wordToInsert.Length, wordIndex);

            for (int characterPosition = wordToInsert.Length - 1; characterPosition >= 0; characterPosition--)
            {
                int childNodeIndex = wordToInsert[characterPosition] - 'a';

                if (currentTrieNode.ChildNodes[childNodeIndex] == null)
                {
                    currentTrieNode.ChildNodes[childNodeIndex] = new TrieNode();
                }

                currentTrieNode = currentTrieNode.ChildNodes[childNodeIndex];

                UpdateBestMatchingCandidate(currentTrieNode, wordToInsert.Length, wordIndex);
            }
        }

        private int FindBestMatchingWordIndex(TrieNode trieRootNode, string queryWord)
        {
            TrieNode currentTrieNode = trieRootNode;

            for (int characterPosition = queryWord.Length - 1; characterPosition >= 0; characterPosition--)
            {
                int childNodeIndex = queryWord[characterPosition] - 'a';

                if (currentTrieNode.ChildNodes[childNodeIndex] == null)
                {
                    break;
                }

                currentTrieNode = currentTrieNode.ChildNodes[childNodeIndex];
            }

            return currentTrieNode.BestMatchingWordIndex;
        }

        private void UpdateBestMatchingCandidate(TrieNode currentTrieNode, int currentWordLength, int currentWordIndex)
        {
            bool currentWordIsShorter = currentWordLength < currentTrieNode.ShortestMatchingWordLength;

            bool sameLengthButEarlierIndex = currentWordLength == currentTrieNode.ShortestMatchingWordLength && currentWordIndex < currentTrieNode.BestMatchingWordIndex;

            if (currentWordIsShorter || sameLengthButEarlierIndex)
            {
                currentTrieNode.ShortestMatchingWordLength = currentWordLength;

                currentTrieNode.BestMatchingWordIndex = currentWordIndex;
            }
        }
    }
}