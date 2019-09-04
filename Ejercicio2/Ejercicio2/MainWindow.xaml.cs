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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void librosButton_Click(object sender, RoutedEventArgs e)
        {
            WindowLibros windowLibros = new WindowLibros();
            windowLibros.Show();
        }

        private void sociosButton_Click(object sender, RoutedEventArgs e)
        {
            WindowSocios windowSocios = new WindowSocios();
            windowSocios.Show();
        }

        private void prestamosButton_Click(object sender, RoutedEventArgs e)
        {
            WindowPrestamos windowPrestamos = new WindowPrestamos();
            windowPrestamos.Show();
        }
    }
}
