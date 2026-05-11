namespace DailyQuestion
{
    public class SeparatetheDigitsinanArray
    {
        public int[] SeparateDigits(int[] numbers)
        {
            List<int> extractedDigits = new List<int>();

            foreach (int currentNumber in numbers)
            {
                string currentNumberAsString = currentNumber.ToString();

                foreach (char digitCharacter in currentNumberAsString)
                {
                    int digitValue = digitCharacter - '0';

                    extractedDigits.Add(digitValue);
                }
            }

            return extractedDigits.ToArray();
        }
    }
}