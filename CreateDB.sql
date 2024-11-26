USE master
GO

/****** Object:  Database AP     ******/
IF DB_ID('BudgetTracker') IS NOT NULL
	DROP DATABASE BudgetTracker
GO

CREATE DATABASE BudgetTracker
GO 

USE BudgetTracker
GO


CREATE TABLE Wallet (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Category NVARCHAR(50) NOT NULL,
    Amount money NOT NULL,
	wType NVARCHAR(50) NOT NULL,
	wDate smalldatetime NOT NULL 
);

CREATE TABLE Budget (
    BudgetId INT PRIMARY KEY IDENTITY(1,1),
    Category NVARCHAR(50) NOT NULL,
    BudgetLimit money NOT NULL,
	wType NVARCHAR(50) NOT NULL,
	wMonth smalldatetime NOT NULL 
);

