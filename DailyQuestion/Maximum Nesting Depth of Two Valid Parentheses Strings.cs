namespace DailyQuestion
{
    public class MaximumNestingDepthOfTwoValidParenthesesStrings
    {
        public int[] MaxDepthAfterSplit(string parenthesesSequence)
        {
            int[] sequenceGroupAssignments = new int[parenthesesSequence.Length];

            int currentParenthesesDepth = 0;

            for (int characterIndex = 0; characterIndex < parenthesesSequence.Length; characterIndex++)
            {
                if (parenthesesSequence[characterIndex] == '(')
                {
                    currentParenthesesDepth++;

                    sequenceGroupAssignments[characterIndex] = currentParenthesesDepth % 2;
                }
                else
                {
                    sequenceGroupAssignments[characterIndex] = currentParenthesesDepth % 2;

                    currentParenthesesDepth--;
                }
            }

            return sequenceGroupAssignments;
        }
    }
}