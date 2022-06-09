CREATE PROCEDURE [dbo].[Transaction_GetAllClient]
	@ClientID INT
AS
BEGIN
	SELECT *
	FROM dbo.[Transaction]
	WHERE ClientID = @ClientID;
END
