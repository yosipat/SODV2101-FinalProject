USE master
GO

/****** Object:  Database AP ******/
IF DB_ID('BudgetTracker') IS NOT NULL
    DROP DATABASE BudgetTracker
GO

CREATE DATABASE BudgetTracker
GO 

USE BudgetTracker
GO

-- Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),  
    CategoryName VARCHAR(100) NOT NULL,
    CategoryType VARCHAR(7) CHECK (CategoryType IN ('Income', 'Expense')) 
);

-- Wallet Table
CREATE TABLE Wallet (
    TransactionID INT PRIMARY KEY IDENTITY(1,1),  
    Amount DECIMAL(10, 2) NOT NULL,
    CategoryID INT NOT NULL,
    TransactionDate DATE NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Budget Table
CREATE TABLE Budget (
    BudgetID INT PRIMARY KEY IDENTITY(1,1), 
    CategoryID INT,
    MonthlyLimit DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);



