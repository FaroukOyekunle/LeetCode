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

    public class MaximumProductofSplittedBinaryTree
    {
        private const int MODULO = 1_000_000_007;
        private long maximumProduct = 0;
        private long totalTreeSum = 0;

        public int MaxProduct(TreeNode rootNode)
        {
            totalTreeSum = CalculateTotalTreeSum(rootNode);

            ComputeSubtreeSumAndMaxProduct(rootNode);

            return (int)(maximumProduct % MODULO);
        }

        private long CalculateTotalTreeSum(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            return currentNode.val + CalculateTotalTreeSum(currentNode.left) + CalculateTotalTreeSum(currentNode.right);
        }

        private long ComputeSubtreeSumAndMaxProduct(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return 0;
            }

            long leftSubtreeSum = ComputeSubtreeSumAndMaxProduct(currentNode.left);
            long rightSubtreeSum = ComputeSubtreeSumAndMaxProduct(currentNode.right);

            long currentSubtreeSum = currentNode.val + leftSubtreeSum + rightSubtreeSum;

            long currentProduct = currentSubtreeSum * (totalTreeSum - currentSubtreeSum);
            maximumProduct = Math.Max(maximumProduct, currentProduct);

            return currentSubtreeSum;
        }
    }
}