-- 1
select * from customers
where left(contactFirstName,length(trim(contactFirstName))/2) like '%l' and length(trim(contactFirstName))%2!=0
;

-- 2

select products.productCode,quantityInStock,sum(quantityOrdered)as TotalOrdered,quantityInStock-(sum(quantityOrdered)) as afterOrdered from products  
inner join orderdetails on products.productCode = orderdetails.productCode
group by orderdetails.productCode
limit 10
;
-- 3
Select products.productCode,productName from products
left join orderdetails
on products.productCode=orderdetails.productCode
where orderdetails.productCode is null;

-- 4
select customers.customerNumber,customerName,"customers" as FromTable from customers
union all
select orders.customerNumber,status,"orders" from orders

; 


-- 5

Select group_concat(productLine separator";") as Mixed from productlines;