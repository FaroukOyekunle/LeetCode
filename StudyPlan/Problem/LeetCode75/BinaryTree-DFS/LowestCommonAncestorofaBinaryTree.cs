namespace StudyPlan.Problem.LeetCode75.BinaryTree-DFS
{
    public class LowestCommonAncestorofaBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) 
        {
            if (root == null || root == p || root == q) 
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            } 
            return left ?? right;
        }
    }

    public class TreeNode 
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
}