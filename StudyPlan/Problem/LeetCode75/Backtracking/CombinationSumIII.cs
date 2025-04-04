namespace StudyPlan.Problem.LeetCode75.Backtracking
{
    public class CombinationSumIII
    {
        public IList<IList<int>> CombinationSum3(int k, int n) 
        {
            List<IList<int>> result = new List<IList<int>>();
            Backtrack(1, k, n, new List<int>(), result);
            return result;
        }

        private void Backtrack(int start, int k, int remaining, List<int> combination, List<IList<int>> result) 
        {
            if (k == 0 && remaining == 0) 
            {
                result.Add(new List<int>(combination));
                return;
            }

            if(k == 0 || remaining < 0)
            {
                return;
            } 

            for(int i = start; i <= 9; i++) 
            {
                combination.Add(i);
                Backtrack(i + 1, k - 1, remaining - i, combination, result);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}