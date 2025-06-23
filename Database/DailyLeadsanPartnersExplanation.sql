✅ Explanation

-   For each date_id and make_name, count how many unique lead_ids and unique partner_ids exist.

-   I use GROUP BY date_id, make_name to group data by both columns.

-   COUNT(DISTINCT lead_id) counts unique leads per group.

-   COUNT(DISTINCT partner_id) counts unique partners per group.

This query satisfies the requirement of producing the number of distinct leads and partners for each (date_id, make_name) combination.