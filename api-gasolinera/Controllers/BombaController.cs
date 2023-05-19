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
    public class BombaController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetBomba")]
        public IHttpActionResult getBomba()
        {
            strSql = $"EXEC USP_GET_Bomba";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado bombas en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostBomba")]
        public IHttpActionResult PostBomba([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;

            strSql = $"EXEC USP_POST_BombaArea '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetCombustible")]
        public IHttpActionResult getCombustible()
        {
            strSql = $"EXEC USP_GET_Combustible";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado combustibles en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostCombustible")]
        public IHttpActionResult PostCombustible([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;

            strSql = $"EXEC USP_POST_Combustible '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMangueras")]
        public IHttpActionResult getManguera()
        {
            strSql = $"EXEC USP_GET_Manguera";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado mangueras en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetManguerasID/{idManguera}")]
        public IHttpActionResult getMangueraID(String idManguera)
        {
            strSql = $"EXEC USP_GET_Manguera '{idManguera}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado mangueras en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetManguerasUsuario/{idUsuario}")]
        public IHttpActionResult getMangueraUsuario(String idUsuario)
        {
            strSql = $"EXEC USP_GET_MangueraUsuario '{idUsuario}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado mangueras en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostManguera")]
        public IHttpActionResult PostManguera([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;
            strSql = $"EXEC USP_POST_Manguera '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
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
