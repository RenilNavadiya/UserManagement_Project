DROP PROC IF EXISTS Sp_InsertNewUser
GO
CREATE PROC Sp_InsertNewUser
	(@FirstName nvarchar(50),
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
	Insert into Users (User_Id,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Country,PostalCode) VALUES
	(NEWID(),@FirstName,@LastName,@DateOfBirth,@Gender,@Street,@City,@Province,@Country,@PostalCode)
END

EXEC Sp_InsertNewUser 'dvij','Patel','2012-09-10','male','125cdcd','dcdc','cdcsc','canada','5d5-8d9'
select * from Users