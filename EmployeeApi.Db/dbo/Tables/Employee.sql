CREATE TABLE [dbo].[Employee] (
    [EmployeeID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [EmployeeName]    VARCHAR (150) NULL,
    [EmployeeAddress] VARCHAR (100) NULL,
    [PhoneNumber]     VARCHAR (50)  NULL,
    CONSTRAINT [PK_EmployeeTable] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

