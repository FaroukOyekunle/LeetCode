namespace DailyQuestion
{
    public class TwoBestNonOverlappingEvents
    {
        public int MaxTwoEvents(int[][] eventDetails)
        {
            Array.Sort(eventDetails, (firstEvent, secondEvent) => firstEvent[0].CompareTo(secondEvent[0]));

            var eventQueue = new PriorityQueue<int[], int>();

            int maximumValueSoFar = 0;
            int maximumEventValue = 0;

            foreach(var currentEvent in eventDetails)
            {
                int eventStartTime = currentEvent[0];
                int eventEndTime = currentEvent[1];
                int eventValue = currentEvent[2];

                while(eventQueue.Count > 0 && eventQueue.Peek()[1] < eventStartTime)
                {
                    var completedEvent = eventQueue.Dequeue();
                    maximumValueSoFar = Math.Max(maximumValueSoFar, completedEvent[2]);
                }

                maximumEventValue = Math.Max(maximumEventValue, maximumValueSoFar + eventValue);

                maximumEventValue = Math.Max(maximumEventValue, eventValue);

                eventQueue.Enqueue(currentEvent, eventEndTime);
            }

            return maximumEventValue;
        }
    }
}