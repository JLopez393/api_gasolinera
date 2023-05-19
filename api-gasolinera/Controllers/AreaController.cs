using api_gasolinera.SqlConnect;
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

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AreaController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetArea")]
        public IHttpActionResult getArea()
        {
            strSql = $"EXEC USP_GET_Area";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado áreas en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAreaBomba/{idBomba}")]
        public IHttpActionResult getArea(String idBomba)
        {
            strSql = $"EXEC USP_GET_BombaArea NULL, '{idBomba}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado áreas en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetAreaID/{ID}")]
        public IHttpActionResult getAreaByID(String id)
        {
            strSql = $"EXEC USP_GET_Area {id}";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado áreas en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostArea")]
        public IHttpActionResult PostArea([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;

            strSql = $"EXEC USP_POST_AREA '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Ha ocurrido un problema al ingresar registro.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
