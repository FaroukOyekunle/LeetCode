namespace DailyQuestion
{
    public class GreatestSumDivisiblebyThree
    {
        public int MaxSumDivThree(int[] nums)
        {
            int totalSum = 0;
            List<int> mod1List = new List<int>();
            List<int> mod2List = new List<int>();

            foreach(var value in nums)
            {
                totalSum += value;

                if(value % 3 == 1)
                {
                    mod1List.Add(value);
                }

                else if(value % 3 == 2)
                {
                    mod2List.Add(value);
                }
            }

            if(totalSum % 3 == 0)
            {
                return totalSum;
            }

            mod1List.Sort();
            mod2List.Sort();

            int remainder = totalSum % 3;
            int removeOption1 = int.MaxValue;
            int removeOption2 = int.MaxValue;

            if(remainder == 1)
            {
                if(mod1List.Count >= 1)
                {
                    removeOption1 = mod1List[0];
                }

                if(mod2List.Count >= 2)
                {
                    removeOption2 = mod2List[0] + mod2List[1];
                }
            }

            else
            {
                if(mod2List.Count >= 1)
                {
                    removeOption1 = mod2List[0];
                }

                if(mod1List.Count >= 2)
                {
                    removeOption2 = mod1List[0] + mod1List[1];
                }
            }

            int amountToRemove = Math.Min(removeOption1, removeOption2);

            if(amountToRemove == int.MaxValue)
            {
                return 0;
            }

            return totalSum - amountToRemove;
        }
    }
}