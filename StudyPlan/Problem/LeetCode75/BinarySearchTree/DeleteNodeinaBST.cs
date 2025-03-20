namespace StudyPlan.Problem.LeetCode75.BinarySearchTree
{
    public class DeleteNodeinaBST
    {
        public TreeNode DeleteNode(TreeNode root, int key) 
        {
            if(root == null)
            {
                return null;
            }
            
            if(key < root.val) 
            {
                root.left = DeleteNode(root.left, key);
            }

            else if(key > root.val) 
            {
                root.right = DeleteNode(root.right, key);
            }

            else 
            {
                if(root.left == null)
                {
                    return root.right;
                }

                if(root.right == null)
                {
                    return root.left;
                }
                
                TreeNode successor = FindMin(root.right);

                root.val = successor.val;

                root.right = DeleteNode(root.right, successor.val);
            }
            
            return root;
        }

        private TreeNode FindMin(TreeNode node) 
        {
            while(node.left != null) 
            {
                node = node.left;
            }

            return node;
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