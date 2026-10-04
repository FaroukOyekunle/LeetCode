namespace DailyQuestion
{
    public class ValidParenthesisString
    {
        public bool CheckValidString(string parenthesesSequence)
        {
            var minimumPossibleOpenParenthesesCount = 0;
            var maximumPossibleOpenParenthesesCount = 0;

            foreach (var currentCharacter in parenthesesSequence)
            {
                if (currentCharacter == '(')
                {
                    minimumPossibleOpenParenthesesCount++;
                    maximumPossibleOpenParenthesesCount++;
                }
                else if (currentCharacter == ')')
                {
                    minimumPossibleOpenParenthesesCount--;
                    maximumPossibleOpenParenthesesCount--;
                }
                else
                {
                    minimumPossibleOpenParenthesesCount--;
                    maximumPossibleOpenParenthesesCount++;
                }

                if (maximumPossibleOpenParenthesesCount < 0)
                {
                    return false;
                }

                minimumPossibleOpenParenthesesCount = Math.Max(minimumPossibleOpenParenthesesCount, 0);
            }

            return minimumPossibleOpenParenthesesCount == 0;
        }
    }
}