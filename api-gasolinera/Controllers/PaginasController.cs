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
    public class PaginasController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getPaginas")]
        public IHttpActionResult getPaginas()
        {
            strSql = $"SELECT * FROM TBLPAGINA";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado páginas en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/getPaginasID/{idMenu}")]
        public IHttpActionResult getPaginas(String idMenu)
        {
            strSql = $"EXEC USP_GET_Pagina '{idMenu}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado páginas para ese menú en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
