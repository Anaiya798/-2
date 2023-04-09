CREATE PROCEDURE [dbo].[GetReagentsInCategory]
	@categoryId int
AS
	SELECT * FROM Reagent
	WHERE CategoryID=@categoryId
GO
