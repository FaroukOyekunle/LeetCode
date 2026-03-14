namespace DailyQuestion
{
    public class ThekthLexicographicalStringofAllHappyStringsofLengthn
    {
        private int currentCount = 0;
        private string result = "";
        public string GetHappyString(int n, int k)
        {
            char[] characters = { 'a', 'b', 'c' };
            BuildHappyString(n, k, "", characters);
            return result;
        }

        private void BuildHappyString(int targetLength, int k, string currentString, char[] characters)
        {
            if (result.Length > 0)
            {
                return;
            }

            if (currentString.Length == targetLength)
            {
                currentCount++;

                if (currentCount == k)
                {
                    result = currentString;
                }

                return;
            }

            foreach (char character in characters)
            {
                if (currentString.Length > 0 && currentString[^1] == character)
                {
                    continue;
                }

                BuildHappyString(targetLength, k, currentString + character, characters);
            }
        }
    }
}