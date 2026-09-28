namespace DailyQuestion
{
    public class MaximumNestingDepthOftheParentheses
    {
        public int MaxDepth(string inputString)
        {
            int currentParenthesesDepth = 0;
            int maximumParenthesesDepth = 0;

            foreach (char currentCharacter in inputString)
            {
                if (currentCharacter == '(')
                {
                    currentParenthesesDepth++;

                    maximumParenthesesDepth = Math.Max(maximumParenthesesDepth, currentParenthesesDepth);
                }
                else if (currentCharacter == ')')
                {
                    currentParenthesesDepth--;
                }
            }

            return maximumParenthesesDepth;
        }
    }
}