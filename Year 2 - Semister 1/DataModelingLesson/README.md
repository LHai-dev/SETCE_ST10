"# DataModelingLesson" 
# លំហាត់១

**តាសមកម្មតកម**(WaitingNumber, Logo , location , Shop-Name, dataOrder, receiptNumber ,QTY, Price ,Vat, User-Account, Customer-number, Product Name, CategoryName, Exchange-Rate, Wifi-Name, WiFi -Password, Receive-Invoice, Supplyer-Name, Receive-Date Tel)

### ធ្វើ1NFបានលុះត្រាតែRemove Repeating Group

-Receipt(Receipt Number ,Waiting Number ,Date Order,Vat)

-Shop(Logo , Location , Shop Name)

-Category(Category Name);

-Product(Product Name Account , User Password Account)

-Customer(Cutomer Number, Customer Name, Tel)

-Wifi(Wifi Name , Wifi Password)

-Exchange Rate (kh,…..)

-Receive(Receive Invoice , Receive Data)

-Suppyier ( Supplyer Name, Tel)

### ធ្វើ2NFបានលុះត្រាតែធ្វើ1NFសិននិងគ្មានPartial Dependencies

-Receipt(ReceiptID**(PK)** ,ReceiptNumber , Vat , WaitingNumber , DateOrder)

-Shop(ShopID**(PK)** , Logo , Location , ShopName)

-Category(categoryID**(PK)** , categoryName)

-Product(productID**(PK**) ,ProductName , QTY , Price)

-Account (UserIDAccount**(PK**) , UserNmaeAccount , userPasswordAccount)

-customer(CustomerID**(PK)** , UserNameAccount , userNumber ,customerNmae , Tel)

-Wifi( WifiID **(PK)** , WifiName , WifiPassword)

-ExchangeRate (ExchangerateID**(PK)** , KHR,…..)

-Receive(receiveID**(PK)** , ReceiveInvoice , Receivedate)

-Supplyer(SupplyerID**(PK)** , SupplyerName , Tel)

### ធ្វើ3NFបានលុះត្រាតែធ្វើ2NFសិននិងគ្មាន transitive Dependencies

--Receipt(ReceiptID**(PK)** ,ReceiptNumber , Vat , WaitingNumber , DateOrder, ShopID**(FK)** , UserID**(FK)** , CustomerID**(FK)** , WifiID**(FK)** , ExchangeRateID**(Fk)**)

-Shop(ShopID**(PK)** , Logo , Location , ShopName)

-Category(categoryID**(PK)** , categoryName , ShopID(Fk) , UserID**(FK)**)

-Product(productID**(PK)**,ProductName , QTY , Price)

-Account (UserIDAccount**(PK**) , UserNmaeAccount , userPasswordAccount)

-customer(CustomerID**(PK)** , UserNameAccount , userNumber ,customerNmae , Tel)

-Wifi( WifiID **(PK)** , WifiName , WifiPassword)

-ExchangeRate (ExchangerateID(PK) , KHR,…..)

-Receive(receiveID**(PK)** , ReceiveInvoice , Receivedate , SupplyerID(Fk))

-Supplyer(SupplyerID**(PK)** , SupplyerName , Tel)
