namespace DailyQuestion
{
    public class LongestValidParentheses
    {
        public int LongestValidParentheses(string parenthesesSequence)
        {
            var unmatchedParenthesesIndices = new Stack<int>();
            unmatchedParenthesesIndices.Push(-1);

            var longestValidParenthesesLength = 0;

            for (var currentParenthesisIndex = 0; currentParenthesisIndex < parenthesesSequence.Length; currentParenthesisIndex++)
            {
                if (parenthesesSequence[currentParenthesisIndex] == '(')
                {
                    unmatchedParenthesesIndices.Push(currentParenthesisIndex);
                }
                else
                {
                    unmatchedParenthesesIndices.Pop();

                    if (unmatchedParenthesesIndices.Count == 0)
                    {
                        unmatchedParenthesesIndices.Push(currentParenthesisIndex);
                    }
                    else
                    {
                        var currentValidParenthesesLength = currentParenthesisIndex - unmatchedParenthesesIndices.Peek();

                        longestValidParenthesesLength = Math.Max(longestValidParenthesesLength, currentValidParenthesesLength);
                    }
                }
            }

            return longestValidParenthesesLength;
        }
    }
}