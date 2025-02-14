namespace StudyPlan.Problem.LeetCode75.ArrayORString
{
    public class MergeStringsAlternately
    {
        public string MergeAlternately(string word1, string word2)
        {
            int length1 = word1.Length;
            int length2 = word2.Length;
            int maxLen = Math.Max(length1, length2);
            StringBuilder merged = new StringBuilder();

            for(int i = 0; i < maxLen; i++)
            {
                if (i < length1)
                {
                    merged.Append(word1[i]);
                }

                if (i < length2)
                {
                    merged.Append(word2[i]);
                }
            }

            return merged.ToString();
        }
    }
}