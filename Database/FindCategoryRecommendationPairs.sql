# Write your MySQL query statement below

WITH user_categories AS (
    SELECT DISTINCT pp.user_id, pi.category
    FROM ProductPurchases pp
    JOIN ProductInfo pi ON pp.product_id = pi.product_id
),
category_pairs AS (
    SELECT 
        uc1.user_id,
        LEAST(uc1.category, uc2.category) AS category1,
        GREATEST(uc1.category, uc2.category) AS category2
    FROM user_categories uc1
    JOIN user_categories uc2 
        ON uc1.user_id = uc2.user_id 
        AND uc1.category < uc2.category
)
SELECT 
    category1,
    category2,
    COUNT(DISTINCT user_id) AS customer_count
FROM category_pairs
GROUP BY category1, category2
HAVING customer_count >= 3
ORDER BY customer_count DESC, category1 ASC, category2 ASC;