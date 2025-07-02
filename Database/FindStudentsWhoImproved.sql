# Write your MySQL query statement below
WITH first_scores AS (
    SELECT student_id, subject, score AS first_score
    FROM Scores
    WHERE (student_id, subject, exam_date) IN (
        SELECT student_id, subject, MIN(exam_date)
        FROM Scores
        GROUP BY student_id, subject
    )
),
latest_scores AS (
    SELECT student_id, subject, score AS latest_score
    FROM Scores
    WHERE (student_id, subject, exam_date) IN (
        SELECT student_id, subject, MAX(exam_date)
        FROM Scores
        GROUP BY student_id, subject
    )
)
SELECT 
    f.student_id, 
    f.subject, 
    f.first_score, 
    l.latest_score
FROM first_scores f
JOIN latest_scores l 
    ON f.student_id = l.student_id AND f.subject = l.subject
WHERE l.latest_score > f.first_score
ORDER BY f.student_id, f.subject;