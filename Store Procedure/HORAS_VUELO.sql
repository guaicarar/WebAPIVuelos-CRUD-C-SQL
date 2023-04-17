SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

create procedure usp_horas_vuelo(@horasalida datetime, @horallegada datetime )
as
begin

select   format(segundos / 3600, '00') + ':' 
       + format(segundos % 3600 / 60, '00') + ':' 
       + format(segundos % 60, '00') horavuelo
  from (select datediff(second, @horasalida , @horallegada) as segundos) q1

end