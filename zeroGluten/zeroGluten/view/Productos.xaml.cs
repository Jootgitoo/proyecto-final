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
using zeroGluten.domain;
using zeroGluten.persistence.manages;

namespace zeroGluten.view
{
    
    public partial class Productos : Window
    {

        ApiManage apiManager;

        public Productos()
        {
            InitializeComponent();
            apiManager = new ApiManage();

            cargarTodosProductos();
        }


        /// <summary>
        ///     Cargamos una lista de productos aleatorios de la API
        /// </summary>
        private async void cargarTodosProductos()
        {
            lbProductos.Items.Clear();

            lbProductos.Items.Add("Cargando datos...");

            try
            {
                //Obtenemos una lista de productos de la API
                List<Producto> listaProductos = await apiManager.getListaProductos();

                lbProductos.Items.Clear();

                //Mostramos la lista
                foreach (Producto p in listaProductos)
                {
                    lbProductos.Items.Add($"ID: {p.IdProducto}, Name: {p.Nombre}");
                }

            }
            catch (Exception ex)
            {
                lbProductos.Items.Clear();
                lbProductos.Items.Add($"Error al obtener datos: {ex.Message}");
            }

        }


        /// <summary>
        ///     Cargamos una lista de recetas aleatorios de la API
        /// </summary>
        private async void cargarTodasRecetas()
        {
            lbProductos.Items.Clear();

            lbProductos.Items.Add("Cargando datos...");

            try
            {
                //Obtenemos una lista de recetas de la API
                List<Receta> listaRecetas = await apiManager.getListaRecetas();

                lbProductos.Items.Clear();

                //Mostramos la lista
                foreach (Receta r in listaRecetas)
                {
                    lbProductos.Items.Add($"ID: {r.IdReceta}, Name: {r.NombreReceta}");
                }

            }
            catch (Exception ex)
            {
                lbProductos.Items.Clear();
                lbProductos.Items.Add($"Error al obtener datos: {ex.Message}");
            }

        }


        /// <summary>
        ///    Método que muestra los filtros de productos
        /// </summary>
        public void MostrarFiltrosProductos()
        {
            filtrosRecetas.Visibility = Visibility.Collapsed;
            filtrosProductos.Visibility = Visibility.Visible;
        }


        /// <summary>
        ///    Método que muestra los filtros de recetas
        /// </summary>
        public void MostrarFiltrosRecetas()
        {
            filtrosProductos.Visibility = Visibility.Collapsed;
            filtrosRecetas.Visibility = Visibility.Visible;
        }


        /// <summary>
        ///    Método que se ejecuta al hacer click en el botón de productos
        ///    Mostramos los filtros de productos y cargamos todos los productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            MostrarFiltrosProductos();
            cargarTodosProductos();
            filtrosProductos.Visibility = Visibility.Visible;
        }


        /// <summary>
        ///     Método que se ejecuta al hacer click en el botón de recetas
        ///     Mostramos los filtros de las recetas y cargamos todos las recetas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecetas_Click(object sender, RoutedEventArgs e)
        {
            MostrarFiltrosRecetas();
            cargarTodasRecetas();
            filtrosRecetas.Visibility = Visibility.Visible;
        }
    }

    
}
