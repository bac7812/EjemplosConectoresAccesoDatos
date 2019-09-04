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
    /// Lógica de interacción para WindowLibros.xaml
    /// </summary>
    public partial class WindowLibros : Window
    {
        string error = "";

        public WindowLibros()
        {
            InitializeComponent();
            for(int i = 0; i < Datos.ds.Libro.DefaultView.Table.Columns.Count; i++)
            {
                busquedaComboBox.Items.Add(Datos.ds.Libro.DefaultView.Table.Columns[i].ColumnName);
            }
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (busquedaComboBox.Text != "" && busquedaTextBox.Text != "")
            {
                Datos.obtenerLibro(busquedaComboBox.Text, busquedaTextBox.Text);

                if (error != null)
                {
                    if (Datos.libro != null)
                    {
                        isbnTextBox.Text = Datos.libro.Isbn.ToString();
                        tituloTextBox.Text = Datos.libro.Titulo.ToString();
                        editorialTextBox.Text = Datos.libro.Editorial.ToString();
                        descripcionTextBox.Text = Datos.libro.Descripcion.ToString();
                        crearButton.IsEnabled = false;
                        modificarButton.IsEnabled = true;
                        eliminarButton.IsEnabled = true;
                        ejemplaresDataGrid.ItemsSource = "";
                        Datos.obtenerEjemplar(Convert.ToString(Datos.libro.CodigoLibro));
                        ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                        ejemplaresDataGrid.IsEnabled = true;
                        fechaPublicacionDatePicker.IsEnabled = true;
                        numeroEjemplaresTextBox.IsEnabled = true;
                        guardarButton.IsEnabled = true;
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

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            busquedaComboBox.Text = "";
            busquedaTextBox.Text = "";
            isbnTextBox.Text = "";
            tituloTextBox.Text = "";
            editorialTextBox.Text = "";
            descripcionTextBox.Text = "";
            crearButton.IsEnabled = true;
            modificarButton.IsEnabled = false;
            eliminarButton.IsEnabled = false;
            ejemplaresDataGrid.ItemsSource = "";
            ejemplaresDataGrid.IsEnabled = false;
            fechaPublicacionDatePicker.IsEnabled = false;
            numeroEjemplaresTextBox.IsEnabled = false;
            guardarButton.IsEnabled = false;
        }

        private void crearButton_Click(object sender, RoutedEventArgs e)
        {
            if (isbnTextBox.Text != "" && tituloTextBox.Text != "" && editorialTextBox.Text != "" && descripcionTextBox.Text != "")
            {
                Datos.insertarLibro(isbnTextBox.Text, tituloTextBox.Text, editorialTextBox.Text, descripcionTextBox.Text);

                if (error != null)
                {
                    if (Datos.libro != null)
                    {
                        ejemplaresDataGrid.ItemsSource = "";
                        Datos.obtenerEjemplar(Convert.ToString(Datos.libro.CodigoLibro));
                        ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                        ejemplaresDataGrid.IsEnabled = true;
                        fechaPublicacionDatePicker.IsEnabled = true;
                        numeroEjemplaresTextBox.IsEnabled = true;
                        guardarButton.IsEnabled = true;
                        MessageBox.Show("El libro ya guardado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("El libro ya existe", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (isbnTextBox.Text != "" && tituloTextBox.Text != "" && editorialTextBox.Text != "" && descripcionTextBox.Text != "")
            {
                Datos.modificarLibro(isbnTextBox.Text, tituloTextBox.Text, editorialTextBox.Text, descripcionTextBox.Text);

                if (error != null)
                {
                    ejemplaresDataGrid.ItemsSource = "";
                    Datos.obtenerEjemplar(Convert.ToString(Datos.libro.CodigoLibro));
                    ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                    MessageBox.Show("El libro ya modificado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (isbnTextBox.Text != "" && tituloTextBox.Text != "" && editorialTextBox.Text != "" && descripcionTextBox.Text != "")
            {
                Datos.eliminarLibro(isbnTextBox.Text);

                if (error != null)
                {
                    busquedaComboBox.Text = "";
                    busquedaTextBox.Text = "";
                    isbnTextBox.Text = "";
                    tituloTextBox.Text = "";
                    editorialTextBox.Text = "";
                    descripcionTextBox.Text = "";
                    ejemplaresDataGrid.ItemsSource = "";
                    crearButton.IsEnabled = true;
                    modificarButton.IsEnabled = false;
                    eliminarButton.IsEnabled = false;
                    ejemplaresDataGrid.IsEnabled = false;
                    fechaPublicacionDatePicker.IsEnabled = false;
                    numeroEjemplaresTextBox.IsEnabled = false;
                    guardarButton.IsEnabled = false;
                    MessageBox.Show("El libro ya eliminado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (fechaPublicacionDatePicker.Text != "" && numeroEjemplaresTextBox.Text != "")
            {
                Datos.insertarEjemplar(isbnTextBox.Text, fechaPublicacionDatePicker.Text, numeroEjemplaresTextBox.Text);

                if (error != null)
                {
                    if (Datos.libro != null)
                    {
                        fechaPublicacionDatePicker.Text = "";
                        numeroEjemplaresTextBox.Text = "";
                        ejemplaresDataGrid.ItemsSource = "";
                        Datos.obtenerEjemplar(Convert.ToString(Datos.libro.CodigoLibro));
                        ejemplaresDataGrid.ItemsSource = Datos.ds.Ejemplar;
                        MessageBox.Show("El ejemplar ya guardado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("El ejemplar ya existe", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}
