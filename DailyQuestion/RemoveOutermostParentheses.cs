using System.Text;

namespace DailyQuestion
{
    public class RemoveOutermostParentheses
    {
        public string RemoveOuterParentheses(string parenthesesSequence)
        {
            var primitiveParenthesesContent = new StringBuilder();
            var currentParenthesesDepth = 0;

            foreach (var currentParenthesisCharacter in parenthesesSequence)
            {
                if (currentParenthesisCharacter == '(')
                {
                    if (currentParenthesesDepth > 0)
                    {
                        primitiveParenthesesContent.Append(currentParenthesisCharacter);
                    }

                    currentParenthesesDepth++;

                    currentParenthesesDepth++;
                }
                else
                {
                    currentParenthesesDepth--;

                    if (currentParenthesesDepth > 0)
                    {
                        primitiveParenthesesContent.Append(currentParenthesisCharacter);
                    }
                }
            }

            return primitiveParenthesesContent.ToString();
        }
    }
}