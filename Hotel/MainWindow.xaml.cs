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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Hotel
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            cuadroDeContenido.Content = new Hotel.Paginas.Inicio();

            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            string datos = "";
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("DESCRIBE EMPLEADO;", conexionBD);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    datos += reader.GetString(0)+ "\n";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            //MessageBox.Show(datos);
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void grdBarra_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //Cambio de paginas 

        private void goToRooms(object sender, RoutedEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.Habitaciones();

        private void goToReservations(object sender, RoutedEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.Reservaciones();

        private void goToMaids(object sender, RoutedEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.Reservar();

        private void btnCliente_Click(object sender, RoutedEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.AgregarCliente();

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.Inicio();

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => cuadroDeContenido.Content = new Hotel.Paginas.Inicio();
    }
}
