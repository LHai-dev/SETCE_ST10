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

-- 1.  ចូរបង្ហាញទិន្នន័យ Colum EmployeeNumber ,LastName,FirstName ចេញពី Table Employees 
-- និង column City ចេញពី Table officesដែលមាន column  FirstName បញ្ចប់ដោយ អក្សរ “Y”  (5Rows)
select employeeNumber, lastName, firstName, city from employees emp
inner join offices ofc on ofc.officeCode= emp.officeCode
where right(firstName, 1) = 'y';

-- 2.  ចូរបង្ហាញទិន្នន័យ Colum CustomerNumber, Amount សរុបតាម customerNumber ចេញពី Table payments 
-- និង FullName ដែលបានមកពី contactFirstName ភ្ជាប់ "  " ភ្ជាប់ contactLastName របស់ Table Customers (98Rows)
select * from 
(select customerNumber, sum(Amount) from payments group by customerNumberproductsproductscustomerscustomers) p
inner join
(select concat(contactFirstname, ' ', contactLastName), customerNumber from customers) c
on c.customerNumber=p.customerNumber;




-- 3.  ចូរបង្ហាញទិន្នន័យ Column CustomerNumber ដែលមិនបាន Pay សោះ និង បាន Pay សរុប តិចជាង 100000  
-- ក្នុង Table Payments និង Customers (119 Rows)
-- Noted: លុប ទិន្នន័យចេញពី Table Payments ដោយទុកតែ CustomerNumber លេខ (103,119,112,114,124)
start transaction;
delete from payments where customerNumber not in (103,119,112,114,124);
rollback;

select customerNumber from customers
where customerNumber in
(select customerNumber from payments
group by customerNumber
having sum(amount) < 100000)
or customerNumber not in
(select customerNumber from payments
group by customerNumber);



-- 4.  ចូរបង្ហាញទិន្នន័យ Column CustomerNumber និង ទិន្នន័យ Amount ធំជាងគេ ចំនួន 3 លេខ ដែលមាន PaymentDate ក្នុងឆ្នាំ 2004 ខែ 3 ចេញពី Table Payments (? Rows)
select customerNumber, amount, paymentDate from payments
where year(paymentDate) = 2004 and month(paymentdate) = 4
order by amount desc
limit 3

-- 5.  ចូរបង្ហាញទិន្នន័យ Column ProductCode ដែលបានលក់ ច្រើនជាងគេបង្អស់ ក្នុង Table OrderDetails (1Row)
select productCode, sum(quantityOrdered) qtyOrder from orderDetails
group by productCode
order by qtyOrder desc limit 1

