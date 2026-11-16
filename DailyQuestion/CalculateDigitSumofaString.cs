using System;
using System.Text;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class CalculateDigitSumofaStrng
    {

        public string DigitSum(string numericString, int groupSize)
        {
            while (numericString.Length > groupSize)
            {
                StringBuilder transformedNumericString = new StringBuilder();

                for (int groupStartIndex = 0; groupStartIndex < numericString.Length; groupStartIndex += groupSize)
                {
                    int currentGroupDigitSum = 0;

                    int groupEndIndex = Math.Min(groupStartIndex + groupSize, numericString.Length);

                    for (int digitIndex = groupStartIndex; digitIndex < groupEndIndex; digitIndex++)
                    {
                        currentGroupDigitSum += numericString[digitIndex] - '0';
                    }

                    transformedNumericString.Append(currentGroupDigitSum);
                }

                numericString = transformedNumericString.ToString();
            }

            return numericString;
        }

    }
}