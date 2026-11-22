using System;

namespace DailyQuestion
{
    public class CheckifAllAsAppearsBeforeAllBs
    {
        public bool CheckString(string inputString)
        {
            bool hasEncounteredBCharacter = false;

            foreach (char currentCharacter in inputString)
            {
                if (currentCharacter == 'b')
                {
                    hasEncounteredBCharacter = true;
                }
                else if (currentCharacter == 'a' && hasEncounteredBCharacter)
                {
                    return false;
                }
            }

            return true;
        }
    }
}