namespace StudyPlan.Problem.LeetCode75.LinkedList
{
    public class DeletetheMiddleNodeofaLinkedList
    {
        public ListNode DeleteMiddle(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;
            ListNode prev = null;

            while(fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = slow.next;

            return head;
        }
    }
}