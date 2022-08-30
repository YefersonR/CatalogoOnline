Create Database CatalogoOnline
use CatalogoOnline

Create table Users
(
ID int primary key identity(1,1),
FirstName varchar(20),
LastName varchar(30),
PhoneNumber varchar(15),
Email varchar(50),
Addres varchar(60),
UserName varchar(40),
UserPassword varchar(30),
IsActive bit,
Autor varchar(20),
FechaCreacion DateTime,
FechaActualizacion DateTime
)
go





Create table Category(
ID int primary key identity(1,1),
CategoryName varchar(20),
CategoryDescription text,
IsActive bit,
Autor varchar(20),
FechaCreacion DateTime,
FechaActualizacion DateTime
)
go

Create table Products(
ID int primary key identity(1,1),
ProductName varchar(40),
UnitPrice Money,
UnitInStock int,
Garantie text,
Discontinued bit,
CategoryID int,
Autor varchar(20),
FechaCreacion DateTime,
FechaActualizacion DateTime
FOREIGN KEY(CategoryID) REFERENCES Category(ID)

)
go

--Inserts
CREATE PROCEDURE InsertCategory
	@CategoryName varchar(20),
	@CategoryDescription text,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime
AS
	insert into Category
	values(@CategoryName,@CategoryDescription,1);
GO

CREATE PROCEDURE InsertProduct
	@ProductName varchar(40),
	@UnitPrice Money,
	@UnitInStock smallint,
	@Garantie text,
	@Discontinued bit,
	@CategoryID int,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime
AS
	insert into Products
	values(@ProductName,@UnitPrice,@UnitInStock,@Garantie,@Discontinued,@CategoryID);
GO

CREATE PROCEDURE InsertUser
	@FirstName varchar(20),
	@LastName varchar(30),
	@PhoneNumber varchar(15),
	@Email varchar(50),
	@Address varchar(60),
	@UserName varchar(40),
	@UserPassword varchar(30),
	@IsActive bit,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime
AS
	insert into Users
	values(@FirstName,@LastName,@PhoneNumber,@Email,@Address,@UserName,@UserPassword,@IsActive);
GO


--Deletes

CREATE PROCEDURE DeleteProducts
	@ID int 
AS
	DELETE FROM Products WHERE ID = @ID;
GO

CREATE PROCEDURE DeleteCategory
	@ID int 
AS
	DELETE FROM Category WHERE ID = @ID;
GO

CREATE PROCEDURE DeleteUser
	@ID int 
AS
	DELETE FROM Users WHERE ID = @ID;
GO
--Updates
CREATE PROCEDURE SetProducts
	@ID int,
	@ProductName varchar(40),
	@UnitPrice Money,
	@UnitInStock smallint,
	@Garantie text,
	@Discontinued bit,
	@CategoryID int,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime

AS
	UPDATE Products
	SET ProductName = @ProductName,
	UnitPrice = @UnitPrice,
	UnitInStock = @UnitInStock,
	Garantie = @Garantie,
	Discontinued= @Discontinued,
	CategoryID = @CategoryID

	WHERE ID = @ID;
GO

CREATE PROCEDURE SetCategorys
	@ID int,
	@CategoryName varchar(20),
	@CategoryDescription text,
	@IsActive bit,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime
AS
	UPDATE Category
	SET CategoryName = @CategoryName,
	CategoryDescription = @CategoryDescription,
	IsActive= @IsActive
	WHERE ID = @ID;
GO

CREATE PROCEDURE SetUsers
	@ID int ,
	@FirstName varchar(20),
	@LastName varchar(30),
	@PhoneNumber varchar(15),
	@Email varchar(50),
	@Address varchar(60),
	@UserName varchar(40),
	@UserPassword varchar(30),
	@IsActive bit,
	@Autor varchar(20),
	@FechaCreacion DateTime,
	@FechaActualizacion DateTime
AS
	UPDATE Products
	SET @FirstName = @FirstName,
	@LastName = @LastName,
	@PhoneNumber = @PhoneNumber,
	@Email = @Email,
	@Address= @Address,
	@UserName= @UserName,
	@UserPassword= @UserPassword,
	@IsActive= @IsActive
	WHERE ID = @ID;
GO

--Get
CREATE PROCEDURE GetAllProducts
AS
	select * from Products
GO

CREATE PROCEDURE GetAllCategory
AS
	select * from Category
GO

CREATE PROCEDURE GetCategoryById
	@ID int
AS
	select * from Category where ID = @ID
GO

CREATE PROCEDURE GetProductById
	@ID int
AS
	select * from Products where ID = @ID
GO

CREATE PROCEDURE SearchProducts
	@ProductName varchar(40)
AS
	select * from Products where ProductName like '%'+@ProductName+'%' 
GO

CREATE PROCEDURE FilterByCategory
	@CategoryID int
AS
	select * from Products where CategoryId = @CategoryId  
GO

CREATE PROCEDURE UserLogin
	@UserName varchar(40),
	@UserPassword varchar(30)
AS
	select * from Users where UserName = @UserName and UserPassword = @UserPassword
GO
