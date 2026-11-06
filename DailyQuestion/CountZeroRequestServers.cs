using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class CountZeroRequestServers
    {
        public int[] CountServers(int totalServerCount, int[][] requestLogs, int timeWindowLength, int[] queryTimes)
        {
            Array.Sort(requestLogs, (firstLog, secondLog) => firstLog[1].CompareTo(secondLog[1]));

            int[][] sortedQueriesWithOriginalIndices = new int[queryTimes.Length][];

            for (int queryIndex = 0; queryIndex < queryTimes.Length; queryIndex++)
            {
                sortedQueriesWithOriginalIndices[queryIndex] = new int[]
                {
                    queryTimes[queryIndex],
                    queryIndex
                };
            }

            Array.Sort(sortedQueriesWithOriginalIndices, (firstQuery, secondQuery) => firstQuery[0].CompareTo(secondQuery[0]));

            int[] inactiveServerCountsByQuery = new int[queryTimes.Length];

            Dictionary<int, int> serverRequestCounts = new Dictionary<int, int>();

            int leftLogIndex = 0;
            int rightLogIndex = 0;

            int activeServerCount = 0;

            foreach (int[] sortedQuery in sortedQueriesWithOriginalIndices)
            {
                int currentQueryTime = sortedQuery[0];
                int originalQueryIndex = sortedQuery[1];

                int requestWindowStartTime = currentQueryTime - timeWindowLength;

                while (rightLogIndex < requestLogs.Length && requestLogs[rightLogIndex][1] <= currentQueryTime)
                {
                    int currentServerId = requestLogs[rightLogIndex][0];

                    if (!serverRequestCounts.ContainsKey(currentServerId))
                    {
                        serverRequestCounts[currentServerId] = 0;
                        activeServerCount++;
                    }

                    serverRequestCounts[currentServerId]++;

                    rightLogIndex++;
                }

                while (leftLogIndex < rightLogIndex && requestLogs[leftLogIndex][1] < requestWindowStartTime)
                {
                    int expiredRequestServerId = requestLogs[leftLogIndex][0];

                    serverRequestCounts[expiredRequestServerId]--;

                    if (serverRequestCounts[expiredRequestServerId] == 0)
                    {
                        serverRequestCounts.Remove(expiredRequestServerId);
                        activeServerCount--;
                    }

                    leftLogIndex++;
                }

                inactiveServerCountsByQuery[originalQueryIndex] = totalServerCount - activeServerCount;
            }

            return inactiveServerCountsByQuery;
        }
    }
}