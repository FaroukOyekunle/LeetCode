namespace DailyQuestion
{
    public class SequentialDigits
    {
        public IList<int> SequentialDigits(int minimumValue, int maximumValue)
        {
            List<int> sequentialDigitNumbers = new List<int>();

            string consecutiveDigits = "123456789";

            int minimumDigitLength = minimumValue.ToString().Length;
            int maximumDigitLength = maximumValue.ToString().Length;

            for (int currentDigitLength = minimumDigitLength; currentDigitLength <= maximumDigitLength; currentDigitLength++)
            {
                for (int startingDigitIndex = 0; startingDigitIndex <= consecutiveDigits.Length - currentDigitLength; startingDigitIndex++)
                {
                    string candidateSequentialDigitString = consecutiveDigits.Substring(startingDigitIndex, currentDigitLength);

                    int candidateSequentialNumber = int.Parse(candidateSequentialDigitString);

                    if (candidateSequentialNumber >= minimumValue && candidateSequentialNumber <= maximumValue)
                    {
                        sequentialDigitNumbers.Add(candidateSequentialNumber);
                    }
                }
            }

            return sequentialDigitNumbers;
        }
    }
}