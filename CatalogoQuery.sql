Create Database CatalogoOnline
use CatalogoOnline

-- Usuario Base

Create table Roles
(
ID int primary key identity(1,1),
RoleName varchar(20)
)
go

Create table UsersRoles
(
UserId int,
RoleId int,
FOREIGN KEY(UserId) REFERENCES Users(ID),
FOREIGN KEY(RoleId) REFERENCES Roles(ID),
)
go

Create table Users
(
ID int primary key identity(1,1),
FirstName varchar(20),
LastName varchar(30),
PhoneNumber varchar(15),
Email varchar(50),
Addres varchar(60),
UserName varchar(40),
UserPassword varchar(MAX),
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
IsActive bit
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
insert into Roles(RoleName)
values('Administrador'),('Cliente');
insert into Users(FirstName,LastName,PhoneNumber,Email,Addres,UserName,UserPassword,IsActive,Autor,FechaCreacion)
values('Administrador','Administrador','00000000000','Admin@gmail.com','Admin','Admin','c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f',1,'Administrador',GETDATE());

CREATE PROCEDURE InsertRoleToUser
	@UserId int,
	@RoleId int
AS
	insert into UsersRoles(RoleId,UserId)
	values(@RoleId,@UserId);
GO

CREATE PROCEDURE UpdateRoleToUser
	@UserId int,
	@RoleId int
AS
	UPDATE UsersRoles
	SET RoleId = @RoleId,
	UserId = @UserId
	WHERE UserId = @UserId;

GO

CREATE PROCEDURE InsertCategory
	@CategoryName varchar(20),
	@CategoryDescription text,
	@Autor varchar(20),
	@FechaCreacion DateTime
AS
	insert into Category(CategoryName,CategoryDescription,IsActive,Autor,FechaCreacion)
	values(@CategoryName,@CategoryDescription,1,@Autor,@FechaCreacion);
GO

CREATE PROCEDURE InsertProduct
	@ProductName varchar(40),
	@UnitPrice Money,
	@UnitInStock smallint,
	@Garantie text,
	@CategoryID int,
	@Autor varchar(20),
	@FechaCreacion DateTime
AS
	insert into Products(ProductName,UnitPrice,UnitInStock,Garantie,Discontinued,CategoryID,Autor,FechaCreacion)
	values(@ProductName,@UnitPrice,@UnitInStock,@Garantie,0,@CategoryID,@Autor,@FechaCreacion);
GO

CREATE PROCEDURE InsertUser
	@FirstName varchar(20),
	@LastName varchar(30),
	@PhoneNumber varchar(15),
	@Email varchar(50),
	@Address varchar(60),
	@UserName varchar(40),
	@UserPassword varchar(MAX),
	@Autor varchar(20),
	@FechaCreacion DateTime
AS
	insert into Users(FirstName,LastName,PhoneNumber,Email,Addres,UserName,UserPassword,IsActive,Autor,FechaCreacion)
	values(@FirstName,@LastName,@PhoneNumber,@Email,@Address,@UserName,@UserPassword,1,@Autor,@FechaCreacion);
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
	alter table UsersRoles nocheck constraint all
	DELETE FROM Users WHERE ID = 4;
	alter table UsersRoles check constraint all
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
	@FechaActualizacion DateTime

AS
	UPDATE Products
	SET ProductName = @ProductName,
	UnitPrice = @UnitPrice,
	UnitInStock = @UnitInStock,
	Garantie = @Garantie,
	Discontinued= @Discontinued,
	CategoryID = @CategoryID,
	Autor = @Autor,
	FechaActualizacion=@FechaActualizacion
	WHERE ID = @ID;
GO

CREATE PROCEDURE SetCategorys
	@ID int,
	@CategoryName varchar(20),
	@CategoryDescription text,
	@IsActive bit,
	@Autor varchar(20),
	@FechaActualizacion DateTime
AS
	UPDATE Category
	SET CategoryName = @CategoryName,
	CategoryDescription = @CategoryDescription,
	IsActive= @IsActive,
	Autor=@Autor,
	FechaActualizacion=@FechaActualizacion
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
	@UserPassword varchar(MAX),
	@IsActive bit,
	@Autor varchar(20),
	@FechaActualizacion DateTime
AS
	UPDATE Users
	SET FirstName = @FirstName,
	LastName = @LastName,
	PhoneNumber = @PhoneNumber,
	Email = @Email,
	Addres= @Address,
	UserName= @UserName,
	UserPassword= @UserPassword,
	IsActive= @IsActive,
	FechaActualizacion =@FechaActualizacion 
	WHERE ID = @ID;
GO

--Get
CREATE PROCEDURE GetAllProducts
AS
	select * from Products
GO

CREATE PROCEDURE GetAllActivesProducts
AS
	select * from Products where Discontinued = 0
GO

CREATE PROCEDURE GetAllCategory
AS
	select * from Category
GO

CREATE PROCEDURE GetActiveCategory
AS
	select * from Category where IsActive = 1
GO

CREATE PROCEDURE GetAllUsers
AS
	select * from Users 
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

CREATE PROCEDURE GetUserById
	@ID int
AS
	select * from Users where ID = @ID
GO

CREATE PROCEDURE SearchProducts
	@ProductName varchar(40)
AS
	select * from Products where ProductName like '%'+@ProductName+'%' and Discontinued = 0
GO

CREATE PROCEDURE FilterByCategory
	@CategoryID int
AS
	select * from Products where CategoryId = @CategoryId  and Discontinued = 0
GO

CREATE PROCEDURE UserLogin
	@UserName varchar(40),
	@UserPassword varchar(MAX)
AS
	select ID,FirstName,LastName,PhoneNumber,Email,Addres,UserName,Autor from Users where UserName = @UserName and UserPassword = @UserPassword and IsActive = 1
GO

CREATE PROCEDURE AdminLogin
	@UserName varchar(40),
	@UserPassword varchar(MAX)
AS
	select ID,FirstName,LastName,PhoneNumber,Email,Addres,UserName,Autor from Users
	join UsersRoles
	on Users.ID = UsersRoles.UserId	
	where Users.UserName = @UserName and Users.UserPassword = @UserPassword and UsersRoles.UserId = Users.ID and UsersRoles.RoleId = 1
GO
