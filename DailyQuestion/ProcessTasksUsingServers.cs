using System;
using System.Linq;

namespace DailyQuestion
{
    public class ProcessTasksUsingServers
    {
        public int[] AssignTasks(int[] serverWeights, int[] taskProcessingTimes)
        {
            int totalServerCount = serverWeights.Length;
            int totalTaskCount = taskProcessingTimes.Length;

            int[] assignedServerIndices = new int[totalTaskCount];

            PriorityQueue<int, (int ServerWeight, int ServerIndex)> availableServers = new();

            PriorityQueue<(int ServerIndex, long AvailableTime), (long AvailableTime, int ServerWeight, int ServerIndex)> busyServers = new();

            for (int serverIndex = 0; serverIndex < totalServerCount; serverIndex++)
            {
                availableServers.Enqueue(serverIndex, (serverWeights[serverIndex], serverIndex));
            }

            long currentProcessingTime = 0;

            for (int taskIndex = 0; taskIndex < totalTaskCount; taskIndex++)
            {
                currentProcessingTime = Math.Max(currentProcessingTime, taskIndex);

                while (busyServers.Count > 0 && busyServers.Peek().AvailableTime <= currentProcessingTime)
                {
                    var releasedServer = busyServers.Dequeue();

                    availableServers.Enqueue(releasedServer.ServerIndex, (serverWeights[releasedServer.ServerIndex], releasedServer.ServerIndex));
                }

                if (availableServers.Count == 0)
                {
                    currentProcessingTime = busyServers.Peek().AvailableTime;

                    while (busyServers.Count > 0 && busyServers.Peek().AvailableTime <= currentProcessingTime)
                    {
                        var releasedServer = busyServers.Dequeue();

                        availableServers.Enqueue(releasedServer.ServerIndex, (serverWeights[releasedServer.ServerIndex], releasedServer.ServerIndex));
                    }
                }

                int selectedServerIndex = availableServers.Dequeue();

                assignedServerIndices[taskIndex] = selectedServerIndex;

                long serverAvailableTime = currentProcessingTime + taskProcessingTimes[taskIndex];

                busyServers.Enqueue((selectedServerIndex, serverAvailableTime), (serverAvailableTime, serverWeights[selectedServerIndex], selectedServerIndex));
            }

            return assignedServerIndices;
        }
    }
}