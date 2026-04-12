namespace DailyQuestion
{
    public class MinimumDistancetoTypeaWordUsingTwoFingers
    {
        public int GetMinimumTypingDistance(string inputWord)
        {
            int wordLength = inputWord.Length;

            int CalculateKeyboardDistance(int firstKeyIndex, int secondKeyIndex)
            {
                int firstRow = firstKeyIndex / 6;
                int firstColumn = firstKeyIndex % 6;

                int secondRow = secondKeyIndex / 6;
                int secondColumn = secondKeyIndex % 6;

                return Math.Abs(firstRow - secondRow) + Math.Abs(firstColumn - secondColumn);
            }

            int[] maxDistanceSavedEndingAtChar = new int[26];

            int totalDistanceWithoutOptimization = 0;

            for (int currentPosition = 0; currentPosition < wordLength - 1; currentPosition++)
            {
                int currentCharIndex = inputWord[currentPosition] - 'A';
                int nextCharIndex = inputWord[currentPosition + 1] - 'A';

                int movementDistance = CalculateKeyboardDistance(currentCharIndex, nextCharIndex);

                totalDistanceWithoutOptimization += movementDistance;

                for (int fingerPositionChar = 0; fingerPositionChar < 26; fingerPositionChar++)
                {
                    int distanceSavedIfUsingSecondFinger = maxDistanceSavedEndingAtChar[fingerPositionChar] + movementDistance - CalculateKeyboardDistance(fingerPositionChar, nextCharIndex);

                    maxDistanceSavedEndingAtChar[currentCharIndex] = Math.Max(maxDistanceSavedEndingAtChar[currentCharIndex], distanceSavedIfUsingSecondFinger);
                }
            }

            int maximumDistanceSaved = 0;

            foreach (int savedDistance in maxDistanceSavedEndingAtChar)
            {
                maximumDistanceSaved = Math.Max(maximumDistanceSaved, savedDistance);
            }

            return totalDistanceWithoutOptimization - maximumDistanceSaved;
        }
    }
}