✅ Explanation

-   We pivot the month values into column names using CASE.

-   MAX() is used to aggregate the single value in each case (since (id, month) is a primary key, there is at most one revenue per month per department).

-   GROUP BY id ensures each row in the result corresponds to a unique department.