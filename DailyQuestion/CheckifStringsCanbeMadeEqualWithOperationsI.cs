namespace DailyQuestion
{
    public class CheckifStringsCanbeMadeEqualWithOperationsI
    {
        public bool CanMakeStringsEqualUsingIndexDistanceTwoSwaps(string firstString, string secondString)
        {
            char[] firstStringEvenIndexedCharacters =
                new char[] { firstString[0], firstString[2] };

            char[] firstStringOddIndexedCharacters =
                new char[] { firstString[1], firstString[3] };

            char[] secondStringEvenIndexedCharacters =
                new char[] { secondString[0], secondString[2] };

            char[] secondStringOddIndexedCharacters =
                new char[] { secondString[1], secondString[3] };

            Array.Sort(firstStringEvenIndexedCharacters);
            Array.Sort(firstStringOddIndexedCharacters);

            Array.Sort(secondStringEvenIndexedCharacters);
            Array.Sort(secondStringOddIndexedCharacters);

            bool areEvenIndexedCharactersEqual = firstStringEvenIndexedCharacters.SequenceEqual(secondStringEvenIndexedCharacters);

            bool areOddIndexedCharactersEqual = firstStringOddIndexedCharacters.SequenceEqual(secondStringOddIndexedCharacters);

            return areEvenIndexedCharactersEqual && areOddIndexedCharactersEqual;
        }
    }
}