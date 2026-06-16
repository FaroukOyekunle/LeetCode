namespace DailyQuestion
{
    public class ProcessStringwithSpecialOperationsI
    {
        public string ProcessStr(string inputSequence)
        {
            StringBuilder processedOutput = new StringBuilder();

            foreach (char currentSymbol in inputSequence)
            {
                if (char.IsLower(currentSymbol))
                {
                    processedOutput.Append(currentSymbol);
                }
                else if (currentSymbol == '*')
                {
                    if (processedOutput.Length > 0)
                    {
                        processedOutput.Length--;
                    }
                }
                else if (currentSymbol == '#')
                {
                    string existingOutputContent = processedOutput.ToString();

                    processedOutput.Append(existingOutputContent);
                }
                else if (currentSymbol == '%')
                {
                    ReverseCharactersInBuilder(processedOutput);
                }
            }

            return processedOutput.ToString();
        }

        private void ReverseCharactersInBuilder(StringBuilder textBuilder)
        {
            int leftCharacterIndex = 0;

            int rightCharacterIndex = textBuilder.Length - 1;

            while (leftCharacterIndex < rightCharacterIndex)
            {
                (
                    textBuilder[leftCharacterIndex],
                    textBuilder[rightCharacterIndex]
                )
                =
                (
                    textBuilder[rightCharacterIndex],
                    textBuilder[leftCharacterIndex]
                );

                leftCharacterIndex++;

                rightCharacterIndex--;
            }
        }
    }
}