using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=reynoso;Password=123";
   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Productos(object sender, RoutedEventArgs e)
        {
            List<Productos> productos = new List<Productos>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idProducto = reader.GetInt32(reader.GetOrdinal("idProducto"));
                    string nombreProducto = reader.GetString(reader.GetOrdinal("nombreProducto"));
                    string cantidadPorUnidad = reader.GetString(reader.GetOrdinal("cantidadPorUnidad"));

                    productos.Add(new Productos { IdProducto = idProducto, NombreProducto = nombreProducto, CantidadPorUnidad = cantidadPorUnidad });
                }

                connection.Close();


                dataProductos.ItemsSource = productos;
                dataProductos.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Button_Categorias(object sender, RoutedEventArgs e)
        {
            List<Categorias> categorias = new List<Categorias>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarCategorias", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Idcategoria = reader.GetInt32(reader.GetOrdinal("Idcategoria"));
                    string nombrecategoria = reader.GetString(reader.GetOrdinal("nombrecategoria"));
                    string descripcion = reader.GetString(reader.GetOrdinal("descripcion"));

                    categorias.Add(new Categorias { Idcategoria = Idcategoria, nombrecategoria = nombrecategoria, descripcion = descripcion });
                }

                connection.Close();

                dataCategorias.ItemsSource = categorias;
                dataCategorias.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button_Proveedores(object sender, RoutedEventArgs e)
        {
            List<Proveedores> proveedores = new List<Proveedores>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("USP_ListarProveedores", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor"));
                    string nombrecontacto = reader.GetString(reader.GetOrdinal("nombrecontacto"));
                    string ciudad = reader.GetString(reader.GetOrdinal("ciudad"));

                    proveedores.Add(new Proveedores { IdProveedor = IdProveedor, nombrecontacto = nombrecontacto, ciudad = ciudad });
                }

                connection.Close();

                dataProveedores.ItemsSource = proveedores;
                dataProveedores.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}