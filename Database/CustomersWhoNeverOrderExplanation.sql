✅ Explanation

-   We want to find all customers who have never placed an order.

-   The Orders table records orders via the customerId field.

-   So, customers whose id is not found in the Orders.customerId column are the ones who never placed an order.

Step-by-step:

-   Select all customerId values from the Orders table.

-   In the Customers table, filter out the rows where the id is NOT IN that list of customer IDs.

-   Rename the output column as Customers for the expected result format.