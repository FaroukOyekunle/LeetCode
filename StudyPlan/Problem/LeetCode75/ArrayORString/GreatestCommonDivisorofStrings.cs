namespace StudyPlan.Problem.LeetCode75.ArrayORString
{
    public class GreatestCommonDivisorofStrings
    {
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1)
            {
                return "";
            }

            int gcdLength = GCD(str1.Length, str2.Length);

            return str1.Substring(0, gcdLength);
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}