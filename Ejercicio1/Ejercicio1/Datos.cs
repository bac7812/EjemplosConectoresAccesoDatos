using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Datos
    {
        //private static String stringConexion = Properties.Settings.Default.sqlConnection.ToString();
        //SqlConnection sqlConnection;
        public static DataTable tabla = new DataTable();
        public static List<Usuario> listaUsuarios = new List<Usuario>();

        public static string obtenerConexion()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.InitialCatalog = "Usuarios";
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sqlserver";
            return sqlConnectionStringBuilder.ToString();
        }

        public static void obtenerUsuarios()
        {
            SqlConnection sqlConnection = new SqlConnection(obtenerConexion());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from usuarios", sqlConnection);
            sqlDataAdapter.Fill(tabla);
            obtenerListaUsuarios();
        }

        public static void obtenerUsuario(string dni)
        {
            SqlConnection sqlConnection = new SqlConnection(obtenerConexion());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Select * from usuarios where dni= '{0}'", dni);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(stringBuilder.ToString(), sqlConnection);
            sqlDataAdapter.Fill(tabla);
            obtenerListaUsuarios();
        }

        public void buscarUsuario(string dni)
        {
            tabla.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(obtenerConexion()))
            {
                SqlCommand sqlCommand = new SqlCommand("Select * from socio where Dni=@Dni", sqlConnection);
                SqlParameter sqlParameter = new SqlParameter("Dni", dni);
                sqlCommand.Parameters.Add(sqlParameter);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(tabla);
                obtenerListaUsuarios();
            }
        }

        public int registrarUsuario(string dni, string nombre, string apellidos, string contrasena, string fechaNacimiento, string fechaRegistro, string telefono, string email)
        {
            SqlCommand sqlCommand;
            int resultado = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Insert usuario values('{0}','{1}','{2}','{3}',{4}','{5}','{6}','{7}')", dni, nombre, apellidos, contrasena, fechaNacimiento, fechaRegistro, telefono, email);
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(obtenerConexion()))
                {
                    sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection);
                    resultado = sqlCommand.ExecuteNonQuery();
                }
                return resultado;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static List<Usuario> obtenerListaUsuarios()
        {
            Usuario usuario = new Usuario();
            foreach (DataRow dr in tabla.Rows)
            {
                listaUsuarios.Add(new Usuario { dni = dr["Dni"].ToString(), nombre = dr["Nombre"].ToString(), apellidos = dr["Apellidos"].ToString(), contrasena = dr["Contrasena"].ToString(), fechaNacimiento = dr["fechaNacimiento"].ToString(), fechaRegistro = dr["fechaRegistro"].ToString(), telefono = dr["Telefono"].ToString(), email = dr["Email"].ToString() });
            }
            return listaUsuarios;
        }
    }
}
