✅ Explanation

-   JOIN Users u ON u.account = t.account:
I join the Users table with Transactions to associate each transaction with the corresponding user''s name.

2.  SUM(t.amount) AS balance:
I compute the total balance per user by summing all their transaction amounts.

3.  GROUP BY u.account, u.name:
I group by both account and name to correctly aggregate balances per user.

4.  HAVING SUM(t.amount) > 10000:
Then filters out users whose total balance does not exceed 10,000.