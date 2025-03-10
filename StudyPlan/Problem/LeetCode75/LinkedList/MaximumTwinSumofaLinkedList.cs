namespace StudyPlan.Problem.LeetCode75.LinkedList
{
    public class MaximumTwinSumofaLinkedList
    {
        public int PairSum(ListNode head)
        {
            ListNode slow = head, fast = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode prev = null;
            ListNode curr = slow;

            while(curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }

            int maxSum = 0;
            ListNode first = head, second = prev;

            while(second != null)
            {
                maxSum = Math.Max(maxSum, first.val + second.val);
                first = first.next;
                second = second.next;
            }

            return maxSum;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}