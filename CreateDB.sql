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


USE BudgetTracker
GO

-- Insert sample categories
INSERT INTO Categories (CategoryName, CategoryType)
VALUES 
    ('Salary', 'Income'),
    ('Freelance', 'Income'),
    ('Groceries', 'Expense'),
    ('Utilities', 'Expense'),
    ('Entertainment', 'Expense'),
    ('Transportation', 'Expense'),
    ('Healthcare', 'Expense'),
    ('Savings', 'Income');

-- Insert sample wallet transactions from January 2024 to October 2024
INSERT INTO Wallet (Amount, CategoryID, TransactionDate)
VALUES
    -- January 2024
    (3000.00, 1, '2024-01-05'), -- Salary
    (500.00, 3, '2024-01-10'), -- Groceries
    (150.00, 4, '2024-01-15'), -- Utilities
    (200.00, 5, '2024-01-20'), -- Entertainment
    (100.00, 6, '2024-01-25'), -- Transportation

    -- February 2024
    (3000.00, 1, '2024-02-05'), -- Salary
    (600.00, 3, '2024-02-10'), -- Groceries
    (120.00, 4, '2024-02-15'), -- Utilities
    (180.00, 5, '2024-02-20'), -- Entertainment
    (150.00, 6, '2024-02-25'), -- Transportation

    -- March 2024
    (3200.00, 1, '2024-03-05'), -- Salary
    (550.00, 3, '2024-03-10'), -- Groceries
    (160.00, 4, '2024-03-15'), -- Utilities
    (250.00, 5, '2024-03-20'), -- Entertainment
    (120.00, 6, '2024-03-25'), -- Transportation

    -- April 2024
    (3200.00, 1, '2024-04-05'), -- Salary
    (580.00, 3, '2024-04-10'), -- Groceries
    (140.00, 4, '2024-04-15'), -- Utilities
    (270.00, 5, '2024-04-20'), -- Entertainment
    (130.00, 6, '2024-04-25'), -- Transportation

    -- May to October 2024
    (3400.00, 1, '2024-05-05'), -- Salary
    (350.00, 4, '2024-06-15'), -- Utilities
    (500.00, 7, '2024-07-20'), -- Healthcare
    (1200.00, 8, '2024-08-10'), -- Savings
    (750.00, 3, '2024-09-25'), -- Groceries
    (850.00, 6, '2024-10-05'); -- Transportation

-- Insert sample budgets
INSERT INTO Budget (CategoryID, MonthlyLimit)
VALUES
    (3, 600.00),  -- Groceries
    (4, 200.00),  -- Utilities
    (5, 250.00),  -- Entertainment
    (6, 150.00),  -- Transportation
    (7, 300.00);  -- Healthcare

