✅ Explanation:

-   This query uses a single UPDATE statement with a CASE expression.

-   The CASE checks the current value of the sex column:

    -   If it is 'm', it changes it to 'f'.

    -   If it is 'f', it changes it to 'm'.

-   This satisfies the requirement of no intermediate tables and no SELECT statement.