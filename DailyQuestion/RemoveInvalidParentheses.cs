namespace DailyQuestion
{
    public class RemoveInvalidParentheses
    {
        public IList<string> RemoveInvalidParentheses(string parenthesesSequence)
        {
            var validParenthesesSequences = new List<string>();
            var visitedParenthesesSequences = new HashSet<string> { parenthesesSequence };
            var pendingParenthesesSequences = new Queue<string>();

            pendingParenthesesSequences.Enqueue(parenthesesSequence);

            while (pendingParenthesesSequences.Count > 0)
            {
                var currentLevelSequenceCount = pendingParenthesesSequences.Count;
                var foundValidSequenceAtCurrentLevel = false;

                for (var currentLevelSequenceIndex = 0; currentLevelSequenceIndex < currentLevelSequenceCount; currentLevelSequenceIndex++)
                {
                    var currentParenthesesSequence = pendingParenthesesSequences.Dequeue();

                    if (IsValidParentheses(currentParenthesesSequence))
                    {
                        validParenthesesSequences.Add(currentParenthesesSequence);
                        foundValidSequenceAtCurrentLevel = true;
                        continue;
                    }

                    if (foundValidSequenceAtCurrentLevel)
                    {
                        continue;
                    }

                    for (var currentCharacterIndex = 0; currentCharacterIndex < currentParenthesesSequence.Length; currentCharacterIndex++)
                    {
                        if (currentParenthesesSequence[currentCharacterIndex] != '(' && currentParenthesesSequence[currentCharacterIndex] != ')')
                        {
                            continue;
                        }

                        var parenthesesSequenceAfterRemoval = currentParenthesesSequence.Remove(currentCharacterIndex, 1);

                        if (visitedParenthesesSequences.Add(parenthesesSequenceAfterRemoval))
                        {
                            pendingParenthesesSequences.Enqueue(parenthesesSequenceAfterRemoval);
                        }
                    }
                }

                if (foundValidSequenceAtCurrentLevel)
                {
                    break;
                }
            }

            return validParenthesesSequences;
        }

        private bool IsValidParentheses(string parenthesesSequence)
        {
            var unmatchedOpeningParenthesesCount = 0;

            foreach (var currentParenthesisCharacter in parenthesesSequence)
            {
                if (currentParenthesisCharacter == '(')
                {
                    unmatchedOpeningParenthesesCount++;
                }
                else if (currentParenthesisCharacter == ')')
                {
                    if (unmatchedOpeningParenthesesCount == 0)
                    {
                        return false;
                    }

                    unmatchedOpeningParenthesesCount--;
                }
            }

            return unmatchedOpeningParenthesesCount == 0;
        }
    }
}