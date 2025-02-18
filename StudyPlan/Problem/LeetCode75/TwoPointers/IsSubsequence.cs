namespace StudyPlan.Problem.LeetCode75.TwoPointers
{
    public class IsSubsequence
    {
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            Dictionary<char, List<int>> charIndices = new Dictionary<char, List<int>>();

            for(int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (!charIndices.ContainsKey(c))
                {
                    charIndices[c] = new List<int>();
                }
                charIndices[c].Add(i);
            }

            int currPos = 0;

            foreach(char c in s)
            {
                if (!charIndices.ContainsKey(c))
                {
                    return false;
                }

                List<int> indices = charIndices[c];
                int nextPos = BinarySearch(indices, currPos);

                if(nextPos == -1)
                {
                    return false;
                }

                currPos = nextPos + 1;
            }
            return true;
        }

        private int BinarySearch(List<int> indices, int target)
        {

            int left = 0, right = indices.Count - 1;
            int result = -1;

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if(indices[mid] >= target)
                {
                    result = indices[mid];
                    right = mid - 1;
                }

                else
                {
                    left = mid + 1;
                }
            }
            return result;
        }
    }
}