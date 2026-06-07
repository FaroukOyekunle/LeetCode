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

    public class CreateBinaryTreeFromDescriptions
    {
        public TreeNode CreateBinaryTree(int[][] parentChildRelationships)
        {
            Dictionary<int, TreeNode> valueToNodeMap =new Dictionary<int, TreeNode>();

            HashSet<int> childNodeValues = new HashSet<int>();

            foreach (int[] relationship in parentChildRelationships)
            {
                int parentNodeValue = relationship[0];
                int childNodeValue = relationship[1];
                int isLeftChildIndicator = relationship[2];

                if (!valueToNodeMap.ContainsKey(parentNodeValue))
                {
                    valueToNodeMap[parentNodeValue] = new TreeNode(parentNodeValue);
                }

                if (!valueToNodeMap.ContainsKey(childNodeValue))
                {
                    valueToNodeMap[childNodeValue] = new TreeNode(childNodeValue);
                }

                TreeNode parentNode = valueToNodeMap[parentNodeValue];

                TreeNode childNode = valueToNodeMap[childNodeValue];

                if (isLeftChildIndicator == 1)
                {
                    parentNode.left = childNode;
                }
                else
                {
                    parentNode.right = childNode;
                }

                childNodeValues.Add(childNodeValue);
            }

            foreach (int nodeValue in valueToNodeMap.Keys)
            {
                bool isRootNode = !childNodeValues.Contains(nodeValue);

                if (isRootNode)
                {
                    return valueToNodeMap[nodeValue];
                }
            }

            return null;
        }
    }
}