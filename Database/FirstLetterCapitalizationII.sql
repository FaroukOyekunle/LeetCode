# Write your MySQL query statement below

WITH RECURSIVE split_words AS (
    SELECT 
        content_id,
        content_text,
        TRIM(SUBSTRING_INDEX(content_text, ' ', 1)) AS word,
        TRIM(SUBSTRING(content_text, LENGTH(SUBSTRING_INDEX(content_text, ' ', 1)) + 2)) AS rest,
        1 AS word_pos
    FROM user_content

    UNION ALL

    SELECT 
        content_id,
        content_text,
        TRIM(SUBSTRING_INDEX(rest, ' ', 1)) AS word,
        TRIM(SUBSTRING(rest, LENGTH(SUBSTRING_INDEX(rest, ' ', 1)) + 2)) AS rest,
        word_pos + 1
    FROM split_words
    WHERE rest <> ''
),
processed_words AS (
    SELECT 
        content_id,
        content_text,
        word_pos,
        CASE 
            WHEN word LIKE '%-%' THEN
                CONCAT(
                    UPPER(LEFT(SUBSTRING_INDEX(word, '-', 1), 1)),
                    LOWER(SUBSTRING(SUBSTRING_INDEX(word, '-', 1), 2)),
                    '-',
                    UPPER(LEFT(SUBSTRING_INDEX(word, '-', -1), 1)),
                    LOWER(SUBSTRING(SUBSTRING_INDEX(word, '-', -1), 2))
                )
            ELSE
                CONCAT(
                    UPPER(LEFT(word, 1)),
                    LOWER(SUBSTRING(word, 2))
                )
        END AS converted_word
    FROM split_words
),
reconstructed AS (
    SELECT 
        content_id,
        content_text,
        GROUP_CONCAT(converted_word ORDER BY word_pos SEPARATOR ' ') AS converted_text
    FROM processed_words
    GROUP BY content_id, content_text
)
SELECT 
    content_id,
    content_text AS original_text,
    converted_text
FROM reconstructed
ORDER BY content_id;