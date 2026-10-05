namespace DailyQuestion
{
    public class ScoreofParentheses
    {
        public int ScoreOfParentheses(string parenthesesSequence)
        {
            var totalParenthesesScore = 0;
            var currentParenthesesDepth = 0;

            for (var currentCharacterIndex = 0;
                 currentCharacterIndex < parenthesesSequence.Length;
                 currentCharacterIndex++)
            {
                var currentParenthesisCharacter = parenthesesSequence[currentCharacterIndex];

                if (currentParenthesisCharacter == '(')
                {
                    currentParenthesesDepth++;
                }
                else
                {
                    currentParenthesesDepth--;

                    if (parenthesesSequence[currentCharacterIndex - 1] == '(')
                    {
                        totalParenthesesScore += 1 << currentParenthesesDepth;
                    }
                }
            }

            return totalParenthesesScore;
        }
    }
}