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
    /// Lógica de interacción para Reservar.xaml
    /// </summary>
    public partial class Reservar : Page
    {
        int total;
        public Reservar()
        {
            InitializeComponent();


            mostrarHabitacion();
            mostrarEmpleado();
            mostrarCliente();
          









        }



        void mostrarHabitacion()
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM habitacion ;  " +
                    "" +
                    "SELECT * FROM empleado;", conexionBD);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbTipoHabitaciones.FontSize = 25;
                    cbTipoHabitaciones.Foreground = Brushes.LightSteelBlue;
                    cbTipoHabitaciones.Items.Add(reader.GetString(4));

                    //txt1grd1.Text = reader.GetString(4);
                    //precio = Convert.ToInt32(reader.GetString(2));
                    //txt2grd1.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                    //conexionBD.Close();

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

            conexionBD.Close();
        }


        void mostrarHabitaciones(string tipo)
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                
                MySqlDataReader read = null;
                

                MySqlCommand cmd2 = new MySqlCommand("select nom_habitacion from reservacion where fecha_reservacion>='" +dpInicio.SelectedDate.Value.Year.ToString()+ dpInicio.SelectedDate.Value.Month.ToString() + dpInicio.SelectedDate.Value.Day.ToString() + "' and fecha_salida<= '" + dpFin.SelectedDate.Value.Year.ToString() + dpFin.SelectedDate.Value.Month.ToString() + dpFin.SelectedDate.Value.Day.ToString() + "';", conexionBD);

                //Console.WriteLine(((System.Data.DataRowView)cbHabitaciones.SelectedItem).Row.ItemArray[0].ToString());
                //Console.WriteLine("Hola");
                read = cmd2.ExecuteReader();
                List<string> habOcupadas = new List<string>();
                while (read.Read())
                {
                    habOcupadas.Add(read.GetString(0));


                }
                conexionBD.Close();

                conexionBD.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SELECT nom_habitacion FROM habitaciones inner join habitacion on habitaciones.num_habitacion=habitacion.num_habitacion where habitacion.clase_habitacion='" + tipo + "'  ;", conexionBD);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool dontExist = true;
                    for (int i=0;i<habOcupadas.Count(); i++)
                    {
                        if (habOcupadas[i]== reader.GetString(0))
                        {
                            dontExist = false;
                        }
                    }

                    if (dontExist) {
                        cbHabitaciones.FontSize = 25;
                        cbHabitaciones.Foreground = Brushes.LightSteelBlue;
                        cbHabitaciones.Items.Add(reader.GetString(0));
                    }
                    //txt1grd1.Text = reader.GetString(4);
                    //precio = Convert.ToInt32(reader.GetString(2));
                    //txt2grd1.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                    //conexionBD.Close();

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

            conexionBD.Close();
        }



        void mostrarEmpleado()
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM empleado ;", conexionBD);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbMucama.FontSize = 25;
                    cbMucama.Foreground = Brushes.LightSteelBlue;
                    cbMucama.Items.Add(reader.GetString(0) + " " + reader.GetString(1));

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }


            conexionBD.Close();

        }


        void mostrarCliente()
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente ;", conexionBD);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbCliente.FontSize = 25;
                    cbCliente.Foreground = Brushes.LightSteelBlue;
                    cbCliente.Items.Add(reader.GetString(0) + "  " + reader.GetString(1));

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }


            conexionBD.Close();

        }

       

        private void cbTipoHabitaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbHabitaciones.Items.Clear();
            mostrarHabitaciones(cbTipoHabitaciones.SelectedValue.ToString());
            mostrarTotal();
        }

        private void Reservar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           

            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
         
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;
                int Adaptador = 0;


                string format = "dd"+$"_"+"mm"+$"_"+"yyyy";
                DateTime c = DateTime.Now;
                DateTime a= new DateTime(dpInicio.SelectedDate.Value.Year, dpInicio.SelectedDate.Value.Month, dpInicio.SelectedDate.Value.Day);
                DateTime b= new DateTime(dpFin.SelectedDate.Value.Year, dpFin.SelectedDate.Value.Month, dpFin.SelectedDate.Value.Day); ;

                Console.WriteLine(a.ToShortDateString());
                Console.WriteLine(b.ToShortDateString());

                //b = Convert.ToDateTime( dpFin.SelectedDate);
                //a = Convert.ToDateTime( dpInicio.SelectedDate);

                string car = "";
                string ini = a.Year + car+ a.Month+ car + a.Day;
                string fin = b.Year + car+ b.Month + car + b.Day ;

                MySqlCommand cmd = new MySqlCommand("INSERT INTO reservacion (nom_habitacion,num_empleado,num_cliente, fecha_reservacion, fecha_salida, total) VALUES (" + (Convert.ToInt32(cbHabitaciones.SelectedValue.ToString()))+"," + (Convert.ToInt32(cbMucama.SelectedIndex.ToString()) + 1) + "," + (Convert.ToInt32(cbCliente.SelectedIndex.ToString()) + 1) + "," + a.Year.ToString() + car + a.Month.ToString() + car + a.Day.ToString() + ","+ b.Year.ToString() + car + b.Month.ToString() + car + b.Day.ToString() + "," + total + ") ;", conexionBD);
                Console.WriteLine("Se guardo " + Adaptador);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se ha reservado correctamente");

               

                conexionBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void mostrarTotal()
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";
            int precio = 0;
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand("SELECT precio FROM habitacion where clase_habitacion='"+ cbTipoHabitaciones.SelectedValue.ToString() +  "' ;", conexionBD);
                Console.WriteLine(cbTipoHabitaciones.SelectedValue.ToString());


             
                reader = cmd.ExecuteReader();

                DateTime a = new DateTime();
                DateTime b = new DateTime();
                b = Convert.ToDateTime(dpFin.SelectedDate.ToString());
                a = Convert.ToDateTime(dpInicio.SelectedDate.ToString());
                int totalDays = Convert.ToInt32((b - a).TotalDays);
          
                
                Console.WriteLine(totalDays);
                while (reader.Read())
                {


                    txtTotal.FontSize = 25;
                    txtTotal.Foreground = Brushes.LightSteelBlue;
                    total= Convert.ToInt32( reader.GetString(0))*totalDays;
                    txtTotal.Content = total / 1000 + "," + total % 1000 + " USD";
                    //txt1grd1.Text = reader.GetString(4);
                    //precio = Convert.ToInt32(reader.GetString(2));
                    //txt2grd1.Text = "" + (precio / 1000) + "," + precio % 1000 + " USD";
                    //conexionBD.Close();

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }

            conexionBD.Close();
        }

        private void dpFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipoHabitaciones.SelectedValue != null )
            {
                mostrarTotal();
            }
        }
    }
}
