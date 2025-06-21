✅ Explanation:

1.   LEFT JOIN:

    -   We use a LEFT JOIN to ensure that even users without any rides (like Donald) are included in the result.

2.  COALESCE(SUM(r.distance), 0):

    -   SUM(r.distance) aggregates the total distance per user.

    -   COALESCE(..., 0) ensures that users with no rides show 0 instead of NULL.

3.  GROUP BY:

    -   We group by both u.id and u.name to compute the total distance per user.

4.  ORDER BY:

    -   First by travelled_distance DESC (highest to lowest),

    -   Then by u.name ASC for users with the same total distance.