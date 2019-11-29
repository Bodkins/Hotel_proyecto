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
    /// Lógica de interacción para AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : Page
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string cadenaConexion = "server=localhost; port=3306 ; userid=root ; password=root; database=hotel;";

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            try
            {
                conexionBD.Open();
                MySqlDataReader reader = null;
                int Adaptador = 0;


               

             

                

                MySqlCommand cmd = new MySqlCommand("INSERT INTO cliente (nom_cliente,apPat_cliente,apMat_cliente, num_telefono, num_tarjeta, sexo) VALUES ('" + txtNombre.Text + "','" + txtApPat.Text + "','" + txtApMat.Text + "','" + txtTel.Text + "','" + txtNumTar.Text + "','"+txtSexo.Text +"') ;", conexionBD);
                Console.WriteLine("Se guardo " + Adaptador);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se ha agregado correctamente");



                conexionBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
