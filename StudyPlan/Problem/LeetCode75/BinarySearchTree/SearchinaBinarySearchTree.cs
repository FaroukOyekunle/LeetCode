namespace StudyPlan.Problem.LeetCode75.BinarySearchTree
{
    public class SearchinaBinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val) 
        {
            while(root != null) 
            {

                if(root.val == val) 
                {
                    return root;
                } 
                
                else if(val < root.val) 
                {
                    root = root.left;
                } 
                
                else 
                {
                    root = root.right;
                }
            }
            
            return null;
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