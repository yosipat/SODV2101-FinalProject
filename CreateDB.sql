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

    -- May 2024
    (3400.00, 1, '2024-05-05'), -- Salary
    (550.00, 3, '2024-05-10'), -- Groceries
    (120.00, 4, '2024-05-15'), -- Utilities
    (200.00, 5, '2024-05-20'), -- Entertainment
    (100.00, 6, '2024-05-25'), -- Transportation

    -- June 2024
    (3400.00, 1, '2024-06-05'), -- Salary
    (600.00, 3, '2024-06-10'), -- Groceries
    (350.00, 4, '2024-06-15'), -- Utilities
    (250.00, 5, '2024-06-20'), -- Entertainment
    (120.00, 6, '2024-06-25'), -- Transportation

    -- July 2024
    (3500.00, 1, '2024-07-05'), -- Salary
    (400.00, 3, '2024-07-10'), -- Groceries
    (100.00, 4, '2024-07-15'), -- Utilities
    (180.00, 5, '2024-07-20'), -- Entertainment
    (130.00, 6, '2024-07-25'), -- Transportation

    -- August 2024
    (3500.00, 1, '2024-08-05'), -- Salary
    (450.00, 3, '2024-08-10'), -- Groceries
    (130.00, 4, '2024-08-15'), -- Utilities
    (300.00, 5, '2024-08-20'), -- Entertainment
    (150.00, 6, '2024-08-25'), -- Transportation

    -- September 2024
    (3600.00, 1, '2024-09-05'), -- Salary
    (500.00, 3, '2024-09-10'), -- Groceries
    (100.00, 4, '2024-09-15'), -- Utilities
    (250.00, 5, '2024-09-20'), -- Entertainment
    (130.00, 6, '2024-09-25'), -- Transportation

    -- October 2024
    (3600.00, 1, '2024-10-05'), -- Salary
    (550.00, 3, '2024-10-10'), -- Groceries
    (120.00, 4, '2024-10-15'), -- Utilities
    (180.00, 5, '2024-10-20'), -- Entertainment
    (150.00, 6, '2024-10-25'), -- Transportation

    -- Adding new income categories for each month to simulate Freelance and Savings
    (1000.00, 2, '2024-01-10'), -- Freelance
    (1000.00, 2, '2024-02-10'), -- Freelance
    (1000.00, 2, '2024-03-10'), -- Freelance
    (1000.00, 2, '2024-04-10'), -- Freelance
    (1000.00, 2, '2024-05-10'), -- Freelance
    (1000.00, 2, '2024-06-10'), -- Freelance
    (1000.00, 2, '2024-07-10'), -- Freelance
    (1000.00, 2, '2024-08-10'), -- Freelance
    (1000.00, 2, '2024-09-10'), -- Freelance
    (1000.00, 2, '2024-10-10'), -- Freelance

    -- Savings income
    (1200.00, 8, '2024-01-10'), -- Savings
    (1200.00, 8, '2024-02-10'), -- Savings
    (1200.00, 8, '2024-03-10'), -- Savings
    (1200.00, 8, '2024-04-10'), -- Savings
    (1200.00, 8, '2024-05-10'), -- Savings
    (1200.00, 8, '2024-06-10'), -- Savings
    (1200.00, 8, '2024-07-10'), -- Savings
    (1200.00, 8, '2024-08-10'), -- Savings
    (1200.00, 8, '2024-09-10'), -- Savings
    (1200.00, 8, '2024-10-10'); -- Savings

-- Insert sample budgets (with limits for both income and expenses)
INSERT INTO Budget (CategoryID, MonthlyLimit)
VALUES
    (1, 4000.00), -- Salary
    (3, 600.00),  -- Groceries
    (4, 200.00),  -- Utilities
    (5, 250.00),  -- Entertainment
    (6, 150.00),  -- Transportation
    (7, 300.00),  -- Healthcare
    (2, 1000.00), -- Freelance Income
    (8, 1200.00); -- Savings

