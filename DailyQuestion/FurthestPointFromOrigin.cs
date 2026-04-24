namespace DailyQuestion
{
    public class FurthestPointFromOrigin
    {
        public int CalculateFurthestDistanceFromOrigin(string movementSequence)
        {
            int totalLeftMoves = 0;
            int totalRightMoves = 0;
            int totalFlexibleMoves = 0; 

            foreach (char currentMove in movementSequence)
            {
                if (currentMove == 'L')
                {
                    totalLeftMoves++;
                }
                else if (currentMove == 'R')
                {
                    totalRightMoves++;
                }
                else 
                {
                    totalFlexibleMoves++;
                }
            }

            int netDisplacement = totalRightMoves - totalLeftMoves;

            int maximumDistanceIfAllGoRight = Math.Abs(netDisplacement + totalFlexibleMoves);
            int maximumDistanceIfAllGoLeft = Math.Abs(netDisplacement - totalFlexibleMoves);

            return Math.Max(maximumDistanceIfAllGoRight, maximumDistanceIfAllGoLeft);
        }
    }
}