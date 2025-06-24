✅ Explanation

-   event_day AS day: I renames event_day to day as required by the output format.

-   SUM(out_time - in_time): For each event, the time spent is out_time - in_time. I sum this across events for the same employee on the same day.

-   GROUP BY emp_id, event_day: Groups the records per employee per day to calculate total time.