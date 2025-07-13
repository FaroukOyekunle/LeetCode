✅ Explanation

1.  FirstPositives CTE:

    *   I get the first positive test date for each patient.

2.  FirstNegativesAfterPositive CTE:

    *   Then for each patient who had a positive test, find the first negative test that happened after their first positive.

3.  Final SELECT:

    *   I join patients who have both a positive and a negative (after the positive).

    *   I use DATEDIFF to compute recovery time in days.

    *   Order the results as required: recovery_time ASC, then patient_name ASC.