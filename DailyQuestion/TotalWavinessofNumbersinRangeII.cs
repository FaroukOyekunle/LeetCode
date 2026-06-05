namespace DailyQuestion
{
    public class TotalWavinessofNumbersinRangeII
    {
        private string upperBoundDigits;
        private Dictionary<DigitDpState, WavinessComputationResult> memoizedStates;

        public long TotalWaviness(long rangeStart, long rangeEnd)
        {
            return CalculateTotalWavinessUpTo(rangeEnd) - CalculateTotalWavinessUpTo(rangeStart - 1);
        }

        private long CalculateTotalWavinessUpTo(long upperLimit)
        {
            if (upperLimit < 0)
            {
                return 0;
            }

            upperBoundDigits = upperLimit.ToString();

            memoizedStates = new Dictionary<DigitDpState, WavinessComputationResult>();

            return CalculateWavinessUsingDigitDp(currentDigitPosition: 0, isRestrictedByUpperBound: true, hasStartedBuildingNumber: false, constructedNumberLength: 0, previousDigit: 0, digitBeforePrevious: 0).TotalWaviness;
        }

        private WavinessComputationResult CalculateWavinessUsingDigitDp(int currentDigitPosition, bool isRestrictedByUpperBound, bool hasStartedBuildingNumber, int constructedNumberLength, int previousDigit, int digitBeforePrevious)
        {
            if (currentDigitPosition == upperBoundDigits.Length)
            {
                return new WavinessComputationResult(totalNumbersGenerated: 1, totalWaviness: 0);
            }

            if (!isRestrictedByUpperBound)
            {
                var dpState = new DigitDpState(currentDigitPosition, hasStartedBuildingNumber, constructedNumberLength, previousDigit, digitBeforePrevious);

                if (memoizedStates.TryGetValue(dpState, out var cachedResult))
                {
                    return cachedResult;
                }
            }

            long totalNumbersGenerated = 0;
            long accumulatedWaviness = 0;

            int maximumAllowedDigit = isRestrictedByUpperBound ? upperBoundDigits[currentDigitPosition] - '0' : 9;

            for (int candidateDigit = 0; candidateDigit <= maximumAllowedDigit; candidateDigit++)
            {
                bool remainsRestrictedByUpperBound = isRestrictedByUpperBound && candidateDigit == maximumAllowedDigit;

                if (!hasStartedBuildingNumber && candidateDigit == 0)
                {
                    var childResult = CalculateWavinessUsingDigitDp(currentDigitPosition + 1, remainsRestrictedByUpperBound, false, 0, 0, 0);

                    totalNumbersGenerated += childResult.TotalNumbersGenerated;
                    accumulatedWaviness += childResult.TotalWaviness;

                    continue;
                }

                if (!hasStartedBuildingNumber)
                {
                    var childResult = CalculateWavinessUsingDigitDp(currentDigitPosition + 1, remainsRestrictedByUpperBound, true, 1, candidateDigit, 0);

                    totalNumbersGenerated += childResult.TotalNumbersGenerated;
                    accumulatedWaviness += childResult.TotalWaviness;

                    continue;
                }

                long wavinessContributionFromCurrentDigit = 0;

                if (constructedNumberLength >= 2)
                {
                    bool formsLocalPeak = previousDigit > digitBeforePrevious && previousDigit > candidateDigit;

                    bool formsLocalValley = previousDigit < digitBeforePrevious &&  previousDigit < candidateDigit;

                    if (formsLocalPeak || formsLocalValley)
                    {
                        wavinessContributionFromCurrentDigit = 1;
                    }
                }

                var childResult = CalculateWavinessUsingDigitDp(currentDigitPosition + 1, remainsRestrictedByUpperBound, true, constructedNumberLength + 1, candidateDigit, previousDigit);

                totalNumbersGenerated += childResult.TotalNumbersGenerated;

                accumulatedWaviness += childResult.TotalWaviness + wavinessContributionFromCurrentDigit * childResult.TotalNumbersGenerated;
            }

            var currentStateResult = new WavinessComputationResult(totalNumbersGenerated, accumulatedWaviness);

            if (!isRestrictedByUpperBound)
            {
                var dpState = new DigitDpState(currentDigitPosition, hasStartedBuildingNumber, constructedNumberLength, previousDigit, digitBeforePrevious);

                memoizedStates[dpState] = currentStateResult;
            }

            return currentStateResult;
        }

        private readonly record struct DigitDpState(int CurrentDigitPosition, bool HasStartedBuildingNumber, int ConstructedNumberLength, int PreviousDigit, int DigitBeforePrevious);

        private readonly record struct WavinessComputationResult(long TotalNumbersGenerated, long TotalWaviness);
    }
}