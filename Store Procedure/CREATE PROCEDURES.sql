go

use DBVUELOS
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrar')
DROP PROCEDURE usp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificar')
DROP PROCEDURE usp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtener')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listar')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminar')
DROP PROCEDURE usp_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure usp_registrar(
@Numvuelo varchar(20),
@Codaerolinea varchar(20),
@Ciudadorigen varchar(60),
@Ciudaddestino varchar(60),
@Horasalida datetime,
@Horallegada datetime
)
as
begin

insert into VUELOS(Numvuelo,Codaerolinea,Ciudadorigen,Ciudaddestino,Horasalida,Horallegada)
values
(
@numvuelo,
@codaerolinea,
@ciudadorigen,
@ciudaddestino,
@horasalida,
@horallegada
)

end


go

create procedure usp_modificar(
@Idvuelo int,
@Numvuelo varchar(20),
@Codaerolinea varchar(20),
@Ciudadorigen varchar(60),
@Ciudaddestino varchar(60),
@Horasalida datetime,
@Horallegada datetime
)
as
begin

update VUELOS set 
Numvuelo =@numvuelo,
Codaerolinea=@codaerolinea,
Ciudadorigen=@ciudadorigen,
Ciudaddestino=@ciudaddestino,
Horasalida=@horasalida,
Horallegada=@horallegada

where Idvuelo = @idvuelo

end

go

create procedure usp_obtener(@idvuelo int)
as
begin

select * from vuelos where Idvuelo = @idvuelo
end

go
create procedure usp_listar
as
begin

select * from vuelos
end


go

go

create procedure usp_eliminar(
@idvuelo int
)
as
begin

delete from vuelos where Idvuelo = @idvuelo

end