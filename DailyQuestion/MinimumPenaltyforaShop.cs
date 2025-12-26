namespace DailyQuestion
{
    public class MinimumPenaltyforaShop
    {
        public int BestClosingTime(string customerVisitPattern)
        {
            int totalYesCustomers = 0;
            
            foreach(char customer in customerVisitPattern)
            {
                if(customer == 'Y') 
                {
                    totalYesCustomers++;
                }
            }

            int currentPenalty = totalYesCustomers; 
            int minimumPenalty = currentPenalty;
            int optimalClosingHour = 0;

            for(int hourIndex = 0; hourIndex < customerVisitPattern.Length; hourIndex++)
            {
                if(customerVisitPattern[hourIndex] == 'Y')
                {
                    currentPenalty--;   
                }

                else
                {
                    currentPenalty++;
                }

                if(currentPenalty < minimumPenalty)
                {
                    minimumPenalty = currentPenalty;
                    optimalClosingHour = hourIndex + 1;
                }
            }

            return optimalClosingHour;
        }
    }
}