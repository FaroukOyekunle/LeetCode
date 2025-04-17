namespace StudyPlan.Problem.LeetCode75.Trie
{
    public class SearchSuggestionsSystem
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) 
        {
    
            Array.Sort(products, StringComparer.Ordinal);

            int n = products.Length;
            var result = new List<IList<string>>(searchWord.Length);

            string prefix = "";
            
            for(int i = 0; i < searchWord.Length; i++) 
            {
                prefix += searchWord[i];
                int idx = LowerBound(products, prefix);
                
                var suggestions = new List<string>(3);

                for(int j = idx; j < n && suggestions.Count < 3; j++) 
                {
                    if(products[j].Length >= prefix.Length && products[j].StartsWith(prefix, StringComparison.Ordinal)) 
                    {
                        suggestions.Add(products[j]);
                    } 
                    
                    else 
                    {
                        break;
                    }
                }

                result.Add(suggestions);
            }

            return result;
        }

        private int LowerBound(string[] arr, string target) 
        {
            int lo = 0, hi = arr.Length;
            
            while(lo < hi) 
            {
                int mid = (lo + hi) / 2;
                if (StringComparer.Ordinal.Compare(arr[mid], target) < 0) 
                {
                    lo = mid + 1;
                } 
                
                else 
                {
                    hi = mid;
                }
            }
            return lo;
        }
    }
}