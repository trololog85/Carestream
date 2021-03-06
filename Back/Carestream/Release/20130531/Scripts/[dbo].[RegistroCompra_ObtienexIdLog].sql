USE [BDTramaPLE]
GO
/****** Object:  StoredProcedure [dbo].[RegistroCompra_ObtienexIdLog]    Script Date: 05/31/2013 23:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[RegistroCompra_ObtienexIdLog]	151
-- =============================================
ALTER PROCEDURE [dbo].[RegistroCompra_ObtienexIdLog]	
	@id_archivo_log int
AS
BEGIN
	SET NOCOUNT ON;

    select 
    id_archivo_log,
    id_linea,
    no_ope_rac,
    fecha_emision,
    fecha_vencimiento,
    tipo_comprobante,
    nro_serie_comprobante,
    anio_emision_comprobante,
    numero_comprobante,
    tipo_documento,
    numero_documento,
    apell_nomb_raz_soc,
    base_imponible_grav,
    igv_gravado,
    base_imp_mixta,
    igv_mixto,
    base_imp_no_grav,
    igv_no_grav,
    adq_no_grav,
    isc,
    otros_tributos,
    total,
    comp_no_domic,
    num_constancia,
    fecha_emision_const,
    tipo_cambio,
    fecha_original,
    tipo_doc_orig,
    num_serie_orig,
    num_doc_orig,
    pago,
    fecha_pago,
    detraccion,
    tasa_detraccion,
    importe_detraccion,
    retencion,
    importe_retencion,
    motivo_retencion,
    revision_tasa,
    revision_tipo_cambio,
    revision_verificacion,
    base_revision,
    igv_revision,
    tipo_gasto,
    recepcion,
    comentario1,
    comentario2,
    vb,
    compra_gravada_pais,
    compra_gravada_exterior,
    compra_no_gravada,
    igv_pais,
    exterior,
    otros_cargos,
    total1,
    estado
    from dbo.InputRegistroCompra
    where id_archivo_log = @id_archivo_log
END
