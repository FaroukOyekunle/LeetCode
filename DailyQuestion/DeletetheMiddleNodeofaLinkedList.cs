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

    public class DeletetheMiddleNodeofaLinkedList
    {
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return null;
            }

            ListNode nodeBeforeMiddle = null;

            ListNode slowPointerForMiddleDetection = head;

            ListNode fastPointerForTraversal = head;

            while (fastPointerForTraversal != null && fastPointerForTraversal.next != null)
            {
                nodeBeforeMiddle = slowPointerForMiddleDetection;

                slowPointerForMiddleDetection = slowPointerForMiddleDetection.next;

                fastPointerForTraversal = fastPointerForTraversal.next.next;
            }

            nodeBeforeMiddle.next = slowPointerForMiddleDetection.next;

            return head;
        }
    }
}