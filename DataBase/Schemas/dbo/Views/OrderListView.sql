CREATE VIEW [dbo].[OrderListView]
AS
SELECT 
    [Order].OrderId,
    [Order].CustomerId,
    [Order].OrderStartDate,
    [Order].OrderEndDate,
    -- Use a subquery with CAST to determine HasOrderWeekMenu
    CAST(
        CASE 
            WHEN EXISTS (SELECT 1 
                         FROM [dbo].[OrderWeekMenu] 
                         WHERE [dbo].[OrderWeekMenu].[OrderId] = [Order].[OrderId]) 
            THEN 1 
            ELSE 0 
        END AS BIT
    ) AS HasOrderWeekMenu
FROM [dbo].[Order]
GO