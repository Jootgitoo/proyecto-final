using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
                    Image image = new Image
                    {
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(10),
                        Stretch = Stretch.UniformToFill
                    };

                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(p.UrlImagen);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        image.Source = bitmap;
                    }
                    catch
                    {
                        //Imagen por si da error
                    }

                    StackPanel horizontalPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5)
                    };

                    // Contenedor de texto (en vertical)
                    StackPanel textPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    // Textos
                    TextBlock nameText = new TextBlock
                    {
                        Text = $"Nombre: {p.Nombre}",
                        FontWeight = FontWeights.Bold,
                        FontSize = 14
                    };

                    TextBlock precioText = new TextBlock
                    {
                        Text = $"Precio: {p.Precio:C}", // Formato moneda
                        FontSize = 12
                    };

                    // Añadir textos al panel de texto
                    textPanel.Children.Add(nameText);
                    textPanel.Children.Add(precioText);

                    // Añadir imagen y panel de texto al panel horizontal
                    horizontalPanel.Children.Add(image);
                    horizontalPanel.Children.Add(textPanel);

                    // Añadir todo al ListBox
                    lbProductos.Items.Add(horizontalPanel);

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

                    Image image = new Image
                    {
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(10),
                        Stretch = Stretch.UniformToFill
                    };

                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(r.UrlImagen);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        image.Source = bitmap;
                    }
                    catch
                    {
                        //Imagen por si da error
                    }


                    StackPanel horizontalPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5)
                    };

                    // Contenedor de texto (en vertical)
                    StackPanel textPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        VerticalAlignment = VerticalAlignment.Center
                    };


                    // Textos
                    TextBlock nameText = new TextBlock
                    {
                        Text = $"Nombre: {r.NombreReceta}",
                        FontWeight = FontWeights.Bold,
                        FontSize = 14
                    };

                    TextBlock tiempoText = new TextBlock
                    {
                        Text = $"Tiempo: {r.TiempoPreparacion} min", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock descText = new TextBlock
                    {
                        Text = $"Descripcion: {r.Descripcion} ", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock sinGluten = new TextBlock
                    {
                        Text = $"Sin gluten: {r.SinGluten} ", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock vegano = new TextBlock
                    {
                        Text = $"Vegano: {r.Vegano} ", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock vegetariano = new TextBlock
                    {
                        Text = $"Sin gluten: {r.Vegetariano} ", // Formato moneda
                        FontSize = 12
                    };

                    textPanel.Children.Add(nameText);
                    textPanel.Children.Add(tiempoText);
                    textPanel.Children.Add(descText);
                    textPanel.Children.Add(sinGluten);
                    textPanel.Children.Add(vegano);
                    textPanel.Children.Add(vegetariano);

                    horizontalPanel.Children.Add(image);
                    horizontalPanel.Children.Add(textPanel);

                    lbProductos.Items.Add(horizontalPanel);
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

                foreach (Producto p in listaProductos)
                {
                    Image image = new Image
                    {
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(10),
                        Stretch = Stretch.UniformToFill
                    };


                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(p.UrlImagen);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        image.Source = bitmap;
                    }
                    catch
                    {
                        //Imagen por si da error
                    }

                    StackPanel horizontalPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5)
                    };

                    // Contenedor de texto (en vertical)
                    StackPanel textPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    // Textos
                    TextBlock nameText = new TextBlock
                    {
                        Text = $"Nombre: {p.Nombre}",
                        FontWeight = FontWeights.Bold,
                        FontSize = 14
                    };



                    TextBlock precioText = new TextBlock
                    {
                        Text = $"Precio: {p.Precio:C}", // Formato moneda
                        FontSize = 12
                    };

                    // Añadir textos al panel de texto
                    textPanel.Children.Add(nameText);
                    textPanel.Children.Add(precioText);

                    // Añadir imagen y panel de texto al panel horizontal
                    horizontalPanel.Children.Add(image);
                    horizontalPanel.Children.Add(textPanel);

                    // Añadir todo al ListBox
                    lbProductos.Items.Add(horizontalPanel);

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

                    Image image = new Image
                    {
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(10),
                        Stretch = Stretch.UniformToFill
                    };

                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(r.UrlImagen);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        image.Source = bitmap;
                    }
                    catch
                    {
                        //Imagen por si da error
                    }


                    StackPanel horizontalPanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(5)
                    };

                    // Contenedor de texto (en vertical)
                    StackPanel textPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        VerticalAlignment = VerticalAlignment.Center
                    };


                    // Textos
                    TextBlock nameText = new TextBlock
                    {
                        Text = $"Nombre: {r.NombreReceta}",
                        FontWeight = FontWeights.Bold,
                        FontSize = 14
                    };

                    TextBlock tiempoText = new TextBlock
                    {
                        Text = $"Precio: {r.TiempoPreparacion} min", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock descText = new TextBlock
                    {
                        Text = $"Descripcion: {r.Descripcion} ", // Formato moneda
                        FontSize = 12
                    };

                    TextBlock sinGluten = new TextBlock
                    {
                        Text = $"Sin gluten: {r.SinGluten} ", // Formato moneda
                        FontSize = 12
                    };

                    textPanel.Children.Add(nameText);
                    textPanel.Children.Add(tiempoText);
                    textPanel.Children.Add(descText);
                    textPanel.Children.Add(sinGluten);

                    horizontalPanel.Children.Add(image);
                    horizontalPanel.Children.Add(textPanel);

                    lbProductos.Items.Add(horizontalPanel);
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
