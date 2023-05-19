using api_gasolinera.Models;
using api_gasolinera.SqlConnect;
using DataLinkLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DataLinkController : ApiController
    {
        private Controller controller = new Controller("10.4.40.78");
        Response resp = new Response();

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/GetDataLinkInfo")]
        public Response getDataLinkInfo([System.Web.Http.FromBody] RequestUsuario content)
        {
            Boolean error;
            String message = string.Empty;
            object result;
            int funcion = content.estado;
            try
            {
                if (!controller.Conectado())
                {
                    controller.ConectarControlador();
                }
                error = false;
                message = "OK";

                switch (funcion)
                {
                    case 1:
                        result = controller.EstadoSistema();
                        break;
                    case 2:
                        result = controller.CerrarTurno("T", false);
                        break;
                    case 3:
                        result = controller.ObtenerConfig();
                        break;
                    case 4:
                        result = controller.EstadoCaras();
                        break;
                    case 5:
                        result = controller.ObtenerUltimas10Ventas(content.usuario);
                        break;
                    case 6:
                        result = controller.ObtenerAforador("1", "1");
                        break;
                    case 7:
                        result = controller.ObtenerReporteDeCierre("D");
                        break;
                    case 8:
                        result = controller.PagarVenta("1-00001", "01");
                        break;
                    case 9:
                        result = controller.ObtenerPagoMP("1-00001", "1", "1");
                        break;
                    case 10:
                        result = controller.SetValues("10.4.40.78",1);
                        break;
                    case 11:
                        result = controller.AcercaDe();
                        break;
                    case 12:
                        result = controller.IsLicenseValid();
                        break;
                    default:
                        result = controller.ObtenerUltimoError();
                        break;
                }
            }
            catch (Exception e)
            {
                error = true;
                message = e.Message;
                result = null;
            }

            resp.error = error;
            resp.message = message;
            resp.result = result;

            return resp;
        }

    }
}
