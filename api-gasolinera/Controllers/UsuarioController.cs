using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using api_gasolinera.Models;
using System.Data;
using api_gasolinera.SqlConnect;
using DataLinkLibrary;
using System.Net;
using Newtonsoft.Json.Linq;

namespace api_gasolinera.Controllers
{
    [Produces("application/json")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        DataTable dt = new DataTable();
        String strSql = string.Empty;

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Login/{usuario},{contrasena}")]
        public IHttpActionResult getUsuarioValido(string usuario, string contrasena)
        {
            strSql = $"EXEC USP_ValidarUsuario '{usuario}', '{contrasena}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado usuarios en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetUsuarios")]
        public IHttpActionResult getUsuarios()
        {
            strSql = $"EXEC USP_GET_Usuario";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado usuarios en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetUsuariosID/{id}")]
        public IHttpActionResult getUsuarios(String id)
        {
            strSql = $"EXEC USP_GET_Usuario '{id}'";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(JArray.Parse(dt.Rows[0]["RESPUESTA"].ToString()));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado usuarios en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostUsuario")]
        public IHttpActionResult PostUsuario([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;
            strSql = $"EXEC USP_POST_RolUsuario '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
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
        [System.Web.Http.Route("api/GetEmpleados")]
        public IHttpActionResult getEmpleados()
        {
            strSql = $"EXEC USP_GET_Empleado";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado empleados en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetEmpleadosID/{codigo}")]
        public IHttpActionResult getEmpleadosID(int codigo)
        {
            strSql = $"EXEC USP_GET_Empleado {codigo}";
            try
            {
                dt = sqlConnectClass.RunSql(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se han encontrado empleados en el sistema.");
                }

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostEmpleado")]
        public IHttpActionResult PostEmpleado([System.Web.Http.FromBody] JObject content)
        {
            DateTime fecha = DateTime.Now;
            strSql = $"EXEC USP_POST_Empleado '{content}', '{fecha.ToString("yyyy-MM-dd HH:mm:ss:fff")}'";
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