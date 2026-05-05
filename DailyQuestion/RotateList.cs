namespace DailyQuestion
{

    /**
    * Definition for singly-linked list.
    * public class ListNode {
    *     public int val;
    *     public ListNode next;
    *     public ListNode(int val=0, ListNode next=null) {
    *         this.val = val;
    *         this.next = next;
    *     }
    * }
    */

    public class RotateList
    {
        public ListNode RotateLinkedListToRight(ListNode headNode, int rotationCount)
        {
            if (headNode == null || headNode.next == null || rotationCount == 0)
            {
                return headNode;
            }

            int totalNodeCount = 1;
            ListNode tailNode = headNode;

            while (tailNode.next != null)
            {
                tailNode = tailNode.next;
                totalNodeCount++;
            }

            int effectiveRotationCount = rotationCount % totalNodeCount;

            if (effectiveRotationCount == 0)
            {
                return headNode;
            }

            tailNode.next = headNode;

            int stepsToReachNewTail = totalNodeCount - effectiveRotationCount;
            ListNode newTailNode = headNode;

            for (int step = 1; step < stepsToReachNewTail; step++)
            {
                newTailNode = newTailNode.next;
            }

            ListNode newHeadNode = newTailNode.next;
            newTailNode.next = null;

            return newHeadNode;
        }
    }
}