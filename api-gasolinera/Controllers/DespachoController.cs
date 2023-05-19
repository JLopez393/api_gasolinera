using api_gasolinera.Clases;
using api_gasolinera.Models;
using api_gasolinera.SqlConnect;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DespachoController : ApiController
    {
        String strSql = string.Empty;
        DataTable dt = new DataTable();
        DataLinkCls dataLinkCls = new DataLinkCls();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getEstadoCara")]
        public IHttpActionResult getEstadoCara()
        {
            string[] lCaras = dataLinkCls.getEstadoCara().Split('~');
            ResponseEstadoCaras respEstadoCaras = new ResponseEstadoCaras();
            
            if (lCaras.Length > 1)
            {
                respEstadoCaras.id = 1;
                respEstadoCaras.estado = lCaras[0];
                respEstadoCaras.descripcion = "Disponible";
                return Ok(dataLinkCls.getEstadoCara());
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, dataLinkCls.getUltError());
            }
            
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route(@"api/GetLectura/{idPistola}")]
        public IHttpActionResult getLectura(int idPistola)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ResponseLectura lectura = new ResponseLectura();
            //TODO
            //int idCara = idPistola <= 2 ? 1 : 2;

            //string[] lCaras = dataLinkCls.getEstadoCara().Split('~');

            //if (lCaras[idPistola - 1].Equals("1"))
            //{
            try
            {
                string[] lDatosVenta = dataLinkCls.getUltimaVenta(idPistola).Split('~');

                if(lDatosVenta.Length > 1)
                {
                    string monto = lDatosVenta[3];
                    string galonaje = lDatosVenta[4];

                    monto = monto.Substring(0, monto.Length - 2) + "." + monto.Substring(monto.Length - 2);
                    galonaje = galonaje.Substring(0, galonaje.Length - 2) + "." + galonaje.Substring(galonaje.Length - 2);

                    float montoVenta = float.Parse(monto);
                    float venta = float.Parse(galonaje);


                    lectura.idVenta = int.Parse(lDatosVenta[0]);
                    lectura.caraVenta = idPistola.ToString();
                    lectura.pistolaVenta = idPistola.ToString();
                    lectura.montoVenta = montoVenta;
                    lectura.galonajeVenta = venta;

                    return Ok(lectura);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema de comunicación con la VOX");
                }

                
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
                
            //}

            //strSql = $"SELECT ID, DESCRIPCION FROM tbl_CatDataLink WHERE ID = '{lCaras[idPistola - 1]}' AND TIPO = 'EstSurti'";


            //return Content(HttpStatusCode.BadRequest, sqlConnectClass.RunSql(strSql));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetOrdenDespacho")]
        public IHttpActionResult getOrdenDespacho()
        {
            strSql = "EXEC USP_GET_OrdenDespacho";

            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado Órdenes de despacho en el sistema.");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMangueraCombustible/{idBomba}")]
        public IHttpActionResult getMangueraCombustible(string idBomba)
        {
            strSql = $"EXEC USP_GET_MangueraCombustible '{idBomba}'";

            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado Bombas-Area en el sistema.");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetDespacho/{idDespacho}")]
        public IHttpActionResult getDespacho(string idDespacho)
        {
            strSql = $"EXEC USP_GET_Despacho '{idDespacho}'";

            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado despachos en el sistema.");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetInfoOrquestador/{fechaInicio},{fechaFin},{activo},{correlativo},{estado}")]
        public IHttpActionResult getInfoOrquestador(string fechaInicio, string fechaFin, string activo, string correlativo, string estado)
        {
            fechaInicio = fechaInicio == "-" ? null : fechaInicio;
            fechaFin = fechaFin == "-" ? null : fechaFin;
            activo = activo == "-" ? null : activo;
            correlativo = correlativo == "-" ? null : correlativo;
            estado = estado == "-" ? null : estado;

            strSql = $"EXEC USP_GET_InfoOrquestador '{fechaInicio}', '{fechaFin}', '{activo}', '{correlativo}', '{estado}' ";

            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado despachos en el sistema.");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
