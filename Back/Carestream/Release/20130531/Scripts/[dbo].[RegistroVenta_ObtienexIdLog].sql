USE [BDTramaPLE]
GO
/****** Object:  StoredProcedure [dbo].[RegistroVenta_ObtienexIdLog]    Script Date: 05/31/2013 23:23:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[RegistroVenta_ObtienexIdLog]	4
-- =============================================
ALTER PROCEDURE [dbo].[RegistroVenta_ObtienexIdLog]	
	@id_archivo_log int
AS
BEGIN
	SET NOCOUNT ON;

    select 
    id_archivo_log,
    id_linea,
    num_correlativo,
    fecha_comprobante,
    tipo_comprobante,
    interno_comprobante,
    serie_comprobante,
    num_comprobante,
    tipo_documento,
    num_documento,
    codigo_documento,
    nombre_razon_social,
    valor_venta_orig,
    moneda,
    tipo_cambio,
    vv,
    igv,
    pv,
    fechamod,
    tipomod,
    seriemod,
    nomod,
    vvmod,
    igvmod,
    pvmod,
    estado
    from dbo.InputRegistroVenta
    where id_archivo_log = @id_archivo_log
END
