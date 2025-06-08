✅ Explanation

-   The subquery:

    SELECT MAX(salary), departmentId FROM Employee GROUP BY departmentId

finds the maximum salary for each department.

-   The main query:

-   I joins the Employee and Department tables to get the department name.

-   Then filters employees where (salary, departmentId) matches a (MAX(salary), departmentId) pair from the subquery.

-   This handles cases where multiple employees share the highest salary in the same department.