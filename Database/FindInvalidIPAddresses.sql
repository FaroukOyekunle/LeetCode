# Write your MySQL query statement below

SELECT 
    ip,
    COUNT(*) AS invalid_count
FROM 
    logs
WHERE

    LENGTH(ip) - LENGTH(REPLACE(ip, '.', '')) != 3
    OR

    REGEXP_LIKE(ip, '\\b0[0-9]+\\b')
    OR

    EXISTS (
        SELECT 1
        FROM (
            SELECT 
                SUBSTRING_INDEX(SUBSTRING_INDEX(ip, '.', 1), '.', -1) AS part1,
                SUBSTRING_INDEX(SUBSTRING_INDEX(ip, '.', 2), '.', -1) AS part2,
                SUBSTRING_INDEX(SUBSTRING_INDEX(ip, '.', 3), '.', -1) AS part3,
                SUBSTRING_INDEX(SUBSTRING_INDEX(ip, '.', 4), '.', -1) AS part4
        ) parts
        WHERE 
            CAST(part1 AS UNSIGNED) > 255 OR
            CAST(part2 AS UNSIGNED) > 255 OR
            CAST(part3 AS UNSIGNED) > 255 OR
            CAST(part4 AS UNSIGNED) > 255
    )
GROUP BY 
    ip
ORDER BY 
    invalid_count DESC,
    ip DESC;