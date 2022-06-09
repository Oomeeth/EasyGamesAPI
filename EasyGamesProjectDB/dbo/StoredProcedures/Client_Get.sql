CREATE PROCEDURE [dbo].[Client_Get]
	@ClientID int
AS
BEGIN
	SELECT *
	FROM dbo.[Client]
	WHERE ClientID = @ClientID;
END
