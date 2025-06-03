✅ Explanation

-   I retrieve first name, last name, city, and state for every person in the Person table.

-   ome people may not have addresses in the Address table.

- We use a LEFT JOIN to:

-   Keep all persons from the Person table.

-   We include matching addresses if they exist in the Address table.

-   If no match is found, city and state return as NULL.