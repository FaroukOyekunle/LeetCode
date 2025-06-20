WITH filtered AS (
    SELECT *
    FROM Stadium
    WHERE people >= 100
),
grouped AS (
    SELECT *,
           id - ROW_NUMBER() OVER (ORDER BY id) AS grp
    FROM filtered
),
valid_ids AS (
    SELECT grp
    FROM grouped
    GROUP BY grp
    HAVING COUNT(*) >= 3
)
SELECT id, visit_date, people
FROM grouped
WHERE grp IN (SELECT grp FROM valid_ids)
ORDER BY visit_date;