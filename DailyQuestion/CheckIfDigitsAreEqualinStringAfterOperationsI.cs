namespace DailyQuestion
{
    public class CheckIfDigitsAreEqualinStringAfterOperationsI
    {
        public bool HasSameDigits(string s)
        {
            while(s.Length > 2)
            {
                char[] next = new char[s.Length - 1];
                
                for(int i = 0; i < s.Length - 1; i++)
                {
                    int sum = ((s[i] - '0') + (s[i + 1] - '0')) % 10;
                    next[i] = (char)(sum + '0');
                }
                
                s = new string(next);
            }

            return s[0] == s[1];
        }
    }
}