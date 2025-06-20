✅ Explanation

1.   OrderedStocks CTE: Assigns a ROW_NUMBER() to each operation per stock separately for 'Buy' and 'Sell', ordered by day. This helps us pair the first Buy with the first Sell, second Buy with second Sell, etc.

2.   BuySellPairs CTE: Joins Buy and Sell rows by:

    -   Same stock_name

    -   Same rn (row number to ensure correct chronological pairing)

    -   Matching operations ('Buy' vs. 'Sell')

3.  Final query: Groups by stock_name and sums up the gain/loss per pair.