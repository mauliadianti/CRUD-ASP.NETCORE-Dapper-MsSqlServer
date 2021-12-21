
CREATE PROCEDURE [dbo].[Sp.DeleteEmployee] 
@EmployeeID int
AS
BEGIN
	DELETE FROM Employee
	WHERE EmployeeID = @EmployeeID
END
