namespace StudyPlan.Problem.LeetCode75.BinaryTree-BFS
{
    public class MaximumLevelSumofaBinaryTree
    {
        public int MaxLevelSum(TreeNode root) 
        {
            if (root == null)
            {
                return 0;
            } 
        
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            int level = 1;
            int ansLevel = 1;
            long maxSum = root.val; 
            
            while(queue.Count > 0) 
            {
                int levelSize = queue.Count;
                long currentSum = 0;
                
                for(int i = 0; i < levelSize; i++) 
                {
                    TreeNode node = queue.Dequeue();
                    currentSum += node.val;
                    
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    } 

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    } 
                }
                
                if(currentSum > maxSum) 
                {
                    maxSum = currentSum;
                    ansLevel = level;
                }
                
                level++;
            }
        
            return ansLevel;
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