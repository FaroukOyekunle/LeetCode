# Write your MySQL query statement below

WITH RECURSIVE hierarchy AS (
    SELECT 
        employee_id AS manager_id,
        employee_id AS employee_id,
        0 AS depth
    FROM Employees
    UNION ALL
    SELECT 
        h.manager_id,
        e.employee_id,
        h.depth + 1
    FROM hierarchy h
    JOIN Employees e ON e.manager_id = h.employee_id
),

team_data AS (
    SELECT 
        h.manager_id,
        COUNT(*) - 1 AS team_size,              
        SUM(e.salary) AS budget
    FROM hierarchy h
    JOIN Employees e ON h.employee_id = e.employee_id
    GROUP BY h.manager_id
),

levels AS (
    SELECT 
        employee_id,
        1 AS level
    FROM Employees
    WHERE manager_id IS NULL
    UNION ALL
    SELECT 
        e.employee_id,
        l.level + 1
    FROM levels l
    JOIN Employees e ON e.manager_id = l.employee_id
)

SELECT 
    e.employee_id,
    e.employee_name,
    l.level,
    COALESCE(td.team_size, 0) AS team_size,
    COALESCE(td.budget, e.salary) AS budget
FROM Employees e
JOIN levels l ON e.employee_id = l.employee_id
LEFT JOIN team_data td ON e.employee_id = td.manager_id
ORDER BY 
    l.level ASC,
    budget DESC,
    e.employee_name ASC;