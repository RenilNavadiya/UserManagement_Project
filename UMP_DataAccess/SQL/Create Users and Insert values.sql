USE [UserManagement]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2022-11-10 8:43:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[User_Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Street] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](15) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Users (User_Id,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Country,PostalCode)
VALUES (NEWID(),'Maitri','Patel','02-04-1996','Female','Karen Cres','Hamilton','Ontario','Canada','L9D-6M3')

INSERT INTO Users (User_Id,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Country,PostalCode)
VALUES (NEWID(),'Parth','Darji','12-11-1998','Male','Lavina Cres','Kitchner','Ontario','Canada','M2D-8N7')

INSERT INTO Users (User_Id,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Country,PostalCode)
VALUES (NEWID(),'Jainee','Shah','01-03-1995','Female','Limeridge Road','Caledon','Ontario','Canada','L8N-5M9')

INSERT INTO Users (User_Id,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Country,PostalCode)
VALUES (NEWID(),'Renil','Navadiya','02-04-1999','Male','Fairview Street','Burlington','Ontario','Canada','J8N-6C8')


