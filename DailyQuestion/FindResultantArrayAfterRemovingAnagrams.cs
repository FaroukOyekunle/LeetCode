namespace DailyQuestion
{
    public class FindResultantArrayAfterRemovingAnagrams
    {
        public IList<string> RemoveAnagrams(string[] words)
        {
            var result = new List<string>();
            string previousSignature = "";

            foreach(var word in words)
            {
                var signature = new string(word.OrderBy(c => c).ToArray());

                if(signature != previousSignature)
                {
                    result.Add(word);
                    previousSignature = signature;
                }
            }

            return result;
        }
    }
}