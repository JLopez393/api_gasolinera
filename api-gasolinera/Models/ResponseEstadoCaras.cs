using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class ResponseEstadoCaras
    {
        public int id { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
    }
}