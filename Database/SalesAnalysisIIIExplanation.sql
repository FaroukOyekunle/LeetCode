✅ Explanation

-   Main Goal: Find products that were sold only during Q1 2019 (i.e., from Jan 1 to Mar 31, 2019).

    -   First, I filter products that were sold in Q1 2019.

    -   Then, exclude products that were sold outside Q1 2019 using a subquery with NOT IN.

    -   The main query selects distinct products that were sold in Q1 2019.

    -   The subquery returns product IDs that had sales outside the Q1 period.
    
    -   Using NOT IN ensures we only get products exclusively sold in Q1.