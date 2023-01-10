using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    class clsConexion
    {
        protected SqlConnection Conectar()
        {
            SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["XCON"].ConnectionString);
            if (cnx.State==ConnectionState.Open)
            {
                cnx.Close();
            }
            else
            {
                cnx.Open();
            }
            return cnx;
        }
    }
}
