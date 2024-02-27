-- 1.  ចូរបង្ហាញទិន្នន័យ Column ProductCode និង មធ្យមភាគ នៃ Column PriceEach របស់ ProductCode និមួយៗ រួចធ្វើការបង្គត់ជាលេខគត់ របស់ Table OrderDetails (109 Rows)
select ProductCode, round(avg(PriceEach)) as AveragePrice
from OrderDetails
group by ProductCode;
-- 2.   ចូរបង្ហាញទិន្នន័យ Column CustomerNumber និង តម្លៃសរុប នៃ Column Amount របស់ CustomerNumber  របស់ Table Payments ដោយយកតែ តម្លៃសរុប នៃ Column Amount មានតួទី 3 ខាងមុខក្បៀសជាលេខ 5,6,7 (39 Rows)
select  customernumber,sum(amount) from payments
group by customernumber
having substring(substring_index(sum(amount), '.', 1), -3) like "5%"
  or substring(substring_index(sum(amount), '.', 1), -3) like "6%"
  or substring(substring_index(sum(amount), '.', 1), -3) like "7%";
-- 3.  ចូរបង្ហាញទិន្នន័យ Column EmployeeNumber,Lastname និង ទិន្នន័យដែលកាត់យកតែអក្សរខាងមុខនៃសញ្ញា @ នៃ Column Email  របស់ Table Employees (23 Rows)
-- 3
select EmployeeNumber, Lastname, substring_index(email,'@',1) as EmailName
from Employees; 
-- 4.  ចូរបង្ហាញទិន្នន័យ Column ទាំងអស់ របស់ Table Payments ដោយយកតែ PaymentDate មានខែលេខគូ ហាមប្រើ Function: Month, Date_format (132 Rows)
select * from Payments
where substring(paymentdate,6,2)% 2 = 0;
-- 5.  ចូរបង្ហាញទិន្នន័យ Column ទាំងអស់ របស់ Table Payments ដោយយកតែ PaymentDate មានថ្ងៃលេខសេស ហាមប្រើ Function: Day, Date_format (135 Rows)
select * from Payments
where right(PaymentDate,1) % 2 <> 0;
