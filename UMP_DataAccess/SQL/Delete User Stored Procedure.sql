USE [UserManagement]
GO

DROP PROC IF EXISTS Sp_DeleteUser
GO
CREATE PROC Sp_DeleteUser(@UserId uniqueidentifier)
AS
BEGIN
	DELETE  
	FROM Users
	WHERE @UserId = User_Id
END
GO

EXEC Sp_DeleteUser 'B308D8C0-7437-4EC5-8BE2-1BE605617A52'