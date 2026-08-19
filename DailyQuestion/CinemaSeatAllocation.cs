namespace DailyQuestion
{
    public class CinemaSeatAllocation
    {
        public int MaxNumberOfFamilies(int totalRowCount, int[][] reservedSeats)
        {
            const int LeftFamilySeatMask = (1 << 2) | (1 << 3) | (1 << 4) | (1 << 5);
            const int MiddleFamilySeatMask = (1 << 4) | (1 << 5) | (1 << 6) | (1 << 7);
            const int RightFamilySeatMask = (1 << 6) | (1 << 7) | (1 << 8) | (1 << 9);

            Dictionary<int, int> reservedSeatMaskByRow = new();

            foreach (int[] reservation in reservedSeats)
            {
                int reservedRowNumber = reservation[0];
                int reservedSeatNumber = reservation[1];

                if (reservedSeatNumber >= 2 && reservedSeatNumber <= 9)
                {
                    reservedSeatMaskByRow.TryAdd(reservedRowNumber, 0);

                    reservedSeatMaskByRow[reservedRowNumber] |= 1 << reservedSeatNumber;
                }
            }

            int maximumFamilyCount = (totalRowCount - reservedSeatMaskByRow.Count) * 2;

            foreach (int reservedSeatMask in reservedSeatMaskByRow.Values)
            {
                bool leftFamilyBlockIsAvailable = (reservedSeatMask & LeftFamilySeatMask) == 0;

                bool middleFamilyBlockIsAvailable = (reservedSeatMask & MiddleFamilySeatMask) == 0;

                bool rightFamilyBlockIsAvailable = (reservedSeatMask & RightFamilySeatMask) == 0;

                if (leftFamilyBlockIsAvailable && rightFamilyBlockIsAvailable)
                {
                    maximumFamilyCount += 2;
                }
                else if (leftFamilyBlockIsAvailable || middleFamilyBlockIsAvailable || rightFamilyBlockIsAvailable)
                {
                    maximumFamilyCount++;
                }
            }

            return maximumFamilyCount;
        }
    }
}