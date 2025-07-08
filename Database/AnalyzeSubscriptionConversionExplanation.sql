✅ Explanation

1.  The goal is to identify users who transitioned from free_trial to paid, and compute:

    *   Average duration during free_trial

    *   Average duration during paid

2.  Step-by-step breakdown:

    *   WHERE user_id IN (...): i filter users who had both free_trial and paid activity types.

    *   The SELECT clause computes:

        *   AVG(...) for both types using a CASE expression.

        *   ROUND(..., 2) to limit decimals to 2 places.

    *   The GROUP BY user_id groups activities per user.

    *   Finally, ORDER BY user_id ensures results are sorted ascending by user ID.

3.  Why two IN subqueries?

    *   First ensures the user has free_trial.

    *   Second ensures the user has paid.

    *   Only users with both are considered.