namespace StudyPlan.Problem.LeetCode75.Backtracking
{
    public class LetterCombinationsofaPhoneNumber
    {
        public IList<string> LetterCombinations(string digits) 
        {
            if(string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            } 

            Dictionary<char, string> mapping = new Dictionary<char, string> {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" }
            };

            List<string> result = new List<string>();
            Backtrack(digits, 0, "", mapping, result);
            return result;
        }

        private void Backtrack(string digits, int index, string path, Dictionary<char, string> mapping, List<string> result) 
        {
            if(index == digits.Length) 
            {
                result.Add(path);
                return;
            }

            char digit = digits[index];

            foreac(char letter in mapping[digit]) 
            {
                Backtrack(digits, index + 1, path + letter, mapping, result);
            }
        }
    }
}