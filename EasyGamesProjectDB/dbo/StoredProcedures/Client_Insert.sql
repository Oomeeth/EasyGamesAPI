CREATE PROCEDURE [dbo].[Client_Insert]
	@FirstName NVARCHAR(50),
	@Surname NVARCHAR(50),
	@ClientBalance FLOAT
AS
BEGIN
	INSERT INTO dbo.[Client] (FirstName, Surname, ClientBalance)
	VALUES (@FirstName, @Surname, @ClientBalance);
END