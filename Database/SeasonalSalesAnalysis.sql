# Write your MySQL query statement below

WITH categorized_sales AS (
    SELECT 
        s.sale_id,
        p.category,
        s.quantity,
        s.price,
        s.quantity * s.price AS revenue,
        CASE 
            WHEN MONTH(s.sale_date) IN (12, 1, 2) THEN 'Winter'
            WHEN MONTH(s.sale_date) IN (3, 4, 5) THEN 'Spring'
            WHEN MONTH(s.sale_date) IN (6, 7, 8) THEN 'Summer'
            WHEN MONTH(s.sale_date) IN (9, 10, 11) THEN 'Fall'
        END AS season
    FROM sales s
    JOIN products p ON s.product_id = p.product_id
),
aggregated AS (
    SELECT 
        season,
        category,
        SUM(quantity) AS total_quantity,
        SUM(revenue) AS total_revenue
    FROM categorized_sales
    GROUP BY season, category
),
ranked AS (
    SELECT *,
           RANK() OVER (
               PARTITION BY season 
               ORDER BY total_quantity DESC, total_revenue DESC
           ) AS rnk
    FROM aggregated
)
SELECT 
    season,
    category,
    total_quantity,
    total_revenue
FROM ranked
WHERE rnk = 1
ORDER BY season;