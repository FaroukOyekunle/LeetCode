✅ Explanation

-   GROUP BY actor_id, director_id: This groups the table by each unique pair of actor and director.

-   HAVING COUNT(*) >= 3: This filters only the pairs that have cooperated at least 3 times.

-   timestamp is not needed in the output, and since it''s unique, it does not affect the aggregation.