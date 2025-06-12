✅ Explanation

-   filtered: Only keeps rows with people >= 100.

-   grouped: Assigns a group key (id - row_number()) for sequences of consecutive ids.

-   valid_ids: Selects groups with 3 or more rows.

-   Final SELECT: Returns all records in those groups, ordered by visit_date.