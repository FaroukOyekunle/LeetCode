✅ Explanation:

-   DENSE_RANK() is used to assign ranks without gaps between ranking numbers when there are ties.

-   We wrapped rank in backticks (``) to avoid conflict with the reserved SQL keyword.

-   The OVER (ORDER BY score DESC) clause ensures that scores are ranked from highest to lowest.

-   ORDER BY score DESC at the end ensures the result is displayed in descending order of score.

-   This correspond exactly to the ranking rules described: same score → same rank, next distinct score → next integer rank without skipping numbers.