using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MigraPle.Api.Controller.Interface;
using MigraPle.Api.Processor.Interface;
using MigraPle.DataAccess.Repository;
using MigraPle.Model.Entities;

namespace MigraPle.Api.Controller
{
    public class OperacionControllerLogic : IOperacionController
    {
        private readonly IFileProcessor _fileProccesor;
        private readonly IOperacionRepository _operacionRepository;
        private readonly IOperacionDetalleRepository _operacionDetalleRepository;

        public OperacionControllerLogic(IFileProcessor fileProccesor, IOperacionRepository operacionRepository, 
            IOperacionDetalleRepository operacionDetalleRepository)
        {
            _fileProccesor = fileProccesor;
            _operacionRepository = operacionRepository;
            _operacionDetalleRepository = operacionDetalleRepository;
        }

        public string ImportArchivo(Operacion operacion)
        {
            try
            {
                var idOperacion = _operacionRepository.InsertOperacion(operacion);

                var operacionDetalle = _fileProccesor.ImportProcess(operacion.NombreArchivo);

                _operacionDetalleRepository.Insert(operacionDetalle, idOperacion);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("{0},{1}", ex.Message, ex.StackTrace))
                };

                throw new HttpResponseException(resp);
            }
        }

        public string ExportArchivo(Operacion operacion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperacionDetalle> GetDetalles(int idOperacion)
        {
            return _operacionDetalleRepository.GetDetalles(idOperacion);
        }

        public IEnumerable<Operacion> GetOperaciones(int idArchivo)
        {
            throw new NotImplementedException();
        }
    }
}