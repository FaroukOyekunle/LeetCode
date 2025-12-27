namespace DailyQuestion
{
    public class MeetingRoomsIII
    {
        public int MostBooked(int totalRooms, int[][] meetingSchedule)
        {
            Array.Sort(meetingSchedule, (firstMeeting, secondMeeting) => firstMeeting[0].CompareTo(secondMeeting[0]));

            var availableRoomQueue = new PriorityQueue<int, int>();

            for(int roomIndex = 0; roomIndex < totalRooms; roomIndex++) 
            {
                availableRoomQueue.Enqueue(roomIndex, roomIndex);
            }

            var ongoingMeetingQueue = new PriorityQueue<(long meetingEndTime, int roomIndex), (long meetingEndTime, int roomIndex)>();

            int[] roomUsageCount = new int[totalRooms];

            foreach(var currentMeeting in meetingSchedule) 
            {
                int meetingStartTime = currentMeeting[0], meetingEndTime = currentMeeting[1];
                int meetingDuration = meetingEndTime - meetingStartTime;

                while(ongoingMeetingQueue.Count > 0 && ongoingMeetingQueue.Peek().meetingEndTime <= meetingStartTime) 
                {
                    var (roomFreeTime, roomIndex) = ongoingMeetingQueue.Dequeue();
                    availableRoomQueue.Enqueue(roomIndex, roomIndex);
                }

                if(availableRoomQueue.Count > 0) 
                {
                    int roomIndex = availableRoomQueue.Dequeue();
                    ongoingMeetingQueue.Enqueue((meetingStartTime + meetingDuration, roomIndex), (meetingStartTime + meetingDuration, roomIndex));
                    roomUsageCount[roomIndex]++;
                }

                else 
                {
                    var (roomFreeTime, roomIndex) = ongoingMeetingQueue.Dequeue();
                    ongoingMeetingQueue.Enqueue((roomFreeTime + meetingDuration, roomIndex), (roomFreeTime + meetingDuration, roomIndex));
                    roomUsageCount[roomIndex]++;
                }
            }

            int mostUsedRoomIndex = 0;
            for(int roomIndex = 1; roomIndex < totalRooms; roomIndex++) 
            {
                if(roomUsageCount[roomIndex] > roomUsageCount[mostUsedRoomIndex]) 
                {
                    mostUsedRoomIndex = roomIndex;
                }
            }

            return mostUsedRoomIndex;
        }
    }
}