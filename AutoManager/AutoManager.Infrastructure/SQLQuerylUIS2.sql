USE master;
-- (localdb)\MSSQLLocalDb THEN expand databases options



-- Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Application Name="SQL Server Management Studio";Command Timeout=0

CREATE TABLE CarStatus
(
   Id TinyInt not null Primary key,
   StatusName VARCHAR(20) NOT NULL UNIQUE,
)

DROP TABLE IF EXISTS CAR;
CREATE TABLE CAR
(
	-- Id Int PRIMARY KEY AUTOINCREMENT,
 	-- ID GUID primary key not null,--  GUI NOT COMPABILBE HERE
	ID UNIQUEIDENTIFIER Not null primary key, -- DEFAULT NEWID(),
	Manufacturer varchar(20) not null,
	[Year] int not null,
	Price decimal(12,2) not null,
	-- [Status] varchar (20) NOT NULL Check ENUMS ARE NTO SUPPORTED in MSSQL
	StatusId TINYINT NOT NULL,

	CreatedAt datetime2 not null  DEFAULT SYSDATETIME(),
	DeletedAt datetime2 null	

	CONSTRAINT FK_Car_CarStatus
	Foreign key (StatusId) References CarStatus(ID)
)

-- Then insert into some status and car samples.
INSERT INTO CarStatus(ID, StatusName)
VALUES (1, 'Available'),(2, 'Sold'), (3, 'Reserved'), (4,'Maintenance');

select * from CarStatus;


-- Then as car may increains exponensitainlly,I like to add an index to speed up filtering by year
INSERT INTO CAR(ID, Manufacturer, [YEAR], Price, StatusId)
Values 
	(NEWID(), 'Ford', 2011, 30000.00, 1),
	 (NEWID(), 'Chrysler', 2011, 30000.00, 2),
	  (NEWID(), 'Ford', 2012, 30000.00, 3);
	  


-- index for millions grows and speeding up performaces
CREATE NONCLUSTERED INDEX Idx_Car_Year_Status
ON CAR ([Year], StatusId);

-- TO REMOVE IT
DROP INDEX car.Idx_Car_Year_Status;
GO;
-- so next eeclt will go faster

-- ========================================
-- Backing up: Right clienc, Task -> back or using the T-SQL statements
BACKUP DATABASE VehicleManager
TO DISK = 'C:\Users\LuisSilva\VehicleManager2.bak'
WITH FORMAT,
     INIT,
     NAME = 'Full Backup of MyDatabase';
GO;

-- ===================================
-- Store proceduder to generate dummy inserts
CREATE OR ALTER PROCEDURE dbo.GenerateMockCars
	@Count INT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @i INT =1;
	WHILE @i <= @Count
	Begin
		INSERT INTO Car (id, Manufacturer, [Year], Price, StatusId)
		Values(
		
			NEWID(),
			CASE ABS(CHECKSUM(NEWID())) % 8
				WHEN 0 THEN 'Toyota'
				WHEN 1 THEN 'Ford'
				WHEN 2 THEN 'Chrysler'
				WHEN 3 THEN 'Testla'
				ELSE 'Nissan'
			END, 
			2000 + ABS(CHECKSUM(NEWID())) % 27, -- Year 2000 ~ 2026
			CAST(
				10000 + ABS(CHECKSUM(NEWID())) % 90000 AS DECIMAL (12,2)
			), 
			1 + ABS(CHECKSUM(NEWID())) % 4

		);

		SET @i += 1;

	End
END;
-- Time to execute it

EXECUTE dbo.GenerateMockCars @Count = 100;

EXEC dbo.GenerateMockCars @Count = 2000000; -- 2 millons
EXEC dbo.GenerateMockCars @Count = 500000; -- 0.5 millons



-- TO VERIFY HOS THE NEW INDES IS HANDLING THE DATA
SET STATISTICS IO ON;
SET STATISTICS TIME ON;
 
SELECT -- TOP 10 
* FROM CAR AS C		
				INNER JOIN CarStatus AS CS ON c.StatusId = cs.Id
WHERE C.[Year] = 2024 AND cs.StatusName LIKE '%Available%';


-- TO REMOVE IT INDEX
DROP INDEX IF EXISTS car.Idx_Car_Year_Status;
-- AND REMOVING CACHE TO EVALUES THE TIME IT TAKE TO RENDER THE prevouis filtering
CHECKPOINT; 
DBCC DROPCLEANBUFFERS;
DBCC FREEPROCCACHE;