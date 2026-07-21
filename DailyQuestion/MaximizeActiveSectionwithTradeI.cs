namespace DailyQuestion
{
    public class MaximizeActiveSectionwithTradeI
    {
        public int MaxActiveSectionsAfterTrade(string binarySectionState)
        {
            int initialActiveSectionCount = 0;

            foreach (char currentSectionState in binarySectionState)
            {
                if (currentSectionState == '1')
                {
                    initialActiveSectionCount++;
                }
            }

            string sectionStateWithBoundarySentinels = "1" + binarySectionState + "1";

            List<char> consecutiveSectionStates = new();
            List<int> consecutiveSectionLengths = new();

            foreach (char currentSectionState in sectionStateWithBoundarySentinels)
            {
                if (consecutiveSectionStates.Count == 0 || consecutiveSectionStates[consecutiveSectionStates.Count - 1] != currentSectionState)
                {
                    consecutiveSectionStates.Add(currentSectionState);
                    consecutiveSectionLengths.Add(1);
                }
                else
                {
                    consecutiveSectionLengths[consecutiveSectionLengths.Count - 1]++;
                }
            }

            int maximumAdditionalActiveSectionCount = 0;

            for (int currentRunIndex = 1; currentRunIndex < consecutiveSectionStates.Count - 1; currentRunIndex++)
            {
                if (consecutiveSectionStates[currentRunIndex] != '1')
                {
                    continue;
                }

                if (consecutiveSectionStates[currentRunIndex - 1] == '0' && consecutiveSectionStates[currentRunIndex + 1] == '0')
                {
                    int additionalActiveSectionsFromTrade = consecutiveSectionLengths[currentRunIndex - 1] + consecutiveSectionLengths[currentRunIndex + 1];

                    maximumAdditionalActiveSectionCount = Math.Max(maximumAdditionalActiveSectionCount, additionalActiveSectionsFromTrade);
                }
            }

            return initialActiveSectionCount + maximumAdditionalActiveSectionCount;
        }
    }
}