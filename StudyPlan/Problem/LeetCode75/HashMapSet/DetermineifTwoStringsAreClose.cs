namespace StudyPlan.Problem.LeetCode75.HashMapSet
{
    public class DetermineifTwoStringsAreClose
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            int[] freq1 = new int[26];
            int[] freq2 = new int[26];

            foreach (char c in word1)
            {
                freq1[c - 'a']++;
            }
            foreach (char c in word2)
            {
                freq2[c - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if ((freq1[i] == 0 && freq2[i] != 0) || (freq1[i] != 0 && freq2[i] == 0))
                {
                    return false;
                }
            }

            Array.Sort(freq1);
            Array.Sort(freq2);

            for (int i = 0; i < 26; i++)
            {
                if (freq1[i] != freq2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}