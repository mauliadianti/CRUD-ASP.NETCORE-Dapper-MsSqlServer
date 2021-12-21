
CREATE PROCEDURE [dbo].[Sp.CreateEmployee] 
(
	@EmployeeName varchar(255), 
	@PhoneNumber varchar(255), 
	@EmployeeAddress varchar(255)
)

AS
BEGIN
	INSERT INTO Employee
	VALUES(@EmployeeName, @PhoneNumber, @EmployeeAddress)

	SELECT * FROM Employee WHERE EmployeeID = SCOPE_IDENTITY();
END
