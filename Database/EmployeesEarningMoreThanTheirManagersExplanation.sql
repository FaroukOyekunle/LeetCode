✅ Explanation

-   We join the Employee table to itself.

-   Then we match each employee's' managerId with the id of another employee (who is the manager).

-   Compare their salary values.

-   e1 represents the employee.

-   e2 represents the manager.

-   We use a self-join: e1.managerId = e2.id to relate employees to their managers.

-   WHERE e1.salary > e2.salary filters only those employees who earn more than their managers.

-   Return the names of employees whose salary is greater than their manager's' salary.