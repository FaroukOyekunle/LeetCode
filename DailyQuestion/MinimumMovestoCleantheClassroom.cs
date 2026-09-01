namespace DailyQuestion
{
    public class MinimumMovestoCleantheClassroom
    {
        public int MinMoves(string[] classroom, int maximumEnergy)
        {
            int classroomRowCount = classroom.Length;
            int classroomColumnCount = classroom[0].Length;

            var litterPositions = new List<(int Row, int Column)>();

            int startingRow = 0;
            int startingColumn = 0;

            for (int rowIndex = 0; rowIndex < classroomRowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < classroomColumnCount; columnIndex++)
                {
                    char currentCell = classroom[rowIndex][columnIndex];

                    if (currentCell == 'S')
                    {
                        startingRow = rowIndex;
                        startingColumn = columnIndex;
                    }
                    else if (currentCell == 'L')
                    {
                        litterPositions.Add((rowIndex, columnIndex));
                    }
                }
            }

            int totalLitterCount = litterPositions.Count;

            if (totalLitterCount == 0)
            {
                return 0;
            }

            var litterBitMaskByPosition = new Dictionary<(int Row, int Column), int>();

            for (int litterIndex = 0; litterIndex < totalLitterCount; litterIndex++)
            {
                var litterPosition = litterPositions[litterIndex];

                litterBitMaskByPosition[litterPosition] = 1 << litterIndex;
            }

            int allLitterCollectedMask = (1 << totalLitterCount) - 1;

            var statesToVisit = new Queue<(int Row, int Column, int RemainingEnergy, int CollectedLitterMask, int MoveCount)>();

            bool[,,,] visitedStates = new bool[classroomRowCount, classroomColumnCount, maximumEnergy + 1, 1 << totalLitterCount];

            statesToVisit.Enqueue((startingRow, startingColumn, maximumEnergy, 0, 0));

            visitedStates[startingRow, startingColumn, maximumEnergy, 0] = true;

            int[] rowMovementDirections = { -1, 1, 0, 0 };
            int[] columnMovementDirections = { 0, 0, -1, 1 };

            while (statesToVisit.Count > 0)
            {
                var currentState = statesToVisit.Dequeue();

                int currentRow = currentState.Row;
                int currentColumn = currentState.Column;
                int currentRemainingEnergy = currentState.RemainingEnergy;
                int currentCollectedLitterMask = currentState.CollectedLitterMask;
                int currentMoveCount = currentState.MoveCount;

                for (int directionIndex = 0; directionIndex < 4; directionIndex++)
                {
                    int nextRow = currentRow + rowMovementDirections[directionIndex];

                    int nextColumn = currentColumn + columnMovementDirections[directionIndex];

                    bool isOutsideClassroom = nextRow < 0 || nextRow >= classroomRowCount || nextColumn < 0 || nextColumn >= classroomColumnCount;

                    if (isOutsideClassroom)
                    {
                        continue;
                    }

                    if (classroom[nextRow][nextColumn] == 'X')
                    {
                        continue;
                    }

                    if (currentRemainingEnergy == 0)
                    {
                        continue;
                    }

                    int nextRemainingEnergy = currentRemainingEnergy - 1;

                    int nextCollectedLitterMask = currentCollectedLitterMask;

                    char nextCell = classroom[nextRow][nextColumn];

                    if (nextCell == 'L')
                    {
                        int collectedLitterBit = litterBitMaskByPosition[(nextRow, nextColumn)];

                        nextCollectedLitterMask |= collectedLitterBit;
                    }

                    if (nextCell == 'R')
                    {
                        nextRemainingEnergy = maximumEnergy;
                    }

                    int nextMoveCount = currentMoveCount + 1;

                    if (nextCollectedLitterMask == allLitterCollectedMask)
                    {
                        return nextMoveCount;
                    }

                    if (visitedStates[nextRow, nextRemainingEnergy, nextCollectedLitterMask])
                    {
                        continue;
                    }

                    visitedStates[nextRow, nextColumn, nextRemainingEnergy, nextCollectedLitterMask] = true;

                    statesToVisit.Enqueue((nextRow, nextColumn, nextRemainingEnergy, nextCollectedLitterMask, nextMoveCount));
                }
            }

            return -1;
        }
    }
}