namespace DailyQuestion
{
    /**
    * Definition for a binary tree node.
    * public class TreeNode {
    *     public int val;
    *     public TreeNode left;
    *     public TreeNode right;
    *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    *         this.val = val;
    *         this.left = left;
    *         this.right = right;
    *     }
    * }
    */
    public class BalanceaBinarySearchTree
    {
        public TreeNode BalanceBinarySearchTree(TreeNode rootNode)
        {
            var inorderNodes = new List<TreeNode>();

            PerformInorderTraversal(rootNode, inorderNodes);

            return ConstructBalancedBinarySearchTree(inorderNodes, 0, inorderNodes.Count - 1);
        }

        private void PerformInorderTraversal(TreeNode currentNode, List<TreeNode> inorderNodes)
        {
            if (currentNode == null)
            {
                return;
            }

            PerformInorderTraversal(currentNode.left, inorderNodes);
            inorderNodes.Add(currentNode);
            PerformInorderTraversal(currentNode.right, inorderNodes);
        }

        private TreeNode ConstructBalancedBinarySearchTree(List<TreeNode> inorderNodes, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
            {
                return null;
            }

            int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            TreeNode rootNode = inorderNodes[middleIndex];

            rootNode.left = ConstructBalancedBinarySearchTree(inorderNodes, leftIndex, middleIndex - 1);
            rootNode.right = ConstructBalancedBinarySearchTree(inorderNodes, middleIndex + 1, rightIndex);

            return rootNode;
        }
    }
}