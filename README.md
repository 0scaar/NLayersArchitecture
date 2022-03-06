# N Layers Architecture
The project uses ADO.Net to connect to a SQL Server database . 

## Technologies
- ASP.NET Core 6
- ADO.Net

## Info
- Generic methods have been created to call the Stored Procedures.
- An API project was implemented to visualize the data.

## Layers
- Presentation Layer
- Business Logic Layer
- Data Access Layer

## Database Configuration
### String Connection
```cs
public class Connection
{
    public static string stringConnection = @"Data Source=localhost;Initial Catalog=Sales;user=sa;pwd=abcDEF123#"; 
}
```

### Query
```sql
CREATE TABLE Sales.dbo.Sale (
	Id uniqueidentifier DEFAULT newid() NOT NULL,
	CustomerName varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Country varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DateSale datetime NULL,
	TotalPrice decimal(10,2) NULL,
	Quantity int NULL,
	CONSTRAINT PK__Sale__3214EC07E543BB42 PRIMARY KEY (Id)
);

CREATE TABLE Sales.dbo.SaleDetail(
	Id uniqueidentifier DEFAULT newid() NOT NULL,
	Product varchar(50) NOT NULL,
	Quantity int NULL,
	Price decimal(10,2) NULL,
	SaleId uniqueidentifier, 
	FOREIGN KEY (SaleId) REFERENCES Ventas.dbo.Sale(Id)
)

INSERT INTO Sales.dbo.Sale (Id,CustomerName,Country,DateSale,TotalPrice,Quantity) VALUES
	 (N'8DFEB9B7-E055-470D-BAAA-10D20683619F',N'Oscar Campos',N'Peru','2022-03-04 02:29:02.743',2345.40,6),
	 (N'9A411EA0-852B-461B-81A7-40907A9BFD75',N'Oscar Cama',N'Peru','2021-10-12 00:00:00.0',4572.00,23),
	 (N'02FEC7DB-4255-425D-97CA-A2BAD631EA73',N'Juan Ore',N'Peru','2022-03-04 02:29:33.27',2345.40,6);
	
INSERT INTO Sales.dbo.SaleDetail (Id,Product,Quantity,Price,SaleId) VALUES
	 (N'0BF81366-89DF-44A3-9252-9A8C66ECC91C',N'Mouse',2,72.70,N'8DFEB9B7-E055-470D-BAAA-10D20683619F'),
	 (N'70A7A428-2066-48AA-B6A1-82273A48A4CA',N'Laptop',4,550.00,N'8DFEB9B7-E055-470D-BAAA-10D20683619F'),
	 (N'4828C3F1-6E6D-4C5F-A87E-577A7D61562F',N'keyboard',23,198.78,N'9A411EA0-852B-461B-81A7-40907A9BFD75'),
	 (N'7CE05710-0510-4D46-9BB2-9AC0EED87E21',N'Ipad',6,390.90,N'02FEC7DB-4255-425D-97CA-A2BAD631EA73');

create procedure GetSalesByName
@name varchar(50)
as 
begin
	set @name = LOWER(@name)  
	
	select * from Sales.dbo.Sale 
	where LOWER(CustomerName) like '%'+ @name +'%'
end;

create procedure GetAllSales
@jsonOutput nvarchar(max) output
as 
begin
	set @jsonOutput = (
		select 
		s.CustomerName,
		s.Country,
		s.DateSale,
		s.Quantity,
		s.TotalPrice,
		SaleDetails = (select Product, Quantity, Price from Sales.dbo.SaleDetail d WHERE d.SaleId = s.Id for JSON path)
		from Sales.dbo.Sale s
		for JSON path)
end;

```
