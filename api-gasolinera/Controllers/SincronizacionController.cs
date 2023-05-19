using api_gasolinera.Models;
using api_gasolinera.SqlConnect;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml;
using WebSocketSharp;

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SincronizacionController : ApiController
    {
        String strSql = string.Empty;
        DataTable dt = new DataTable();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/IniciaSincronizacion/{idDispositivo},{usuarioCreacion},{aplicacionCreacion}")]
        public IHttpActionResult iniciaSincronizacion(string idDispositivo, string usuarioCreacion, string aplicacionCreacion)
        {
            try
            {
                ModelSincronizacion modelSincronizacion = new ModelSincronizacion();
                strSql = $"EXEC USP_IniciaSincronizacion '{idDispositivo}', '{usuarioCreacion}', '{aplicacionCreacion}'";
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    strSql = $"EXEC USP_SincronizacionOUT '{idDispositivo}'";
                    dt = sqlConnectClass.RunSql(strSql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //JObject jsonTablas = JObject.Parse(dt.Rows[0]["RESPUESTA"].ToString());

                        //strSql = $"EXEC USP_FinalizaSincronizacion '{idDispositivo}', '{usuarioCreacion}', '{aplicacionCreacion}'";
                        //dt = sqlConnectClass.RunSql(strSql);
                        //if (dt == null)
                        //{
                        //    return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema finalizando sincronización.");
                        //}

                        return Ok(JObject.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {

                return Content(HttpStatusCode.BadRequest, e.Message);
            }

            return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema iniciando sincronización.");
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/FinalizaSincronizacion/{idDispositivo},{usuarioCreacion},{aplicacionCreacion}")]
        public IHttpActionResult finalizaSincronizacion(string idDispositivo, string usuarioCreacion, string aplicacionCreacion)
        {
            try
            {
                strSql = $"EXEC USP_FinalizaSincronizacion '{idDispositivo}', '{usuarioCreacion}', '{aplicacionCreacion}'";
                dt = sqlConnectClass.RunSql(strSql);
                if (dt == null)
                {
                    return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema finalizando sincronización.");
                }

                return Ok();
            }
            catch (Exception e)
            {

                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/SincronizacionIN")]
        public IHttpActionResult SincronizacionIN([System.Web.Http.FromBody] JObject content)
        {

            strSql = $"EXEC USP_SincronizacionIN '{content}'";

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

                    return Ok(resp);
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            
            return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema sincronización dispositivo móvil.");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/JDESincronizacion/")]
        public IHttpActionResult getInfoOrquestador([System.Web.Http.FromBody] JArray content)
        {
            int opr = 0;
            strSql = $"EXEC USP_SincronizacionJDE '{content}'";

            try
            {
                opr = sqlConnectClass.ExecuteSql(strSql);
                if (opr > 0)
                {
                    return Ok();
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Ocurrió un problema en la ejecución del procedimiento almacenado para sincronización de JDE.");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
