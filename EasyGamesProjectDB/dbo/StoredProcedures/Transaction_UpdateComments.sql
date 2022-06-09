CREATE PROCEDURE [dbo].[Transaction_UpdateComments]
	@TransactionID INT,
	@Comment NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.[Transaction]
	SET Comment = @Comment
	WHERE TransactionID = @TransactionID;
END
