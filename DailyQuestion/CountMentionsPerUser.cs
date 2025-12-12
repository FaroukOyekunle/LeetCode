namespace DailyQuestion
{
    public class CountMentionsPerUser
    {
        public int[] CountMentions(int userCount, IList<IList<string>> events)
        {
            int[] mentionCounts = new int[userCount];
            int[] userOfflineUntilTimes = new int[userCount];

            var sortedEvents = new List<(string EventType, int EventTimestamp, string EventPayload, int OriginalOrder)>();
            for (int eventIndex = 0; eventIndex < events.Count; eventIndex++)
            {
                var currentEvent = events[eventIndex];
                string eventType = currentEvent[0];
                int eventTimestamp = int.Parse(currentEvent[1]);
                string eventPayload = currentEvent[2];
                sortedEvents.Add((eventType, eventTimestamp, eventPayload, eventIndex));
            }

            sortedEvents.Sort((firstEvent, secondEvent) =>
            {
                if (firstEvent.EventTimestamp != secondEvent.EventTimestamp)
                {
                    return firstEvent.EventTimestamp - secondEvent.EventTimestamp;
                }

                int firstPriority = firstEvent.EventType == "OFFLINE" ? 0 : 1;
                int secondPriority = secondEvent.EventType == "OFFLINE" ? 0 : 1;

                if (firstPriority != secondPriority)
                {
                    return firstPriority - secondPriority;
                }

                return firstEvent.OriginalOrder - secondEvent.OriginalOrder;
            });

            int lastProcessedTimestamp = int.MinValue;

            foreach (var processedEvent in sortedEvents)
            {
                int currentTimestamp = processedEvent.EventTimestamp;

                if (currentTimestamp != lastProcessedTimestamp)
                {
                    for (int userIndex = 0; userIndex < userCount; userIndex++)
                    {
                        if (userOfflineUntilTimes[userIndex] != 0 && currentTimestamp >= userOfflineUntilTimes[userIndex])
                        {
                            userOfflineUntilTimes[userIndex] = 0;
                        }
                    }
                    lastProcessedTimestamp = currentTimestamp;
                }

                if (processedEvent.EventType == "OFFLINE")
                {
                    int userId = int.Parse(processedEvent.EventPayload);

                    userOfflineUntilTimes[userId] = currentTimestamp + 60;
                }
                else
                {
                    var mentionTokens = processedEvent.EventPayload.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var mentionToken in mentionTokens)
                    {
                        if (mentionToken == "ALL")
                        {
                            for (int userIndex = 0; userIndex < userCount; userIndex++) mentionCounts[userIndex]++;
                        }

                        else if (mentionToken == "HERE")
                        {
                            for (int userIndex = 0; userIndex < userCount; userIndex++)
                            {
                                if (userOfflineUntilTimes[userIndex] == 0)
                                {
                                    mentionCounts[userIndex]++;
                                }
                            }
                        }
                        
                        else if (mentionToken.StartsWith("id"))
                        {
                            int userId = int.Parse(mentionToken.Substring(2));
                            mentionCounts[userId]++;
                        }
                    }
                }
            }

            return mentionCounts;
        }
    }
}