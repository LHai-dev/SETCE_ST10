CREATE TABLE sale_master (
  sale_id INT NOT NULL,
  sale_datetime DATETIME NOT NULL,
  supplier_id INT NOT NULL,
  customer_id INT NOT NULL,
  delivery_day DATE NOT NULL,
  exchange_rate DECIMAL(10,2) NOT NULL,
  created_date DATETIME NOT NULL,
  created_by INT NOT NULL,
  updated_date DATETIME NULL,
  updated_by INT NULL,
  PRIMARY KEY (sale_id)
);

CREATE TABLE sale_detail (
  sale_detail_id INT NOT NULL,
  sale_id INT NOT NULL,
  pro_id INT NOT NULL,
  price DECIMAL(10,2) NOT NULL,
  qty INT NOT NULL,
  discount DECIMAL(10,2) NULL,
  created_date DATETIME NOT NULL,
  created_by INT NOT NULL,
  updated_date DATETIME NULL,
  updated_by INT NULL,
  PRIMARY KEY (sale_detail_id),
  FOREIGN KEY (sale_id) REFERENCES sale_master (sale_id)
);

CREATE TABLE product (
  pro_id INT NOT NULL,
  pro_name VARCHAR(255) NOT NULL,
  is_active BIT NOT NULL,
  supplier_id INT NOT NULL,
  customer_id INT NOT NULL,
  PRIMARY KEY (pro_id),
  FOREIGN KEY (supplier_id) REFERENCES supplier (supplier_id),
  FOREIGN KEY (customer_id) REFERENCES customer (customer_id)
);

CREATE TABLE supplier (
  supplier_id INT NOT NULL ,
  first_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  is_active BIT NOT NULL,
  PRIMARY KEY (supplier_id)
);

CREATE TABLE customer (
  customer_id INT NOT NULL ,
  first_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  is_active BIT NOT NULL,
  PRIMARY KEY (customer_id)
);



-- Insert data into supplier table
INSERT INTO supplier (supplier_id, first_name, last_name, is_active)
VALUES 
(1, 'Supplier1_FirstName', 'Supplier1_LastName', 1),
(2, 'Supplier2_FirstName', 'Supplier2_LastName', 1),
(3, 'Supplier3_FirstName', 'Supplier3_LastName', 1);

-- Insert data into customer table
INSERT INTO customer (customer_id, first_name, last_name, is_active)
VALUES 
(1, 'Customer1_FirstName', 'Customer1_LastName', 1),
(2, 'Customer2_FirstName', 'Customer2_LastName', 1),
(3, 'Customer3_FirstName', 'Customer3_LastName', 1);

-- Insert data into product table
INSERT INTO product (pro_id, pro_name, is_active, supplier_id, customer_id)
VALUES 
(1, 'Product1', 1, 1, 1),
(2, 'Product2', 1, 2, 2),
(3, 'Product3', 1, 3, 3);

-- Insert data into sale_master table
INSERT INTO sale_master (sale_id, sale_datetime, supplier_id, customer_id, delivery_day, exchange_rate, created_date, created_by, updated_date, updated_by)
VALUES 
(1, '2023-11-13 12:00:00', 1, 1, '2023-11-14', 1.5, '2023-11-13 12:00:00', 1, NULL, NULL),
(2, '2023-11-14 14:30:00', 2, 2, '2023-11-15', 1.3, '2023-11-14 14:30:00', 2, NULL, NULL),
(3, '2023-11-15 10:45:00', 3, 3, '2023-11-16', 1.2, '2023-11-15 10:45:00', 3, NULL, NULL);

-- Insert data into sale_detail table
INSERT INTO sale_detail (sale_detail_id, sale_id, pro_id, price, qty, discount, created_date, created_by, updated_date, updated_by)
VALUES 
(1, 1, 1, 50.00, 5, 2.00, '2023-11-13 12:05:00', 1, NULL, NULL),
(2, 2, 2, 30.00, 3, 1.50, '2023-11-14 14:35:00', 2, NULL, NULL),
(3, 3, 3, 25.00, 4, 1.00, '2023-11-15 10:50:00', 3, NULL, NULL);



-- Report 1
SELECT
    sm.sale_id,
    sm.sale_datetime,
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    p.pro_name AS product,
    sd.price,
    sd.qty,
    sd.discount,
    (sd.price * sd.qty - sd.discount) AS subtotal_usd,
    c.customer_id,
    sd.price * sd.qty - sd.discount AS subtotal_riel,
    sm.delivery_day,
    sm.created_date AS delivery_date
FROM
    sale_master sm
INNER JOIN
    sale_detail sd ON sm.sale_id = sd.sale_id
INNER JOIN
    customer c ON sm.customer_id = c.customer_id
INNER JOIN
    product p ON sd.pro_id = p.pro_id;


	-- Report 2
SELECT
    c.customer_id,
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    t.total_usd,
    t.total_riel
FROM
    customer c
INNER JOIN (
    SELECT
        sm.customer_id,
        SUM(sd.price * sd.qty - sd.discount) AS total_usd,
        SUM((sd.price * sd.qty - sd.discount) * sm.exchange_rate) AS total_riel
    FROM
        sale_master sm
    INNER JOIN
        sale_detail sd ON sm.sale_id = sd.sale_id
    GROUP BY
        sm.customer_id
) t ON t.customer_id = c.customer_id;

-- Report 3
SELECT
    sm.customer_id,
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    p.pro_name AS product,
    (p.price * sd.qty - sd.discount) * sm.exchange_rate AS total_usd
FROM
    sale_master sm
INNER JOIN
    sale_detail sd ON sm.sale_id = sd.sale_id
INNER JOIN
    customer c ON c.customer_id = sm.customer_id
INNER JOIN
    product p ON p.pro_id = sd.pro_id;