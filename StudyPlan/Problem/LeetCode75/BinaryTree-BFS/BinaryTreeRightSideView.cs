namespace StudyPlan.Problem.LeetCode75.BinaryTree-BFS
{
    public class BinaryTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root) 
        {
            List<int> result = new List<int>();

            if(root == null)
            {
                return result;
            }
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            while(queue.Count > 0) 
            {
                int levelCount = queue.Count;

                for(int i = 0; i < levelCount; i++) 
                {
                    TreeNode node = queue.Dequeue();
                    
                    if(i == levelCount - 1) 
                    {
                        result.Add(node.val);
                    }
                    
                    if(node.left != null) 
                    {
                        queue.Enqueue(node.left);
                    }

                    if(node.right != null) 
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            
            return result;
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