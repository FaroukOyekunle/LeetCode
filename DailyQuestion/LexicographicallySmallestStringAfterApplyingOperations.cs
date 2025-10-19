namespace DailyQuestion
{
    public class LexicographicallySmallestStringAfterApplyingOperations
    {
        public string FindLexSmallestString(string s, int a, int b)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            string result = s;

            queue.Enqueue(s);
            visited.Add(s);

            while(queue.Count > 0)
            {
                var currentSet = queue.Dequeue();
                if(string.Compare(currentSet, result, StringComparison.Ordinal) < 0)
                {
                    result = currentSet;
                }

                char[] currentCharacterSet = currentSet.ToCharArray();

                for(int i = 1; i < currentCharacterSet.Length; i += 2)
                {
                    int digit = (currentCharacterSet[i] - '0' + a) % 10;
                    currentCharacterSet[i] = (char)('0' + digit);
                }

                string addNewSet = new string(currentCharacterSet);

                if(!visited.Contains(addNewSet))
                {
                    visited.Add(addNewSet);
                    queue.Enqueue(addNewSet);
                }

                string rotate = currentSet.Substring(currentSet.Length - b) + currentSet.Substring(0, currentSet.Length - b);
                
                if(!visited.Contains(rotate))
                {
                    visited.Add(rotate);
                    queue.Enqueue(rotate);
                }
            }

            return result;
        }
    }
}