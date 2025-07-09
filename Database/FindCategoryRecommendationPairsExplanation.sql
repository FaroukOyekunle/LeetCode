✅ Explanation

1.  user_categories CTE:

    *   Retrieves distinct (user_id, category) pairs by joining ProductPurchases with ProductInfo.

2.  category_pairs CTE:

    *   For each user, forms unique category pairs (category1, category2) such that category1 < category2 to avoid duplicates like (A,B) and (B,A).


3.  Main Query:

    *   I counts how many distinct users purchased products from both categories.

    *   Then filters only pairs with at least 3 users using HAVING customer_count >= 3.

    *   Finally i then orders by customer_count DESC, then category1 ASC, and category2 ASC.