namespace DailyQuestion
{
    public class GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int pairCount)
        {
            var validParenthesesCombinations = new List<string>();
            var currentParenthesesCombination = new StringBuilder();

            GenerateValidCombinations(0, 0);

            return validParenthesesCombinations;

            void GenerateValidCombinations(int openingParenthesisCount, int closingParenthesisCount)
            {
                if (currentParenthesesCombination.Length == 2 * pairCount)
                {
                    validParenthesesCombinations.Add(currentParenthesesCombination.ToString());

                    return;
                }

                if (openingParenthesisCount < pairCount)
                {
                    currentParenthesesCombination.Append('(');

                    GenerateValidCombinations(openingParenthesisCount + 1, closingParenthesisCount);

                    currentParenthesesCombination.Length--;
                }

                if (closingParenthesisCount < openingParenthesisCount)
                {
                    currentParenthesesCombination.Append(')');

                    GenerateValidCombinations(openingParenthesisCount, closingParenthesisCount + 1);

                    currentParenthesesCombination.Length--;
                }
            }
        }
    }
}