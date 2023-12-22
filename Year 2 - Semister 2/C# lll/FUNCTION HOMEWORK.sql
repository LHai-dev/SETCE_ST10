CREATE TABLE tblEmployee (
  emp_id INT IDENTITY(1,1) PRIMARY KEY,
  first_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  sex CHAR(1) NOT NULL,
  dob DATE NOT NULL,
  address VARCHAR(255) NOT NULL,
  salary DECIMAL(10,2) NOT NULL
);

INSERT INTO tblEmployee (first_name, last_name, sex, dob, address, salary)
VALUES
  ('Sang', 'Choch', 'm', '2023-01-01', 'PP', 200),
  ('Sopaek', 'Na', 'm', '2023-05-01', 'PP', 250),
  ('Sok', 'Chan', 'f', '1999-01-01', 'PP', 168),
  ('Chab', 'Dina', 'f', '2000-01-05', 'PP', 5000);


CREATE FUNCTION dbo.full_name(@first_name VARCHAR(255), @last_name VARCHAR(255))
RETURNS VARCHAR(255)
AS
BEGIN
  RETURN CONCAT(@first_name, ' ', @last_name);
END;


SELECT emp_id, dbo.full_name(first_name, last_name) AS full_name, sex, dob, address, salary
FROM tblEmployee;



CREATE FUNCTION get_retired_date(@dob DATE, @sex CHAR(1))
RETURNS DATE
AS 
BEGIN
  DECLARE @retirement_age INTEGER;
  DECLARE @retired_date DATE;

  IF @sex = 'm'
    SET @retirement_age = 60;
  ELSE
    SET @retirement_age = 55;

  SET @retired_date = DATEADD(YEAR, @retirement_age, @dob);
  RETURN @retired_date;
END;

SELECT dbo.get_retired_date(dob, sex) AS retired_date
FROM tblEmployee;


CREATE FUNCTION display_currency(@salary DECIMAL(10,2), @currency VARCHAR(10))
RETURNS VARCHAR(255)
AS 
BEGIN
  RETURN @currency + CONVERT(VARCHAR, @salary, 1);
END;



SELECT dbo.display_currency(salary, '$') AS salary
FROM tblEmployee;



-- 2-function showGender (sex) that returns as this format (Male)
CREATE FUNCTION show_gender(@sex VARCHAR(1))
RETURNS VARCHAR(255)
AS
BEGIN
  DECLARE @s VARCHAR(255) = '';

  IF @sex = 'm'
    SET @s = 'Male';
  ELSE IF @sex = 'f'
    SET @s = 'Female';

  RETURN @s;
END;

select dbo.show_gender(sex) gender from tblEmployee;
