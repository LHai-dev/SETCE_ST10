USE [master]
GO
/****** Object:  Database [db_demo]    Script Date: 1/7/2024 6:22:11 PM ******/
CREATE DATABASE [db_demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_demo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_demo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_demo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_demo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_demo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_demo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_demo] SET RECOVERY FULL 
GO
ALTER DATABASE [db_demo] SET  MULTI_USER 
GO
ALTER DATABASE [db_demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_demo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_demo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_demo', N'ON'
GO
ALTER DATABASE [db_demo] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_demo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_demo]
GO
/****** Object:  User [hong]    Script Date: 1/7/2024 6:22:11 PM ******/
CREATE USER [hong] FOR LOGIN [hong] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [app-login]    Script Date: 1/7/2024 6:22:11 PM ******/
CREATE USER [app-login] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [app-login]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 1/7/2024 6:22:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nchar](200) NOT NULL,
	[gener] [nchar](10) NOT NULL,
	[dob] [date] NOT NULL,
	[salary] [smallmoney] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [nchar](100) NOT NULL,
	[password] [nchar](100) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[last_login] [datetime] NOT NULL,
	[otp] [int] NULL,
	[otp_expired] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_find_rec]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_find_rec]
	@id INT
AS
BEGIN
    select * from employees
	WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insert]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert]
    @id INT,
    @name VARCHAR(200),
    @gender VARCHAR(10),
	@dob DATE,
	@salary DECIMAL(7,2)
AS
BEGIN
    INSERT INTO employees(id, name, gener, dob, salary)
    VALUES (@id, @name, @gender, @dob, @salary);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_rec]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_rec]
    @name VARCHAR(200),
    @gender VARCHAR(10),
	@dob DATE,
	@salary DECIMAL(7,2)
AS
BEGIN
    INSERT INTO employees(name, gener, dob, salary)
    VALUES (@name, @gender, @dob, @salary);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_remove_rec]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_remove_rec]
	@id INT
AS
BEGIN
    DELETE employees
	WHERE id = @id;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_update_rec]    Script Date: 1/7/2024 6:22:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_rec]
	@id INT,
    @name VARCHAR(200),
    @gender VARCHAR(10),
	@dob DATE,
	@salary DECIMAL(7,2)
AS
BEGIN
    UPDATE employees
	SET name = @name,
		gener = @gender,
		dob = @dob,
		salary = @salary
	WHERE id = @id;
END;
GO
USE [master]
GO
ALTER DATABASE [db_demo] SET  READ_WRITE 
GO
