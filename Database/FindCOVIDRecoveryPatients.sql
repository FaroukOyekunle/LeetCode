# Write your MySQL query statement below

WITH FirstPositives AS (
    SELECT 
        patient_id,
        MIN(test_date) AS first_positive_date
    FROM covid_tests
    WHERE result = 'Positive'
    GROUP BY patient_id
),
FirstNegativesAfterPositive AS (
    SELECT 
        p.patient_id,
        MIN(c.test_date) AS first_negative_date
    FROM FirstPositives p
    JOIN covid_tests c 
        ON p.patient_id = c.patient_id
       AND c.result = 'Negative'
       AND c.test_date > p.first_positive_date
    GROUP BY p.patient_id
)
SELECT 
    pt.patient_id,
    pt.patient_name,
    pt.age,
    DATEDIFF(n.first_negative_date, p.first_positive_date) AS recovery_time
FROM FirstPositives p
JOIN FirstNegativesAfterPositive n ON p.patient_id = n.patient_id
JOIN patients pt ON pt.patient_id = p.patient_id
ORDER BY recovery_time ASC, pt.patient_name ASC;