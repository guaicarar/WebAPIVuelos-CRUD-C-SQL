use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBVUELOS')
CREATE DATABASE DBVUELOS

GO 

USE DBVUELOS

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'vuelos')
create table vuelos(
Idvuelo int primary key identity(1,1),
Numvuelo varchar(20),
Codaerolinea varchar(20),
Ciudadorigen varchar(60),
Ciudaddestino varchar(60),
Horasalida datetime,
Horallegada datetime,
FechaRegistro datetime default getdate()
)

go

select * from dbo.dbvuelos