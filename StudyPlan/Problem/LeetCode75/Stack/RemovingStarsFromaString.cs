namespace StudyPlan.Problem.LeetCode75.Stack
{
    public class RemovingStarsFromaString
    {
        public string RemoveStars(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach(char c in s)
            {
                if(c == '*')
                {
                    if(sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }

                else
                {
                    sb.Append(c);
                }
            }
            
            return sb.ToString();
        }
    }
}