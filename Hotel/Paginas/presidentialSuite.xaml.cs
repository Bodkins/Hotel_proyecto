using MySql.Data.MySqlClient;
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


namespace Hotel.Paginas
{
    /// <summary>
    /// Lógica de interacción para presidentialSuite.xaml
    /// </summary>
    public partial class presidentialSuite : Page
    {
        public presidentialSuite()
        {
            InitializeComponent();
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM habitacion WHERE clase_habitacion='presidential Suite';", conexionBD);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   

                    txtCapacidad.Text = "Cap " + reader.GetString(1) + " per";
                    precio = Convert.ToInt32( reader.GetString(2));
                    txtPrecio.Text = precio / 1000 + "," + precio % 1000 + " USD";
                    txtDescripcion.Text = reader.GetString(3);
                    txtNombre.Text = reader.GetString(4);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }






        }

        private void btnReservar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Reservar());
        }
    }
}
