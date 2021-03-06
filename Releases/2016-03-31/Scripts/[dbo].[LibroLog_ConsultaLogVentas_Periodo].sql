USE [AdmTramaPLE]
GO
/****** Object:  StoredProcedure [dbo].[LibroLog_ConsultaLogVentas_Periodo]    Script Date: 3/31/2016 2:23:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LibroLog_ConsultaLogVentas_Periodo]
	@mes int,
	@anio int
AS
BEGIN
	SET NOCOUNT ON;

    select Linea,
    IdLibroLog,
    IdLibro,
    Numero,
    FechaComprobante,
    TipoComprobante,
    SerieComprobante,
    NumeroComprobante,
    TipoDocumento,
    NumeroDocumento,
    CodigoDocumento,
    NombreRazonSocial,
    ValorVentaOriginal,
    Moneda,
    TipoCambio,
    VV,
    IGV,
    PV,
    FechaModificada,
    TipoComprobanteModificado,
    NumeroSerieModificado,
    NumeroComprobanteModificado,
    VVModificado,
    IGVModificado,
    PVModificado,
    NumeroUnicoOperacion,
    OperacionNoGravada,
    estado,
    FechaVencimiento,
    ValorEmbarcadoExportacion,
    operaciongravada,
    numerocorrelativo
    from RegistroVentas
    where month(fechaComprobante) = @mes
	and year(fechaComprobante) = @anio
END
