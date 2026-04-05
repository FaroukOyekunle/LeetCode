namespace DailyQuestion
{
    public class RobotReturntoOrigin
    {
        public bool DoesRobotReturnToOrigin(string movementSequence)
        {
            int currentXPosition = 0;
            int currentYPosition = 0;

            foreach (char movementDirection in movementSequence)
            {
                switch (movementDirection)
                {
                    case 'U': 
                        currentYPosition++;
                        break;

                    case 'D': 
                        currentYPosition--;
                        break;

                    case 'R': 
                        currentXPosition++;
                        break;

                    case 'L': 
                        currentXPosition--;
                        break;
                }
            }

            return currentXPosition == 0 && currentYPosition == 0;
        }
    }
}