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

    public class MaximumLevelSumofaBinaryTree
    {
        public int MaxLevelSum(TreeNode rootNode)
        {
            if (rootNode == null) 
            {
                return 0;
            }
        
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(rootNode);
            int currentLevel = 1;
            int levelWithMaximumSum = 1;
            long maximumLevelSum = rootNode.val; 
        
            while (nodeQueue.Count > 0) 
            {
                int nodesAtCurrentLevel = nodeQueue.Count;
                long currentLevelSum = 0;
                
                for (int nodeIndex = 0; nodeIndex < nodesAtCurrentLevel; nodeIndex++) 
                {
                    TreeNode currentNode = nodeQueue.Dequeue();
                    currentLevelSum += currentNode.val;
                    if (currentNode.left != null) 
                    {
                        nodeQueue.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null) 
                    {
                        nodeQueue.Enqueue(currentNode.right);
                    }
                }
                
                if (currentLevelSum > maximumLevelSum) 
                {
                    maximumLevelSum = currentLevelSum;
                    levelWithMaximumSum = currentLevel;
                }
                
                currentLevel++;
            }
            
            return levelWithMaximumSum;
        }
    }
}