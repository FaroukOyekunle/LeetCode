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
    public class SumofRootToLeafBinaryNumbers
    {
        public int CalculateSumOfRootToLeafBinaryNumbers(TreeNode rootNode)
        {
            return PerformDepthFirstSearch(rootNode, 0);
        }

        private int PerformDepthFirstSearch(TreeNode currentNode, int accumulatedValue)
        {
            if (currentNode == null)
            {
                return 0;
            }

            accumulatedValue = (accumulatedValue << 1) | currentNode.val;

            if (currentNode.left == null && currentNode.right == null)
            {
                return accumulatedValue;
            }

            return PerformDepthFirstSearch(currentNode.left, accumulatedValue) + PerformDepthFirstSearch(currentNode.right, accumulatedValue);
        }
    }
}