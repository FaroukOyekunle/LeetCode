namespace DailyQuestion
{
    public class WaterBottles
    {
        public int NumWaterBottles(int numBottles, int numExchange) 
        {
            int drank = numBottles;
            int empty = numBottles;

            while(empty >= numExchange) 
            {
                int exchanged = empty / numExchange;
                drank += exchanged;
                empty = exchanged + (empty % numExchange);
            }

            return drank;
        }   
    }
}