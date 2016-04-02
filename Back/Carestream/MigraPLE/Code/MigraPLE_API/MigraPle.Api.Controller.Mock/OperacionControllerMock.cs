using System;
using System.Collections.Generic;
using MigraPle.Api.Controller.Interface;
using MigraPle.Api.Processor.Interface;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller.Mock
{
    public class OperacionControllerMock : IOperacionController
    {
        private readonly IFileProcessor _fileProcessor;

        public OperacionControllerMock(IFileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }

        public string ImportArchivo(Operacion operacion)
        {
            try
            {
                _fileProcessor.ImportProcess(@"\\ASUS-DEV\SharedImport\Ventas_2014.xlsx");

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ExportArchivo(Operacion operacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperacionDetalle> GetDetalles(int idOperacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacion> GetOperaciones(int idArchivo)
        {
            throw new NotImplementedException();
        }
    }
}