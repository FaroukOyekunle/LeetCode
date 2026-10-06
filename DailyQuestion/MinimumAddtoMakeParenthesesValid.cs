namespace DailyQuestion
{
    public class MinimumAddtoMakeParenthesesValid
    {
        public int MinAddToMakeValid(string s)
        {
            var requiredOpeningParentheses = 0;
            var unmatchedOpeningParentheses = 0;

            foreach (var currentParenthesis in s)
            {
                if (currentParenthesis == '(')
                {
                    unmatchedOpeningParentheses++;
                    continue;
                }

                if (unmatchedOpeningParentheses > 0)
                {
                    unmatchedOpeningParentheses--;
                }
                else
                {
                    requiredOpeningParentheses++;
                }
            }

            return requiredOpeningParentheses + unmatchedOpeningParentheses;
        }
    }
}