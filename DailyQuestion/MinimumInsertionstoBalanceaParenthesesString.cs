namespace DailyQuestion
{
    public class MinimumInsertionstoBalanceaParenthesesString
    {
        public int MinInsertions(string parenthesesSequence)
        {
            var requiredInsertionsCount = 0;
            var requiredClosingParenthesesCount = 0;

            foreach (var currentParenthesisCharacter in parenthesesSequence)
            {
                if (currentParenthesisCharacter == '(')
                {
                    if (requiredClosingParenthesesCount % 2 != 0)
                    {
                        requiredInsertionsCount++;
                        requiredClosingParenthesesCount--;
                    }

                    requiredClosingParenthesesCount += 2;
                }
                else
                {
                    requiredClosingParenthesesCount--;

                    if (requiredClosingParenthesesCount < 0)
                    {
                        requiredInsertionsCount++;

                        requiredClosingParenthesesCount = 1;
                    }
                }
            }

            requiredInsertionsCount += requiredClosingParenthesesCount;

            return requiredInsertionsCount;
        }
    }
}