namespace StudyPlan.Problem.LeetCode75.BinaryTree-DFS
{
    public class PathSumIII
    {
        public int PathSum(TreeNode root, int targetSum)
        {

            Dictionary<long, int> prefixSumMap = new Dictionary<long, int>();
            prefixSumMap[0] = 1;

            return DFS(root, 0, targetSum, prefixSumMap);
        }

        private int DFS(TreeNode node, long currentSum, int target, Dictionary<long, int> prefixSumMap)
        {
            if (node == null)
            {
                return 0;
            }

            currentSum += node.val;

            int pathCount = prefixSumMap.ContainsKey(currentSum - target) ? prefixSumMap[currentSum - target] : 0;

            if(!prefixSumMap.ContainsKey(currentSum))
            {
                prefixSumMap[currentSum] = 0;
            }
            
            prefixSumMap[currentSum]++;

            pathCount += DFS(node.left, currentSum, target, prefixSumMap);
            pathCount += DFS(node.right, currentSum, target, prefixSumMap);
            prefixSumMap[currentSum]--;

            return pathCount;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}