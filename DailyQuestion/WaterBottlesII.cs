namespace DailyQuestion
{
    public class WaterBottlesII
    {
        public int MaxBottlesDrunk(int numBottles, int numberExchange)
        {
            int drunk = numBottles;  
            int empty = numBottles;  
            
            while(empty >= numberExchange)
            {
                empty -= numberExchange;
                numberExchange++;
                
                drunk++;
                empty++; 
            }
            
            return drunk;
        }
    }
}