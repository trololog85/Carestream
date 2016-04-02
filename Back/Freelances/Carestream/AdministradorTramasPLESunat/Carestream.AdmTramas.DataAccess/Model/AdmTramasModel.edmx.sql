
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/28/2014 23:41:09
-- Generated from EDMX file: D:\Proyectos\Carestream\4.0\PLE\AdmTramasPLESolution\Carestream.AdmTramas.DataAccess\Model\AdmTramasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdmTramaPLE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LibroEstructura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estructuras] DROP CONSTRAINT [FK_LibroEstructura];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLibroLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LibroLogs] DROP CONSTRAINT [FK_LibroLibroLog];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLogExportDetalleErrorLinea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ErrorLineas] DROP CONSTRAINT [FK_LibroLogExportDetalleErrorLinea];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLogLibroDiario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LibroDiarios] DROP CONSTRAINT [FK_LibroLogLibroDiario];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLogLibroLogExportDetalle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LibroLogExportDetalles] DROP CONSTRAINT [FK_LibroLogLibroLogExportDetalle];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLogRegistroCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroCompras] DROP CONSTRAINT [FK_LibroLogRegistroCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_LibroLogRegistroVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroVentas] DROP CONSTRAINT [FK_LibroLogRegistroVenta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CodigoDetalles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CodigoDetalles];
GO
IF OBJECT_ID(N'[dbo].[ErrorLineas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ErrorLineas];
GO
IF OBJECT_ID(N'[dbo].[Estructuras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estructuras];
GO
IF OBJECT_ID(N'[dbo].[LibroDiarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LibroDiarios];
GO
IF OBJECT_ID(N'[dbo].[LibroLogExportDetalles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LibroLogExportDetalles];
GO
IF OBJECT_ID(N'[dbo].[LibroLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LibroLogs];
GO
IF OBJECT_ID(N'[dbo].[Libros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Libros];
GO
IF OBJECT_ID(N'[dbo].[RegistroCompras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroCompras];
GO
IF OBJECT_ID(N'[dbo].[RegistroVentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroVentas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Libros'
CREATE TABLE [dbo].[Libros] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [Codigo] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'LibroLogs'
CREATE TABLE [dbo].[LibroLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [NombreLibro] nvarchar(250)  NOT NULL,
    [FechaCarga] datetime  NULL,
    [FechaGeneracion] datetime  NULL,
    [Registros] int  NOT NULL,
    [RUC] nvarchar(11)  NOT NULL,
    [IndicadorOperacion] nvarchar(1)  NULL,
    [IndicadorMoneda] nvarchar(3)  NULL,
    [IndicadorLibro] nvarchar(1)  NULL,
    [TipoLog] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'LibroLogExportDetalles'
CREATE TABLE [dbo].[LibroLogExportDetalles] (
    [IdLibroLog] int  NOT NULL,
    [Linea] int  NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [Trama] nvarchar(max)  NOT NULL,
    [Estado] tinyint  NOT NULL
);
GO

-- Creating table 'ErrorLineas'
CREATE TABLE [dbo].[ErrorLineas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdLibroLog] int  NOT NULL,
    [Linea] int  NOT NULL,
    [Campo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CodigoDetalles'
CREATE TABLE [dbo].[CodigoDetalles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(2)  NOT NULL,
    [Descripcion] nvarchar(500)  NOT NULL,
    [Etiqueta] nvarchar(500)  NOT NULL,
    [Campo1] nvarchar(15)  NOT NULL,
    [Campo2] nvarchar(15)  NOT NULL,
    [Campo3] nvarchar(15)  NOT NULL,
    [Campo4] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'LibroDiarios'
CREATE TABLE [dbo].[LibroDiarios] (
    [Linea] int  NOT NULL,
    [IdLibroLog] int  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [NumeroCorrelativo] int  NOT NULL,
    [CodigoUnico] nvarchar(25)  NOT NULL,
    [Referencia] nvarchar(25)  NOT NULL,
    [Cuenta] nvarchar(25)  NOT NULL,
    [Centro] nvarchar(25)  NOT NULL,
    [DescripcionAsiento] nvarchar(250)  NOT NULL,
    [Debe] decimal(18,0)  NOT NULL,
    [Haber] decimal(18,0)  NOT NULL,
    [IdLibro] smallint  NOT NULL
);
GO

-- Creating table 'RegistroVentas'
CREATE TABLE [dbo].[RegistroVentas] (
    [IdLibroLog] int  NOT NULL,
    [Linea] int  NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [NumeroCorrelativo] int  NOT NULL,
    [FechaComprobante] datetime  NOT NULL,
    [TipoComprobante] int  NOT NULL,
    [InternoComprobante] nvarchar(30)  NOT NULL,
    [SerieComprobante] nvarchar(20)  NOT NULL,
    [NumeroComprobante] nvarchar(20)  NOT NULL,
    [TipoDocumento] nvarchar(1)  NOT NULL,
    [NumeroDocumento] nvarchar(15)  NOT NULL,
    [CodigoDocumento] nvarchar(20)  NOT NULL,
    [NombreRazonSocial] nvarchar(60)  NOT NULL,
    [ValorVentaOriginal] decimal(18,0)  NOT NULL,
    [Moneda] nvarchar(3)  NOT NULL,
    [TipoCambio] decimal(18,0)  NOT NULL,
    [VV] decimal(18,0)  NOT NULL,
    [IGV] decimal(18,0)  NOT NULL,
    [PV] decimal(18,0)  NOT NULL,
    [FechaModificada] datetime  NOT NULL,
    [TipoComprobanteModificado] nvarchar(2)  NOT NULL,
    [NumeroSerieModificado] nvarchar(20)  NOT NULL,
    [NumeroComprobanteModificado] nvarchar(20)  NOT NULL,
    [VVModificado] decimal(18,0)  NOT NULL,
    [IGVModificado] decimal(18,0)  NOT NULL,
    [PVModificado] decimal(18,0)  NOT NULL,
    [NumeroUnicoOperacion] nvarchar(15)  NOT NULL,
    [OperacionNoGravada] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'RegistroCompras'
CREATE TABLE [dbo].[RegistroCompras] (
    [IdLibroLog] int  NOT NULL,
    [Linea] int  NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [NumeroOperacion] nvarchar(50)  NOT NULL,
    [FechaEmision] datetime  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [TipoComprobante] nvarchar(2)  NOT NULL,
    [NumeroSerieComprobante] nvarchar(20)  NOT NULL,
    [AnioEmisionComprobante] int  NOT NULL,
    [NumeroComprobante] nvarchar(50)  NOT NULL,
    [TipoDocumento] nvarchar(2)  NOT NULL,
    [NumeroDocumento] nvarchar(15)  NOT NULL,
    [NombreRazonSocial] nvarchar(50)  NOT NULL,
    [BaseImponibleGravada] decimal(18,0)  NOT NULL,
    [IGVGravado] nvarchar(max)  NOT NULL,
    [BaseImponibleMixta] decimal(18,0)  NOT NULL,
    [IGVMixto] decimal(18,0)  NOT NULL,
    [BaseImponibleNoGravada] decimal(18,0)  NOT NULL,
    [IGVNoGravado] decimal(18,0)  NOT NULL,
    [AdquisicionNoGravada] decimal(18,0)  NOT NULL,
    [ISC] decimal(18,0)  NOT NULL,
    [OtrosTributos] decimal(18,0)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [ComprobanteNoDomiciliado] nvarchar(50)  NOT NULL,
    [NumeroConstancia] nvarchar(50)  NOT NULL,
    [FechaEmisionConstancia] datetime  NOT NULL,
    [TipoCambio] decimal(18,0)  NOT NULL,
    [FechaOriginal] datetime  NOT NULL,
    [TipoDocumentoOriginal] nvarchar(2)  NOT NULL,
    [NumeroSerieOriginal] nvarchar(20)  NOT NULL,
    [NumeroDocumentoOriginal] nvarchar(15)  NOT NULL,
    [Pago] nvarchar(20)  NOT NULL,
    [FechaPago] datetime  NOT NULL,
    [Detraccion] nvarchar(20)  NOT NULL,
    [TasaDetraccion] decimal(18,0)  NOT NULL,
    [ImporteDetraccion] decimal(18,0)  NOT NULL,
    [Retencion] nvarchar(20)  NOT NULL,
    [ImporteRetencion] decimal(18,0)  NOT NULL,
    [MotivoRetencion] nvarchar(250)  NOT NULL,
    [RevisionTasa] decimal(18,0)  NOT NULL,
    [RevisionTipoCambio] decimal(18,0)  NOT NULL,
    [RevisionVerificacion] nvarchar(250)  NOT NULL,
    [BaseRevision] decimal(18,0)  NOT NULL,
    [IGVRevision] decimal(18,0)  NOT NULL,
    [TipoGasto] nvarchar(20)  NOT NULL,
    [Recepcion] nvarchar(20)  NOT NULL,
    [Comentario1] nvarchar(250)  NOT NULL,
    [Comentario2] nvarchar(250)  NOT NULL,
    [VB] nvarchar(20)  NOT NULL,
    [CompraGravadaPais] decimal(18,0)  NOT NULL,
    [CompraGravadaExterior] decimal(18,0)  NOT NULL,
    [CompraNoGravada] decimal(18,0)  NOT NULL,
    [IGVPais] decimal(18,0)  NOT NULL,
    [Exterior] decimal(18,0)  NOT NULL,
    [OtrosCargos] decimal(18,0)  NOT NULL,
    [Total1] decimal(18,0)  NOT NULL,
    [Estado] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'Estructuras'
CREATE TABLE [dbo].[Estructuras] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [NumCampo] smallint  NOT NULL,
    [Descripcion] nvarchar(200)  NOT NULL,
    [TipoDato] nvarchar(1)  NOT NULL,
    [PosicionInicial] int  NOT NULL,
    [PosicionFinal] int  NOT NULL,
    [Longitud] smallint  NOT NULL,
    [Obligatorio] tinyint  NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [Version] nvarchar(3)  NOT NULL,
    [Nombre] nvarchar(50)  NOT NULL,
    [NombreCampo] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'LibroMayors'
CREATE TABLE [dbo].[LibroMayors] (
    [IdLibroLog] int IDENTITY(1,1) NOT NULL,
    [Linea] int  NOT NULL,
    [IdLibro] smallint  NOT NULL,
    [NumeroDocumento] nvarchar(50)  NOT NULL,
    [FechaOperacion] datetime  NOT NULL,
    [Importe] decimal(18,0)  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL,
    [Cuenta] nvarchar(50)  NOT NULL,
    [GL] nvarchar(50)  NOT NULL,
    [Debito] decimal(18,0)  NOT NULL,
    [Credito] decimal(18,0)  NOT NULL,
    [Saldo] decimal(18,0)  NOT NULL,
    [Referencia] nvarchar(250)  NOT NULL,
    [Item] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [Glosa] nvarchar(50)  NOT NULL,
    [Tipo] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Libros'
ALTER TABLE [dbo].[Libros]
ADD CONSTRAINT [PK_Libros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [IdLibro] in table 'LibroLogs'
ALTER TABLE [dbo].[LibroLogs]
ADD CONSTRAINT [PK_LibroLogs]
    PRIMARY KEY CLUSTERED ([Id], [IdLibro] ASC);
GO

-- Creating primary key on [IdLibroLog], [Linea] in table 'LibroLogExportDetalles'
ALTER TABLE [dbo].[LibroLogExportDetalles]
ADD CONSTRAINT [PK_LibroLogExportDetalles]
    PRIMARY KEY CLUSTERED ([IdLibroLog], [Linea] ASC);
GO

-- Creating primary key on [Id] in table 'ErrorLineas'
ALTER TABLE [dbo].[ErrorLineas]
ADD CONSTRAINT [PK_ErrorLineas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CodigoDetalles'
ALTER TABLE [dbo].[CodigoDetalles]
ADD CONSTRAINT [PK_CodigoDetalles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdLibroLog], [Linea] in table 'LibroDiarios'
ALTER TABLE [dbo].[LibroDiarios]
ADD CONSTRAINT [PK_LibroDiarios]
    PRIMARY KEY CLUSTERED ([IdLibroLog], [Linea] ASC);
GO

-- Creating primary key on [Linea], [IdLibroLog] in table 'RegistroVentas'
ALTER TABLE [dbo].[RegistroVentas]
ADD CONSTRAINT [PK_RegistroVentas]
    PRIMARY KEY CLUSTERED ([Linea], [IdLibroLog] ASC);
GO

-- Creating primary key on [Linea], [IdLibroLog] in table 'RegistroCompras'
ALTER TABLE [dbo].[RegistroCompras]
ADD CONSTRAINT [PK_RegistroCompras]
    PRIMARY KEY CLUSTERED ([Linea], [IdLibroLog] ASC);
GO

-- Creating primary key on [Id], [NumCampo] in table 'Estructuras'
ALTER TABLE [dbo].[Estructuras]
ADD CONSTRAINT [PK_Estructuras]
    PRIMARY KEY CLUSTERED ([Id], [NumCampo] ASC);
GO

-- Creating primary key on [Linea], [IdLibroLog] in table 'LibroMayors'
ALTER TABLE [dbo].[LibroMayors]
ADD CONSTRAINT [PK_LibroMayors]
    PRIMARY KEY CLUSTERED ([Linea], [IdLibroLog] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdLibro] in table 'LibroLogs'
ALTER TABLE [dbo].[LibroLogs]
ADD CONSTRAINT [FK_LibroLibroLog]
    FOREIGN KEY ([IdLibro])
    REFERENCES [dbo].[Libros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLibroLog'
CREATE INDEX [IX_FK_LibroLibroLog]
ON [dbo].[LibroLogs]
    ([IdLibro]);
GO

-- Creating foreign key on [IdLibroLog], [IdLibro] in table 'LibroLogExportDetalles'
ALTER TABLE [dbo].[LibroLogExportDetalles]
ADD CONSTRAINT [FK_LibroLogLibroLogExportDetalle]
    FOREIGN KEY ([IdLibroLog], [IdLibro])
    REFERENCES [dbo].[LibroLogs]
        ([Id], [IdLibro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogLibroLogExportDetalle'
CREATE INDEX [IX_FK_LibroLogLibroLogExportDetalle]
ON [dbo].[LibroLogExportDetalles]
    ([IdLibroLog], [IdLibro]);
GO

-- Creating foreign key on [IdLibroLog], [Linea] in table 'ErrorLineas'
ALTER TABLE [dbo].[ErrorLineas]
ADD CONSTRAINT [FK_LibroLogExportDetalleErrorLinea]
    FOREIGN KEY ([IdLibroLog], [Linea])
    REFERENCES [dbo].[LibroLogExportDetalles]
        ([IdLibroLog], [Linea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogExportDetalleErrorLinea'
CREATE INDEX [IX_FK_LibroLogExportDetalleErrorLinea]
ON [dbo].[ErrorLineas]
    ([IdLibroLog], [Linea]);
GO

-- Creating foreign key on [IdLibroLog], [IdLibro] in table 'LibroDiarios'
ALTER TABLE [dbo].[LibroDiarios]
ADD CONSTRAINT [FK_LibroLogLibroDiario]
    FOREIGN KEY ([IdLibroLog], [IdLibro])
    REFERENCES [dbo].[LibroLogs]
        ([Id], [IdLibro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogLibroDiario'
CREATE INDEX [IX_FK_LibroLogLibroDiario]
ON [dbo].[LibroDiarios]
    ([IdLibroLog], [IdLibro]);
GO

-- Creating foreign key on [IdLibroLog], [IdLibro] in table 'RegistroVentas'
ALTER TABLE [dbo].[RegistroVentas]
ADD CONSTRAINT [FK_LibroLogRegistroVenta]
    FOREIGN KEY ([IdLibroLog], [IdLibro])
    REFERENCES [dbo].[LibroLogs]
        ([Id], [IdLibro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogRegistroVenta'
CREATE INDEX [IX_FK_LibroLogRegistroVenta]
ON [dbo].[RegistroVentas]
    ([IdLibroLog], [IdLibro]);
GO

-- Creating foreign key on [IdLibroLog], [IdLibro] in table 'RegistroCompras'
ALTER TABLE [dbo].[RegistroCompras]
ADD CONSTRAINT [FK_LibroLogRegistroCompra]
    FOREIGN KEY ([IdLibroLog], [IdLibro])
    REFERENCES [dbo].[LibroLogs]
        ([Id], [IdLibro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogRegistroCompra'
CREATE INDEX [IX_FK_LibroLogRegistroCompra]
ON [dbo].[RegistroCompras]
    ([IdLibroLog], [IdLibro]);
GO

-- Creating foreign key on [IdLibro] in table 'Estructuras'
ALTER TABLE [dbo].[Estructuras]
ADD CONSTRAINT [FK_LibroEstructura]
    FOREIGN KEY ([IdLibro])
    REFERENCES [dbo].[Libros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroEstructura'
CREATE INDEX [IX_FK_LibroEstructura]
ON [dbo].[Estructuras]
    ([IdLibro]);
GO

-- Creating foreign key on [IdLibroLog], [IdLibro] in table 'LibroMayors'
ALTER TABLE [dbo].[LibroMayors]
ADD CONSTRAINT [FK_LibroLogLibroMayor]
    FOREIGN KEY ([IdLibroLog], [IdLibro])
    REFERENCES [dbo].[LibroLogs]
        ([Id], [IdLibro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LibroLogLibroMayor'
CREATE INDEX [IX_FK_LibroLogLibroMayor]
ON [dbo].[LibroMayors]
    ([IdLibroLog], [IdLibro]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------