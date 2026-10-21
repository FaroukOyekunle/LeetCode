namespace DailyQuestion
{
    public class MinimumSwapstoSortbyDigitSum
    {
        public int MinOperations(string inputString)
        {
            int totalCharacterCount = inputString.Length;
            bool isAlreadySortedInAscendingOrder = true;

            for (int currentCharacterIndex = 1; currentCharacterIndex < totalCharacterCount; currentCharacterIndex++)
            {
                if (inputString[currentCharacterIndex] < inputString[currentCharacterIndex - 1])
                {
                    isAlreadySortedInAscendingOrder = false;
                    break;
                }
            }

            if (isAlreadySortedInAscendingOrder)
            {
                return 0;
            }

            if (totalCharacterCount == 2)
            {
                return -1;
            }

            char minimumCharacterInString = inputString.Min();
            char maximumCharacterInString = inputString.Max();

            if (inputString[0] == minimumCharacterInString || inputString[totalCharacterCount - 1] == maximumCharacterInString)
            {
                return 1;
            }

            for (int currentCharacterIndex = 1; currentCharacterIndex < totalCharacterCount - 1; currentCharacterIndex++)
            {
                if (inputString[currentCharacterIndex] == minimumCharacterInString || inputString[currentCharacterIndex] == maximumCharacterInString)
                {
                    return 2;
                }
            }

            return 3;
        }
    }
}