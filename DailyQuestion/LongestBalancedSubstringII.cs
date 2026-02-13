namespace DailyQuestion
{
    public class LongestBalancedSubstringII
    {
        public int CalculateLongestBalancedSubstringLength(string inputString)
        {
            int totalLength = inputString.Length;

            int CalculateSingleCharacterBalancedLength()
            {
                int longestLength = 0;
                int currentRunLength = 0;

                for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
                {
                    currentRunLength++;

                    if (currentIndex + 1 == totalLength || inputString[currentIndex + 1] != inputString[currentIndex])
                    {
                        longestLength = Math.Max(longestLength, currentRunLength);
                        currentRunLength = 0;
                    }
                }

                return longestLength;
            }

            int CalculateTwoCharacterBalancedLength(char positiveCharacter, char negativeCharacter)
            {
                int longestLength = 0;
                int runningBalance = 0;

                var earliestIndexByBalance = new Dictionary<int, int>();

                earliestIndexByBalance[runningBalance] = -1;

                for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
                {
                    char currentCharacter = inputString[currentIndex];

                    if (currentCharacter == positiveCharacter)
                    {
                        runningBalance++;
                    }
                    else if (currentCharacter == negativeCharacter)
                    {
                        runningBalance--;
                    }
                    else
                    {
                        runningBalance = 0;
                        earliestIndexByBalance.Clear();
                        earliestIndexByBalance[runningBalance] = currentIndex;

                        continue;
                    }

                    if (earliestIndexByBalance.TryGetValue(runningBalance, out int previousIndex))
                    {
                        longestLength = Math.Max(longestLength, currentIndex - previousIndex);
                    }
                    else
                    {
                        earliestIndexByBalance[runningBalance] = currentIndex;
                    }
                }

                return longestLength;
            }

            int CalculateThreeCharacterBalancedLength()
            {
                int longestLength = 0;

                int countOfA = 0;
                int countOfB = 0;

                var earliestIndexByBalancePair = new Dictionary<(int countOfA, int countOfB), int>();

                earliestIndexByBalancePair[(countOfA, countOfB)] = -1;

                for (int currentIndex = 0; currentIndex < totalLength; currentIndex++)
                {
                    char currentCharacter = inputString[currentIndex];

                    if (currentCharacter == 'a')
                    {
                        countOfA++;
                    }
                    else if (currentCharacter == 'b')
                    {
                        countOfB++;
                    }
                    else
                    {
                        countOfA--;
                        countOfB--;
                    }

                    var balanceKey = (countOfA, countOfB);

                    if (earliestIndexByBalancePair.TryGetValue(balanceKey, out int previousIndex))
                    {
                        longestLength = Math.Max(longestLength, currentIndex - previousIndex);
                    }
                    else
                    {
                        earliestIndexByBalancePair[balanceKey] = currentIndex;
                    }
                }

                return longestLength;
            }

            return Math.Max(CalculateSingleCharacterBalancedLength(), Math.Max(
                    Math.Max(CalculateTwoCharacterBalancedLength('a', 'b'),
                        CalculateTwoCharacterBalancedLength('b', 'c')),
                    Math.Max(CalculateTwoCharacterBalancedLength('c', 'a'),
                        CalculateThreeCharacterBalancedLength()
                    )
                )
            );
        }

    }
}