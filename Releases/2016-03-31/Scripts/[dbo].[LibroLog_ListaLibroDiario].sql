USE [AdmTramaPLE]
GO
/****** Object:  StoredProcedure [dbo].[LibroLog_ListaLibroDiario]    Script Date: 3/31/2016 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroLog_ListaLibroDiario] 
AS
BEGIN	
	SET NOCOUNT ON;

	select id,
	IdLibro,
	NombreLibro,
	FechaCarga,
	FechaGeneracion,
	Registros,
	RUC,
	IndicadorOperacion,
	IndicadorMoneda,
	IndicadorLibro,
	TipoLog,
	Errores,
	FechaPeriodo 
	from dbo.LibroLogs
	where TipoLog = 'I'
	and IdLibro = 3
	order by fechacarga desc
END
