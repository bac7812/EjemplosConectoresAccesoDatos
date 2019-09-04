using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ejercicio2
{
    /// <summary>
    /// Lógica de interacción para WindowSocios.xaml
    /// </summary>
    public partial class WindowSocios : Window
    {
        string error = "";

        public WindowSocios()
        {
            InitializeComponent();
            for (int i = 0; i < Datos.ds.Socio.DefaultView.Table.Columns.Count; i++)
            {
                busquedaComboBox.Items.Add(Datos.ds.Socio.DefaultView.Table.Columns[i].ColumnName);
            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (busquedaComboBox.Text != "" && busquedaTextBox.Text != "")
            {
                Datos.obtenerSocio(busquedaComboBox.Text, busquedaTextBox.Text);

                if (error != null)
                {
                    if (Datos.socio != null)
                    {
                        dniTextBox.Text = Datos.socio.Dni.ToString();
                        nombreTextBox.Text = Datos.socio.Nombre.ToString();
                        apellidosTextBox.Text = Datos.socio.Apellidos.ToString();
                        direccionTextBox.Text = Datos.socio.Direccion.ToString();
                        correoTextBox.Text = Datos.socio.Correo.ToString();
                        telefonoTextBox.Text = Datos.socio.Telefono.ToString();
                        dniTextBox.IsEnabled = false;
                        crearButton.IsEnabled = false;
                        modificarButton.IsEnabled = true;
                        eliminarButton.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    error = "";
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void crearButton_Click(object sender, RoutedEventArgs e)
        {
            if (dniTextBox.Text != "" && nombreTextBox.Text != "" && apellidosTextBox.Text != "" && direccionTextBox.Text != "" && correoTextBox.Text != "" && telefonoTextBox.Text != "")
            {
                Datos.insertarSocio(dniTextBox.Text, nombreTextBox.Text, apellidosTextBox.Text, direccionTextBox.Text, correoTextBox.Text, telefonoTextBox.Text);

                if (error != null)
                {
                    if (Datos.socio != null)
                    {
                        MessageBox.Show("El socio ya guardado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("El socio ya existe", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    error = "";
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarButton_Click(object sender, RoutedEventArgs e)
        {
            if (dniTextBox.Text != "" && nombreTextBox.Text != "" && apellidosTextBox.Text != "" && direccionTextBox.Text != "" && correoTextBox.Text != "" && telefonoTextBox.Text != "")
            {
                Datos.modificarSocio(dniTextBox.Text, nombreTextBox.Text, apellidosTextBox.Text, direccionTextBox.Text, correoTextBox.Text, telefonoTextBox.Text);

                if (error != null)
                {
                    MessageBox.Show("El socio ya modificado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    error = "";
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (dniTextBox.Text != "" && nombreTextBox.Text != "" && apellidosTextBox.Text != "" && direccionTextBox.Text != "" && correoTextBox.Text != "" && telefonoTextBox.Text != "")
            {
                Datos.eliminarSocio(dniTextBox.Text);

                if (error != null)
                {
                    busquedaComboBox.Text = "";
                    busquedaTextBox.Text = "";
                    dniTextBox.Text = "";
                    nombreTextBox.Text = "";
                    apellidosTextBox.Text = "";
                    direccionTextBox.Text = "";
                    correoTextBox.Text = "";
                    telefonoTextBox.Text = "";
                    dniTextBox.IsEnabled = true;
                    crearButton.IsEnabled = true;
                    modificarButton.IsEnabled = false;
                    eliminarButton.IsEnabled = false;
                    MessageBox.Show("El socio ya eliminado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    error = "";
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            busquedaComboBox.Text = "";
            busquedaTextBox.Text = "";
            dniTextBox.Text = "";
            nombreTextBox.Text = "";
            apellidosTextBox.Text = "";
            direccionTextBox.Text = "";
            correoTextBox.Text = "";
            telefonoTextBox.Text = "";
            dniTextBox.IsEnabled = true;
            crearButton.IsEnabled = true;
            modificarButton.IsEnabled = false;
            eliminarButton.IsEnabled = false;
        }
    }
}
