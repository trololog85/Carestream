USE [AdmTramaPLE]
GO
/****** Object:  StoredProcedure [dbo].[LibroLog_ConsultaLogCompras_Periodo]    Script Date: 3/31/2016 2:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LibroLog_ConsultaLogCompras_Periodo]
	@mes int,
	@anio int
AS
BEGIN
	SET NOCOUNT ON;

    select IdLibroLog,
    Linea,
    IdLibro,
    NumeroOperacion,
    FechaEmision,
    FechaVencimiento,
    TipoComprobante,
    NumeroSerieComprobante,
    AnioEmisionComprobante,
    NumeroComprobante,
    TipoDocumento,
    NumeroDocumento,
    NombreRazonSocial,
    BaseImponibleGravada,
    IGVGravado,
    BaseImponibleMixta,
    IGVMixto,
    BaseImponibleNoGravada,
    IGVNoGravado,
    AdquisicionNoGravada,
    ISC,
    OtrosTributos,
    Total,
    ComprobanteNoDomiciliado,
    NumeroConstancia,
    FechaEmisionConstancia,
    TipoCambio,
    FechaOriginal,
    TipoDocumentoOriginal,
    NumeroSerieOriginal,
    NumeroDocumentoOriginal,
    Pago,
    FechaPago,
    Detraccion,
    TasaDetraccion,
    ImporteDetraccion,
    Retencion,
    ImporteRetencion,
    MotivoRetencion,
    RevisionTasa,
    RevisionTipoCambio,
    RevisionVerificacion,
    BaseRevision,
    IGVRevision,
    TipoGasto,
    Recepcion,
    Comentario1,
    Comentario2,
    VB,
    CompraGravadaPais,
    CompraGravadaExterior,
    CompraNoGravada,
    IGVPais,
    Exterior,
    OtrosCargos,
    Total1,
    Estado,
    codigounicooperacion,
    numerocorrelativo,
    DUA,
	ClasificacionBien as ClasificacionBien1
    from dbo.RegistroCompras
    where month(FechaEmision) = @mes
	and year(FechaEmision) = @anio
END
