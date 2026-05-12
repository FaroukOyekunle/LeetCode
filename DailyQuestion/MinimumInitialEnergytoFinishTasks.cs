namespace DailyQuestion
{
    public class MinimumInitialEnergytoFinishTasks
    {
        public int MinimumEffort(int[][] tasks)
        {
            Array.Sort(tasks, (firstTaskDetails, secondTaskDetails) =>
            {
                int firstTaskEnergyBuffer = firstTaskDetails[1] - firstTaskDetails[0];

                int secondTaskEnergyBuffer = secondTaskDetails[1] - secondTaskDetails[0];

                return secondTaskEnergyBuffer.CompareTo(firstTaskEnergyBuffer);
            });

            int minimumStartingEnergyNeeded = 0;

            int currentAvailableEnergy = 0;

            foreach (int[] taskDetails in tasks)
            {
                int actualEnergyConsumedByTask = taskDetails[0];

                int minimumEnergyNeededToStartTask = taskDetails[1];

                if (currentAvailableEnergy < minimumEnergyNeededToStartTask)
                {
                    int additionalEnergyRequired = minimumEnergyNeededToStartTask - currentAvailableEnergy;

                    minimumStartingEnergyNeeded += additionalEnergyRequired;

                    currentAvailableEnergy = minimumEnergyNeededToStartTask;
                }

                currentAvailableEnergy -= actualEnergyConsumedByTask;
            }

            return minimumStartingEnergyNeeded;
        }
    }
}