using MigraPle.Api.Configurations;
using MigraPle.Api.Controller;
using MigraPle.Api.Controller.Interface;
using MigraPle.Api.Controller.Mock;
using MigraPle.Api.Processor.Import;
using MigraPle.Api.Processor.Interface;
using MigraPle.DataAccess.Converter;
using MigraPle.DataAccess.Repository;
using MigraPle.DataAccess.Repository.Sql;
using MigraPle.DataAccess.Sql;
using MigraPle.DataAccess.Sql.Interfaces;
using MigraPLE.DataAccess.Converter;
using Ninject;

namespace MigraPle.Api.Resolver
{
    public class KernelResolver
    {
        public void ConfigureKernel(IKernel kernel)
        {
            kernel.Bind<IDAOperacion>().To<DAOperacion>().InSingletonScope();
            kernel.Bind<IDAOperacionDetalle>().To<DAOperacionDetalle>().InSingletonScope();
            kernel.Bind<IDAArchivo>().To<DAArchivo>().InSingletonScope();
            kernel.Bind<IArchivoRepository>().To<SqlArchivoRepository>().InSingletonScope();
            kernel.Bind<IOperacionRepository>().To<SqlOperacionRepository>().InSingletonScope();
            kernel.Bind<IOperacionDetalleRepository>().To<SqlOperacionDetalleRepository>().InSingletonScope();
            kernel.Bind<IFileProcessor>().To<ExcelProcessor>().InSingletonScope();
            kernel.Bind<IConfigurationGetter>().To<ConfigurationGetter>().InSingletonScope();
            kernel.Bind<ILoginController>().To<LoginControllerMock>().InSingletonScope();
            kernel.Bind<IArchivoController>().To<ArchivoControllerLogic>().InSingletonScope();
            kernel.Bind<IOperacionController>().To<OperacionControllerLogic>().InSingletonScope();
            kernel.Bind<IOperacionConverter>().To<OperacionConverter>().InSingletonScope();
            kernel.Bind<IOperacionDetalleConverter>().To<OperacionDetalleConverter>().InSingletonScope();
            kernel.Bind<IArchivoConverter>().To<ArchivoConverter>().InSingletonScope();
        }
    }
}