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
    public class MenuController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMenus")]
        public IHttpActionResult GetMenus()
        {
            strSql = $"SELECT * FROM TBLMENU";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado Menus en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMenuPaginas")]
        public IHttpActionResult GetMenuPaginas()
        {
            strSql = $"EXEC USP_GET_MenuPagina";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado Menus en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetMenuPaginasXRol/{idRol}")]
        public IHttpActionResult GetMenuPaginasXRol(string idRol)
        {
            strSql = $"EXEC USP_GET_MenuPagina '{idRol}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado Menus en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
