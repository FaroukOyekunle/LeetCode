✅ Explanation:

*   I joined the sales and products tables using product_id.

* Then added a derived season column based on the month of the sale_date:

    *   Dec–Feb → Winter

    *   Mar–May → Spring

    *   Jun–Aug → Summer

    *   Sep–Nov → Fall

*   Lastly computes the revenue of each sale as quantity * price.

*   I groups the previous result by season and category.

*   For each combination, calculates:

    *   total_quantity: how many units were sold.

    *   total_revenue: total sales value (sum of individual revenues).

*   For each season i (PARTITION BY season):

*   Ranks the categories by:

    *   Highest total_quantity sold (primary sort).

    *   If tied, by total_revenue (secondary sort).

*   Uses RANK() window function to assign a ranking per season.

*   Finally i selects only the top category per season (i.e. rnk = 1).

*   Then Ordered the result by season name alphabetically (Fall, Spring, etc.).