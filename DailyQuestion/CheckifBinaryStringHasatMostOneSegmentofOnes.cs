namespace DailyQuestion
{
    public class CheckifBinaryStringHasatMostOneSegmentofOnes
    {
        public bool CheckIfBinaryStringHasAtMostOneSegmentOfOnes(string binaryString)
        {
            bool hasEncounteredZero = false;

            foreach (char currentCharacter in binaryString)
            {
                if (currentCharacter == '0')
                {
                    hasEncounteredZero = true;
                }
                else if (hasEncounteredZero)
                {
                    return false;
                }
            }

            return true;
        }
    }
}