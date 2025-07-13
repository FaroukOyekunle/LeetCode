✅ Explanation

1.  RankedReviews CTE:

    *   I Use ROW_NUMBER() to get the last 3 reviews (rn = 1 is most recent) for each employee.

2.  LastThree CTE:

    *   Then i filter each employee to keep only their last 3 reviews.

3.  GroupedRatings CTE:

    *   Pivots the 3 reviews for each employee into columns (rating1, rating2, rating3), ordered from most recent to oldest.

4.  ImprovedEmployees CTE:

    *   I filter employees who show strictly increasing ratings: rating3 < rating2 < rating1.

    *   Computes the improvement_score = rating1 - rating3.

5.  Final SELECT:

    *   I join with the employees table to get names.

    *   Then order by improvement_score DESC and name ASC.