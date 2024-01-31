--4.  ចូរបង្ហាញទិន្នន័យ Column ទាំងអស់ដែលមាននៅក្នុង Table Customers ដែលយកតែ Column ContactLastname មានផ្ទុកអក្សរ A ចំនួន 2 តួរ និង មានលាយអក្សរ L (3 Rows)
select * from customers where (length(contactlastname)-length(replace(contactlastname,'a','')) 
  + length (contactlastname) - length (replace(contactlastname,'A',''))) = 2 and contactlast like '%L%';
-- 1.  រាប់ចំនួន Status តាមប្រភេទ Status នីមួយៗ ដែលមាននៅក្នុង Table Orders
-- ដោយបង្ហាញ 6 columns (Shipped, Resolved, Cancelled, On Hold, Disputed, In Process) ដោយប្រើ Function IF

select 
  sum(if(status = 'Shipped',1,0))as Shipped,
  sum(if(status = 'Resolved',1,0))as Resolved,
  sum(if(status = 'Cancelled',1,0))as Cancelled,
  sum(if(status = 'On Hold',1,0))as OnHold,
  sum(if(status = 'Disputed',1,0))as Disputed,
  sum(if(status = 'In Process',1,0))as InProcess from Orders; 


--2.  ចូរបង្ហាញ ទិន្នន័យ Column ទាំងអស់ ពី Table Productlines តែចំពោះ Column productline
--  ទិន្នន័យ “Classic Cars” ត្រូវបង្ហាញ “CC”
--  ទិន្នន័យ “Motorcycles” ត្រូវបង្ហាញ “MC”
--  ទិន្នន័យ “Planes” ត្រូវបង្ហាញ “P”
--  ទិន្នន័យ “Ships” ត្រូវបង្ហាញ “S”
--  ទិន្នន័យ “Trains” ត្រូវបង្ហាញ “T”
--  ទិន្នន័យ “Trucks and Buses” ត្រូវបង្ហាញ “T&B”
--  ទិន្នន័យ “Vintage Cars” ត្រូវបង្ហាញ “VC” ដោយប្រើ Function IF  


-- 3.  ចូរកែទិន្នន័យទាំងអស់ ដែលនៅក្នុង Table offices ចំពោះ state ណាដែលមានទិន្នន័យទទេ ប្ដូរជា “Don’t Have” បើមានទិន្នន័យប្ដូរជា “Have” (7 Rows)

-- 5.  ចូរកែទិន្នន័យ Table Products ដោយកែត្រង់ Column QuantityInstock តាមលក្ខខណ្ឌដូចខាងក្រោម 
--   បើ Column Productline មានទិន្នន័យ “Planes”  ថែម 50 លើ QuantityInstock ចាស់
--   បើ Column Productline មានទិន្នន័យ “Classic Cars”  ថែម 10 លើ QuantityInstock ចាស់
--   បើ Column Productline មានទិន្នន័យ “Trains”  ថែម 100 លើ QuantityInstock ចាស់
--   ខុសពីលក្ខខណ្ឌខាងលើត្រូវរក្សា QuantityInstock នៅដដែល ដោយប្រើ Function IF
