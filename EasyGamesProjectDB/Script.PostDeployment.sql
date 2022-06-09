IF NOT EXISTS (SELECT 1 FROM dbo.[Client])
BEGIN
	INSERT INTO dbo.[Client] (FirstName, Surname, ClientBalance)
	VALUES ('John', 'Doe', 0.00), ('Jane', 'Doe', 0.00), ('Carl', 'Cracker', 0.00), ('Harry', 'Hacker', 0.00);
END