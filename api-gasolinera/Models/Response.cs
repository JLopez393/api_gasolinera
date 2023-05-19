using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_gasolinera.Models
{
    public class Response
    {
        public bool error { get; set; }
        public string message { get; set; }
        public Object result { get; set; }
    }
}