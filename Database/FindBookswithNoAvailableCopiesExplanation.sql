✅ Explanation


*   LEFT JOIN ... AND br.return_date IS NULL:

    *   This ensures all books are included in the join, even if they have 0 current borrowings.

    *   The return_date IS NULL filter is applied in the join condition, not in the WHERE clause. 
        This is important, because putting it in WHERE would convert the LEFT JOIN into an INNER JOIN, excluding books with 0 current borrowings.

*   HAVING COUNT(br.record_id) = lb.total_copies:

    *   This ensures we only include books that are completely borrowed — i.e., available copies = 0.

*   ORDER BY current_borrowers DESC, title ASC:

    *   Proper ordering per requirements.