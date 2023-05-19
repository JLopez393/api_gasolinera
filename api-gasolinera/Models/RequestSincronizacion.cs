using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class RequestSincronizacion
    {
        public List<ModelDespacho> lDespacho { get; set; }
        public List<ModelActivo> lActivo { get; set; }
        public List<ModelOrdenDespacho> lOrdenes { get; set; }
        public List<ModelEmpleado> lEmpleado { get; set;}
    }
}