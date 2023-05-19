using api_gasolinera.Models;
using api_gasolinera.SqlConnect;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebSocketSharp;

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReporteController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetReporte/{fechaInicio},{fechaFin}")]
        public IHttpActionResult getReporte(string fechaInicio, string fechaFin)
        {

            strSql = $"EXEC USP_Reporte '{fechaInicio}', '{fechaFin}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    ResponseSincronizacionIN resp = new ResponseSincronizacionIN();

                    resp.lActivo = dt.Rows[0]["tblActivo"].ToString().IsNullOrEmpty() ? null : JArray.Parse(dt.Rows[0]["tblActivo"].ToString());
                    resp.lDespacho = dt.Rows[0]["tblDespacho"].ToString().IsNullOrEmpty() ? null : JArray.Parse(dt.Rows[0]["tblDespacho"].ToString());
                    resp.lEmpleado = dt.Rows[0]["tblEmpleado"].ToString().IsNullOrEmpty() ? null : JArray.Parse(dt.Rows[0]["tblEmpleado"].ToString());
                    resp.lOrdenes = dt.Rows[0]["tblOrdenDespacho"].ToString().IsNullOrEmpty() ? null : JArray.Parse(dt.Rows[0]["tblOrdenDespacho"].ToString());

                    if (resp.lActivo == null && resp.lDespacho == null && resp.lEmpleado == null && resp.lOrdenes == null) return Content(HttpStatusCode.BadRequest, "No hay datos en el rango de fechas ingresado.");

                    return Ok(resp);
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }


            return NotFound();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMensajeDespacho/{idDespacho}")]
        public IHttpActionResult GetMensajeDespacho(string idDespacho)
        {

            strSql = $"EXEC USP_GET_MensajeDespacho '{idDespacho}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {

                    return Content(HttpStatusCode.BadRequest, "No se han encontrado mensajes en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
