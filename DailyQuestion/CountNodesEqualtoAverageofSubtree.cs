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

    public class CountNodesEqualtoAverageofSubtree
    {
        public int AverageOfSubtree(TreeNode root)
        {
            int matchingNodeCount = 0;

            (int subtreeSum, int subtreeNodeCount) CalculateSubtreeStatistics(TreeNode currentNode)
            {
                if (currentNode == null)
                {
                    return (0, 0);
                }

                var leftSubtreeStatistics = CalculateSubtreeStatistics(currentNode.left);
                var rightSubtreeStatistics = CalculateSubtreeStatistics(currentNode.right);

                int currentSubtreeSum = currentNode.val + leftSubtreeStatistics.subtreeSum + rightSubtreeStatistics.subtreeSum;

                int currentSubtreeNodeCount = 1 + leftSubtreeStatistics.subtreeNodeCount + rightSubtreeStatistics.subtreeNodeCount;

                int currentSubtreeAverage = currentSubtreeSum / currentSubtreeNodeCount;

                if (currentNode.val == currentSubtreeAverage)
                {
                    matchingNodeCount++;
                }

                return (currentSubtreeSum, currentSubtreeNodeCount);
            }

            CalculateSubtreeStatistics(root);

            return matchingNodeCount;
        }
    }
}