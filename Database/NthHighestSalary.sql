CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  DECLARE offsetVal INT;
  SET offsetVal = N - 1;

  RETURN (
    SELECT salary FROM (
      SELECT DISTINCT salary
      FROM Employee
      ORDER BY salary DESC
    ) AS temp
    LIMIT 1 OFFSET offsetVal
  );
END