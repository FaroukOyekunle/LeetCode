✅ Explanation

1.  weekly_meetings CTE:

    *   I calculates the total meeting hours per employee per week.

    *   Then i uses YEARWEEK(meeting_date, 1) to group meetings from Monday to Sunday.

    *   Afterwards we aggregates total duration for each (employee_id, week).

2.  meeting_heavy_weeks CTE:

    *   Here we filters only those week entries where meeting hours > 20 (i.e., meeting-heavy).

    *   Then group by employee_id and counts such weeks.

    *   Filters employees with at least 2 such weeks.

3.  Final SELECT:

    *   Joins the results with the employees table to fetch employee details.

    *   Orders by meeting_heavy_weeks DESC, then employee_name ASC.