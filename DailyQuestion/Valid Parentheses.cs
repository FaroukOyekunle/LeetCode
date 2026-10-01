namespace DailyQuestion
{
    public class ValidParentheses
    {
        public bool IsValid(string bracketSequence)
        {
            var openingBracketStack = new Stack<char>();

            foreach (char currentBracket in bracketSequence)
            {
                if (currentBracket == '(' || currentBracket == '{' || currentBracket == '[')
                {
                    openingBracketStack.Push(currentBracket);
                    continue;
                }

                if (openingBracketStack.Count == 0)
                {
                    return false;
                }

                char mostRecentOpeningBracket = openingBracketStack.Pop();

                bool isClosingParenthesisMismatch = currentBracket == ')' && mostRecentOpeningBracket != '(';

                bool isClosingCurlyBracketMismatch = currentBracket == '}' && mostRecentOpeningBracket != '{';

                bool isClosingSquareBracketMismatch = currentBracket == ']' && mostRecentOpeningBracket != '[';

                if (isClosingParenthesisMismatch || isClosingCurlyBracketMismatch || isClosingSquareBracketMismatch)
                {
                    return false;
                }
            }

            return openingBracketStack.Count == 0;
        }
    }
}