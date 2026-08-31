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

    public class FindtheMinimumandMaximumNumberofNodesBetweenCriticalPoints
    {
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            int currentNodePosition = 1;

            int firstCriticalPointPosition = -1;
            int previousCriticalPointPosition = -1;

            int minimumCriticalPointDistance = int.MaxValue;
            int maximumCriticalPointDistance = -1;

            ListNode previousNode = head;
            ListNode currentNode = head.next;

            while (currentNode.next != null)
            {
                ListNode nextNode = currentNode.next;

                bool isCurrentNodeLocalMaximum = currentNode.val > previousNode.val && currentNode.val > nextNode.val;

                bool isCurrentNodeLocalMinimum = currentNode.val < previousNode.val && currentNode.val < nextNode.val;

                bool isCurrentNodeCriticalPoint = isCurrentNodeLocalMaximum || isCurrentNodeLocalMinimum;

                if (isCurrentNodeCriticalPoint)
                {
                    if (firstCriticalPointPosition == -1)
                    {
                        firstCriticalPointPosition = currentNodePosition;
                    }
                    else
                    {
                        int distanceFromPreviousCriticalPoint = currentNodePosition - previousCriticalPointPosition;

                        minimumCriticalPointDistance = Math.Min(minimumCriticalPointDistance, distanceFromPreviousCriticalPoint);

                        maximumCriticalPointDistance = currentNodePosition - firstCriticalPointPosition;
                    }

                    previousCriticalPointPosition = currentNodePosition;
                }

                previousNode = currentNode;
                currentNode = nextNode;
                currentNodePosition++;
            }

            bool foundFewerThanTwoCriticalPoints = previousCriticalPointPosition == -1 || firstCriticalPointPosition == previousCriticalPointPosition;

            if (foundFewerThanTwoCriticalPoints)
            {
                return new[] { -1, -1 };
            }

            return new[]
            {
                minimumCriticalPointDistance,
                maximumCriticalPointDistance
            };
        }
    }
}