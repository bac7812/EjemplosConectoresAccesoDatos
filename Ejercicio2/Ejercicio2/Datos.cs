using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejercicio2
{
    class Datos
    {
        public static BibliotecaDataSet ds = new BibliotecaDataSet();
        public static string conexion = Properties.Settings.Default.BibliotecaConnectionString.ToString();
        public static BibliotecaDataSet.SocioRow socio;
        public static BibliotecaDataSet.LibroRow libro;
        public static BibliotecaDataSet.EjemplarRow ejemplar;
        public static string error = "";

        public static void obtenerLibro(string busquedaComboBox, string busquedaTextBox)
        {
            ds.Libro.Clear();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Select * from libro where {0} ='{1}'", busquedaComboBox, busquedaTextBox);
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conexion);
                adapter.Fill(ds.Libro);
                if (ds.Libro.Count() == 1)
                {
                    libro = ds.Libro[0];
                }
                else
                {
                    libro = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void obtenerEjemplar(string busqueda)
        {
            ds.Ejemplar.Clear();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Select * from ejemplar where codigolibro='{0}'", busqueda);
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conexion);
                adapter.Fill(ds.Ejemplar);
                if (ds.Ejemplar.Count() == 1)
                {
                    ejemplar = ds.Ejemplar[0];
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void insertarLibro(string isbn, string titulo, string editorial, string descripcion)
        {
            ds.Libro.Clear();
            obtenerLibro("Isbn",isbn);
            try
            {
                if(libro == null)
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Insert libro values('{0}','{1}','{2}','{3}')", isbn, titulo, editorial, descripcion);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    obtenerLibro("Isbn", isbn);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void insertarEjemplar(string isbn, string fechaPublicacion, string numeroEjemplares)
        {
            ds.Libro.Clear();
            obtenerLibro("Isbn", isbn);
            try
            {
                if (libro != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Insert ejemplar values('{0}','{1}','{2}','{3}')", libro.CodigoLibro, numeroEjemplares, fechaPublicacion, "D");
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void modificarLibro(string isbn, string titulo, string editorial, string descripcion)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                sqlConnection.Open();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Update libro set Titulo='{0}', Editorial='{1}', Descripcion='{2}' where Isbn='{3}'", titulo, editorial, descripcion, isbn);
                SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void eliminarLibro(string isbn)
        {
            ds.Libro.Clear();
            obtenerLibro("Isbn", isbn);
            try
            {
                if(libro != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Delete from ejemplar where CodigoLibro='{0}'", libro.CodigoLibro);
                    sql.AppendFormat("Delete from libro where CodigoLibro='{0}'", libro.CodigoLibro);
                    //sql.AppendFormat("Exec historico '{0}'", libro.CodigoLibro);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void obtenerSocio(string busquedaComboBox, string busquedaTextBox)
        {
            ds.Socio.Clear();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Select * from socio where {0} ='{1}'", busquedaComboBox, busquedaTextBox);
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conexion);
                adapter.Fill(ds.Socio);
                if (ds.Socio.Count() == 1)
                {
                    socio = ds.Socio[0];
                }
                else
                {
                    socio = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void insertarSocio(string dni, string nombre, string apellidos, string direccion, string correo, string telefono)
        {
            ds.Socio.Clear();
            obtenerSocio("Dni", dni);
            try
            {
                if (socio == null)
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Insert socio values('{0}','{1}','{2}','{3}','{4}','{5}')", dni, nombre, apellidos, direccion, correo, telefono);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    obtenerSocio("Dni", dni);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void modificarSocio(string dni, string nombre, string apellidos, string direccion, string correo, string telefono)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                sqlConnection.Open();
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Update socio set Nombre='{0}', Apellidos='{1}', Direccion='{2}', Correo='{3}', Telefono='{4}' where Dni='{5}'", nombre, apellidos, direccion, correo, telefono, dni);
                SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void eliminarSocio(string dni)
        {
            ds.Socio.Clear();
            obtenerSocio("Dni", dni);
            try
            {
                if (socio != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Delete from socio where CodigoSocio='{0}'", socio.CodigoSocio);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void registrarPrestamo(string busquedaSocioComboBox, string busquedaSocioTextBox, string busquedaLibroComboBox, string busquedaLibroTextBox)
        {
            ds.Socio.Clear();
            ds.Libro.Clear();
            ds.Ejemplar.Clear();
            obtenerSocio(busquedaSocioComboBox, busquedaSocioTextBox);
            obtenerLibro(busquedaLibroComboBox, busquedaLibroTextBox);
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Select * from ejemplar where CodigoLibro='{0}' and Estado='D'", libro.CodigoLibro);
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conexion);
                adapter.Fill(ds.Ejemplar);
                if (ds.Socio.Count() == 1)
                {
                    if (ds.Libro.Count() == 1)
                    {
                        if(ds.Ejemplar.Count() != 0)
                        {
                            ejemplar = ds.Ejemplar[0];
                        }
                        else
                        {
                            ejemplar = null;
                        }
                    }
                    else
                    {
                        libro = null;
                    }
                }
                else
                {
                    socio = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void devolverPrestamo(string busquedaSocioComboBox, string busquedaSocioTextBox, string busquedaLibroComboBox, string busquedaLibroTextBox)
        {
            ds.Socio.Clear();
            ds.Libro.Clear();
            ds.Ejemplar.Clear();
            obtenerSocio(busquedaSocioComboBox, busquedaSocioTextBox);
            obtenerLibro(busquedaLibroComboBox, busquedaLibroTextBox);
            try
            {
                SqlConnection sqlConnection = new SqlConnection(conexion);
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat("Select * from ejemplar where CodigoLibro='{0}' and Estado='P'", libro.CodigoLibro);
                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conexion);
                adapter.Fill(ds.Ejemplar);
                if (ds.Socio.Count() == 1)
                {
                    if (ds.Libro.Count() == 1)
                    {
                        if (ds.Ejemplar.Count() != 0)
                        {
                            ejemplar = ds.Ejemplar[0];
                        }
                        else
                        {
                            ejemplar = null;
                        }
                    }
                    else
                    {
                        libro = null;
                    }
                }
                else
                {
                    socio = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }

        public static void actualizarPrestamo(string busquedaSocioComboBox, string busquedaSocioTextBox, string busquedaLibroComboBox, string busquedaLibroTextBox, int numero, string mensaje)
        {
            ds.Socio.Clear();
            ds.Libro.Clear();
            ds.Ejemplar.Clear();
            obtenerSocio(busquedaSocioComboBox, busquedaSocioTextBox);
            obtenerLibro(busquedaLibroComboBox, busquedaLibroTextBox);
            try
            {
                if(mensaje == "Registrar")
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Insert prestamo values('{0}','{1}','{2}',SYSDATETIME(),NULL)", libro.CodigoLibro, numero , socio.CodigoSocio);
                    sql.AppendFormat("Update ejemplar set Estado='P' where CodigoLibro='{0}' and NumeroEjemplar='{1}'", libro.CodigoLibro, numero);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection(conexion);
                    sqlConnection.Open();
                    StringBuilder sql = new StringBuilder();
                    sql.AppendFormat("Update prestamo set FechaDevolucion=SYSDATETIME() where CodigoLibro='{0}'", libro.CodigoLibro);
                    sql.AppendFormat("Update ejemplar set Estado='D' where CodigoLibro='{0}' and NumeroEjemplar='{1}'", libro.CodigoLibro, numero);
                    SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = null;
            }
        }
    }
}
