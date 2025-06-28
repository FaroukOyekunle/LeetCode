# Write your MySQL query statement below

SELECT all_ids.employee_id
FROM (
    SELECT employee_id FROM Employees
    UNION
    SELECT employee_id FROM Salaries
) AS all_ids
LEFT JOIN Employees e ON all_ids.employee_id = e.employee_id
LEFT JOIN Salaries s ON all_ids.employee_id = s.employee_id
WHERE e.name IS NULL OR s.salary IS NULL
ORDER BY all_ids.employee_id;