namespace StudyPlan.Problem.LeetCode75.Heap-PriorityQueue
{
    public class TotalCosttoHireKWorkers
    {
        public long TotalCost(int[] costs, int k, int candidates) 
        {
    
            int n = costs.Length;
            long totalCost = 0;
            
            int left = 0, right = n - 1;
            
            PriorityQueue<(int cost, int idx), (int cost, int idx)> leftPQ = new PriorityQueue<(int, int), (int, int)>();

            PriorityQueue<(int cost, int idx), (int cost, int idx)> rightPQ = new PriorityQueue<(int, int), (int, int)>();

            for(int i = 0; i < candidates && left <= right; i++) 
            {
                leftPQ.Enqueue((costs[left], left), (costs[left], left));
                left++;
            }

            for(int i = 0; i < candidates && left <= right; i++) 
            {
                rightPQ.Enqueue((costs[right], right), (costs[right], right));
                right--;
            }
            
            for(int session = 0; session < k; session++) 
            {
                if(leftPQ.Count > 0 && rightPQ.Count > 0) 
                {
                    var leftCandidate = leftPQ.Peek();
                    var rightCandidate = rightPQ.Peek();
                    
                    if(leftCandidate.cost <= rightCandidate.cost) 
                    {
                        var chosen = leftPQ.Dequeue();
                        totalCost += chosen.cost;

                        if(left <= right) 
                        {
                            leftPQ.Enqueue((costs[left], left), (costs[left], left));
                            left++;
                        }
                    } 
                    
                    else 
                    {
                        var chosen = rightPQ.Dequeue();
                        totalCost += chosen.cost;

                        if(left <= right) 
                        {
                            rightPQ.Enqueue((costs[right], right), (costs[right], right));
                            right--;
                        }
                    }
                } 

                else if(leftPQ.Count > 0) 
                {
                    var chosen = leftPQ.Dequeue();
                    totalCost += chosen.cost;

                    if(left <= right) 
                    {
                        leftPQ.Enqueue((costs[left], left), (costs[left], left));
                        left++;
                    }
                } 

                else if(rightPQ.Count > 0) 
                {
                    var chosen = rightPQ.Dequeue();
                    totalCost += chosen.cost;

                    if(left <= right) 
                    {
                        rightPQ.Enqueue((costs[right], right), (costs[right], right));
                        right--;
                    }
                }
            }
            
            return totalCost;
        }
    }
}