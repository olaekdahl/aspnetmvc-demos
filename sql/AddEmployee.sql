use AdventureWorks2017
go

create procedure HumanResources.AddEmployee(
      @NationalIDNumber nvarchar(15)
      ,@LoginID nvarchar(256)
	  ,@FirstName nvarchar(50)
	  ,@LastName nvarchar(50)
      ,@JobTitle nvarchar(50)
      ,@BirthDate date
      ,@MaritalStatus nchar(1)
      ,@Gender nchar(1)
      ,@HireDate date
      ,@SalariedFlag bit
      ,@VacationHours smallint
      ,@SickLeaveHours smallint
)
as
begin
	declare @id int, @uid uniqueidentifier, @mod datetime
	set @uid = NEWID()
	set @mod = GETDATE()

	insert into person.BusinessEntity values (@uid, @mod)
	set @id = @@IDENTITY

	insert into  Person.Person(BusinessEntityID,PersonType, NameStyle, FirstName, LastName, EmailPromotion, rowguid, ModifiedDate)
		values(@id,'EM', 0, @FirstName, @LastName, 0, @uid, @mod)

	insert into HumanResources.Employee(BusinessEntityID, NationalIDNumber, LoginID, JobTitle, BirthDate, MaritalStatus, Gender, HireDate, SalariedFlag, VacationHours, SickLeaveHours, CurrentFlag, rowguid, ModifiedDate)
		values(@id, @NationalIDNumber, @LoginID, @JobTitle, @BirthDate, @MaritalStatus, @Gender, @HireDate, @SalariedFlag, @VacationHours, @SickLeaveHours, 1, @uid, @mod);

	insert into HumanResources.EmployeeDepartmentHistory(BusinessEntityID, DepartmentID, ShiftID,StartDate, ModifiedDate)
		values(@id,1,1,@mod,@mod)
end
go