
CREATE PROCEDURE [dbo].[Sp.UpdateEmployee] 

(
	@EmployeeID int, 
	@EmployeeName varchar(255), 
	@PhoneNumber varchar(255), 
	@EmployeeAddress varchar(255)
)
AS
BEGIN
	UPDATE Employee
	SET EmployeeName = @EmployeeName, 
	EmployeeAddress = @EmployeeAddress, 
	PhoneNumber = @PhoneNumber
	WHERE EmployeeID = @EmployeeID

	SELECT * FROM Employee WHERE EmployeeID = @EmployeeID;
END
