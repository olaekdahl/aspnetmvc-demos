use AdventureWorks2017
go

CREATE PROCEDURE Production.Search
	@searchTerm nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    select * from production.product where [Name] like '%' + @searchTerm + '%';
END
GO