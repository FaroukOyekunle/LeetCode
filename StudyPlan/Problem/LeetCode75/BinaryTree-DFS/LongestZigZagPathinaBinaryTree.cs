namespace StudyPlan.Problem.LeetCode75.BinaryTree-DFS
{
    public class LongestZigZagPathinaBinaryTree
    {
        private int maxZigZag = 0;

        public int LongestZigZag(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            } 

            DFS(root.left, 1, true);  
            DFS(root.right, 1, false); 
            return maxZigZag;
        }

        private void DFS(TreeNode node, int length, bool isLeft) 
        {
            if (node == null)
            {
                return;
            }

            maxZigZag = Math.Max(maxZigZag, length);

            if(isLeft) 
            {
                DFS(node.left, 1, true);  
                DFS(node.right, length + 1, false); 
            } 
            
            else 
            {
                DFS(node.right, 1, false);
                DFS(node.left, length + 1, true);
            }
        }   
    }

    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) 
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}