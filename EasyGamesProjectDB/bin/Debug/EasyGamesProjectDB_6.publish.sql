/*
Deployment script for EasyGamesProjectDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "EasyGamesProjectDB"
:setvar DefaultFilePrefix "EasyGamesProjectDB"
:setvar DefaultDataPath "C:\Users\user-pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\user-pc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering Procedure [dbo].[Client_Insert]...';


GO
ALTER PROCEDURE [dbo].[Client_Insert]
	@FirstName NVARCHAR(50),
	@Surname NVARCHAR(50),
	@ClientBalance FLOAT
AS
BEGIN
	INSERT INTO dbo.[Client] (FirstName, Surname, ClientBalance)
	VALUES (@FirstName, @Surname, @ClientBalance);
END
GO
IF NOT EXISTS (SELECT 1 FROM dbo.[Client])
BEGIN
	INSERT INTO dbo.[Client] (FirstName, Surname, ClientBalance)
	VALUES ('John', 'Doe', 0.00), ('Jane', 'Doe', 0.00), ('Carl', 'Cracker', 0.00), ('Harry', 'Hacker', 0.00);
END
GO

GO
PRINT N'Update complete.';


GO
