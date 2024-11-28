-- Example name: GetMonthlyBudgetReport
SELECT 
    c.CategoryName AS [Category], 
    b.MonthlyLimit AS [Budget], 
    ISNULL(SUM(w.Amount), 0) AS [Expense], 
    (b.MonthlyLimit - ISNULL(SUM(w.Amount), 0)) AS [Net],
    FORMAT(w.TransactionDate, 'yyyy-MM') AS [Month] 
FROM Budget b
JOIN Categories c ON b.CategoryID = c.CategoryID
LEFT JOIN Wallet w ON b.CategoryID = w.CategoryID 
GROUP BY c.CategoryName, b.MonthlyLimit, FORMAT(w.TransactionDate, 'yyyy-MM')