using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    class clsAcceso : clsConexion
    {
        public Boolean verificarUsuario(String usu, String con)
        {
            SqlCommand cmd  = new SqlCommand("PA_ACCESO",Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", @usu);
            cmd.Parameters.AddWithValue("@password", @con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable MostrarDatos(String usu)
        {
            SqlDataAdapter da = new SqlDataAdapter("PA_CARGARDATOS", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@USUARIO",usu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}
