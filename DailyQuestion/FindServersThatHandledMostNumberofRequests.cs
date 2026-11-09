using System;
using System.Linq;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class FindServersThatHandledMostNumberofRequests
    {
        public IList<int> BusiestServers(int totalServerCount, int[] requestArrivalTimes, int[] requestProcessingTimes)
        {
            int totalRequestCount = requestArrivalTimes.Length;

            int[] requestCountByServer = new int[totalServerCount];

            SortedSet<int> availableServerIds = new SortedSet<int>(Enumerable.Range(0, totalServerCount));

            PriorityQueue<int, long> busyServersByCompletionTime = new PriorityQueue<int, long>();

            for (int currentRequestIndex = 0; currentRequestIndex < totalRequestCount; currentRequestIndex++)
            {
                int currentRequestArrivalTime = requestArrivalTimes[currentRequestIndex];

                while (busyServersByCompletionTime.TryPeek(out int releasedServerId, out long earliestRequestCompletionTime) && earliestRequestCompletionTime <= currentRequestArrivalTime)
                {
                    busyServersByCompletionTime.Dequeue();
                    availableServerIds.Add(releasedServerId);
                }

                if (availableServerIds.Count == 0)
                {
                    continue;
                }

                int preferredServerId = currentRequestIndex % totalServerCount;

                var availableServerEnumerator = availableServerIds.GetViewBetween(preferredServerId, totalServerCount - 1).GetEnumerator();

                int assignedServerId;

                if (availableServerEnumerator.MoveNext())
                {
                    assignedServerId = availableServerEnumerator.Current;
                }
                else
                {
                    assignedServerId = availableServerIds.Min;
                }

                availableServerIds.Remove(assignedServerId);

                requestCountByServer[assignedServerId]++;

                long assignedRequestCompletionTime = (long)currentRequestArrivalTime + requestProcessingTimes[currentRequestIndex];

                busyServersByCompletionTime.Enqueue(assignedServerId, assignedRequestCompletionTime);
            }

            int maximumRequestsHandledByServer = requestCountByServer.Max();

            List<int> busiestServerIds = new List<int>();

            for (int serverId = 0; serverId < totalServerCount; serverId++)
            {
                if (requestCountByServer[serverId] == maximumRequestsHandledByServer)
                {
                    busiestServerIds.Add(serverId);
                }
            }

            return busiestServerIds;
        }
    }
}