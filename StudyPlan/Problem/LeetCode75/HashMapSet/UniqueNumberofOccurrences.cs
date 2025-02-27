namespace StudyPlan.Problem.LeetCode75.HashMapSet
{
    public class UniqueNumberofOccurrences
    {
        public bool UniqueOccurrences(int[] array)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach(int number in array)
            {
                if(frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }

                else
                {
                    frequency[number] = 1;
                }

            }

            HashSet<int> seen = new HashSet<int>();
            foreach(int count in frequency.Values)
            {
                if(seen.Contains(count))
                {
                    return false;
                }

                seen.Add(count);
            }

            return true;
        }
    }
}