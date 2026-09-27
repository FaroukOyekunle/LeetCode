namespace DailyQuestion
{
    public class ReverseSubstringsBetweenEachPairOfParentheses
    {
        public string ReverseParentheses(string inputString)
        {
            var substringStack = new Stack<StringBuilder>();
            substringStack.Push(new StringBuilder());

            foreach (char currentCharacter in inputString)
            {
                if (currentCharacter == '(')
                {
                    substringStack.Push(new StringBuilder());
                }
                else if (currentCharacter == ')')
                {
                    StringBuilder currentSubstring = substringStack.Pop();

                    for (int characterIndex = currentSubstring.Length - 1; characterIndex >= 0; characterIndex--)
                    {
                        substringStack.Peek().Append(currentSubstring[characterIndex]);
                    }
                }
                else
                {
                    substringStack.Peek().Append(currentCharacter);
                }
            }

            return substringStack.Pop().ToString();
        }
    }
}