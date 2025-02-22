namespace StudyPlan.Problem.LeetCode75.SlidingWindow
{
    public class MaximumNumberofVowelsinaSubstringofGivenLength
    {
        public int MaxVowels(string s, int k)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            int count = 0, maxCount = 0;

            for(int i = 0; i < k; i++)
            {
                if(vowels.Contains(s[i]))
                {
                    count++;
                }
            }
            maxCount = count;

            for(int i = k; i < s.Length; i++)
            {
                if(vowels.Contains(s[i - k]))
                {
                    count--;
                }

                if(vowels.Contains(s[i]))
                {
                    count++;
                }

                maxCount = Math.Max(maxCount, count);

                if(maxCount == k)
                {
                    return k;
                }
            }

            return maxCount;
        }
    }
}