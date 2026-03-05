namespace DailyQuestion
{
    public class MinimumChangesToMakeAlternatingBinaryString
    {
        public int CalculateMinimumChangesForAlternatingBinaryString(string binaryString)
        {
            int changesForPatternStartingWith0 = 0;
            int changesForPatternStartingWith1 = 0;

            for (int currentIndex = 0; currentIndex < binaryString.Length; currentIndex++)
            {
                char expectedCharacterForPattern0 = (currentIndex % 2 == 0) ? '0' : '1';
                char expectedCharacterForPattern1 = (currentIndex % 2 == 0) ? '1' : '0';

                if (binaryString[currentIndex] != expectedCharacterForPattern0)
                {
                    changesForPatternStartingWith0++;
                }

                if (binaryString[currentIndex] != expectedCharacterForPattern1)
                {
                    changesForPatternStartingWith1++;
                }
            }

            return Math.Min(changesForPatternStartingWith0, changesForPatternStartingWith1);
        }
    }
}