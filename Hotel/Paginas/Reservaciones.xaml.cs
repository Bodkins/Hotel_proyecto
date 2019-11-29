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
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;

namespace Hotel.Paginas
{
    /// <summary>
    /// Lógica de interacción para Reservaciones.xaml
    /// </summary>
    public partial class Reservaciones : Page
    {
        System.Windows.Controls.Grid miGrid;
     
        public Reservaciones()
        {

          
            
            InitializeComponent();

          

            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM reservacion;", conexionBD);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    mostrarReservaciones(
                        reader.GetString(0), 
                        reader.GetString(1),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5)
                        ) ;
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }




    
        
        
        }

       
     
        
        private void mostrarReservaciones(
            string numRer,
            string numHab,
            string nomClien,
            string FechaRese,
            string FechaSal
            )
        {
            Card back = new Card();
            BrushConverter bc = new BrushConverter();
             ListViewItem itemReservacion = new ListViewItem();
            itemReservacion.Background = (Brush)bc.ConvertFrom("#ffffff");
            itemReservacion.Focusable = false;
                     
            back.Width =810 ;
            back.Height=100;
            back.Background = (Brush)bc.ConvertFrom("#F1F3F6");
            back.UniformCornerRadius = 10;
            System.Windows.Controls.Grid miGrid = new System.Windows.Controls.Grid();
            
            TextBlock txtNumReservacion = new TextBlock();
            TextBlock txtNumHabitacion = new TextBlock();
            TextBlock txtCliente = new TextBlock();
            TextBlock txtFechaReservacion = new TextBlock();
            TextBlock txtFechaSalida = new TextBlock();

            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(3, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(2, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(2, GridUnitType.Star);


            miGrid.ColumnDefinitions.Add(new ColumnDefinition());
            miGrid.ColumnDefinitions.Add(new ColumnDefinition());
            miGrid.ColumnDefinitions.Add(c1);
            miGrid.ColumnDefinitions.Add(c2);
            miGrid.ColumnDefinitions.Add(c3);
            miGrid.ColumnDefinitions.Add(new ColumnDefinition());

            txtNumReservacion.Text = numRer ;
            txtNumReservacion.FontSize = 40;
            txtNumReservacion.FontWeight = FontWeights.Medium;
            txtNumReservacion.VerticalAlignment = VerticalAlignment.Center;
            txtNumReservacion.HorizontalAlignment = HorizontalAlignment.Center;
            txtNumReservacion.Foreground = Brushes.Blue;
            miGrid.Children.Add(txtNumReservacion);




            txtNumHabitacion.Text = "Hab "+ numHab;
            txtNumHabitacion.FontSize = 20;
            txtNumHabitacion.VerticalAlignment = VerticalAlignment.Center;
            txtNumHabitacion.HorizontalAlignment = HorizontalAlignment.Left;
            
            txtNumHabitacion.Foreground = Brushes.Gray;
            txtNumHabitacion.SetValue(Grid.ColumnProperty, 1);
           miGrid.Children.Add(txtNumHabitacion);


            txtCliente.Text = nomClien;
            txtCliente.FontSize = 30;
            txtCliente.FontStyle = FontStyles.Italic;
            txtCliente.FontWeight = FontWeights.Light;
            txtCliente.VerticalAlignment = VerticalAlignment.Center;
            txtCliente.HorizontalAlignment = HorizontalAlignment.Center;
            txtCliente.Foreground = Brushes.Gray;
            txtCliente.SetValue(Grid.ColumnProperty, 2);
            miGrid.Children.Add(txtCliente);

            txtFechaReservacion.Text = "Del "+ FechaRese[6] + FechaRese[7] + "/" + FechaRese[4] + FechaRese[5] + "/" + FechaRese[0]+ FechaRese[1]+ FechaRese[2]+ FechaRese[3] ;
            txtFechaReservacion.FontSize = 20;
            txtFechaReservacion.VerticalAlignment = VerticalAlignment.Center;
            txtFechaReservacion.HorizontalAlignment = HorizontalAlignment.Center;
            txtFechaReservacion.Foreground = Brushes.Gray;
            txtFechaReservacion.SetValue(Grid.ColumnProperty, 3);
            miGrid.Children.Add(txtFechaReservacion);



            txtFechaSalida.Text = "Al "+ FechaSal[6] + FechaSal[7] + "/" + FechaSal[4] + FechaSal[5] + "/" + FechaSal[0]+ FechaSal[1]+ FechaSal[2]+ FechaSal[3];
            txtFechaSalida.FontSize = 20;
            txtFechaSalida.VerticalAlignment = VerticalAlignment.Center;
            txtFechaSalida.HorizontalAlignment = HorizontalAlignment.Center;
            txtFechaSalida.Foreground = Brushes.Gray;
            txtFechaSalida.SetValue(Grid.ColumnProperty, 4);
            miGrid.Children.Add(txtFechaSalida);

            CheckBox cb = new CheckBox();
            cb.Content = "cancelar";
            cb.SetValue(Grid.ColumnProperty,5);
            miGrid.Children.Add(cb);


            back.Content = miGrid;
            
            itemReservacion.Content = back;
            lstReservaciones.Items.Add(itemReservacion);
           
        }

      
    }
}
