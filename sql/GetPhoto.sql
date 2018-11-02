use AdventureWorks2017
go

CREATE PROCEDURE Production.GetPhoto  
	@pid int
AS
BEGIN
	SET NOCOUNT ON;

	select thumbnailphoto from Production.ProductPhoto as p
	join Production.ProductProductPhoto as pp on p.ProductPhotoID = pp.ProductPhotoID
	join Production.Product as pr on pr.ProductID = pp.ProductID
	where pr.ProductID = @pid
END
GO
