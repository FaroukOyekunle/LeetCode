namespace DailyQuestion
{
    public class FindAllPeopleWithSecret
    {
        public IList<int> FindAllPeople(int totalPeople, int[][] meetingDetails, int initialPerson)
        {
            bool[] secretKnowledge = new bool[totalPeople];
            secretKnowledge[0] = true;
            secretKnowledge[initialPerson] = true;

            Array.Sort(meetingDetails, (firstMeeting, secondMeeting) => firstMeeting[2].CompareTo(secondMeeting[2]));

            int meetingIndex = 0;
            while(meetingIndex < meetingDetails.Length)
            {
                int currentTime = meetingDetails[meetingIndex][2];

                Dictionary<int, List<int>> meetingGraph = new Dictionary<int, List<int>>();
                HashSet<int> currentParticipants = new HashSet<int>();

                while(meetingIndex < meetingDetails.Length && meetingDetails[meetingIndex][2] == currentTime)
                {
                    int personA = meetingDetails[meetingIndex][0];
                    int personB = meetingDetails[meetingIndex][1];

                    if(!meetingGraph.ContainsKey(personA))
                    {
                        meetingGraph[personA] = new List<int>();
                    }

                    if(!meetingGraph.ContainsKey(personB))
                    {
                        meetingGraph[personB] = new List<int>();
                    }

                    meetingGraph[personA].Add(personB);
                    meetingGraph[personB].Add(personA);

                    currentParticipants.Add(personA);
                    currentParticipants.Add(personB);
                    meetingIndex++;
                }

                Queue<int> processingQueue = new Queue<int>();
                HashSet<int> visitedPeople = new HashSet<int>();

                foreach(int participant in currentParticipants)
                {
                    if(secretKnowledge[participant])
                    {
                        processingQueue.Enqueue(participant);
                        visitedPeople.Add(participant);
                    }
                }

                while(processingQueue.Count > 0)
                {
                    int currentPerson = processingQueue.Dequeue();
                    foreach(int neighbor in meetingGraph[currentPerson])
                    {
                        if(!visitedPeople.Contains(neighbor))
                        {
                            visitedPeople.Add(neighbor);
                            secretKnowledge[neighbor] = true;
                            processingQueue.Enqueue(neighbor);
                        }
                    }
                }
            }

            List<int> peopleWithSecret = new List<int>();

            for(int personIndex = 0; personIndex < totalPeople; personIndex++)
            {
                if(secretKnowledge[personIndex])
                {
                    peopleWithSecret.Add(personIndex);
                }
            }

            return peopleWithSecret;
        }
    }
}