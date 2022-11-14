USE [UserManagement]
GO

DROP PROC IF EXISTS Sp_UpdateUser
GO
CREATE PROC Sp_UpdateUser
	(@UserId uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateOfBirth date,
	@Gender nchar(10),
	@Street nvarchar(200),
	@City nvarchar(50),
	@Province nvarchar(50),
	@Country nvarchar(50),
	@PostalCode nvarchar(15))
AS
BEGIN
	UPDATE Users 
	SET FirstName = @FirstName,LastName = @LastName,
		DateOfBirth = @DateOfBirth,Gender = @Gender,
		Street = @Street ,City = @City ,Province = @Province,
		Country = @Country,PostalCode = @PostalCode
	WHERE User_Id = @UserId
END
GO


EXEC Sp_UpdateUser 'a75407de-05a2-4bde-a420-90054db0b9e4','Renil','Patel','2012-09-10','male','ottawa','kitchener','ON','canada','5d58d9'
select * from Users 