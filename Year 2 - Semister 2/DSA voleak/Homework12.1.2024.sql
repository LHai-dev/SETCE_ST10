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

SELECT
    ProductCode,
    COUNT(*) AS TotalSales
FROM OrderDetails
GROUP BY ProductCode
ORDER BY TotalSales DESC
LIMIT 1;



-- 1
select employeeNumber, lastname,firstname,city 
from employees e
inner join offices o on o.officeCode=e.officeCode
where right(firstname,1)='y';
-- 2
select p.customerNumber,concat(contactFirstName," ",contactLastName) as fullname,sum(amount) total_amount
from payments p
inner join customers c on c.customerNumber=p.customerNumber
group by customerNumber;
-- 3 
create table payments1 as select * from payments; -- create
delete from payments1 where customerNumber not in (103,119,112,114,124); -- delete

select C.CustomerNumber from Customers C
where not exists (
    select 1 from Payments P
    where C.CustomerNumber = P.CustomerNumber and (P.Amount is null or P.Amount >= 100000)
);
-- 4
select CustomerNumber,Amount,PaymentDate
from Payments
where paymentDate like "2004-03-%"
order by Amount desc limit 3;
-- 5
SELECT
    ProductCode,
    COUNT(*) AS TotalSales
FROM OrderDetails
GROUP BY ProductCode
ORDER BY TotalSales DESC
LIMIT 1;
