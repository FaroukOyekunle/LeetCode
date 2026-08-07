namespace DailyQuestion
{
    public class SmallestDivisibleDigitProductII
    {
        public string SmallestNumber(string inputNumber, long targetProduct)
        {
            List<int> FindDigitFactors(long remainingTargetProduct, int maximumCandidateLength)
            {
                List<int> factorDigits = new List<int>();

                for (int candidateFactorDigit = 9; candidateFactorDigit >= 2; candidateFactorDigit--)
                {
                    while (remainingTargetProduct % candidateFactorDigit == 0)
                    {
                        remainingTargetProduct /= candidateFactorDigit;
                        factorDigits.Add(candidateFactorDigit);

                        if (factorDigits.Count > maximumCandidateLength)
                        {
                            return new List<int>();
                        }
                    }

                    if (remainingTargetProduct == 1)
                    {
                        factorDigits.Reverse();
                        return factorDigits;
                    }
                }

                return new List<int>();
            }

            string BuildNumberFromSuffixDigits(List<int> suffixFactorDigits, int totalNumberLength)
            {
                char[] constructedNumberDigits = new string('1', totalNumberLength).ToCharArray();

                int suffixStartPosition = totalNumberLength - suffixFactorDigits.Count;

                foreach (int factorDigit in suffixFactorDigits)
                {
                    constructedNumberDigits[suffixStartPosition++] = (char)('0' + factorDigit);
                }

                return new string(constructedNumberDigits);
            }

            long CalculateGreatestCommonDivisor(long firstNumber, long secondNumber)
            {
                while (secondNumber != 0)
                {
                    long remainderAfterDivision = firstNumber % secondNumber;

                    firstNumber = secondNumber;
                    secondNumber = remainderAfterDivision;
                }

                return firstNumber;
            }

            List<int> completeTargetFactorDigits = FindDigitFactors(targetProduct, int.MaxValue);

            if (targetProduct != 1 && completeTargetFactorDigits.Count == 0)
            {
                return "-1";
            }

            char[] numberDigits = inputNumber.ToCharArray();

            int firstZeroPosition = 0;

            while (firstZeroPosition < numberDigits.Length && numberDigits[firstZeroPosition] != '0')
            {
                firstZeroPosition++;
            }

            for (int digitPosition = firstZeroPosition; digitPosition < numberDigits.Length; digitPosition++)
            {
                numberDigits[digitPosition] = '1';
            }

            string zeroFreeInputNumber = new string(numberDigits);

            long[] prefixDigitProductsModuloTarget = new long[zeroFreeInputNumber.Length + 1];

            prefixDigitProductsModuloTarget[0] = 1;

            for (int digitPosition = 0; digitPosition < zeroFreeInputNumber.Length; digitPosition++)
            {
                int currentDigitValue = zeroFreeInputNumber[digitPosition] - '0';

                prefixDigitProductsModuloTarget[digitPosition + 1] = (prefixDigitProductsModuloTarget[digitPosition] * currentDigitValue) % targetProduct;
            }

            if (prefixDigitProductsModuloTarget[zeroFreeInputNumber.Length] == 0)
            {
                return zeroFreeInputNumber;
            }

            for (int replacementDigitPosition = zeroFreeInputNumber.Length - 1; replacementDigitPosition >= 0; replacementDigitPosition--)
            {
                long requiredSuffixProduct = targetProduct / CalculateGreatestCommonDivisor(targetProduct, prefixDigitProductsModuloTarget[replacementDigitPosition]);

                int originalDigitValue = zeroFreeInputNumber[replacementDigitPosition] - '0';

                for (int replacementDigitValue = originalDigitValue + 1; replacementDigitValue <= 9; replacementDigitValue++)
                {
                    long remainingRequiredProduct = requiredSuffixProduct / CalculateGreatestCommonDivisor(requiredSuffixProduct, replacementDigitValue);

                    int remainingSuffixLength = zeroFreeInputNumber.Length - 1 - replacementDigitPosition;

                    List<int> suffixFactorDigits = FindDigitFactors(remainingRequiredProduct, remainingSuffixLength);

                    if (remainingRequiredProduct != 1 && suffixFactorDigits.Count == 0)
                    {
                        continue;
                    }

                    string numberPrefix = zeroFreeInputNumber.Substring(0, replacementDigitPosition) + (char)('0' + replacementDigitValue);

                    return numberPrefix + BuildNumberFromSuffixDigits(suffixFactorDigits, remainingSuffixLength);
                }
            }

            int minimumRequiredNumberLength = Math.Max(zeroFreeInputNumber.Length + 1, completeTargetFactorDigits.Count);

            return BuildNumberFromSuffixDigits(completeTargetFactorDigits, minimumRequiredNumberLength);
        }
    }
}