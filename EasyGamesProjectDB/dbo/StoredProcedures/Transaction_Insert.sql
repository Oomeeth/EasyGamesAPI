CREATE PROCEDURE [dbo].[Transaction_Insert]
	@Amount FLOAT,
	@TransactionTypeID INT,
	@ClientID INT,
	@Comment NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.[Transaction] (Amount, TransactionTypeID, ClientID, Comment)
	VALUES (@Amount, @TransactionTypeID, @ClientID, @Comment);
END
