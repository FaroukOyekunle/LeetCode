✅ Explanation

-   Main Table: I start from the Users table since we want data for each user (even those with 0 orders).

-   Join Type: Then i use LEFT JOIN to include users with no orders in 2019.

-   Join Condition: Match Users.user_id with Orders.buyer_id, and filter Orders to 2019 using YEAR(order_date) = 2019.

-   Aggregation: Use COUNT(o.order_id) to count the number of orders made by each user as a buyer in 2019.

-   Group By: I then group the result by user_id and join_date to ensure each user's count is accurate.