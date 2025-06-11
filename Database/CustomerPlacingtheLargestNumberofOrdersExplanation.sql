✅ Explanation

-   I GROUP BY customer_number: Groups orders by each customer.

-   COUNT(*): Counts how many orders each customer has made.

-   ORDER BY COUNT(*) DESC: Sorts customers by number of orders in descending order.

-   LIMIT 1: Returns the customer with the most orders.

-   The problem guarantees exactly one customer with the highest order count, so no need to handle ties here.