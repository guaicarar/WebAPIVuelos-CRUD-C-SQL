SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

create procedure usp_ciudades_visitadas(@ciudaddestino varchar(60))
as
begin

select count(*) as nroveces from vuelos where Ciudaddestino = @ciudaddestino
end

