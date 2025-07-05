✅ Explanation

-   We need to:

    -   Traverse all reporting chains, not just from the CEO.

    -   So for each employee, recursively collect all subordinates (direct and indirect).

    -   I count team size as total subordinates.

    -   Then budget as sum of salaries of self + subordinates.

        -   hierarchy CTE builds every manager-to-subordinate path (including indirect).

        -   team_data aggregates count and salary for each manager.

        -   levels determines depth/level in org using another recursive CTE.

        -   LEFT JOIN ensures even non-managers appear with team_size = 0.