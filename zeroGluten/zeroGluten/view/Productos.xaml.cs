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

        //Para saber que tipo de filtro queremos aplicar
        //Como la aplicacion por defecto carga los productos, inicializamos la variable en "Productos"
        string tipoSeleccionado = "Productos";

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
                List<Producto> listaProductos = await apiManager.obtenerTodosProductos();

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
                List<Receta> listaRecetas = await apiManager.obtenerTodasRecetas();

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
            tipoSeleccionado = "Productos";
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
            tipoSeleccionado = "Recetas";
            MostrarFiltrosRecetas();
            cargarTodasRecetas();
            filtrosRecetas.Visibility = Visibility.Visible;
        }


        /// <summary>
        ///     Método que se ejecuta al hacer click en el botón de buscar
        ///     Llama a un método u a otro dependiendo de lo que quiera buscar el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (tipoSeleccionado.Equals("Productos"))
            {

                buscarProductosPorFiltros();

            } else if (tipoSeleccionado.Equals("Recetas"))
            {
                buscarRecetasPorFiltros();
            } 
        }


        /// <summary>
        ///   Método que busca productos por filtros y los escribe en el listbox
        /// </summary>
        public async void buscarProductosPorFiltros()
        {
            string nombre = tbNombreProd.Text;
            string caloriasMaximas = tbCaloriasMaximas.Text;
            string proteinasMinimas = tbProteinas.Text;
            string grasasMaximas = tbGrasas.Text;

            try
            {
                lbProductos.Items.Clear();
                lbProductos.Items.Add("Buscando productos que cumplan las siguientes caracteriasticas...");

                //Obtenemos una lista de productos de la API
                List<Producto> listaProductos = await apiManager.obtenerProductosConFiltros(nombre, caloriasMaximas, proteinasMinimas, grasasMaximas);


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
        ///   Método que busca recetas por filtros y los escribe en el listbox
        /// </summary>
        public async void buscarRecetasPorFiltros()
        {
            string nombre = tbNombreRecet.Text;
            string tiempoPreparacion = tbTiempoRecet.Text;
            string intolerancia = tbIntoleranciasRecet.Text;
            string tipoComida = tbTipoComida.Text;

            try
            {
                lbProductos.Items.Clear();
                lbProductos.Items.Add("Buscando recetas que cumplan las siguientes caracteriasticas...");

                //Obtenemos una lista de productos de la API
                List<Receta> listaRecetas = await apiManager.obtenerRecetasConFiltros(nombre, tiempoPreparacion, intolerancia, tipoComida);


                lbProductos.Items.Clear();

                //Mostramos la lista
                foreach (Receta r in listaRecetas)
                {
                    lbProductos.Items.Add($"ID: {r.IdReceta}, Nombre: {r.NombreReceta}, Sin gluten:{r.SinGluten}");
                }

            }
            catch (Exception ex)
            {
                lbProductos.Items.Clear();
                lbProductos.Items.Add($"Error al obtener datos: {ex.Message}");
            }
        }


        /// <summary>
        ///   Método que minimiza la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        /// <summary>
        ///    Método que cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
