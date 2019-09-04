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

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para ConsultasWindow.xaml
    /// </summary>
    public partial class ConsultasWindow : Window
    {
        public ConsultasWindow()
        {
            InitializeComponent();
        }

        private void mantenimientoButton_Click(object sender, RoutedEventArgs e)
        {
            MantenimientoWindow mantenimientoWindow = new MantenimientoWindow();
            mantenimientoWindow.Show();
        }

        private void consultarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void consultarEstadoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void consultarFechaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void verDatosButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
