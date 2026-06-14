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

    public class MaximumTwinSumofaLinkedList
    {
        public int GetMaximumTwinSum(ListNode head)
        {
            if (head == null)
            {
                return 0;
            }

            ListNode slowTraversalPointer = head;
            ListNode fastTraversalPointer = head;

            while (fastTraversalPointer != null && fastTraversalPointer.next != null)
            {
                slowTraversalPointer = slowTraversalPointer.next;
                fastTraversalPointer = fastTraversalPointer.next.next;
            }

            ListNode previousNodeInReversedHalf = null;
            ListNode currentNodeInSecondHalf = slowTraversalPointer;

            while (currentNodeInSecondHalf != null)
            {
                ListNode nextNodeToProcess = currentNodeInSecondHalf.next;

                currentNodeInSecondHalf.next = previousNodeInReversedHalf;

                previousNodeInReversedHalf = currentNodeInSecondHalf;
                currentNodeInSecondHalf = nextNodeToProcess;
            }

            int maximumTwinPairSum = 0;

            ListNode pointerFromStartOfList = head;
            ListNode pointerFromReversedSecondHalf = previousNodeInReversedHalf;

            while (pointerFromReversedSecondHalf != null)
            {
                int currentTwinSum = pointerFromStartOfList.val + pointerFromReversedSecondHalf.val;

                maximumTwinPairSum = Math.Max(maximumTwinPairSum, currentTwinSum);

                pointerFromStartOfList = pointerFromStartOfList.next;

                pointerFromReversedSecondHalf = pointerFromReversedSecondHalf.next;
            }

            return maximumTwinPairSum;
        }
    }
}