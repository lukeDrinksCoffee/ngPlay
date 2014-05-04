
-- Perform on master
CREATE LOGIN [<user name here>]
	WITH PASSWORD = '<password here>'
GO

-- Perform on ngPlay-data
CREATE USER [ngPlay-data-login-app-user] FROM LOGIN [ngPlay-data-login-app]
	WITH DEFAULT_SCHEMA = [ngPlay-data]
GO

EXEC sp_addrolemember 'db_datareader', 'ngPlay-data-login-app-user'
GO

EXEC sp_addrolemember 'db_datawriter', 'ngPlay-data-login-app-user'
GO
