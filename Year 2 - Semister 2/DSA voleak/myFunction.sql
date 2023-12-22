select group_concat(officecode,city) from offices;

select productcode,group_concat( distinct priceEach order by priceEach asc) from orderdetails group by productCode;

select lastname,upper(lastname) from employees;

update employees set lastname=upper(lastname),firstname=upper(firstname);

select lastname,concat(upper(left(lastname,1)),lower(mid(lastname,2))) from employees;

select officecode,state,country,concat(officecode,"/",ifnull(state,""),"/",country),concat_ws("/",officecode,state,country) from offices;


select * from employees where lastName like "%o%";

select lastname ,locate("O",lastname) from employees where locate("o",lastname) = 0;
select lastname ,locate("O",lastname) from employees where locate("o",lastname) > 0;

SELECT
    customerName,
    SUBSTRING_INDEX(customerName, ' ', 1) AS first_name,
    SUBSTRING_INDEX(customerName, ' ', -1) AS last_name
FROM
    customers;
    
    
    SELECT
    customerName,
    SUBSTRING_INDEX(customerName, ' ', 1) AS first_name,
    SUBSTRING(customerName, LENGTH(SUBSTRING_INDEX(customerName, ' ', 1)) + 2) AS last_name
FROM
    customers;


select locate("r",lastname),lastname from employees where locate("r",lastname)=3;
select locate("r",lastname),lastname from employees where lastName like "___r%";

select lastname ,left(lastname,3),mid(lastname,2,3) from employees;
select customername,mid(customername,1,locate(" ",customername)),mid(customername,locate(" ",customername)) from customers ;
select productcode from products;

select productcode ,left (productcode,locate("_",productcode)-1),mid(productcode,locate("_",porductcode+1),right(productcode,length(productcode)-locate("_",productcode))) from products;
select * from employees where lastname like "__r%";
select * from employees where mid(lastname,3,1)="r"; 

