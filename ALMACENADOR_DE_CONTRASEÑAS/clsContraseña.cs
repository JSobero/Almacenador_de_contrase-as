using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ALMACENADOR_DE_CONTRASEÑAS
{
    class clsContraseña : clsConexion
    {
        public DataTable RellenarDatos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT NOMBRE, DESCRIPCION FROM CATEGORIAS;", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LlenarCategoria()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT IDCATEGORIA,NOMBRE FROM CATEGORIAS", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Check()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from CONTRASEÑA order by DESCRIPCION ASC;", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LlenarContraseñas(String usu)
        {
            SqlDataAdapter da = new SqlDataAdapter("PA_CARGARCONTRASEÑA", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@COD",usu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void AgregarContraseña(String DES, String USU, String CON, int IDCAT, String IDUSU)
        {
            SqlCommand cmd = new SqlCommand("PA_AGREGARCONTRASEÑA", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DES", DES);
            cmd.Parameters.AddWithValue("@USU", USU);
            cmd.Parameters.AddWithValue("@CON", CON);
            cmd.Parameters.AddWithValue("@IDCAT", IDCAT);
            cmd.Parameters.AddWithValue("@IDUSU", IDUSU);
            cmd.ExecuteNonQuery();
        }

        public void EliminarContraseña(String USU)
        {
            SqlCommand cmd = new SqlCommand("PA_ELIMINARCONTRASEÑA", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USUARIO", USU);
            cmd.ExecuteNonQuery();
        }

        public void EditarContraseña(int cod,String des,String usu,String con,int idcat)
        {
            SqlCommand cmd = new SqlCommand("PA_EDITARCONTRASEÑA", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD", cod);
            cmd.Parameters.AddWithValue("@DES", des);
            cmd.Parameters.AddWithValue("@USU", usu);
            cmd.Parameters.AddWithValue("@CON", con);
            cmd.Parameters.AddWithValue("@IDCAT", idcat);
            cmd.ExecuteNonQuery();
        }
    }
}
