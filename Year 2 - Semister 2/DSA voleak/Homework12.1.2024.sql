SELECT Employees.EmployeeNumber, Employees.LastName, Employees.FirstName, Offices.City
FROM Employees
JOIN Offices
ON Employees.OfficeCode = Offices.OfficeCode
WHERE Employees.FirstName LIKE '%y';

SELECT Payments.CustomerNumber, SUM(Payments.Amount) AS 'Total CustomerNumber Amount', CONCAT(ContactFirstName, ' ', ContactLastName) AS FullName
FROM Payments
JOIN Customers
ON Payments.CustomerNumber = Customers.CustomerNumber
GROUP BY Payments.CustomerNumber;


SELECT Customers.CustomerNumber
FROM Customers
JOIN Payments
ON Customers.CustomerNumber = Payments.CustomerNumber
WHERE (Payments.CustomerNumber IS NULL OR Payments.Amount < 100000) AND Customers.CustomerNumber IN (103, 119, 112, 114, 124);

SELECT CustomerNumber, PaymentDate, Amount
FROM Payments
WHERE PaymentDate BETWEEN '2004-03-01' AND '2004-03-31'
ORDER BY Amount DESC
LIMIT 3;

SELECT ProductCode AS TotalQuantity
FROM OrderDetails
GROUP BY ProductCode
ORDER BY TotalQuantity DESC;
