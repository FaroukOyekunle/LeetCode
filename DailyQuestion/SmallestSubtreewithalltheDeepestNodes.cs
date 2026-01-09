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

    public class SmallestSubtreewithalltheDeepestNodes
    {
        public TreeNode SubtreeWithAllDeepest(TreeNode rootNode)
        {
            return FindDeepestSubtree(rootNode).deepestNode;
        }

        private (TreeNode deepestNode, int maximumDepth) FindDeepestSubtree(TreeNode currentNode) 
        {
            if(currentNode == null)
            {
                return (null, 0);
            }

            var leftSubtree = FindDeepestSubtree(currentNode.left);
            var rightSubtree = FindDeepestSubtree(currentNode.right);

            if (leftSubtree.maximumDepth > rightSubtree.maximumDepth)
            {
                return (leftSubtree.deepestNode, leftSubtree.maximumDepth + 1);
            }

            if (rightSubtree.maximumDepth > leftSubtree.maximumDepth)
            {
                return (rightSubtree.deepestNode, rightSubtree.maximumDepth + 1);
            }

            return (currentNode, leftSubtree.maximumDepth + 1);
        }
    }
}