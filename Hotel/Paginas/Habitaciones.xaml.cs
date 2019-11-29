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
using MySql.Data.MySqlClient;

namespace Hotel.Paginas
{
    /// <summary>
    /// Lógica de interacción para Habitaciones.xaml
    /// </summary>
    public partial class Habitaciones : Page
    {
        MainWindow ven = new MainWindow();
        


        public Habitaciones()
        {
            InitializeComponent();
            for (int i=4;i>0;i--)
            {
                mostrarHabitaciones(i);
            }
            
           




        }

        private void btnPresidentialSuite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new presidentialSuite());
            
        }


        void mostrarHabitaciones(int id)
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio= 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;
              
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM habitacion WHERE num_habitacion="+ id +";", conexionBD);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    switch (id)
                    {
                        case 4:
                            txt1grd4.Text = reader.GetString(4);
                            precio = Convert.ToInt32(reader.GetString(2));
                            txt2grd4.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                            
                            break;
                        case 3:
                            txt1grd3.Text = reader.GetString(4);
                            precio = Convert.ToInt32(reader.GetString(2));
                            txt2grd3.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                            break;
                        case 2:
                            txt1grd2.Text = reader.GetString(4);
                            precio = Convert.ToInt32(reader.GetString(2));
                            txt2grd2.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                            break;
                        case 1:
                            txt1grd1.Text = reader.GetString(4);
                            precio = Convert.ToInt32(reader.GetString(2));
                            txt2grd1.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                            break;

                    }
                   
                   
         
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }







        }

        private void btnGrandSuite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new grantSuite());
        }

        private void btnSeniorSuite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new seniorSuite());
        }

        private void btnDeluxe_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new deluxe());
        }
    }
}
