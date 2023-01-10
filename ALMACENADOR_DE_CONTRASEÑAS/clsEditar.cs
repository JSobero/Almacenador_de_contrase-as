using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    class clsEditar:clsConexion
    {
        public void EditarCategoria(String nom,String des)
        {
            SqlCommand cmd = new SqlCommand("PA_ACTUALIZARCATEGORIA", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", nom);
            cmd.Parameters.AddWithValue("@DESCRIPCION", des);
            cmd.ExecuteNonQuery();
        }

        public void EditarUsuario(String nom, String usu, String con)
        {
            SqlCommand cmd = new SqlCommand("PA_ACTUALIZARUSUARIO", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", nom);
            cmd.Parameters.AddWithValue("@USUARIO", usu);
            cmd.Parameters.AddWithValue("@CONTRASEÑA", con);
            cmd.ExecuteNonQuery();
        }
    }
}
