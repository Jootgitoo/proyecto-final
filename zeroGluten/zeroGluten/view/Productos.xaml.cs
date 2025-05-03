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
        ///     Hacemos una llamada a la API para obtener una lista de productos
        /// </summary>
        private async void cargarTodosProductos()
        {
            //Limpiamos el ResultsListBox
            lvProductos.Items.Clear();

            //Mostramos al usuario un mensaje de q estamos cargando (es temporal)
            lvProductos.Items.Add("Cargando datos...");

            try
            {
                //Llamamos al método getListaObjetos para realizar una solicitud a una API REST obteniendo una lista de objetos
                List<Producto> objetos = await apiManager.getListaObjetos();

                //Limpiamos el ResultsListBox para esscribir en el los datos obtenidos de la consulta
                lvProductos.Items.Clear();

                //Por cada objeto que haya en objetos(lista de valores extraidos de la api)
                foreach (var obj in objetos)
                {
                    //Escribimos el id y el nombre
                    lvProductos.Items.Add($"ID: {obj.IdProducto}, Name: {obj.Nombre}");
                }

            }
            catch (Exception ex)
            {
                lvProductos.Items.Clear();
                lvProductos.Items.Add($"Error al obtener datos: {ex.Message}");
            }

        }
    }

    
}
