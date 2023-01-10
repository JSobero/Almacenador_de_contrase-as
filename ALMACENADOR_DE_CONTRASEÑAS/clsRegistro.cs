using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    class clsRegistro:clsConexion
    {
        public void RegistrarCliente(String nom, String usu, String con)
        {
            SqlCommand cmd = new SqlCommand("PA_REGISTRARUSUARIO", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", nom);
            cmd.Parameters.AddWithValue("@user", usu);
            cmd.Parameters.AddWithValue("@password", con);
            cmd.ExecuteNonQuery();
        }

        public DataTable AgregarCategoria(String nom, String des)
        {
            SqlDataAdapter da = new SqlDataAdapter("PA_AÑADIRCATEGORIA",Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@NOMBRE",nom);
            da.SelectCommand.Parameters.AddWithValue("@DESCRIPCION",des);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
