﻿CREATE TABLE dbo.[User] (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	[Password] VARCHAR(256) NOT NULL,
	ConfirmPassword VARCHAR(265) NOT NULL,
	IsActive BIT NOT NULL DEFAULT(0),
	CreationDate DATETIME NOT NULL,
	LastUpdate DATETIME NOT NULL
)
GO

ALTER TABLE dbo.[User] 
		ADD CONSTRAINT Pk_User PRIMARY KEY CLUSTERED (Id)
GO

CREATE UNIQUE NONCLUSTERED INDEX UX_User_Username
	ON dbo.[User] (Username)
GO

CREATE UNIQUE NONCLUSTERED INDEX UX_User_Email
	ON dbo.[User] (Email)
GO

CREATE TABLE dbo.Role(
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	RoleName VARCHAR(50) NOT NULL
)
GO

ALTER TABLE dbo.Role
	ADD CONTRAINT Pk_Role PRIMARY KEY CLUSTERED (Id)
GO

CREATE UNIQUE NONCLUSTERED INDEX UX_Role_Name
	ON dbo.Role (RoleName)
GO

CREATE TABLE dbo.UserRole(
	User_UserId INT NOT NULL,
	Role_RoleId INT  NOT NULL
)
GO

ALTER TABLE dbo.UserRole	
	ADD FOREIGN KEY (User_UserId) REFERENCES dbo.[User](Id)
GO

ALTER TABLE dbo.UserRole
	ADD FOREIGN KEY (Role_RoleId) REFERENCES dbo.Role(Id)
GO