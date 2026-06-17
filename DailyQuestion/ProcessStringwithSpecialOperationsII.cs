namespace DailyQuestion
{
    public class ProcessStringwithSpecialOperationsII
    {
        public char ProcessStr(string operationSequence, long targetIndex)
        {
            int operationCount = operationSequence.Length;

            long[] outputLengthAfterEachOperation = new long[operationCount];

            long currentOutputLength = 0;

            for (int operationIndex = 0; operationIndex < operationCount; operationIndex++)
            {
                char currentOperation = operationSequence[operationIndex];

                if (char.IsLower(currentOperation))
                {
                    currentOutputLength++;
                }
                else if (currentOperation == '*')
                {
                    if (currentOutputLength > 0)
                    {
                        currentOutputLength--;
                    }
                }
                else if (currentOperation == '#')
                {
                    currentOutputLength *= 2;
                }
                else if (currentOperation == '%')
                {
                    // Reverse operation changes order only.
                    // Output length remains unchanged.
                }

                outputLengthAfterEachOperation[operationIndex] = currentOutputLength;
            }

            if (targetIndex >= currentOutputLength)
            {
                return '.';
            }

            for (int operationIndex = operationCount - 1; operationIndex >= 0; operationIndex--)
            {
                char currentOperation = operationSequence[operationIndex];

                long outputLengthAfterCurrentOperation = outputLengthAfterEachOperation[operationIndex];

                if (char.IsLower(currentOperation))
                {
                    long outputLengthBeforeAppend = outputLengthAfterCurrentOperation - 1;

                    if (targetIndex == outputLengthBeforeAppend)
                    {
                        return currentOperation;
                    }
                }
                else if (currentOperation == '*')
                {
                    // Character deletion only affects length.
                }
                else if (currentOperation == '#')
                {
                    long outputLengthBeforeDuplicate = outputLengthAfterCurrentOperation / 2;

                    if (outputLengthBeforeDuplicate > 0)
                    {
                        targetIndex %= outputLengthBeforeDuplicate;
                    }
                }
                else if (currentOperation == '%')
                {
                    if (outputLengthAfterCurrentOperation > 0)
                    {
                        targetIndex = outputLengthAfterCurrentOperation - 1 - targetIndex;
                    }
                }
            }

            return '.';
        }
    }
}