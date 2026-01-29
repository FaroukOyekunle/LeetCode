namespace DailyQuestion
{
    public class MinimumCosttoConvertStringI
    {
        public long CalculateMinimumCostToConvertString(string sourceString, string targetString, char[] originalCharacters, char[] changedCharacters, int[] conversionCosts)
        {
            const long Infinity = long.MaxValue / 4;
            int alphabetSize = 26;

            long[,] minimumConversionCosts = new long[alphabetSize, alphabetSize];

            for (int sourceCharIndex = 0; sourceCharIndex < alphabetSize; sourceCharIndex++)
            {
                for (int targetCharIndex = 0; targetCharIndex < alphabetSize; targetCharIndex++)
                {
                    minimumConversionCosts[sourceCharIndex, targetCharIndex] = (sourceCharIndex == targetCharIndex) ? 0 : Infinity;
                }
            }

            for (int conversionIndex = 0; conversionIndex < originalCharacters.Length; conversionIndex++)
            {
                int sourceChar = originalCharacters[conversionIndex] - 'a';
                int targetChar = changedCharacters[conversionIndex] - 'a';

                minimumConversionCosts[sourceChar, targetChar] = Math.Min(minimumConversionCosts[sourceChar, targetChar], conversionCosts[conversionIndex]);
            }

            for (int intermediateChar = 0; intermediateChar < alphabetSize; intermediateChar++)
            {
                for (int sourceChar = 0; sourceChar < alphabetSize; sourceChar++)
                {
                    for (int targetChar = 0; targetChar < alphabetSize; targetChar++)
                    {
                        if (minimumConversionCosts[sourceChar, intermediateChar] + minimumConversionCosts[intermediateChar, targetChar] < minimumConversionCosts[sourceChar, targetChar])
                        {
                            minimumConversionCosts[sourceChar, targetChar] = minimumConversionCosts[sourceChar, intermediateChar] + minimumConversionCosts[intermediateChar, targetChar];
                        }
                    }
                }
            }

            long totalConversionCost = 0;

            for (int charIndex = 0; charIndex < sourceString.Length; charIndex++)
            {
                int sourceChar = sourceString[charIndex] - 'a';
                int targetChar = targetString[charIndex] - 'a';

                if (minimumConversionCosts[sourceChar, targetChar] == Infinity)
                {
                    return -1;
                }

                totalConversionCost += minimumConversionCosts[sourceChar, targetChar];
            }

            return totalConversionCost;
        }
    }
}