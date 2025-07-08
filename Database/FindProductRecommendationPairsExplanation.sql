✅ Explanation

1.  Self-Join on ProductPurchases table:

    -   I join the table to itself on the same user_id to find all combinations of products a customer bought.

    -   The condition p1.product_id < p2.product_id ensures distinct and ordered product pairs without duplicates or reverse pairs (i.e., avoids (102, 101) if (101, 102)
        exists).

2.  Join with ProductInfo:

    -   I join each product in the pair (p1.product_id and p2.product_id) with the ProductInfo table to get their categories.

3.  Group by product pairs:

    -   I group by the product pair to count the number of distinct customers who bought both.

4.  Filter pairs:

    -   I only include product pairs with at least 3 distinct customers who purchased both.

5.  Ordering:

    -   Then the results are ordered by customer_count DESC, and in case of ties, by product1_id ASC, product2_id ASC.