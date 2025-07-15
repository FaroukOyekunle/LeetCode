# Write your MySQL query statement below

WITH weekly_meetings AS (
    SELECT 
        m.employee_id,
        YEARWEEK(m.meeting_date, 1) AS week_year,
        SUM(m.duration_hours) AS total_meeting_hours
    FROM meetings m
    GROUP BY m.employee_id, YEARWEEK(m.meeting_date, 1)
),
meeting_heavy_weeks AS (
    SELECT 
        employee_id,
        COUNT(*) AS meeting_heavy_weeks
    FROM weekly_meetings
    WHERE total_meeting_hours > 20
    GROUP BY employee_id
    HAVING COUNT(*) >= 2
)
SELECT 
    e.employee_id,
    e.employee_name,
    e.department,
    mhw.meeting_heavy_weeks
FROM meeting_heavy_weeks mhw
JOIN employees e ON e.employee_id = mhw.employee_id
ORDER BY mhw.meeting_heavy_weeks DESC, e.employee_name ASC;