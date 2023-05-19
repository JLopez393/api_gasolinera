using api_gasolinera.SqlConnect;
using DataLinkLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace api_gasolinera.Clases
{
    public class DataLinkCls
    {
        private Controller controller = new Controller("10.4.40.78");
        String strSql = string.Empty;
        protected void conectarControlador()
        {
            if (!controller.Conectado())
            {
                controller.ConectarControlador();
            }
        }

        public DataTable getUltError()
        {
            string error = controller.ObtenerUltimoError();

            strSql = $"SELECT ID, DESCRIPCION FROM tbl_CatDataLink WHERE ID = '{error}' AND TIPO = 'ERROR'";
            return sqlConnectClass.RunSql(strSql);
        }

        public string getEstadoCara()
        {
            conectarControlador();

            return controller.EstadoCaras();
        }

        public string getUltimaVenta(int idCara)
        {
            conectarControlador();

            return controller.ObtenerUltimas10Ventas(idCara.ToString());
        }
    }
}