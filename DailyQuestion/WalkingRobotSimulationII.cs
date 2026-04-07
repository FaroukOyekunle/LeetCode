namespace DailyQuestion
{
    /**
    * Your Robot object will be instantiated and called as such:
    * Robot obj = new Robot(width, height);
    * obj.Step(num);
    * int[] param_2 = obj.GetPos();
    * string param_3 = obj.GetDir();
    */

    public class WalkingRobotSimulationII
    {
        private int gridWidth;
        private int gridHeight;
        private int currentX;
        private int currentY;
        private int currentDirectionIndex; 

        private readonly int[][] directionVectors = new int[][]
        {
            new int[] {1, 0},   
            new int[] {0, 1},   
            new int[] {-1, 0}, 
            new int[] {0, -1}   
        };

        private readonly string[] directionNames = { "East", "North", "West", "South" };

        private int perimeterCycleLength;

        public Robot(int width, int height)
        {
            gridWidth = width;
            gridHeight = height;

            currentX = 0;
            currentY = 0;

            currentDirectionIndex = 0;

            perimeterCycleLength = 2 * (gridWidth + gridHeight - 2);
        }

        public void Step(int stepsToMove)
        {
            stepsToMove %= perimeterCycleLength;

            if (stepsToMove == 0)
            {
                stepsToMove = perimeterCycleLength;
            }

            while (stepsToMove > 0)
            {
                int nextX = currentX + directionVectors[currentDirectionIndex][0];
                int nextY = currentY + directionVectors[currentDirectionIndex][1];

                if (nextX < 0 || nextX >= gridWidth || nextY < 0 || nextY >= gridHeight)
                {
                    currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                    continue;
                }

                currentX = nextX;
                currentY = nextY;

                stepsToMove--;
            }
        }

        public int[] GetPos()
        {
            return new int[] { currentX, currentY };
        }

        public string GetDir()
        {
            return directionNames[currentDirectionIndex];
        }
    }
}