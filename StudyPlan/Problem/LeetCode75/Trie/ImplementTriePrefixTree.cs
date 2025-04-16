namespace StudyPlan.Problem.LeetCode75.Trie
{
    public class ImplementTriePrefixTree
    {
        private class Node 
        {
            public Node[] children = new Node[26];
            public bool isWord = false;
        }

        private readonly Node root;

        public Trie() 
        {
            root = new Node();
        }
    
        public void Insert(string word) 
        {
            var node = root;

            foreach(char c in word) 
            {
                int idx = c - 'a';

                if(node.children[idx] == null) 
                {
                    node.children[idx] = new Node();
                }

                node = node.children[idx];
            }

            node.isWord = true;
        }
    
        public bool Search(string word) 
        {
            var node = root;

            foreach(char c in word) 
            {
                int idx = c - 'a';

                if(node.children[idx] == null)
                {
                    return false;
                } 

                node = node.children[idx];
            }

            return node.isWord;
        }
    
        public bool StartsWith(string prefix) 
        {
            var node = root;

            foreach(char c in prefix) 
            {
                int idx = c - 'a';

                if(node.children[idx] == null)
                {
                    return false;
                } 

                node = node.children[idx];
            }

            return true;
        }
    }
}