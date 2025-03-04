namespace StudyPlan.Problem.LeetCode75.Stack
{
    public class DecodeString
    {
        public string DekodeString(string s)
        {
            int index = 0;
            return Decode(s, ref index);
        }

        private string Decode(string s, ref int index)
        {
            StringBuilder result = new StringBuilder();

            while(index < s.Length && s[index] != ']')
            {
                if(char.IsDigit(s[index]))
                {
                    int count = 0;

                    while(index < s.Length && char.IsDigit(s[index]))
                    {
                        count = count * 10 + (s[index] - '0');
                        index++;
                    }

                    index++;

                    string decodedSubstring = Decode(s, ref index);

                    index++;

                    for(int i = 0; i < count; i++)
                    {
                        result.Append(decodedSubstring);
                    }
                }

                else
                {
                    result.Append(s[index]);
                    index++;
                }
            }

            return result.ToString();
        }
    }
}