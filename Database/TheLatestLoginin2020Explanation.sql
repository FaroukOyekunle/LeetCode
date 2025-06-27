✅ Explanation:

-   WHERE YEAR(time_stamp) = 2020: I filters the records to only include logins that happened in the year 2020.

-   GROUP BY user_id: Then i groups the logins by user.

-   MAX(time_stamp): For each user, i finds the most recent login in 2020.

This way, users who didn''t log in during 2020 are automatically excluded, and for those who did, we get their latest login that year.