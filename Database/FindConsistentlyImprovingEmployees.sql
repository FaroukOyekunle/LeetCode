# Write your MySQL query statement below

WITH RankedReviews AS (
    SELECT 
        pr.employee_id,
        pr.rating,
        pr.review_date,
        ROW_NUMBER() OVER (PARTITION BY pr.employee_id ORDER BY pr.review_date DESC) AS rn
    FROM performance_reviews pr
),
LastThree AS (
    SELECT * FROM RankedReviews
    WHERE rn <= 3
),
GroupedRatings AS (
    SELECT 
        employee_id,
        MAX(CASE WHEN rn = 1 THEN rating END) AS rating1,
        MAX(CASE WHEN rn = 2 THEN rating END) AS rating2,
        MAX(CASE WHEN rn = 3 THEN rating END) AS rating3
    FROM LastThree
    GROUP BY employee_id
),
ImprovedEmployees AS (
    SELECT 
        gr.employee_id,
        (rating1 - rating3) AS improvement_score
    FROM GroupedRatings gr
    WHERE rating3 < rating2 AND rating2 < rating1
)
SELECT 
    e.employee_id,
    e.name,
    ie.improvement_score
FROM ImprovedEmployees ie
JOIN employees e ON e.employee_id = ie.employee_id
ORDER BY ie.improvement_score DESC, e.name ASC;