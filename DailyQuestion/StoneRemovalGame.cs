using System;

namespace DailyQuestion
{
    public class StoneRemovalGame
    {

        public bool CanAliceWin(int totalNumberOfStones)
        {
            int stonesRequiredForCurrentTurn = 10;
            bool isAliceTurn = true;

            while (totalNumberOfStones >= stonesRequiredForCurrentTurn)
            {
                totalNumberOfStones -= stonesRequiredForCurrentTurn;
                stonesRequiredForCurrentTurn--;

                isAliceTurn = !isAliceTurn;
            }

            return !isAliceTurn;
        }
    }
}