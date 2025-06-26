✅ Explanation

-   We are asked to calculate a bonus for each employee based on two conditions:

    -   The employee_id is odd → MOD(employee_id, 2) = 1

    -   The name does not start with 'M' → name NOT LIKE 'M%'

If both conditions are met, the employee gets a bonus equal to their full salary. Otherwise, the bonus is 0.

Query breakdown:

    -   I use CASE to check the two conditions.

    -   Then make use of MOD(employee_id, 2) to test for oddness.

    -   I then make use of operator LIKE 'M%' to check if the name starts with 'M'.

    -   Return salary as bonus if both conditions are met; otherwise return 0.

    -   Order the result by employee_id.