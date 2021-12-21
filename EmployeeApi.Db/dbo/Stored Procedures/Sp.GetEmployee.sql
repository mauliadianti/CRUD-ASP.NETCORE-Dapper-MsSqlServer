
CREATE PROCEDURE [dbo].[Sp.GetEmployee] 
@EmployeeID int
AS
BEGIN
	SELECT * FROM Employee
	WHERE EmployeeID = @EmployeeID
END
