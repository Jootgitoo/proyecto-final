using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            // Rellenamos el comboBox de las calorias maximas
            for (int caloria = 100; caloria <= 1000; caloria += 100)
            {
                cbCaloriasMax.Items.Add($"{caloria}");
            }

            //Rellenamos el comboBox de las proteinas
            for (int proteina = 5; proteina <= 50; proteina += 5)
            {
                cbProteinasMin.Items.Add($"{proteina}");
            }

            //Rellenamos el comboBox de las grasas
            for (int grasas = 5; grasas <= 50; grasas += 5)
            {
                cbGrasasMax.Items.Add($"{grasas}");
            }


            //Rellenamos el comboBox del tiempo de las recetas
            for (int tiempo = 10; tiempo <= 90; tiempo += 5)
            {
                cbTiempoReceta.Items.Add($"{tiempo}");
            }


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

                    image.Source = CargarImagen(p.UrlImagen);


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
                    textPanel.Children.Add(nameText);

                    if (p.Precio.Equals("0.00"))
                    {
                        TextBlock precioText = new TextBlock
                        {
                            Text = "Precio no disponible",
                            FontSize = 12
                        };
                        textPanel.Children.Add(precioText);

                    }
                    else
                    {
                        TextBlock precioText = new TextBlock
                        {
                            Text = $"Precio: {p.Precio:C}",
                            FontSize = 12
                        };
                        textPanel.Children.Add(precioText);
                    }

                    // Añadir textos al panel de texto

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

                    image.Source = CargarImagen(r.UrlImagen);

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
                    textPanel.Children.Add(nameText);


                    TextBlock tiempoText = new TextBlock
                    {
                        Text = $"Tiempo: {r.TiempoPreparacion} min", // Formato moneda
                        FontSize = 12
                    };
                    textPanel.Children.Add(tiempoText);


                    TextBlock descText = new TextBlock
                    {
                        Text = $"Descripcion: {r.Descripcion} ", // Formato moneda
                        FontSize = 12
                    };
                    textPanel.Children.Add(descText);


                    if (r.SinGluten.Equals("true"))
                    {
                        TextBlock sinGluten = new TextBlock
                        {

                            Text = "Sin gluten", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(sinGluten);

                    }
                    else
                    {
                        TextBlock sinGluten = new TextBlock
                        {
                            Text = "Con gluten", // Formato moneda
                            FontSize = 12
                        };
                        textPanel.Children.Add(sinGluten);
                    }

                    if (r.Vegano.Equals("true"))
                    {
                        TextBlock vegano = new TextBlock
                        {
                            Text = "Vegano", // Formato moneda
                            FontSize = 12
                        };
                    }
                    else
                    {
                        TextBlock vegano = new TextBlock
                        {
                            Text = "No vegano", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(vegano);
                    }

                    if( r.Vegetariano.Equals("true"))
                    {

                        TextBlock vegetariano = new TextBlock
                        {
                            Text = "Vegetariano", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(vegetariano);

                    }
                    else
                    {
                        TextBlock vegetariano = new TextBlock
                        {
                            Text = "No vegetariano", // Formato moneda
                            FontSize = 12
                        };
                        textPanel.Children.Add(vegetariano);
                    }

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
            string caloriasMaximas = cbCaloriasMax.Text;
            string proteinasMinimas = cbProteinasMin.Text;
            string grasasMaximas = cbGrasasMax.Text;
           
            lbProductos.Items.Clear();
            lbProductos.Items.Add("Buscando productos que cumplan las siguientes caracteriasticas...");

            //Obtenemos una lista de productos de la API
            List<Producto> listaProductos = await apiManager.obtenerProductosConFiltros(nombre, caloriasMaximas, proteinasMinimas, grasasMaximas);

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

                image.Source = CargarImagen(p.UrlImagen);

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
                textPanel.Children.Add(nameText);

                if (p.Precio.Equals("0.00"))
                {
                    TextBlock precioText = new TextBlock
                    {
                        Text = "Precio no disponible",
                        FontSize = 12
                    };
                    textPanel.Children.Add(precioText);

                }
                else
                {
                    TextBlock precioText = new TextBlock
                    {
                        Text = $"Precio: {p.Precio:C}",
                        FontSize = 12
                    };
                    textPanel.Children.Add(precioText);
                }

                // Añadir textos al panel de texto

                // Añadir imagen y panel de texto al panel horizontal
                horizontalPanel.Children.Add(image);
                horizontalPanel.Children.Add(textPanel);

                // Añadir todo al ListBox
                lbProductos.Items.Add(horizontalPanel);

            }

        }


        /// <summary>
        ///   Método que busca recetas por filtros y los escribe en el listbox
        /// </summary>
        public async void buscarRecetasPorFiltros()
        {
            string nombre = tbNombreRecet.Text;
            string tiempoPreparacion = cbTiempoReceta.Text;

            string intolerancia = "";
            string tipoComida = "";

            if (cbIntolerancias.Text.Equals("Lacteo"))
            {
                intolerancia = "dairy";

            }else if (cbIntolerancias.Text.Equals("Huevo"))
            {
                intolerancia = "egg";

            }else if (cbIntolerancias.Text.Equals("Gluten"))
            {
                intolerancia = "gluten";
            }
            else if (cbIntolerancias.Text.Equals("Marisco"))
            {
                intolerancia = "seafood";

            } else if (cbIntolerancias.Text.Equals("Soja"))
            {
                intolerancia = "soy";

            } else if (cbIntolerancias.Text.Equals("Trigo"))
            {
                intolerancia = "wheat";
            }


            if (cbTipoComida.Text.Equals("Plato"))
            {
                tipoComida = "main course";

            }else if (cbTipoComida.Text.Equals("Postre"))
            {
                tipoComida = "dessert";

            }
            else if (cbTipoComida.Text.Equals("Pan"))
            {
                tipoComida = "bread";

            }
            else if (cbTipoComida.Text.Equals("Bebida"))
            {
                tipoComida = "drink";

            }

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

                    image.Source = CargarImagen(r.UrlImagen);

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
                    textPanel.Children.Add(nameText);


                    TextBlock tiempoText = new TextBlock
                    {
                        Text = $"Tiempo: {r.TiempoPreparacion} min", // Formato moneda
                        FontSize = 12
                    };
                    textPanel.Children.Add(tiempoText);


                    TextBlock descText = new TextBlock
                    {
                        Text = $"Descripcion: {r.Descripcion} ", // Formato moneda
                        FontSize = 12
                    };
                    textPanel.Children.Add(descText);


                    if (r.SinGluten.Equals("true"))
                    {
                        TextBlock sinGluten = new TextBlock
                        {

                            Text = "Sin gluten", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(sinGluten);

                    }
                    else
                    {
                        TextBlock sinGluten = new TextBlock
                        {
                            Text = "Con gluten", // Formato moneda
                            FontSize = 12
                        };
                        textPanel.Children.Add(sinGluten);
                    }

                    if (r.Vegano.Equals("true"))
                    {
                        TextBlock vegano = new TextBlock
                        {
                            Text = "Vegano", // Formato moneda
                            FontSize = 12
                        };
                    }
                    else
                    {
                        TextBlock vegano = new TextBlock
                        {
                            Text = "No vegano", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(vegano);
                    }

                    if (r.Vegetariano.Equals("true"))
                    {

                        TextBlock vegetariano = new TextBlock
                        {
                            Text = "Vegetariano", // Formato moneda
                            FontSize = 12
                        };

                        textPanel.Children.Add(vegetariano);

                    }
                    else
                    {
                        TextBlock vegetariano = new TextBlock
                        {
                            Text = "No vegetariano", // Formato moneda
                            FontSize = 12
                        };
                        textPanel.Children.Add(vegetariano);
                    }

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


        /// <summary>
        ///   Borramos lo que haya en los filtros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            //Limpiamos los filtros de productos
            tbNombreProd.Text = "";
            cbCaloriasMax.SelectedIndex = -1;
            cbProteinasMin.SelectedIndex = -1;
            cbGrasasMax.SelectedIndex = -1;

            //Limpiamos los filtros de recetas
            tbNombreRecet.Text = "";
            cbTiempoReceta.SelectedIndex = -1;
            cbIntolerancias.SelectedIndex = -1;
            cbTipoComida.SelectedIndex = -1;

        }


        /// <summary>
        ///    Método que carga la imagen de la api
        ///    Si no tiene imagen (o no existe) carga una imagen por defecto
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private BitmapImage CargarImagen(string url)
        {
            BitmapImage imagen = new BitmapImage();
            try
            {
                // Validamos que la imagen realmente exista (HEAD evita descargar todo el contenido)
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        imagen = new BitmapImage();
                        imagen.BeginInit();
                        imagen.UriSource = new Uri(url);
                        imagen.CacheOption = BitmapCacheOption.OnLoad;
                        imagen.EndInit();
                    }
                }
            }
            catch
            {

                // Imagen por defecto si la URL falla
                imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri("pack://application:,,,/images/productos/img-no-encontrada.jpg");
                imagen.EndInit();

            }

            return imagen;

        }

    }
}
