✅ Explanation

-   The query transforms columns into rows, a process called unpivoting. Here''s what it does:

    -   For each store column (store1, store2, store3):

        -   It selects product_id, the store name as a string ('store1', etc.), and the corresponding price.

        -   It excludes nulls using WHERE storeX IS NOT NULL.

    -   Then, i combine the 3 queries using UNION ALL.

-   This ensures each row in the output contains only non-null product prices with their associated store.