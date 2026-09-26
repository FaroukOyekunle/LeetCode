namespace DailyQuestion
{
    public class EvaluateTheBracketPairsofAString
    {
        public string Evaluate(string inputString, IList<IList<string>> knowledge)
        {
            var knowledgeByKey = new Dictionary<string, string>(knowledge.Count);

            foreach (var knowledgeEntry in knowledge)
            {
                string knowledgeKey = knowledgeEntry[0];
                string knowledgeValue = knowledgeEntry[1];

                knowledgeByKey[knowledgeKey] = knowledgeValue;
            }

            var evaluatedString = new StringBuilder(inputString.Length);

            for (int currentIndex = 0; currentIndex < inputString.Length; currentIndex++)
            {
                if (inputString[currentIndex] != '(')
                {
                    evaluatedString.Append(inputString[currentIndex]);
                    continue;
                }

                int closingParenthesisIndex = currentIndex + 1;

                while (inputString[closingParenthesisIndex] != ')')
                {
                    closingParenthesisIndex++;
                }

                string currentKey = inputString.Substring(currentIndex + 1, closingParenthesisIndex - currentIndex - 1);

                if (knowledgeByKey.TryGetValue(currentKey, out string knowledgeValue))
                {
                    evaluatedString.Append(knowledgeValue);
                }
                else
                {
                    evaluatedString.Append('?');
                }

                currentIndex = closingParenthesisIndex;
            }

            return evaluatedString.ToString();
        }
    }
}