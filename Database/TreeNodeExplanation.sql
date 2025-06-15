✅ Explanation:

We are to categorize each node in the tree as:

-   Root: if p_id IS NULL

-   Inner: if it has children (i.e., appears as a p_id for other rows)

-   Leaf: if it is not the root and does not appear as a p_id

So the logic in the SQL query is:

1.  t1.p_id IS NULL: I marks the node as 'Root'.

2.  t1.id IN (SELECT DISTINCT p_id FROM Tree WHERE p_id IS NOT NULL): Marks it as 'Inner' if it is referenced as a parent by any other node.

3.  ELSE: All remaining nodes are 'Leaf'.