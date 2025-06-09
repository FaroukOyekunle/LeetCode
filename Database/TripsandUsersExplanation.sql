✅ Explanation:

-   We join the Trips table with the Users table twice:

    -   Once to get clients and filter only those who are not banned.

    -   Once to get drivers and filter only those who are not banned.

-   We then:

    -   Count the total unbanned trips per day.

    -   Count the number of cancellations (either by driver or client) per day.

-   Finally, we compute the cancellation rate using:


SUM(cancelled_trips) / COUNT(all_unbanned_trips)

-   And round the result to two decimal places.