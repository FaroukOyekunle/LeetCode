namespace StudyPlan.Problem.LeetCode75.BinaryTree-DFS
{
    public class CountGoodNodesinBinaryTree
    {
        public int GoodNodes(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            }
        
            return Dfs(root, root.val);
        }

        private int Dfs(TreeNode node, int maxSoFar) 
        {
            if(node == null)
            {
                return 0;
            }
            
            int count = (node.val >= maxSoFar) ? 1 : 0;
            
            maxSoFar = Math.Max(maxSoFar, node.val);
            
            count += Dfs(node.left, maxSoFar);
            count += Dfs(node.right, maxSoFar);
            
            return count;
        }
    }

    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}