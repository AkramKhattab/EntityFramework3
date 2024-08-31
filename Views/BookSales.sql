-- Creating a view for book sales
CREATE VIEW BookSales AS
SELECT 
    b.Id AS BookId,
    b.Title AS BookTitle,
    COUNT(*) AS TotalSales,
    SUM(s.Price) AS TotalRevenue
FROM 
    Books b
JOIN 
    Sales s ON b.Id = s.BookId
GROUP BY 
    b.Id, b.Title;