--4.  ចូរបង្ហាញទិន្នន័យ Column ទាំងអស់ដែលមាននៅក្នុង Table Customers ដែលយកតែ Column ContactLastname មានផ្ទុកអក្សរ A ចំនួន 2 តួរ និង មានលាយអក្សរ L (3 Rows)
select * from customers where (length(contactlastname)-length(replace(contactlastname,'a','')) + length (contactlastname) - length (replace(contactlastname,'A',''))) = 2 and contactlast like '%L%';


