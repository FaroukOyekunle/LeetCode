✅ Explanation:

-   DECLARE offsetVal INT; → Declares a local variable.

-   SET offsetVal = N - 1; → I computes the offset since MySQL doesn''t allow LIMIT 1 OFFSET N - 1 directly.

-   The subquery selects all distinct salaries in descending order, and LIMIT 1 OFFSET offsetVal picks the Nth highest.

-   If there are fewer than N salaries, it returns NULL (which is the correct behavior).