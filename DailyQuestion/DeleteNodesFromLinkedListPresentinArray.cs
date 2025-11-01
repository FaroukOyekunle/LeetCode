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

    public class DeleteNodesFromLinkedListPresentinArray
    {
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            var toRemove = new HashSet<int>(nums);
            var dummy = new ListNode(0, head);
            var current = dummy;

            while(current.next != null)
            {
                if(toRemove.Contains(current.next.val))
                {
                    current.next = current.next.next;
                }

                else
                {
                    current = current.next;
                }
            }

            return dummy.next;
        }
    }
}