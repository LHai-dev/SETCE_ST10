select  max(amount) from payments where paymentDate between "2004-1-1" and "2004-12-31";-- 116208.4-- 
select* from payments;
select customerNumber , amount from payments where amount =(
select min(amount) from payments where paymentDate like "2004%"
);

-- select customer count(pay count by customer id) customer pay
select customerNumber,count(customerNumber),sum(amount) from payments group by customerNumber;

-- want to know orderNumer who order how many time 
select  sum(priceEach*quantityOrdered),count(orderNumber),orderNumber  from orderdetails group by orderNumber; 



-- homework
SELECT * FROM customers
WHERE LENGTH(contactFirstName) > 5
AND contactFirstName NOT LIKE '%E%';

-- SELECT * FROM customers
-- WHERE LENGTH(contactFirstName) > 5
-- AND REPLACE(contactFirstName, 'E', '') = contactFirstName;


SELECT productName, productLine, productVendor, productDescription
FROM products
WHERE productLine IN ('Classic Cars', 'Planes', 'Motorcycles');


select productName from products where buyPrice between 60 and 90;

-- select * from payments where max(amount) and paymentDate like '%2004-05%';-- 


select * from payments where amount =(
select max(amount) from payments where paymentDate like "2004-05%"
);


select * from employees where firstName Like '%l%' And officeCode in(6,2,4);



select * from customers;

create table if not exists customer1 like customers;
-- column , primary key , no data-- 
insert into customer1 select * from customers;
-- column ,primary key , have data--

create table if not exists customer2 select * from customers;
-- column ,no primary key , have data
alter table customer2 add primary key(customernumber);
-- column , primary key ,have data



create table if not exists customer3 select * from customer limit 0;
-- column , no primary key , no data
alter table customer3 add primary key(customernumber);
insert into customer3 select * from customers;
-- column , primary key , have data 


create table ol
select officeCode,city,state from offices limit 2 ;
-- select trasaction;-- 
insert into ol set offiiceCode =3,city = "A";
insert into o1 values(4,"b",null),(5,"C","test")


-- create clone table (pk don't come)
create table if not exists Office1 select * from offices;
drop table office1;
drop table test;
-- create clone table 
create table if not exists Offices1 like offices;
-- create table not pk and no data
create table if not exists test select * from offices limit 0;
-- insert 
insert into offices1 select * from offices; 
select * from offices1;

-- backup data
start transaction;

insert into offices1 set officecode=8,city="Phnom Penh",territory="N/A",postalCode=1200,country="Sanhok",state="Boostcamp",
addressLine2=null,addressLine1="86A",phone="077 441 577";

rollback;


-- concat
select concat (officeCode,0) from offices;
select concat (lastName,".",firstName,"@gmail.com") Email from employees;

-- Order by
select * from payments
order by amount desc;

-- limit 
select * from payments where paymentDate like "2004%" order by amount desc limit 1;
select count(customerNumber) as num, country from customers group by country
having num=( select count(customerNumber) from customers group by country 
order by 1 asc limit 1);



-- 1
select * 
from customers
where contactFirstName not like "%E%" and length(contactFirstName)>5;
-- 2
select productName,productLine,productVendor,productDescription 
from products
where productLine = "Classic Cars" or productLine="Planes" or productLine="Motorcycles";

select productName,productLine,productVendor,productDescription 
from products
where productLine in ("Classic Cars","Planes","Motorcycles");


-- 3
select productName from products where buyPrice between 60 and 90;
-- 4 
select *
from payments 
where amount=(select max(amount)
			from payments
			where paymentDate between "2004-05-01" and "2004-05-31");
select paymentDate,amount
from payments
where paymentDate between "2004-05-01" and "2004-05-31";
-- 5
select firstName 
from employees
where firstName like "%L%" and officeCode in (6,2,4);


-- homework-- 

select * from customers where contactLastName like '__t%' and contactFirstName like '_r%' and city like "Singapore";


create table if not exists ep as select employeeNumber,lastName,firstName,officeCode,
jobTitle ,concat(lastName,'.',firstName,'@gmail.com') as email from employees;

SELECT customerName FROM customers WHERE customerName LIKE 'A%' ORDER BY customerName DESC;

select * from customers where customerName like '__G%' limit 3;

SELECT ProductCode FROM OrderDetails GROUP BY ProductCode ORDER BY SUM(QuantityOrdered) DESC LIMIT 1;


-- --test


-- 31/10
create table if not exists New_office
select officecode,country from offices;

set sql_safe_updates=0;

update New_office set officecode = concat("A",officecode,1);
select * from New_office;

start transaction;
set foreign_key_checks=0;
update offices set officecode = concat("A",officecode,1);
update employees set officecode  = concat("A",officecode,1);
rollback;







