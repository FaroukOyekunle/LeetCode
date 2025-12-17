namespace DailyQuestion
{
    public class MaximumProfitfromTradingStockswithDiscounts
    {
        public int MaxProfit(int totalNodes, int[] presentCosts, int[] futureProfits, int[][] hierarchyTree, int availableBudget)
        {
            List<int>[] childNodes = new List<int>[totalNodes + 1];
            
            for (int nodeIndex = 0; nodeIndex <= totalNodes; nodeIndex++) 
            {
                childNodes[nodeIndex] = new List<int>();
            }

            foreach(var edge in hierarchyTree)
            {
                childNodes[edge[0]].Add(edge[1]);
            }

            int NEGATIVE_INFINITY = -1_000_000_000;

            (int[] dpWithoutParent, int[] dpWithParent) DepthFirstSearch(int currentNode)
            {
                int[] dpNotBought = new int[availableBudget + 1];
                int[] dpBought = new int[availableBudget + 1];

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpNotBought[budgetIndex] = NEGATIVE_INFINITY;
                    dpBought[budgetIndex] = NEGATIVE_INFINITY;
                }

                dpNotBought[0] = 0;
                dpBought[0] = 0;

                List<int> currentChildren = childNodes[currentNode];

                int[] currentDpNotBought = new int[availableBudget + 1];
                for (int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    currentDpNotBought[budgetIndex] = dpNotBought[budgetIndex];
                }

                int[] currentDpParentBought = new int[availableBudget + 1];

                for (int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    currentDpParentBought[budgetIndex] = dpBought[budgetIndex];
                }

                foreach(int childNode in currentChildren)
                {
                    var (childDpWithoutParent, childDpWithParent) = DepthFirstSearch(childNode);

                    currentDpNotBought = MergeKnapsack(currentDpNotBought, childDpWithoutParent, availableBudget, NEGATIVE_INFINITY);

                    currentDpParentBought = MergeKnapsack(currentDpParentBought, childDpWithoutParent, availableBudget, NEGATIVE_INFINITY);
                }

                int fullCost = presentCosts[currentNode - 1];
                int halfCost = presentCosts[currentNode - 1] / 2;
                int profitWithoutParent = futureProfits[currentNode - 1] - fullCost;
                int profitWithParent = futureProfits[currentNode - 1] - halfCost;

                int[] dpBuyWithoutParent = new int[availableBudget + 1];

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpBuyWithoutParent[budgetIndex] = NEGATIVE_INFINITY;
                }

                if(fullCost <= availableBudget)
                {
                    dpBuyWithoutParent[fullCost] = profitWithoutParent;

                    foreach(int childNode in currentChildren)
                    {
                        var (childDpWithoutParent, childDpWithParent) = DepthFirstSearch(childNode);

                        dpBuyWithoutParent = MergeKnapsack(dpBuyWithoutParent, childDpWithParent, availableBudget, NEGATIVE_INFINITY);
                    }
                }

                int[] dpBuyWithParent = new int[availableBudget + 1];

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpBuyWithParent[budgetIndex] = NEGATIVE_INFINITY;
                }

                if(halfCost <= availableBudget)
                {
                    dpBuyWithParent[halfCost] = profitWithParent;

                    foreach(int childNode in currentChildren)
                    {
                        var (childDpWithoutParent, childDpWithParent) = DepthFirstSearch(childNode);
                        dpBuyWithParent = MergeKnapsack(dpBuyWithParent, childDpWithParent, availableBudget, NEGATIVE_INFINITY);
                    }
                }

                int[] dpParentNotBought = new int[availableBudget + 1];
                int[] dpParentBought = new int[availableBudget + 1];

                for (int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpParentNotBought[budgetIndex] = Math.Max(currentDpNotBought[budgetIndex], dpBuyWithoutParent[budgetIndex]);
                    dpParentBought[budgetIndex] = Math.Max(currentDpParentBought[budgetIndex], dpBuyWithParent[budgetIndex]);
                }

                return (dpParentNotBought, dpParentBought);
            }

            Dictionary<int, (int[] dpWithoutParent, int[] dpWithParent)> cachedResults = new Dictionary<int, (int[], int[])>();

            (int[] dpWithoutParent, int[] dpWithParent) DepthFirstSearchCached(int currentNode)
            {
                if (cachedResults.ContainsKey(currentNode)) 
                {
                    return cachedResults[currentNode];
                }

                int[] dpNotBought = new int[availableBudget + 1];
                int[] dpParentBought = new int[availableBudget + 1];
                int NEGATIVE_INFINITY_LOCAL = NEGATIVE_INFINITY;

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpNotBought[budgetIndex] = NEGATIVE_INFINITY_LOCAL;
                    dpParentBought[budgetIndex] = NEGATIVE_INFINITY_LOCAL;
                }
                dpNotBought[0] = 0;
                dpParentBought[0] = 0;

                List<int> currentChildren = childNodes[currentNode];

                foreach(int childNode in currentChildren)
                {
                    var (childDpWithoutParent, childDpWithParent) = DepthFirstSearchCached(childNode);
                    dpNotBought = MergeKnapsack(dpNotBought, childDpWithoutParent, availableBudget, NEGATIVE_INFINITY_LOCAL);
                    dpParentBought = MergeKnapsack(dpParentBought, childDpWithoutParent, availableBudget, NEGATIVE_INFINITY_LOCAL);
                }

                int fullCost = presentCosts[currentNode - 1];
                int halfCost = presentCosts[currentNode - 1] / 2;
                int profitWithoutParent = futureProfits[currentNode - 1] - fullCost;
                int profitWithParent = futureProfits[currentNode - 1] - halfCost;

                int[] dpBuyWithoutParent = new int[availableBudget + 1];
                int[] dpBuyWithParent = new int[availableBudget + 1];

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpBuyWithoutParent[budgetIndex] = NEGATIVE_INFINITY_LOCAL;
                    dpBuyWithParent[budgetIndex] = NEGATIVE_INFINITY_LOCAL;
                }

                if(fullCost <= availableBudget)
                {
                    dpBuyWithoutParent[fullCost] = profitWithoutParent;

                    foreach(int childNode in currentChildren)
                    {
                        var (childDpWithoutParent, childDpWithParent) = DepthFirstSearchCached(childNode);
                        dpBuyWithoutParent = MergeKnapsack(dpBuyWithoutParent, childDpWithParent, availableBudget, NEGATIVE_INFINITY_LOCAL);
                    }
                }

                if(halfCost <= availableBudget)
                {
                    dpBuyWithParent[halfCost] = profitWithParent;
                    foreach(int childNode in currentChildren)
                    {
                        var (childDpWithoutParent, childDpWithParent) = DepthFirstSearchCached(childNode);
                        dpBuyWithParent = MergeKnapsack(dpBuyWithParent, childDpWithParent, availableBudget, NEGATIVE_INFINITY_LOCAL);
                    }
                }

                int[] dpParentNotBought = new int[availableBudget + 1];
                int[] dpParentBought = new int[availableBudget + 1];

                for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
                {
                    dpParentNotBought[budgetIndex] = Math.Max(dpNotBought[budgetIndex], dpBuyWithoutParent[budgetIndex]);
                    dpParentBought[budgetIndex] = Math.Max(dpParentBought[budgetIndex], dpBuyWithParent[budgetIndex]);
                }

                cachedResults[currentNode] = (dpParentNotBought, dpParentBought);
                return (dpParentNotBought, dpParentBought);
            }

            var rootDp = DepthFirstSearchCached(1).dpWithoutParent;

            int maximumProfit = 0;
            for(int budgetIndex = 0; budgetIndex <= availableBudget; budgetIndex++)
            {
                maximumProfit = Math.Max(maximumProfit, rootDp[budgetIndex]);
            }

            return maximumProfit;
        }

        private static int[] MergeKnapsack(int[] parentKnapsack, int[] childKnapsack, int maxBudget, int negativeInfinity)
        {
            int[] mergedKnapsack = new int[maxBudget + 1];
            for(int budgetIndex = 0; budgetIndex <= maxBudget; budgetIndex++)
            {
                mergedKnapsack[budgetIndex] = negativeInfinity;
            }

            for(int parentBudget = 0; parentBudget <= maxBudget; parentBudget++)
            {
                if (parentKnapsack[parentBudget] <= negativeInfinity / 2) 
                {
                    continue;
                }

                int parentValue = parentKnapsack[parentBudget];
                int remainingBudget = maxBudget - parentBudget;

                for(int childBudget = 0; childBudget <= remainingBudget; childBudget++)
                {
                    if (childKnapsack[childBudget] <= negativeInfinity / 2) 
                    {
                        continue;
                    }

                    int combinedValue = parentValue + childKnapsack[childBudget];
                    int totalBudget = parentBudget + childBudget;

                    if (combinedValue > mergedKnapsack[totalBudget])
                    {
                        mergedKnapsack[totalBudget] = combinedValue;
                    }
                }
            }
            return mergedKnapsack;
        }
    }
}