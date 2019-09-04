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
    /// Lógica de interacción para WindowPrestamos.xaml
    /// </summary>
    public partial class WindowPrestamos : Window
    {
        string mensaje;
        string error = "";

        public WindowPrestamos()
        {

            InitializeComponent();
            for (int i = 0; i < Datos.ds.Libro.DefaultView.Table.Columns.Count; i++)
            {
                busquedaLibroComboBox.Items.Add(Datos.ds.Libro.DefaultView.Table.Columns[i].ColumnName);
            }
            for (int i = 0; i < Datos.ds.Socio.DefaultView.Table.Columns.Count; i++)
            {
                busquedaSocioComboBox.Items.Add(Datos.ds.Socio.DefaultView.Table.Columns[i].ColumnName);
            }
        }

        private void registrarButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (busquedaSocioComboBox.Text != "" && busquedaSocioTextBox.Text != "" && busquedaLibroComboBox.Text != "" && busquedaLibroTextBox.Text != "")
            {
                Datos.registrarPrestamo(busquedaSocioComboBox.Text, busquedaSocioTextBox.Text, busquedaLibroComboBox.Text, busquedaLibroTextBox.Text);

                if(error != null)
                {
                    if (Datos.ejemplar != null)
                    {
                        ejemplaresDataGrid.ItemsSource = "";
                        ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                        devolverButton.IsEnabled = false;
                        ejemplaresDataGrid.IsEnabled = true;
                        actualizarButton.IsEnabled = true;
                        cancelarButton.IsEnabled = true;
                        mensaje = "Registrar";
                    }
                    else
                    {
                        MessageBox.Show("No hay ejemplares disponibles", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void devolverButton_Click(object sender, RoutedEventArgs e)
        {
            if (busquedaSocioComboBox.Text != "" && busquedaSocioTextBox.Text != "" && busquedaLibroComboBox.Text != "" && busquedaLibroTextBox.Text != "")
            {
                Datos.devolverPrestamo(busquedaSocioComboBox.Text, busquedaSocioTextBox.Text, busquedaLibroComboBox.Text, busquedaLibroTextBox.Text);

                if (error != null)
                {
                    if (Datos.ejemplar != null)
                    {
                        ejemplaresDataGrid.ItemsSource = "";
                        ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                        registrarButton.IsEnabled = false;
                        ejemplaresDataGrid.IsEnabled = true;
                        actualizarButton.IsEnabled = true;
                        cancelarButton.IsEnabled = true;
                        mensaje = "Devolver";
                    }
                    else
                    {
                        MessageBox.Show("No hay ejemplares disponibles", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void actualizarButton_Click(object sender, RoutedEventArgs e)
        {
            if (busquedaSocioComboBox.Text != "" && busquedaSocioTextBox.Text != "" && busquedaLibroComboBox.Text != "" && busquedaLibroTextBox.Text != "")
            {
                if (ejemplaresDataGrid.SelectedItem != null)
                {
                    int numero = Datos.ds.Ejemplar[ejemplaresDataGrid.SelectedIndex].NumeroEjemplar;
                    Datos.actualizarPrestamo(busquedaSocioComboBox.Text, busquedaSocioTextBox.Text, busquedaLibroComboBox.Text, busquedaLibroTextBox.Text, numero, mensaje);
                    if (error != null)
                    {
                        MessageBox.Show("El prestamo ya actualizado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                        ejemplaresDataGrid.ItemsSource = "";
                        registrarButton.IsEnabled = true;
                        ejemplaresDataGrid.IsEnabled = false;
                        actualizarButton.IsEnabled = false;
                    }
                    else
                    {
                        error = "";
                    }
                }
                else
                {
                    MessageBox.Show("Debes seleccionar un ejemplar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            registrarButton.IsEnabled = true;
            devolverButton.IsEnabled = true;
            ejemplaresDataGrid.ItemsSource = "";
            ejemplaresDataGrid.IsEnabled = false;
            actualizarButton.IsEnabled = false;
            cancelarButton.IsEnabled = false;
        }
    }
}
