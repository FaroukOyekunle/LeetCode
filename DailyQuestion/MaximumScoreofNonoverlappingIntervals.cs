using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyQuestion
{
    public class MaximumScoreofNonoverlappingIntervals
    {
        public int[] MaximumWeight(IList<IList<int>> intervalList)
        {
            const int maximumIntervalsToSelect = 4;

            var intervalIndexBySortedKey = new SortedDictionary<(int endPosition, int startPosition, int weight), int>();

            for (int intervalIndex = 0; intervalIndex < intervalList.Count; intervalIndex++)
            {
                int startPosition = intervalList[intervalIndex][0];
                int endPosition = intervalList[intervalIndex][1];
                int intervalWeight = intervalList[intervalIndex][2];

                var intervalKey = (endPosition, startPosition, intervalWeight);

                if (!intervalIndexBySortedKey.ContainsKey(intervalKey))
                {
                    intervalIndexBySortedKey[intervalKey] = intervalIndex;
                }
            }

            var sortedIntervals = intervalIndexBySortedKey.Keys.ToList();

            var dynamicProgrammingStates = new State[sortedIntervals.Count + 1, maximumIntervalsToSelect + 1];

            for (int intervalPosition = 0; intervalPosition <= sortedIntervals.Count; intervalPosition++)
            {
                for (int selectedIntervalCount = 0; selectedIntervalCount <= maximumIntervalsToSelect; selectedIntervalCount++)
                {
                    dynamicProgrammingStates[intervalPosition, selectedIntervalCount] = new State(0, new List<int>());
                }
            }

            for (int intervalPosition = 0; intervalPosition < sortedIntervals.Count; intervalPosition++)
            {
                var currentInterval = sortedIntervals[intervalPosition];

                int currentIntervalStartPosition = currentInterval.startPosition;
                int currentIntervalWeight = currentInterval.weight;
                int currentOriginalIndex = intervalIndexBySortedKey[currentInterval];

                int previousNonOverlappingIntervalPosition = FindUpperBound(sortedIntervals, (currentIntervalStartPosition, 0, 0)) - 1;

                for (int selectedIntervalCount = 1; selectedIntervalCount <= maximumIntervalsToSelect; selectedIntervalCount++)
                {
                    State stateWithoutCurrentInterval = dynamicProgrammingStates[intervalPosition, selectedIntervalCount];

                    State stateBeforeCurrentInterval = dynamicProgrammingStates[previousNonOverlappingIntervalPosition + 1, selectedIntervalCount - 1];

                    var selectedIntervalIndices = new List<int>(stateBeforeCurrentInterval.Indices);

                    selectedIntervalIndices.Add(currentOriginalIndex);
                    selectedIntervalIndices.Sort();

                    var stateWithCurrentInterval = new State(stateBeforeCurrentInterval.Score - currentIntervalWeight, selectedIntervalIndices);

                    dynamicProgrammingStates[intervalPosition + 1, selectedIntervalCount] = GetBetterState(stateWithoutCurrentInterval, stateWithCurrentInterval);
                }
            }

            return dynamicProgrammingStates[sortedIntervals.Count, maximumIntervalsToSelect].Indices.ToArray();
        }

        private class State
        {
            public long Score { get; }
            public List<int> Indices { get; }

            public State(long score, List<int> selectedIntervalIndices)
            {
                Score = score;
                Indices = selectedIntervalIndices;
            }
        }

        private static State GetBetterState(State firstState, State secondState)
        {
            if (firstState.Score < secondState.Score)
            {
                return firstState;
            }

            if (firstState.Score > secondState.Score)
            {
                return secondState;
            }

            return IsLexicographicallySmaller(firstState.Indices, secondState.Indices) ? firstState : secondState;
        }

        private static bool IsLexicographicallySmaller(IList<int> firstIndexList, IList<int> secondIndexList)
        {
            int comparisonLength = Math.Min(firstIndexList.Count, secondIndexList.Count);

            for (int currentIndex = 0; currentIndex < comparisonLength; currentIndex++)
            {
                if (firstIndexList[currentIndex] < secondIndexList[currentIndex])
                {
                    return true;
                }

                if (firstIndexList[currentIndex] > secondIndexList[currentIndex])
                {
                    return false;
                }
            }

            return firstIndexList.Count < secondIndexList.Count;
        }

        private static int FindUpperBound(List<(int endPosition, int startPosition, int weight)> sortedIntervals, (int endPosition, int startPosition, int weight) targetInterval)
        {
            int searchStartIndex = 0;
            int searchEndIndex = sortedIntervals.Count;

            while (searchStartIndex < searchEndIndex)
            {
                int middleIndex = searchStartIndex + (searchEndIndex - searchStartIndex) / 2;

                if (sortedIntervals[middleIndex].CompareTo(targetInterval) <= 0)
                {
                    searchStartIndex = middleIndex + 1;
                }
                else
                {
                    searchEndIndex = middleIndex;
                }
            }

            return searchStartIndex;
        }
    }
}