CREATE PROCEDURE [dbo].[Client_UpdateBalance]
	@UpdatedAmount FLOAT,
	@ClientID INT
AS
BEGIN
	UPDATE dbo.[Client]
	SET ClientBalance = ClientBalance + @UpdatedAmount
	WHERE ClientID = @ClientID;
END