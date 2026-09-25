namespace DailyQuestion
{
    public class BraceExpansionII
    {
        public IList<string> BraceExpansionII(string expression)
        {
            int currentExpressionIndex = 0;

            HashSet<string> expandedWords = ParseExpression(expression, ref currentExpressionIndex);

            return expandedWords.OrderBy(word => word).ToList();
        }

        private HashSet<string> ParseExpression(string expression, ref int currentExpressionIndex)
        {
            HashSet<string> expressionResults = new();

            while (currentExpressionIndex < expression.Length && expression[currentExpressionIndex] != '}')
            {
                HashSet<string> currentTermResults = ParseTerm(expression, ref currentExpressionIndex);

                expressionResults.UnionWith(currentTermResults);

                if (currentExpressionIndex < expression.Length && expression[currentExpressionIndex] == ',')
                {
                    currentExpressionIndex++;
                }
            }

            return expressionResults;
        }

        private HashSet<string> ParseTerm(string expression, ref int currentExpressionIndex)
        {
            HashSet<string> termResults = new() { "" };

            while (currentExpressionIndex < expression.Length && expression[currentExpressionIndex] != '}' && expression[currentExpressionIndex] != ',')
            {
                HashSet<string> currentFactorResults = ParseFactor(expression, ref currentExpressionIndex);

                termResults = ConcatenateWordSets(termResults, currentFactorResults);
            }

            return termResults;
        }

        private HashSet<string> ParseFactor(string expression, ref int currentExpressionIndex)
        {
            if (expression[currentExpressionIndex] == '{')
            {
                currentExpressionIndex++;

                HashSet<string> braceExpressionResults = ParseExpression(expression, ref currentExpressionIndex);

                currentExpressionIndex++;

                return braceExpressionResults;
            }

            string currentLetter = expression[currentExpressionIndex].ToString();

            currentExpressionIndex++;

            return new HashSet<string> { currentLetter };
        }

        private HashSet<string> ConcatenateWordSets(HashSet<string> firstWordSet, HashSet<string> secondWordSet)
        {
            HashSet<string> concatenatedWordResults = new();

            foreach (string firstWord in firstWordSet)
            {
                foreach (string secondWord in secondWordSet)
                {
                    concatenatedWordResults.Add(firstWord + secondWord);
                }
            }

            return concatenatedWordResults;
        }
    }
}